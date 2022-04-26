using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject _defaultWeapon;
    [SerializeField] private GameObject _weaponHolder;

    private Player _player;
    private AttackComponent _attackComponent;
    private List<Weapon> _weapons = new List<Weapon>();
    private Weapon _equippedWeapon;

    public Weapon EquippedWeapon => _equippedWeapon;

    public UnityAction<Weapon> WeaponAdded;
    public UnityAction<Weapon> WeaponEquipped;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _attackComponent = GetComponent<AttackComponent>();
        EquipWeapon(_defaultWeapon.GetComponent<Weapon>());
    }

    public List<Weapon> GetWeaponsList()
    {
        List<Weapon> weapons = new List<Weapon>();

        foreach (var weapon in _weapons)
            weapons.Add(weapon);

        return weapons;
    }

    public void Add(Weapon weapon)
    {
        _weapons.Add(weapon);
        WeaponAdded?.Invoke(weapon);
    }

    public void EquipWeapon(Weapon weapon)
    {
        _equippedWeapon = weapon;
        _player.GetComponent<Animator>().runtimeAnimatorController = weapon.CharacterController;
        _attackComponent.SetWeapon(weapon);

        if (_weaponHolder.transform.childCount > 0)
            Destroy(_weaponHolder.transform.GetChild(0));

        if (weapon.Data.Model != null)
            Instantiate(weapon.Data.Model, _weaponHolder.transform);
    }
}
