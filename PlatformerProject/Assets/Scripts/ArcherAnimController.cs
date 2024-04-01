using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ArcherAnimController : MonoBehaviour
{
    [SerializeField] private string _layerIgnoreAll;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Death()
    {
        _animator.SetBool("Death", true);
        gameObject.layer = LayerMask.NameToLayer(_layerIgnoreAll);
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
    }

    public void Shoot()
    {
        _animator.SetTrigger("Shoot");
    }

    public void GetHit()
    {
        _animator.SetTrigger("GetHit");
    }
}
