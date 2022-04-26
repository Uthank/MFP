using System.Collections;
using UnityEngine;

public class Bow : Weapon
{
    [SerializeField] private Vector3 _shootOffset = new Vector3(1.5f, 1f, 0);

    public override void TriggerAttack()
    {
        GameObject arrow = Instantiate(_data.Ammo, transform.position + (transform.rotation * _shootOffset), transform.rotation);
        arrow.GetComponent<Arrow>().Damage = _data.Damage;
    }
}
