using System.Collections;
using UnityEngine;

public class SpearPattern : AttackPattern
{
    [SerializeField] private float _attackDuration = 1;
    [SerializeField] private Vector3 _hitboxCenter = new Vector3(3, 0, 0);
    [SerializeField] private Vector3 _hitboxHalfExtents = new Vector3(3, 1, 1);
    [SerializeField] private GameObject _particle;

    public override void Awake()
    {
        _animationAttack = "AttackSpear";
        base.Awake();
    }

    protected override IEnumerator HitPattern()
    {
        yield return new WaitForSeconds(15f / 45f * _attackDuration);
        Hit();
        yield return new WaitForSeconds(10f / 45f * _attackDuration);
        Hit();
        yield return new WaitForSeconds(10f / 45f * _attackDuration);
        Hit();
        _attackCoroutine = null;
    }

    protected override void Hit()
    {
        GameObject perticle = Instantiate(_particle, transform.position, transform.rotation);
        Destroy(perticle, perticle.GetComponent<ParticleSystem>().main.duration);
        _targets = Physics.OverlapBox(transform.position + (transform.rotation * _hitboxCenter), _hitboxHalfExtents, transform.rotation, _layerMask);
        base.Hit();
    }
}
