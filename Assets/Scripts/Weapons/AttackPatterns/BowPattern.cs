using System.Collections;
using UnityEngine;

public class BowPattern : AttackPattern
{
    [SerializeField] private Vector3 _shootOffset = new Vector3(1.5f, 1f, 0);

    private Vector3 _arrowStartPosition;

    public override void Awake()
    {
        _animationAttack = "AttackBow";
        base.Awake();
    }

    private void Shoot()
    {
        GameObject arrow = Instantiate(Particles, transform.position + (transform.rotation * _shootOffset), transform.rotation);
        arrow.GetComponent<Arrow>().Damage = _damage;
    }
}
