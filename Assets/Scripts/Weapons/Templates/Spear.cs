using UnityEngine;

public class Spear : Weapon
{
    [SerializeField] private Vector3 _hitboxCenter = new Vector3(3, 1f, 0);
    [SerializeField] private Vector3 _hitboxHalfExtents = new Vector3(3, 1, 1);

    public override void TriggerAttack()
    {
        GameObject particle = Instantiate(_data.Particles, transform.position, transform.rotation);
        Destroy(particle, particle.GetComponent<ParticleSystem>().main.duration);
        _targets = Physics.OverlapBox(transform.position + (transform.rotation * _hitboxCenter), _hitboxHalfExtents, transform.rotation, _layerMask);
        base.TriggerAttack();
    }
}
