using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffCollisionPlayerForObjects : MonoBehaviour
{
    [SerializeField] private Collider2D[] _ignorePlayerColliders;
    [SerializeField] private string[] _tagName;
    private GameObject[] _ignoreObjects;
    private Collider2D[] _ignoreColliders;

    void Start()
    {
        for(int j = 0; j < _tagName.Length; j++)
        {
            _ignoreObjects = GameObject.FindGameObjectsWithTag(_tagName[j]);
            _ignoreColliders = new Collider2D[ _ignoreObjects.Length ];

            for (int i = 0; i < _ignoreObjects.Length; i++)
            {
                _ignoreColliders[i] = _ignoreObjects[i].GetComponent<Collider2D>();
                Physics2D.IgnoreCollision(_ignorePlayerColliders[j], _ignoreColliders[i], true);
            }
        }
    }
}
