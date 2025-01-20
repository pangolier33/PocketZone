using UnityEngine;

namespace _Project.Scripts.Utils
{
    public class LookAt : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;

        public bool isGlobal;

        private int diseredOffset;
        private Vector3 diseredPosition;
        private Quaternion initialRotation;

        private void Start()
        {
            if (isGlobal)
            {
                initialRotation = transform.rotation;
                return;
            }
            initialRotation = transform.localRotation;
        }

        private void LateUpdate()
        {
            if (isGlobal)
            {
                diseredPosition = _target.transform.position + _offset;
                transform.rotation = initialRotation;
            }
            else
            {
                diseredPosition = _target.transform.localPosition + _offset;
                transform.localRotation = initialRotation;
            }
            var smoothPosition = Vector3.Lerp(transform.position, diseredPosition, 5f);
            transform.position = smoothPosition;
        }
    }
}
