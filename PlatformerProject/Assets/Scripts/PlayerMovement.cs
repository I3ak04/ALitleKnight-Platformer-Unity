using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Vars")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _isGround;

    [Header("Settings")]
    [SerializeField] private float _jumpOffset;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private Transform _groundColliderTransform;
    [SerializeField] private LayerMask _groundMask;
    private Rigidbody2D _rigidBody;

    public bool IsGround => _isGround;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>(); 
    }

    private void FixedUpdate()
    {
        Vector2 overlapCirclePosition = _groundColliderTransform.position;
        _isGround = Physics2D.OverlapCircle(overlapCirclePosition, _jumpOffset, _groundMask);
    }

    public void Move(float direction, bool isJumpButtonPressed)
    {
        if(isJumpButtonPressed) 
        {
            Jump();
        }

        if(Mathf.Abs(direction) > 0.01)
        {
            HorizontalMovement(direction);
        }
    }

    public void Jump()
    {
        if(_isGround)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
        }
    }

    private void HorizontalMovement(float direction)
    {
        _rigidBody.velocity = new Vector2(_curve.Evaluate(direction) * _moveSpeed, _rigidBody.velocity.y);
    }
}
