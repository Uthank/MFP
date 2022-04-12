using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] float _health = 100;
    [SerializeField] float _damage = 30;

    public  UnityEvent Dying;

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

    private void Damage(Enemy enemy)
    {
        enemy.TakeDamage(_damage);
    }
}
