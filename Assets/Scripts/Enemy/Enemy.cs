using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    [SerializeField] private Player _target;

    public Player Target => _target;
    public float Speed { get; private set; } = 3f;

    public event UnityAction Dying;

    private State[] _states;
    private Transition[] _transitions;
    private Animator _animator;
    private string _animationDie = "Die";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _states = gameObject.GetComponents<State>();
        _transitions = gameObject.GetComponents<Transition>();
    }

    public void TakeDamage(float damage)
    {
        if (_health > 0)
        {
            _health -= damage;

            if (_health <= 0)
                Die();
        }

    }

    private void Die()
    {
        foreach (var state in _states)
        {
            state.enabled = false;
        }
        foreach (var transition in _transitions)
        {
            transition.enabled = false;
        }

        _animator.SetTrigger(_animationDie);
        Dying?.Invoke();
    }
}
