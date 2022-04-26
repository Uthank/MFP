using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons", order = 51)]
public class WeaponData : ScriptableObject
{
    [SerializeField] protected float _damage;
    [SerializeField] protected GameObject _model = null;
    [SerializeField] protected GameObject _particles = null;
    [SerializeField] protected GameObject _ammo = null;

    public float Damage => _damage;
    public GameObject Model => _model;
    public GameObject Particles => _particles;
    public GameObject Ammo => _ammo;
}
