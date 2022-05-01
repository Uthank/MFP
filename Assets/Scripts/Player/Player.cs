using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Inventory))]
[RequireComponent(typeof(Interactor))]
public class Player : Damageable
{
    [SerializeField] private WaitForSeconds _respawnTimer = new WaitForSeconds(3f);

    private string _respawnAnimation = "Respawn";
    private Vector3 _respawnPoint;

    public event UnityAction Respawned;

    public bool IsInputEnabled { get; private set; } = true;

    protected override void Awake()
    {
        SetRespawnPoint(transform.position);
        base.Awake();
    }

    public void Respawn()
    {
        transform.position = _respawnPoint;
        _health = _maxHealth;
        HealthChanged?.Invoke(_health / _maxHealth);
        _animator.SetBool(_dieAnimation, false);
        _animator.SetTrigger(_respawnAnimation);
        IsInputEnabled = true;
        Respawned?.Invoke();
    }

    protected override void Die()
    {
        IsInputEnabled = false;
        base.Die();
        StartCoroutine(TimedRespawn());
    }

    private IEnumerator TimedRespawn()
    {
        yield return _respawnTimer;
        Respawn();
    }

    public void SetRespawnPoint(Vector3 point)
    {
        _respawnPoint = point;
    }
}
