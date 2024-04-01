using UnityEngine;
using UnityEngine.Events;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private UnityEvent _coinTaked;
    [SerializeField] private GameObject _particleCoinTaked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _coinTaked.Invoke();
            PlayParticle();
            DestroyCoin();
        }
    }

    private void PlayParticle()
    {
        Instantiate(_particleCoinTaked, transform.position, Quaternion.Euler(0,0,0));
    }

    private void DestroyCoin()
    {
        Destroy(gameObject);
    }
}
