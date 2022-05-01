using UnityEngine;

public class Sword : Weapon
{
    [SerializeField] private Vector3 _hitboxCenter = new Vector3(1.5f, 1f, 0);
    [SerializeField] private Vector3 _hitboxHalfExtents = new Vector3(1.5f, 1, 2);

    public override void Attack()
    {
        _targets = Physics.OverlapBox(transform.position + (transform.rotation * _hitboxCenter), _hitboxHalfExtents, transform.rotation, _layerMask);
        base.Attack();
    }
}