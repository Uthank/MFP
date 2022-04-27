using UnityEngine;

public class BattleState : State
{
    [SerializeField] private float _damage = 40;

    private Animator _animator;
    private string _hitAnimation = "Hit";
    private Vector3 _direction;
    private float _rotation;

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
        _animator.SetTrigger(_hitAnimation);
    }

    private void Hit()
    {
        Target.TakeDamage(_damage);
    }
}
