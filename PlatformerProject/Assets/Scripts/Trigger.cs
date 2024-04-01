using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _playerInside;
    private bool _isPlayerWasInside = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !_isPlayerWasInside)
        {
            _isPlayerWasInside = true;
            _playerInside.Invoke();
        }
    }
}
