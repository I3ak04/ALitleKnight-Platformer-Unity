using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private PlayerInput _playerInput;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Run(_playerInput.Direction);
        Falling(_playerMovement.IsGround);
    }

    public void Dead()
    {
        _animator.SetBool("IsDead", true);
    }

    public void Jump()
    {
        _animator.SetBool("IsJump", true);
    }

    private void Run(float direction)
    {
        if(direction > 0)
        {
            _animator.SetBool("IsRun", true);
            _spriteRenderer.flipX = false;

        }
        else if(direction < 0)
        {
            _animator.SetBool("IsRun", true);
            _spriteRenderer.flipX = true;

        }
        else
        {
            _animator.SetBool("IsRun", false);
        }
    }

    private void Falling(bool isGround)
    {
        if (isGround == false)
        {
            _animator.SetBool("IsFalling", true);

        }
        else
        {
            _animator.SetTrigger("FallOnGround");
            _animator.SetBool("IsFalling", false);
            
        }
    }
}
