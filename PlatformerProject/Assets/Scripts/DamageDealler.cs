using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageDealler : MonoBehaviour
{
    [SerializeField] private bool _isDestroyObject;
    [SerializeField] private int _damage;
    [SerializeField] private bool _isDiscardObject;
    [SerializeField] private float _discardForce;
    [SerializeField] private float _upOffset;
    [SerializeField] private bool _isAreaDamage;
    [SerializeField] private float _radiusArea;
    [SerializeField] private bool _isGetDamageWithTag;
    [SerializeField] private string _enemyTag;
    [SerializeField] private UnityEvent _hitTheObject;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetDamageType(collision);
        _hitTheObject.Invoke();

        if (_isDestroyObject)
        {
            Destroy(gameObject);
        }
    }

    private void GetDamageType(Collision2D collision)
    {
        if (!_isAreaDamage)
        {
            if(collision.gameObject.GetComponent<Health>())
            {
                if(_isGetDamageWithTag)
                {
                    if(collision.gameObject.CompareTag(_enemyTag))
                    {
                        GetSingleDamage(collision);
                    }
                }
                else
                {
                    GetSingleDamage(collision);
                }
            }
        }
        else if(_isAreaDamage)
        {
            GetAreaDamage();
        }
    }

    private void GetSingleDamage(Collision2D collision)
    {
        Health objectHealth = collision.gameObject.GetComponent<Health>();
        objectHealth.TakeDamage(_damage);

        if (_isDiscardObject)
        {
            DiscardObject(collision.transform, collision.gameObject.GetComponent<Rigidbody2D>());
        }
    }

    private void GetAreaDamage()
    {
        Collider2D[] ObjectsInside = Physics2D.OverlapCircleAll(transform.position, _radiusArea);

        if(_isGetDamageWithTag)
        {
            foreach(Collider2D collider in ObjectsInside)
            {
                if(collider.GetComponent<Health>())
                {
                    if(collider.CompareTag(_enemyTag))
                    {
                        collider.GetComponent<Health>().TakeDamage(_damage);
                    }
                }
            }
        }
        else
        {
            foreach (Collider2D collider in ObjectsInside)
            {
                if (collider.GetComponent<Health>())
                {
                    collider.GetComponent<Health>().TakeDamage(_damage);
                }
            }
        }
    }

    private void DiscardObject(Transform damagedTransform, Rigidbody2D damagedRB)
    {
        if(_isDiscardObject)
        {
            Vector2 direction = damagedTransform.position - transform.position;
            direction.y += _upOffset;
            damagedRB.AddForce(direction.normalized * _discardForce, ForceMode2D.Impulse);
        }
    }
}
