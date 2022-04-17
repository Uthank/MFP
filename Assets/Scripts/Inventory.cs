using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AttackComponent))]
public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject _defaultWeapon;
    [SerializeField] private GameObject _weaponHolder;

    private List<Weapon> _weapons = new List<Weapon>();
    private Weapon _equippedWeapon;
    private AttackComponent _attackComponent;

    public Weapon EquippedWeapon => _equippedWeapon;

    private void Awake()
    {
        _attackComponent = GetComponent<AttackComponent>();
        EquipWeapon(_defaultWeapon.GetComponent<Weapon>());
    }

    public void Add(Weapon weapon)
    {
        _weapons.Add(weapon);
    }

    public void Drop(Weapon weapon)
    {

    }

    public void EquipWeapon(Weapon weapon)
    {
        _equippedWeapon = weapon;
        _attackComponent.SetAttackPattern(weapon);

        if (_weaponHolder.transform.childCount > 0)
            Destroy(_weaponHolder.transform.GetChild(0));

        if (weapon.Model != null)
            Instantiate(weapon.Model, _weaponHolder.transform);
    }
}
