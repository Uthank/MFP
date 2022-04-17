using System.Collections;
using UnityEngine;

public class UnarmedPattern : AttackPattern
{
    [SerializeField] private float _attackDuration = 1;
    [SerializeField] private Vector3 _hitboxCenter = new Vector3(1.5f, 1f, 0);
    [SerializeField] private Vector3 _hitboxHalfExtents = new Vector3(1.5f, 1, 1);
    [SerializeField] private GameObject _particle;

    private Vector3 _lefthandOffset = new Vector3(0, 1, 0.5f);
    private Vector3 _righthandOffset = new Vector3(0, 1, -0.5f);

    public override void Awake()
    {
        _animationAttack = "Attack";
        base.Awake();
    }

    protected override IEnumerator HitPattern()
    {
        yield return new WaitForSeconds(15f / 45f * _attackDuration);
        Hit(_righthandOffset);
        yield return new WaitForSeconds(10f / 45f * _attackDuration);
        Hit(_lefthandOffset);
        yield return new WaitForSeconds(10f / 45f * _attackDuration);
        Hit(_righthandOffset);
        _attackCoroutine = null;
    }

    protected void Hit(Vector3 handOffset)
    {
        GameObject perticle = Instantiate(_particle, transform.position + handOffset, transform.rotation);
        Destroy(perticle, perticle.GetComponent<ParticleSystem>().main.duration);
        _targets = Physics.OverlapBox(transform.position + (transform.rotation * _hitboxCenter) + handOffset, _hitboxHalfExtents, transform.rotation, _layerMask);
        base.Hit();
    }

    protected void HitTest()
    {
        GameObject perticle = Instantiate(_particle, transform.position, transform.rotation);
        Destroy(perticle, perticle.GetComponent<ParticleSystem>().main.duration);
        _targets = Physics.OverlapBox(transform.position + (transform.rotation * _hitboxCenter), _hitboxHalfExtents, transform.rotation, _layerMask);
        base.Hit();
    }
}
