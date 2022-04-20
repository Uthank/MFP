using System.Collections;
using UnityEngine;

public class BossMeleeAttackState : State
{
    [SerializeField] private float _damage = 40;
    [SerializeField] private float _attackDuration = 1.5f;

    private Animator _animator;
    private string _hitAnimation = "Hit1";
    private Vector3 _direction;
    private float _rotation;
    private Coroutine _attack;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_attack == null)
        {
            _attack = StartCoroutine(Attack());
        }
    }

    public IEnumerator Attack()
    {
        _direction = (Target.transform.position - transform.position).normalized;
        _rotation = Mathf.Atan2(_direction.z, _direction.x) * Mathf.Rad2Deg * -1;
        transform.rotation = Quaternion.Euler(0, _rotation, 0);
        _animator.SetTrigger(_hitAnimation);
        yield return new WaitForSeconds(_attackDuration);
        _attack = null;
        Transitions[0].NeedTransit = true;
    }

    private void Hit()
    {
        Target.TakeDamage(_damage);
        Debug.Log("Shoot");
    }
}
