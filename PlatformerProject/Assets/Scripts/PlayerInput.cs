using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent (typeof(PlayerShoot))]
public class PlayerInput : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string Jump = "Jump";
    private const string Fire2 = "Fire2";
    private const string UseButton = "Use";

    [SerializeField] private UnityEvent _playerJump;

    private PlayerShoot _playerShoot;
    private PlayerMovement _playerMovement;
    private float _horizontalDirection;
    private bool _isJumpButtonPressed;
    private bool _isUsePressed;

    public float Direction => _horizontalDirection;
    public bool IsJumpPressed => _isJumpButtonPressed;
    public bool IsUsePressed => _isUsePressed;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerShoot = GetComponent<PlayerShoot>();
    }

    private void Update()
    {
        _horizontalDirection = Input.GetAxis(HorizontalAxis);
        _isJumpButtonPressed = Input.GetButtonDown(Jump);
        _isUsePressed = Input.GetButtonDown(UseButton);

        Shoot();
        _playerMovement.Move(_horizontalDirection, _isJumpButtonPressed);
    }

    public void ResetHorizontalDirection()
    {
        _horizontalDirection = 0;
    }

    private void Shoot()
    {
        if(Input.GetButton(Fire2))
        {
            _playerShoot.ShootBullet();
        }
    }
}
