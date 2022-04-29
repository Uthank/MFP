using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class Inventory : MonoBehaviour
{
    [SerializeField] private Weapon _defaultWeapon;
    [SerializeField] private GameObject _weaponHolder;
    [SerializeField] private GameObject _inventoryView;

    private Player _player;
    private Attacker _attacker;
    private List<Weapon> _weapons = new List<Weapon>();
    private Weapon _equippedWeapon;
    private GameObject _weaponHolderModel;
    private PlayerInput _input;

    public Weapon EquippedWeapon => _equippedWeapon;

    public UnityAction<Weapon> WeaponAdded;
    public UnityAction<Weapon> WeaponEquipped;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _attacker = GetComponent<Attacker>();
        _input = new PlayerInput();
        _input.Player.Inventory.performed += ctx => View();
        _input.Enable();
    }

    private void Start()
    {
        EquipWeapon(_defaultWeapon);
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
        if (_equippedWeapon != _defaultWeapon && _equippedWeapon != null)
            Add(_equippedWeapon);

        _equippedWeapon = weapon;
        _player.GetComponent<Animator>().runtimeAnimatorController = weapon.CharacterController;
        _attacker.SetWeapon(weapon);

        if (_weaponHolderModel != null)
            Destroy(_weaponHolderModel);

        if (weapon.Data.Model != null)
            _weaponHolderModel = Instantiate(weapon.Data.Model, _weaponHolder.transform);

        Remove(weapon);

        WeaponEquipped?.Invoke(_equippedWeapon);
    }

    public void UnequipWeapon()
    {
        EquipWeapon(_defaultWeapon);
    }

    private void Remove(Weapon weapon)
    {
        _weapons.Remove(weapon);
    }

    private void View()
    {
        if (_inventoryView.activeSelf == false)
        {
            _inventoryView.SetActive(true);
        }
        else
        {
            _inventoryView.SetActive(false);
        }
    }
}
