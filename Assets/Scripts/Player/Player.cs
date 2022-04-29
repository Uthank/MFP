using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Inventory))]
public class Player : Damageable
{
    [SerializeField] private WaitForSeconds _respawnTimer = new WaitForSeconds(3f);
    
    private string _respawnAnimation = "Respawn";

    [HideInInspector] public Vector3 RespawnPoint;

    public UnityAction Respawned;

    public bool IsInputEnabled { get; private set; } = true;

    protected override void Awake()
    {
        RespawnPoint = transform.position;
        base.Awake();
    }

    public void Respawn()
    {
        transform.position = RespawnPoint;
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
}
