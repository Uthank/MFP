using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] Inventory _inventory;
    [SerializeField] EquippedWeaponView _equippedWeaponView;
    [SerializeField] GameObject _contentView;
    [SerializeField] GameObject _weaponViewTemplate;

    private void Awake()
    {
        _equippedWeaponView.Set(_inventory.EquippedWeapon);

        //foreach (var weapon in _inventory.GetWeaponsList())
        //{
        //    var weaponView = Instantiate(new WeaponView(), _contentView.transform);
        //    weaponView.Set(weapon);
        //}
    }

    private void OnEnable()
    {
        _inventory.WeaponAdded += AddWeaponView;
    }

    private void OnDisable()
    {
        _inventory.WeaponAdded -= AddWeaponView;
    }

    private void AddWeaponView(Weapon weapon)
    {
        Instantiate(_weaponViewTemplate, _contentView.transform).GetComponent<WeaponView>().Set(weapon);
    }
}
