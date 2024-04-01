using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletSpawnR;
    [SerializeField] private Transform _bulletSpawnL;
    [SerializeField] private float _bulletLife;
    [SerializeField] private float _shootOffset;
    [SerializeField] private float _fireForce;
    [SerializeField] private UnityEvent _playerShootNow;
    private SpriteRenderer _spriteRender;
    private bool _isShoot = true;

    public float ShootOffset => _shootOffset;

    private void Start()
    {
        _spriteRender = GetComponent<SpriteRenderer>();
    }

    public void ShootBullet()
    {
        if(_isShoot)
        {
            _isShoot = false;
            int direction = GetDirection();
            GameObject currentBullet = SpawnBullet(direction);
            Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
            BulletAddForce(direction, currentBulletVelocity);
            StartCoroutine(BulletLife(currentBullet));
            StartCoroutine(ShootOffsetTimer());
            _playerShootNow.Invoke();
        }
    }

    private GameObject SpawnBullet(int direction)
    {
        GameObject bullet;

        if(direction == 1)
            bullet = Instantiate(_bullet, _bulletSpawnR.position, Quaternion.identity);
        else
            bullet = Instantiate(_bullet, _bulletSpawnL.position, Quaternion.Euler(0, 180, 0));

        return bullet;
    }

    private void BulletAddForce(int direction, Rigidbody2D currentBulletVelocity)
    {
        currentBulletVelocity.velocity = new Vector3(_fireForce * direction, currentBulletVelocity.velocity.y);
    }

    private int GetDirection()
    {

        if (_spriteRender.flipX)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    private IEnumerator BulletLife(GameObject bullet)
    {
        yield return new WaitForSeconds(_bulletLife);
        Destroy(bullet);
    }

    private IEnumerator ShootOffsetTimer()
    {
        _isShoot = false;
        yield return new WaitForSeconds(_shootOffset);
        _isShoot = true;
    }
}
