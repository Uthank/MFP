using UnityEngine;

public class Unarmed : Weapon
{
    [SerializeField] private Vector3 _hitboxCenter = new Vector3(1.5f, 1f, 0);
    [SerializeField] private Vector3 _hitboxHalfExtents = new Vector3(1.5f, 1, 1);

    public override void AttackWithOffset(float handOffset)
    {
        if (_data.Particles != null)
        {
            ParticleSystem particle = Instantiate(_data.Particles, transform.position + new Vector3(handOffset, 1, 0), transform.rotation);
            Destroy(particle, particle.main.duration);
        }

        _targets = Physics.OverlapBox(transform.position + (transform.rotation * _hitboxCenter) + new Vector3(handOffset, 1, 0), _hitboxHalfExtents, transform.rotation, _layerMask);
        Attack();
    }
}