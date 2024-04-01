using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerShoot))]
public class ReloadShootImage : MonoBehaviour
{
    [SerializeField] private Image _imageReload;
    private PlayerShoot _playerShoot;
    private bool _isStartReloadImage = false;
    private float _currentTime = 0;
    private float _maxTime;

    private void Start()
    {
        _playerShoot = GetComponent<PlayerShoot>();
        _maxTime = _playerShoot.ShootOffset;
    }

    void Update()
    {
        if (_isStartReloadImage)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > _maxTime)
            {
                _isStartReloadImage = false;
            }

            _imageReload.fillAmount = _currentTime / _maxTime;
        }
    }

    public void ReloadImage()
    {
        _imageReload.fillAmount = 0;
        _currentTime = 0;
        _isStartReloadImage = true;
    }
}
