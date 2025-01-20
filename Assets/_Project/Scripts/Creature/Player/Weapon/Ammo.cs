using System;
using UnityEngine;

namespace _Project.Scripts.Creature.Player.Weapon
{
    public class Ammo : MonoBehaviour
    {
        [SerializeField] private int AmmoCount;
        public event Action<int> OnAmmoChanged;
    
        public int AmmoValue
        {
            get { return AmmoCount; }
            set
            {
                AmmoCount = value;
                OnAmmoChanged?.Invoke(AmmoCount);
            }
        }
    
        public void AmmoChanged(int ammo)
        {
            AmmoValue += ammo;
        }
    }
}
