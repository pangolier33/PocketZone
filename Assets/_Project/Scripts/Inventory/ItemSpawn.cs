using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Inventory
{
    public class ItemSpawn : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _itemsList = new();

        public void SpawnItem(Vector3 transform)
        {
            int randomNumber = Random.Range(0, _itemsList.Count);
            Instantiate(_itemsList[randomNumber], transform, Quaternion.identity);
        }
    }
}
