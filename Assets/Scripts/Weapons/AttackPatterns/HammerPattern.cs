using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerPattern : AttackPattern
{
    [SerializeField] private float _attackDuration = 1;
    [SerializeField] private Vector3 _hitboxCenter = new Vector3(3f, 1f, 0);
    [SerializeField] private Vector3 _hitboxHalfExtents = new Vector3(3f, 1f, 3f);
    [SerializeField] private GameObject _particle;

    private Vector3 _groundOffset;

    public override void Awake()
    {
        _groundOffset = new Vector3(0, GetComponent<Collider>().bounds.size.y / 2f, 0);
        _animationAttack = "AttackHammer";
        base.Awake();
    }

    protected override IEnumerator HitPattern()
    {
        yield return new WaitForSeconds(20f / 45f * _attackDuration);
        Hit();
        _attackCoroutine = null;
    }

    protected override void Hit()
    {
        Vector3 hitboxCenter = transform.position + (transform.rotation * _hitboxCenter);
        GameObject perticle = Instantiate(_particle, hitboxCenter - _groundOffset, transform.rotation);
        Destroy(perticle, perticle.GetComponent<ParticleSystem>().main.duration);
        _targets = Physics.OverlapBox(hitboxCenter, _hitboxHalfExtents, transform.rotation, _layerMask);
        base.Hit();
    }
}
