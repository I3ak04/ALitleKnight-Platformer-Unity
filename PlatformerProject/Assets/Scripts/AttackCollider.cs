using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Lumin;

public class AttackCollider : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private string _playerMask;
    [SerializeField] private float _timeOfOnGameObject;
    [SerializeField] private GameObject[] _attackColliders;
    [SerializeField] private UnityEvent _playerInside;
    [SerializeField] private UnityEvent _playerOutside;
    private bool _isPlayerInside = false;   // Добавлен, чтобы события не вызывались дважды
    private LayerMask _firstLayer;

    private void Start()
    {
        _firstLayer = gameObject.layer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer(_playerMask) && !_isPlayerInside)
        {
            _playerInside.Invoke();
            _isPlayerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(_playerMask) && _isPlayerInside)
        {
            _playerOutside.Invoke();
            _isPlayerInside = false;
        }
    }

    public void FlipSpriteL()
    {
        _spriteRenderer.flipX = true;
    }

    public void FlipSpriteR()
    {
        _spriteRenderer.flipX = false;
    }

    public void OffAttackColliders()
    {
        foreach (GameObject aColliders in _attackColliders)
        {
            aColliders.layer = LayerMask.NameToLayer("IgnoreAll");
        }

        StartCoroutine(TimeOfOnGameObject());
    }

    private IEnumerator TimeOfOnGameObject()
    {
        yield return new WaitForSeconds(_timeOfOnGameObject);
        
        foreach(GameObject aColliders in _attackColliders)
        {
            aColliders.layer = _firstLayer;
        }
    }
}
