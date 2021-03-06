using UnityEngine;

[RequireComponent(typeof(EnemyStateMachine))]
[RequireComponent(typeof(Path))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Enemy : Damageable
{
    [SerializeField] private Player _target;
    [SerializeField] private float _speed = 3;
    [SerializeField] private State _defaultState;

    private State[] _states;
    private Transition[] _transitions;
    private EnemyStateMachine _enemyStateMachine;

    public Player Target => _target;
    public float Speed => _speed;

    protected override void Awake()
    {
        base.Awake();
        _states = gameObject.GetComponents<State>();
        _transitions = gameObject.GetComponents<Transition>();
        _enemyStateMachine = GetComponent<EnemyStateMachine>();
    }

    private void OnEnable()
    {
        Target.Respawned += ResetState;
        Target.Dying += DisableStates;
    }

    private void OnDisable()
    {
        Target.Respawned -= ResetState;
        Target.Dying -= DisableStates;
    }

    protected override void Die()
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

        base.Die();
    }

    private void DisableStates()
    {
        foreach (var state in _states)
        {
            state.Exit();
        }
    }

    private void ResetState()
    {
        _enemyStateMachine.Reset(_defaultState);
    }
}
