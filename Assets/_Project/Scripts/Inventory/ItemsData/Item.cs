using System;
using UnityEngine;

namespace _Project.Scripts.Inventory.ItemsData
{
    public class Item : MonoBehaviour
    {
        [field: SerializeField, Min(1)] public int Count { get; private set; } = 1;
        [field: SerializeField] public String Name { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public bool MayStack { get; private set; }

        public void StackItem(int amount)
        {
            if (amount <= 0) return;
            if (MayStack)
                Count += amount;
        }
    }
}
