using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerAnimController : MonoBehaviour
{
    [SerializeField] private string _layerIgnoreAll;
    [SerializeField] private string _layerPlayer;
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

    public void GetHit()
    {
        _animator.SetTrigger("GetHit");
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
    }

    public void Walk()
    {
        _animator.SetBool("Walk", true);
    }
}
