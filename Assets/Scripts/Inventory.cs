using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject _defaultWeapon;
    [SerializeField] private GameObject _weaponHolder;

    private List<GameObject> _items = new List<GameObject>();
    private Weapon _equippedWeapon;
    private AttackComponent _attackComponent;

    public Weapon EquippedWeapon => _equippedWeapon;

    private void Awake()
    {
        _attackComponent = GetComponent<AttackComponent>();
        EquipWeapon(_defaultWeapon.GetComponent<Weapon>());
    }

    public void Add(GameObject item)
    {
        _items.Add(item);
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
