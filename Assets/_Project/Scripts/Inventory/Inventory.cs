using System.Linq;
using _Project.Scripts.Inventory.ItemsData;
using UnityEngine;

namespace _Project.Scripts.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [field: SerializeField] public InventorySlot[] InventorySlots { get; private set; }
    
        public void AddItemInSlot(Item item)
        {
            var slotWithItem = InventorySlots.FirstOrDefault(s => s.Item != null && s.Item.Name == item.Name);
            if (slotWithItem != null)
            {
                slotWithItem.Item.StackItem(item.Count);
                slotWithItem.InitializeSlot(slotWithItem.Item);
            }
            else
            {
                var freeslot = InventorySlots.FirstOrDefault(s => s.Item == null);
                freeslot.InitializeSlot(item);
            }
        }
    }
}
