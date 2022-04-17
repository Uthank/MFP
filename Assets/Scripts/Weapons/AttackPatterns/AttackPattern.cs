using System.Collections;
using UnityEngine;

public abstract class AttackPattern : MonoBehaviour
{
    public GameObject Particles;

    protected float _damage;
    protected LayerMask _layerMask;
    protected string _animationAttack;
    protected Animator _animator;
    protected Collider[] _targets;
    protected AttackComponent _attackComponent;
    protected IEnumerator _attackCoroutine;

    public virtual void Awake()
    {
        _attackComponent = GetComponent<AttackComponent>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _damage = _attackComponent.Damage;
        _layerMask = _attackComponent.EnemyLayerMask;
    }

    public void Attack()
    {
        if (_attackCoroutine == null)
        {
            _animator.SetTrigger(_animationAttack);
        }
    }

    protected virtual void Hit()
    {
        foreach (var target in _targets)
            ApplyDamage(target.transform.GetComponent<Enemy>());
    }

    protected void ApplyDamage(Enemy enemy)
    {
        enemy.TakeDamage(_damage);
    }
}
