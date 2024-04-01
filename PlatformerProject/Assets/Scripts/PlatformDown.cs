using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDown : MonoBehaviour
{
    private const string Down = "Down";

    [SerializeField] private Collider2D[] _playerCollider;
    [SerializeField] private float _time;
    private Collider2D _platformCollider;
    private bool _isOnPlatform;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
                _isOnPlatform = true;
                _platformCollider = collision.gameObject.GetComponent<Collider2D>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            _isOnPlatform = false;
        }
    }

    private void Update()
    {
        if (_isOnPlatform && Input.GetButtonDown(Down)) 
        {
            foreach(Collider2D collider in _playerCollider)
            {
                OffCollider(_platformCollider, collider);
            }
        }
    }

    private void OffCollider(Collider2D collider1, Collider2D collider2)
    {
        Physics2D.IgnoreCollision(collider1, collider2, true);
        StartCoroutine(Timer(collider1, collider2));
    }

    private IEnumerator Timer(Collider2D collider1, Collider2D collider2)
    {
        yield return new WaitForSeconds(_time);
        OnCollider(collider1, collider2);
    }

    private void OnCollider(Collider2D collider1, Collider2D collider2)
    {
        Physics2D.IgnoreCollision(collider1, collider2, false);
    }
}
