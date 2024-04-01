using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamageTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _attackTrigger;
    [SerializeField] private int _damage;
    [SerializeField] private float _positionOffsetX;
    [SerializeField] private float _timeOfOffCollider;
    private SpriteRenderer _spriteRender;
    private Health _playerHealth;

    private void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _spriteRender = GetComponent<SpriteRenderer>();
    }

    public void GetDamage()
    {
        _playerHealth.TakeDamage(_damage);
    }

    public void OnDamageTrigger()
    {
        AttackTriggerPosition();
        _attackTrigger.SetActive(true);
        StartCoroutine(TimeOfOffcollider());
    }

    private void OffDamageTrigger()
    {
        _attackTrigger.SetActive(false);
    }

    private void AttackTriggerPosition()
    {
        
        if(_spriteRender.flipX)
        {
            _attackTrigger.transform.position = transform.position + new Vector3(-_positionOffsetX, 0);
        }
        else
        {
            _attackTrigger.transform.position = transform.position + new Vector3(_positionOffsetX, 0);
        }
    }

    private IEnumerator TimeOfOffcollider()
    {
        yield return new WaitForSeconds(_timeOfOffCollider);
        OffDamageTrigger();
    }
}
