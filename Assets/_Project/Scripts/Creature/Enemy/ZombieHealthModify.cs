using _Project.Scripts.Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Creature.Enemy
{
    public class ZombieHealthModify : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Image _healthBar;
        [SerializeField] private ItemSpawn _itemSpawn;

        private float _maxHealth;

        private void Start()
        {
            _maxHealth = _health.HealthValue;
        }

        public void OnTakeHit()
        {
            _healthBar.fillAmount = _health.HealthValue / _maxHealth;
        }

        public void OnDie()
        {
            _itemSpawn.SpawnItem(transform.position);
            Destroy(gameObject);
        }

        public void RecieveHealth(int amount)
        {
            if (amount <= 0) return;
            _health.HealthValue -= amount;
        }
    }
}
