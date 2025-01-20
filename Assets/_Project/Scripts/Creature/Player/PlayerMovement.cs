using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.Creature.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public Vector2 moveInput;
        public Vector2 moveDirection;
    
        [SerializeField] private float speed;
        [SerializeField] private Joystick joystick;
        [SerializeField] private Transform _weapon;

        private Vector2 _moveVelocity;
        private Rigidbody2D _rigidbody;
        private PlayerData _playerData;
        private string _filePath;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _filePath = Path.Combine(Application.persistentDataPath, "playerData.json");
            LoadPlayerData();
        }
    

        private void FixedUpdate()
        {
            PlayerMove();
            PlayerRotate();
        }
    
        private void PlayerMove()
        {
            moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
            _moveVelocity = moveInput.normalized * speed;
            _rigidbody.MovePosition(_rigidbody.position + _moveVelocity * Time.deltaTime);
        }

        private void PlayerRotate()
        {
            if (joystick.Horizontal > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                _weapon.rotation = Quaternion.Euler(0, 0, 0);
                moveDirection = Vector2.right;
            }
        
            if (joystick.Horizontal < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                _weapon.rotation = Quaternion.Euler(0, 180, 0);
                moveDirection = Vector2.left;
            }
        }
    
        private void LoadPlayerData()
        {
            if (File.Exists(_filePath))
            {
                string jsonData = File.ReadAllText(_filePath);
                _playerData = JsonUtility.FromJson<PlayerData>(jsonData);

                transform.position = new Vector3(_playerData.position[0], _playerData.position[1], _playerData.position[2]);
                transform.rotation = Quaternion.Euler(_playerData.rotation[0], _playerData.rotation[1], _playerData.rotation[2]);
                speed = _playerData.speed;
            }
            else
            {
                _playerData = new PlayerData();
                _playerData.position = new float[3] { transform.position.x, transform.position.y, transform.position.z };
                _playerData.rotation = new float[3] { transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z };
                _playerData.speed = speed;
            }
        }
        private void SavePlayerData()
        {
            _playerData.position = new float[3] { transform.position.x, transform.position.y, transform.position.z };
            _playerData.rotation = new float[3] { transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z };
            _playerData.speed = speed;
        
            string jsonData = JsonUtility.ToJson(_playerData);
            File.WriteAllText(_filePath, jsonData);
        }

        private void OnApplicationQuit()
        {
            SavePlayerData();
        }
    }
}
