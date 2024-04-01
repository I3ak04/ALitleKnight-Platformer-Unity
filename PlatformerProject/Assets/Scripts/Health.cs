using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private UnityEvent _playerDie;
    [SerializeField] private UnityEvent _playerGetDamage;
    private string _deadCharacterTag = "DeadCharacter";

    public bool IsAlive => _currentHealth <= 0;
    public int CurrentHP => _currentHealth;
    
    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        _playerGetDamage.Invoke();

        if (IsAlive)
        {
            _playerDie.Invoke();
            gameObject.tag = _deadCharacterTag;
        }
    }
}
