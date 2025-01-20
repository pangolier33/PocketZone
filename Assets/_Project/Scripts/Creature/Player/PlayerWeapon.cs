using _Project.Scripts.Creature.Player.Weapon;
using UnityEngine;

namespace _Project.Scripts.Creature.Player
{
    public class PlayerWeapon : MonoBehaviour
    {
        private const int PROJECTILE_PRELOAD_COUNT = 20;
        
        [SerializeField] private float _delay = 0.25f;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Ammo _ammo;
        
        private PoolBase<Bullet> _bulletPool;
        [SerializeField] private DetectZone _detectZone;
    
        
        private float _nextFireTime;
    
        private void Awake()
        {
            _bulletPool = new PoolBase<Bullet>(
                Preload, 
                GetAction,
                ReturnAction, 
                PROJECTILE_PRELOAD_COUNT);
        }
        
        public void FireButtonPressed()
        {
            if (ReadyToShoot() && (_ammo.AmmoValue > 0))
            {
                _ammo.AmmoChanged(-1);
                Shoot();
            }
        }
        
        private void ReturnAllBullets() =>  _bulletPool.ReturnAll();

        private Bullet Preload() => Instantiate(_bulletPrefab, transform.position, _firePoint.localRotation);

        private void GetAction(Bullet bullet) => bullet.gameObject.SetActive(true);

        private void ReturnAction(Bullet bullet) => bullet.gameObject.SetActive(false);

        private bool ReadyToShoot() => Time.time >= _nextFireTime;
    
        private void Shoot()
        {
            ShootDelay();
            
            Bullet bullet = _bulletPool.Get();
            bullet.transform.position = _firePoint.position;
            bullet.Launch(_firePoint.right);
        }

        private void ShootDelay()
        {
            float delay = _delay;
            _nextFireTime = Time.time + delay;
        }

        private void Update()
        {
            if (_detectZone._target == null) return;
            Vector2 direction = (_detectZone._target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0,0,angle);
            GetComponent<SpriteRenderer>().flipY = angle > 90 || angle < -90;
        }
    }
}
