using UnityEngine;

namespace _Project.Scripts.Inventory.ItemsData
{
    public class AmmoItem : Item
    {
        [field: SerializeField, Min(1)] public int AmmoCount = 1;
    }
}
