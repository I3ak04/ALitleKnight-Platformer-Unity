using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyWalk : MonoBehaviour
{
    [SerializeField] private bool _isMustWalk = true;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeOfIdle;
    [SerializeField] private float _timeOfOnWalk;
    [SerializeField] private string _walkAnimParameterName;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private bool _isWalk = false;
    private bool _isOnWalkStart = false;


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("EnemyStopper"))
        {
            StartCoroutine(TimeOfIdle());
            _isWalk = false;
            _animator.SetBool(_walkAnimParameterName, false);
        }
    }

    private void Update()
    {
        if(_isMustWalk)
        {
            if(_isWalk)
            {
                Walk(GetDirection());
            }
            else if (!_isOnWalkStart)
            {
                OnWalk();
                _animator.SetBool(_walkAnimParameterName, false);
                _isOnWalkStart = true;
            }
        }
    }

    public void StopWalk()
    {
        StopAllCoroutines();
        _isWalk = false;
        _isOnWalkStart = false;
    }

    public void OnWalk()
    {
        StartCoroutine(TimeOfOnWalk());
    }

    private void Walk(int direction)
    {
        _animator.SetBool(_walkAnimParameterName, true);
        _rigidbody2D.velocity = new Vector2(direction, 0) * _speed;
    }

    /// <summary>
    /// ¬озвращ€ет направление, куда должен идти игрок
    /// </summary>
    /// <returns></returns>
    private int GetDirection()
    {
        if(_spriteRenderer.flipX)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    private IEnumerator TimeOfIdle()
    {
        yield return new WaitForSeconds(_timeOfIdle);
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        _isWalk = true;
    }

    private IEnumerator TimeOfOnWalk()
    {
        yield return new WaitForSeconds(_timeOfOnWalk);
        _isWalk = true;
    }
}
