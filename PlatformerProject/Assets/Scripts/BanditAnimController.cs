using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BanditAnimController : MonoBehaviour
{
    [SerializeField] private string _layerIgnoreAll;
    [SerializeField] private string _layerPlayer;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer(_layerPlayer))
        {
            Attack();
        }
    }

    public void Death()
    {
        _animator.SetTrigger("Death");

        gameObject.layer = LayerMask.NameToLayer(_layerIgnoreAll);
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
    }

    public void OnPrepareAttack()
    {
        _animator.SetBool("PrepareAttack", true);
    }

    public void OffPrepareAttack()
    {
        _animator.SetBool("PrepareAttack", false);
    }

    public void Hurt()
    {
        _animator.SetTrigger("Hurt");
    }
}
