using System.Collections;
using UnityEngine;

namespace _Project.Scripts.Creature.Enemy
{
    public class SpawnEnemies : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab; 
        [SerializeField] private float spawnRadius = 5f; 
        [SerializeField] private float spawnInterval = 2f; 
        [SerializeField] private int maxEnemies = 10; 
        [SerializeField] private Color gizmoColor = Color.red;

        private int currentEnemies = 0;

        void Start()
        {
            StartCoroutine(SpawnEnemie());
        }

        private IEnumerator SpawnEnemie()
        {
            while (true) 
            {
                if (currentEnemies < maxEnemies)
                {
                    Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
                    
                    Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, 0.5f);
                    if (colliders.Length == 0) 
                    {
                        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                        currentEnemies++;
                    }
                }


                yield return new WaitForSeconds(spawnInterval);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
    }
}
