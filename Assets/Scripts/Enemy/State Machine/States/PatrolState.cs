using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Path))]
public class PatrolState : State
{
    private Path _path;
    private Enemy _enemy;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private string _runAnimation = "Run";
    private Vector3 _targetPosition;
    private float _speed;
    private float _minimalDistance = 0.3f;
    private Vector3 _direction;
    private IEnumerator _run;
    private float _rotation;

    private void Start()
    {
        _path = GetComponent<Path>();
        _enemy = GetComponent<Enemy>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _speed = _enemy.Speed;
        _targetPosition = transform.position;
    }

    private void OnDisable()
    {
        _animator.SetBool(_runAnimation, false);

        if (_run != null)
            StopCoroutine(_run);
    }

    private void Update()
    {
        if (_path.HasPath == true)
            Patrol();
    }

    private void Patrol()
    {
        if ((_targetPosition - transform.position).magnitude < _minimalDistance && _run == null)
        {
            _targetPosition = _path.GetNextPosition();
            _run = Run();
            StartCoroutine(_run);
        }
    }

    private IEnumerator Run()
    {
        _animator.SetBool(_runAnimation, true);

        while ((_targetPosition - transform.position).magnitude > _minimalDistance)
        {
            _direction = (_targetPosition - transform.position).normalized;
            _rotation = Mathf.Atan2(_direction.z, _direction.x) * Mathf.Rad2Deg * -1;
            transform.rotation = Quaternion.Euler(0, _rotation, 0);
            _rigidbody.velocity = _direction * _speed;
            yield return null;
        }

        _animator.SetBool(_runAnimation, false);
        _run = null;
    }
}
