using System.Collections;
using UnityEngine;

public class Bow : Weapon
{
    [SerializeField] private Vector3 _shootOffset = new Vector3(1.5f, 1f, 0);

    public override void Attack()
    {
        Arrow arrow = Instantiate(_data.Ammo, transform.position + (transform.rotation * _shootOffset), transform.rotation);
        arrow.Damage = _data.Damage;
    }
}
