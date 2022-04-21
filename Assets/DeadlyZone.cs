using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player) == true)
        {
            player.TakeDamage(1000);
        }
        else if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy) == true)
        {
            enemy.TakeDamage(1000);
        }
    }
}
