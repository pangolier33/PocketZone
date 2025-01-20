using _Project.Scripts.Creature.Enemy;
using UnityEngine;

namespace _Project.Scripts.Creature.Player.Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 15f;
        [SerializeField] private int _damage = 1;

        public void Launch(Vector2 direction)
        {
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        private void OnEnable()
        {
            Invoke(nameof(Deactivate), 2f); 
        }

        private void Deactivate()
        {
            gameObject.SetActive(false); 
        }

        private void OnDisable()
        {
            CancelInvoke(); 
        }
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out ZombieHealthModify zombieHealthModify))
            {
                zombieHealthModify.RecieveHealth(_damage);
            }
        
            gameObject.SetActive(false);
        }
    }
}
