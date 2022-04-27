using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons", order = 51)]
public class WeaponData : ScriptableObject
{
    [SerializeField] protected float _damage;
    [SerializeField] protected GameObject _model;
    [SerializeField] protected GameObject _particles;
    [SerializeField] protected GameObject _ammo;
    [SerializeField] protected Sprite _icon;

    public float Damage => _damage;
    public GameObject Model => _model;
    public GameObject Particles => _particles;
    public GameObject Ammo => _ammo;
    public Sprite Icon => _icon;
}
