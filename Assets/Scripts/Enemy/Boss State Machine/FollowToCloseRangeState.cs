using UnityEngine;

public class FollowToCloseRangeState : State
{
    [SerializeField] private float _speed = 3f;

    private Rigidbody _rigidbody;
    private Animator _animator;
    private string _runAnimation = "Run";
    private Vector3 _direction;
    private float _rotation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.SetBool(_runAnimation, true);
    }

    private void OnDisable()
    {
        _animator.SetBool(_runAnimation, false);
    }

    private void Update()
    {
        _direction = (Target.transform.position - transform.position).normalized;
        _rotation = Mathf.Atan2(_direction.z, _direction.x) * Mathf.Rad2Deg * -1;
        transform.rotation = Quaternion.Euler(0, _rotation, 0);
        _rigidbody.velocity = _direction * _speed;
    }
}
