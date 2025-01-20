using System.Collections;
using _Project.Scripts.Creature.Player;
using UnityEngine;

namespace _Project.Scripts.Creature.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        public PlayerMovement Player;

        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        [SerializeField] private float _attackRange;
        [SerializeField] private float _attackSpeed;

        private Rigidbody2D _rigidbody2D;
        private Vector2 _direction;
        private Coroutine _attackCoroutine;
    

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerMovement player) && Player == null)
            {
                Player = player;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerMovement player) && Player != null)
            {
                Player = null;
            }
        }

        private void Update()
        {
            if (Player == null) return;
            _attackCoroutine ??= StartCoroutine(Attack());
        }

        private void FixedUpdate()
        {
            if (Player == null) return;
            Move();
            Rotate();
        }

        private void Move()
        {
            _direction = (Player.transform.position - (Vector3) _rigidbody2D.position).normalized;
            Vector2 newPosition = _rigidbody2D.position + _direction * (_speed * Time.fixedDeltaTime);
            _rigidbody2D.MovePosition(newPosition);
        }

        private void Rotate()
        {
            if ((Vector3) _direction != Vector3.zero)
            {
                if (Player.transform.position.x > transform.position.x)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                else if (Player.transform.position.x < transform.position.x)
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
            }
        }

        private bool ReadyToAttack()
        {
            if (Player == null) return false;
            return Vector2.Distance(transform.position, Player.transform.position) < _attackRange;
        }

        private IEnumerator Attack()
        {
            while (ReadyToAttack())
            {
                Player.GetComponent<PlayerHealthModify>().RecieveHealth(_damage);
                yield return new WaitForSeconds(_attackSpeed);
            }

            _attackCoroutine = null;
        }
    }
}
