using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : State
{
    [SerializeField] private float _damage = 40;
    [SerializeField] private float _attackSpeed = 0.8f;
    [SerializeField] private IEnumerator _hit;

    private Animator _animator;
    private string _hitAnimation = "Hit";
    private Vector3 _direction;
    private float _rotation;
    private Enemy _enemy;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
    }

    public void Attack()
    {
        _direction = (Target.transform.position - transform.position).normalized;
        _rotation = Mathf.Atan2(_direction.z, _direction.x) * Mathf.Rad2Deg * -1;
        transform.rotation = Quaternion.Euler(0, _rotation, 0);

        if (_hit == null)
            _hit = Hit();
        StartCoroutine(_hit);
    }

    private IEnumerator Hit()
    {
        _animator.SetTrigger(_hitAnimation);
        yield return new WaitForSeconds(1 / _attackSpeed);
        Target.TakeDamage(_damage);
        _hit = null;
    }
}
