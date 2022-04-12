using System.Collections;
using UnityEngine;

public class SwordPattern : AttackPattern
{
    [SerializeField] private float _attackDuration = 1;
    [SerializeField] private Vector3 _hitboxCenter = new Vector3(1.5f, 0, 0);
    [SerializeField] private Vector3 _hitboxHalfExtents = new Vector3(1.5f, 1, 2);

    public override void Awake()
    {
        _animationAttack = "AttackSword";
        base.Awake();
    }

    protected override IEnumerator HitPattern()
    {
        yield return new WaitForSeconds(13f / 45f * _attackDuration);
        _targets = Physics.OverlapBox(transform.position + (transform.rotation * _hitboxCenter), _hitboxHalfExtents, transform.rotation, _layerMask);
        Hit();
        yield return new WaitForSeconds(12f / 45f * _attackDuration);
        _targets = Physics.OverlapBox(transform.position + (transform.rotation * _hitboxCenter), _hitboxHalfExtents, transform.rotation, _layerMask);
        Hit();
        yield return new WaitForSeconds(10f / 45f * _attackDuration);
        _targets = Physics.OverlapBox(transform.position + (transform.rotation * _hitboxCenter), _hitboxHalfExtents, transform.rotation, _layerMask);
        Hit();
        _attackCoroutine = null;
    }
}
