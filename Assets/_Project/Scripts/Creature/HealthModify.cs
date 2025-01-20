using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Creature;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class HealthModify : MonoBehaviour
{
    [SerializeField] private Health _health;
        
    [Header("Take Hit")]
    [SerializeField] private UnityEvent _takeHit;
        
    [Header("Die")]
    [SerializeField] private UnityEvent _die;
    
    private void OnEnable()
    {
        _health.OnHealthChanged += DecreaseHealth;
    }
    
    public void DecreaseHealth(int currenthealth)
    {
        _takeHit?.Invoke();
        if (currenthealth <= 0)
        {
            _die?.Invoke();
        }
    }
    
    private void OnDisable()
    {
        _health.OnHealthChanged -= DecreaseHealth;
    }
}
