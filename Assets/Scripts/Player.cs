using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(MoveComponent))]
[RequireComponent(typeof(AttackComponent))]
[RequireComponent(typeof(Inventory))]
public class Player : MonoBehaviour
{
    [SerializeField] float _maxHealth = 100;
    [SerializeField] float _health = 100;
    
    public Vector3 RespawnPoint;

    private Animator _animator;
    private string _dieAnimation = "Die";
    private string _respawnAnimation = "Respawn";

    public float MaxHealth => _maxHealth;
    public bool IsInputEnabled { get; private set; } = true;

    public UnityEvent Dying;
    public UnityEvent<float> HealthChanged;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        if (damage > _health)
        {
            Dying?.Invoke();
            Die();
        }
        else
        {
            _health -= damage;
            HealthChanged?.Invoke(_health);
        }
    }

    public void Respawn()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke(_health);
        transform.position = RespawnPoint;
        _animator.SetTrigger(_respawnAnimation);
        IsInputEnabled = true;
    }

    private void Die()
    {
        _animator.SetTrigger(_dieAnimation);
        IsInputEnabled = false;
    }
}
