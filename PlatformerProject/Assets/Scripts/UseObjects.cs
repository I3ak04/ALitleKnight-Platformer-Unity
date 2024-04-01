using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UseObjects : MonoBehaviour
{
    [SerializeField] private float _useOffsetTime;   // Задержка перед повторным использованием Event
    [SerializeField] private float _timeOfEvent;     // Время через которое сработает EventAfterTime после использования
    [SerializeField] private bool _isUseOnce = false;
    [SerializeField] private UnityEvent _eventNow;
    [SerializeField] private UnityEvent _eventAfterTime;
    private PlayerInput _playerInput;
    private bool _isPlayerInside;
    private bool _isUse = true;

    private void Start()
    {
        _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isPlayerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isPlayerInside = false;
        }
    }

    private void Update()
    {
        if (_isPlayerInside && _playerInput.IsUsePressed && _isUse)
        {
            _eventNow.Invoke();
            StartCoroutine(TimeOfEvent());
            _isUse = false;
            
            if (_isUseOnce)
            {
                _isUse = false;
            }
            else
            {
                StartCoroutine(OffsetUse());
            }
        }
    }

    private IEnumerator TimeOfEvent()
    {
        yield return new WaitForSeconds(_timeOfEvent);
        _eventAfterTime.Invoke();
    }

    private IEnumerator OffsetUse()
    {
        yield return new WaitForSeconds(_useOffsetTime);
        _isUse = true;
    }
}
