using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Damageable>(out Damageable damageable) == true)
        {
            damageable.TakeDamage(1000);
        }
    }
}
