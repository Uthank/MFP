using UnityEngine;

public class Hammer : Weapon
{
    [SerializeField] private Vector3 _hitboxCenter = new Vector3(3f, 1f, 0);
    [SerializeField] private Vector3 _hitboxHalfExtents = new Vector3(3f, 1f, 3f);
    private Vector3 _groundOffset = new Vector3(0, 2f, 0);

    public override void Attack()
    {
        Vector3 hitboxCenter = transform.position + (transform.rotation * _hitboxCenter);
        ParticleSystem particle = Instantiate(_data.Particles, hitboxCenter - _groundOffset, transform.rotation);
        Destroy(particle, particle.main.duration);
        _targets = Physics.OverlapBox(hitboxCenter, _hitboxHalfExtents, transform.rotation, _layerMask);
        base.Attack();
    }
}
