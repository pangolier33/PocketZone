using _Project.Scripts.Creature.Player.Weapon;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class AmmoDisplay : MonoBehaviour
    {
        [SerializeField] private Ammo _ammo;
        [SerializeField] private TMP_Text _ammoText;
    
        private void OnEnable()
        {
            UpdateHealthDisplay(_ammo.AmmoValue);
            _ammo.OnAmmoChanged += UpdateHealthDisplay;
        }

        private void OnDisable()
        {
            _ammo.OnAmmoChanged -= UpdateHealthDisplay;
        }
    
        private void UpdateHealthDisplay(int ammo)
        {
            _ammoText.text = $"Ammo: {_ammo.AmmoValue.ToString()}";
        }
    }
}
