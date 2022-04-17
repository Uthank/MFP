using System.Collections;
using UnityEngine;

public class UnarmedPattern : AttackPattern
{
    [SerializeField] private Vector3 _hitboxCenter = new Vector3(1.5f, 1f, 0);
    [SerializeField] private Vector3 _hitboxHalfExtents = new Vector3(1.5f, 1, 1);

    public override void Awake()
    {
        _animationAttack = "Attack";
        base.Awake();
    }

    protected void Hit(float handOffset)
    {
        if (Particles != null)
        {
            GameObject particle = Instantiate(Particles, transform.position + new Vector3(handOffset, 1, 0), transform.rotation);
            Destroy(particle, particle.GetComponent<ParticleSystem>().main.duration);
        }

        _targets = Physics.OverlapBox(transform.position + (transform.rotation * _hitboxCenter) + new Vector3(handOffset, 1, 0), _hitboxHalfExtents, transform.rotation, _layerMask);
        base.Hit();
    }
}
