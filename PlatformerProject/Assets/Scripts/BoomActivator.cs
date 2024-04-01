using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomActivator : MonoBehaviour
{
    [SerializeField] private GameObject _particleObject;
    [SerializeField] private float _timeBoomLife;
    private GameObject _spawnedBomb;

    public void SpawnBoomPlace(Transform bombTransform)
    {
        _spawnedBomb = Instantiate(gameObject, bombTransform.position, new Quaternion(0,0,0,0));
        Instantiate(_particleObject, bombTransform.position, new Quaternion(0, 0, 0, 0));
        _spawnedBomb.GetComponent<BoomActivator>().StartCoroutine(TimerOfLife(_spawnedBomb));
    }

    private IEnumerator TimerOfLife(GameObject bombForce)
    {
        yield return new WaitForSeconds(_timeBoomLife);
        Destroy(bombForce);
    }
}
