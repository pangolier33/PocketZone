using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Creature.Player
{
    public class PlayerHealthModify : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Image _healthBar;
        [SerializeField] private GameObject _restartPanel;

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
            _restartPanel.SetActive(true);
        }

        public void RecieveHealth(int amount)
        {
            if (amount <= 0) return;
            _health.HealthValue -= amount;
        }
    }
}
