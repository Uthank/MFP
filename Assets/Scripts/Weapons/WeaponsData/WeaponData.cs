using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons", order = 51)]
public class WeaponData : ScriptableObject
{
    [SerializeField] protected float _damage;
    [SerializeField] protected GameObject _model;
    [SerializeField] protected ParticleSystem _particles;
    [SerializeField] protected Arrow _ammo;
    [SerializeField] protected Sprite _icon;

    public float Damage => _damage;
    public GameObject Model => _model;
    public ParticleSystem Particles => _particles;
    public Arrow Ammo => _ammo;
    public Sprite Icon => _icon;
}
