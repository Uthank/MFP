using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private EquippedWeaponView _equippedWeaponView;
    [SerializeField] private GameObject _contentView;
    [SerializeField] private WeaponView _weaponViewTemplate;

    public Inventory Inventory => _inventory;

    private void OnEnable()
    {
        _inventory.WeaponAdded += AddWeaponView;
        _inventory.WeaponEquipped += SetEquippedWeaponView;
        Initialize();
    }

    private void OnDisable()
    {
        _inventory.WeaponAdded -= AddWeaponView;
        _inventory.WeaponEquipped -= SetEquippedWeaponView;
        Clear();
    }

    private void AddWeaponView(Weapon weapon)
    {
        WeaponView weaponView = Instantiate(_weaponViewTemplate, _contentView.transform);
        weaponView.Initialize(weapon, this);
    }

    private void SetEquippedWeaponView(Weapon weapon)
    {
        _equippedWeaponView.Set(weapon);
    }

    private void Initialize()
    {
        _equippedWeaponView.Set(Inventory.EquippedWeapon);

        foreach (var weapon in Inventory.GetWeaponsList())
        {
            AddWeaponView(weapon);
        }
    }

    private void Clear()
    {
        foreach (var weaponView in _contentView.GetComponentsInChildren<WeaponView>())
        {
            Destroy(weaponView.gameObject);
        }
    }
}
