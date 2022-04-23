using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private Player _target;

    public Player Target => _target;
    public float Speed { get; private set; } = 3f;

    private bool isAlive => _health > 0;

    public event UnityAction Dying;
    public UnityAction<float> HealthChanged;

    private State[] _states;
    private float _health;
    private Transition[] _transitions;
    private EnemyStateMachine _enemyStateMachine;
    private Animator _animator;
    private Collider _collider;
    private string _animationDie = "Die";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _states = gameObject.GetComponents<State>();
        _transitions = gameObject.GetComponents<Transition>();
        _enemyStateMachine = GetComponent<EnemyStateMachine>();
        _collider = GetComponent<Collider>();
        _health = _maxHealth;
    }

    private void Start()
    {
        HealthChanged?.Invoke(_health / _maxHealth);
    }

    public void TakeDamage(float damage)
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

    private void Die()
    {
        _enemyStateMachine.enabled = false;

        foreach (var state in _states)
        {
            state.enabled = false;
        }

        foreach (var transition in _transitions)
        {
            transition.enabled = false;
        }

        _animator.SetBool(_animationDie, true);
        Dying?.Invoke();
    }
}
