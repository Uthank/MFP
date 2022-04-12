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

    public event UnityAction<Enemy> Dying;

    public void TakeDamage(float damage)
    {
        if (damage > _health)
        {
            Dying?.Invoke(this);
            Destroy(gameObject);
        }
        else
        {
            _health -= damage;
        }
    }
}
