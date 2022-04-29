using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class BossRangeAttackState : State
{
    [SerializeField] private float _damage = 40;
    [SerializeField] private float _attackDuration = 1.5f;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _mouth;

    private Animator _animator;
    private string _hitAnimation = "Hit2";
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

    private IEnumerator Shoot()
    {
        float chargeSpeed = 1;
        GameObject projectile = Instantiate(_projectile, _mouth.position, Quaternion.identity, _mouth);

        while (projectile.transform.localScale.x < Vector3.one.x)
        {
            projectile.transform.localScale += Vector3.one * chargeSpeed * Time.deltaTime;
            yield return null;
        }

        projectile.transform.parent = null;
        Bullet bulletComponentOfProjectile = projectile.GetComponent<Bullet>();
        bulletComponentOfProjectile.Target = Target.transform;
        bulletComponentOfProjectile.Damage = _damage;
    }
}
