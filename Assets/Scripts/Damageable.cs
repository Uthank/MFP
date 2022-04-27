using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField] protected float _maxHealth = 100;

    protected float _health;
    protected string _dieAnimation = "Die";
    protected Animator _animator;

    protected bool isAlive => _health > 0;

    public UnityAction Dying;
    public UnityAction<float> HealthChanged;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = _maxHealth;
    }
    protected void Start()
    {
        HealthChanged?.Invoke(_health / _maxHealth);
    }

    public virtual void TakeDamage(float damage)
    {
        if (isAlive == true)
        {
            _health -= damage;
            HealthChanged?.Invoke(_health / _maxHealth);

            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
        }
    }

    protected virtual void Die()
    {
        _animator.SetBool(_dieAnimation, true);
        Dying?.Invoke();
    }
}
