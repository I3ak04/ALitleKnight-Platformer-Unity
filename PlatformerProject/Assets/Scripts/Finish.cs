using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _lvlCompletedCanvas;
    [SerializeField] private bool _isLastLevel;
    [SerializeField] private UnityEvent _lastLevelEvent;
    private MenuInput _menuInput;

    private void Start()
    {
        _menuInput = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MenuInput>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !_isLastLevel)
        {
            Instantiate(_lvlCompletedCanvas);
            _menuInput.enabled = false;
            collision.gameObject.GetComponent<PlayerInput>().ResetHorizontalDirection();
            Time.timeScale = 0;
        }
        else
        {
            _lastLevelEvent.Invoke();
        }
    }
}
