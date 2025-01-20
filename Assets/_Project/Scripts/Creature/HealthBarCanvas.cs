using UnityEngine;

namespace _Project.Scripts.Creature
{
    public class HealthBarCanvas : MonoBehaviour
    {
        private void OnEnable()
        {
            Canvas canvas = GetComponent<Canvas>();
            canvas.worldCamera = Camera.main;
        }
    }
}
