using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyObject : MonoBehaviour
{
    [SerializeField] private GameObject[] _destroyingObjects;
    private bool _isObjectsDestroy = false;

    private void Awake()
    {
        DestroyObjects();
    }

    private void DestroyObjects()
    {
        if (_isObjectsDestroy == false)
        {
            foreach (GameObject obj in _destroyingObjects)
            {
                Destroy(obj);
            }
            _isObjectsDestroy = true;
        }
    }
}
