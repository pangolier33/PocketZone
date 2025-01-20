using _Project.Scripts.Creature.Player.Weapon;
using _Project.Scripts.Inventory.ItemsData;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Creature.Player
{
    public class DetectZone : MonoBehaviour
    {
        [SerializeField] private Button _fireButton;
        [SerializeField] private PlayerWeapon _playerWeapon;
        [SerializeField] private Ammo _ammo;
        
        public Transform _target;
        private Inventory.Inventory _inventory;

        private void Start()
        {
            _inventory = GetComponentInParent<Inventory.Inventory>();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                _fireButton.interactable = true;
                _target = other.transform;
            }
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                _fireButton.interactable = false;
                _target = null;
                _playerWeapon.gameObject.GetComponent<SpriteRenderer>().flipY = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out AmmoItem ammo))
            {
                _ammo.AmmoChanged(ammo.AmmoCount);
            }
            if (other.TryGetComponent(out Item item))
            {
                _inventory.AddItemInSlot(item);
                item.gameObject.SetActive(false);
            }
        }
    }
}
