using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _jumpForce = 300;
    [SerializeField] private LayerMask _groundLayer;

    private Player _player;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private string _animationRun = "Run";
    private PlayerInput _input;
    private Vector2 _direction;
    private Vector3 _velocity;
    private float _velocityEpsilon = 0.01f;
    private RaycastHit _hitBuffer;

    private bool IsGrounded
    {
        get
        {
            return Physics.Raycast(new Ray(transform.position + transform.rotation * new Vector3(0.5f, 1, 0), Vector3.down), out _hitBuffer, 1.2f);
        }
    }

    private void Awake()
    {
        _input = new PlayerInput();
        _input.Player.Jump.performed += ctx => Jump();
        _input.Enable();
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (_player.IsInputEnabled == true)
        {
            _direction = _input.Player.Move.ReadValue<Vector2>();
            _velocity = new Vector3(_direction.x * _speed, _rigidbody.velocity.y, _direction.y * _speed);
            _rigidbody.velocity = _velocity;

            if (_velocity.magnitude > _velocityEpsilon)
            {
                _animator.SetBool(_animationRun, true);
            }
            else
            {
                _animator.SetBool(_animationRun, false);
            }

            Look();
        }
    }

    private void Jump()
    {
        if (IsGrounded == true)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce);
        }
    }

    private void Look()
    {
        Vector3 mousePosition2D = Mouse.current.position.ReadValue();
        mousePosition2D.z = 5f;
        Vector3 pointOnClipPlane = Camera.main.ScreenToWorldPoint(mousePosition2D);
        Vector3 direction = (pointOnClipPlane - Camera.main.transform.position).normalized;
        Physics.Raycast(new Ray(Camera.main.transform.position, direction), out _hitBuffer, 100f, _groundLayer);
        Vector3 targetPoint = _hitBuffer.point;
        targetPoint.y = transform.position.y;
        Vector3 difference = (targetPoint - transform.position).normalized;

        float rotation_y = Mathf.Atan2(difference.z, difference.x) * Mathf.Rad2Deg * -1;
        transform.rotation = Quaternion.Euler(0f, rotation_y, 0f);
    }
}
