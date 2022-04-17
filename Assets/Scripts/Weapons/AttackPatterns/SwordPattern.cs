using System.Collections;
using UnityEngine;

public class SwordPattern : AttackPattern
{
    [SerializeField] private Vector3 _hitboxCenter = new Vector3(1.5f, 1f, 0);
    [SerializeField] private Vector3 _hitboxHalfExtents = new Vector3(1.5f, 1, 2);

    public override void Awake()
    {
        _animationAttack = "AttackSword";
        base.Awake();
    }
}
