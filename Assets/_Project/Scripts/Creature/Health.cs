using System;
using UnityEngine;

namespace _Project.Scripts.Creature
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _health;
        public event Action<int> OnHealthChanged;

        public int HealthValue
        {
            get { return _health; }
            set
            {
                _health = value;
                OnHealthChanged?.Invoke(_health);
            }
        }
    }
}
