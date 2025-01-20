using _Project.Scripts.Inventory.ItemsData;
using UnityEngine;

namespace _Project.Scripts.Inventory
{
    public class DeleteItemPanel : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        private Item _item;
        private InventorySlot _slot;

        public void Initialize(Item item, InventorySlot slot)
        {
            _item = item;
            _slot = slot;
        }
        
        public void DeleteSlot()
        {
            if (_slot == null || _item == null) return;
            bool SuccessfullyDrop = _slot.DropItem(_player);
            if (SuccessfullyDrop)
            {
                gameObject.SetActive(false);
                Initialize(null, null);
            }
        }
    }
}

