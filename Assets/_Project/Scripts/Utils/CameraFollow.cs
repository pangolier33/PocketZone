using UnityEngine;

namespace _Project.Scripts.Utils
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
    
        private void LateUpdate()
        {
            transform.position =new Vector3(target.position.x, target.position.y + 1.5f, transform.position.z);
        }
    }
}
