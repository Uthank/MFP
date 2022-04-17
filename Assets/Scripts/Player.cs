using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] float _health = 100;
    [SerializeField] float _damage = 30;

    private PlayerInput _input;
    private Animator _animator;
    private string _dieAnimation = "Die";
    private string _respawnAnimation = "Respawn";

    public Vector3 RespawnPoint;

    public  UnityEvent Dying;

    private void Awake()
    {
        RespawnPoint = transform.position;
        //_input = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        if (damage > _health)
        {
            Dying?.Invoke();
        }
        else
        {
            _health -= damage;
        }
    }

    public void Respawn()
    {
        transform.position = RespawnPoint;
        //_input.Enable();
        _animator.SetTrigger(_respawnAnimation);
    }

    private void Damage(Enemy enemy)
    {
        enemy.TakeDamage(_damage);
    }

    private void Die()
    {
        //_input.Disable();
        _animator.SetTrigger(_dieAnimation);
    }
}
