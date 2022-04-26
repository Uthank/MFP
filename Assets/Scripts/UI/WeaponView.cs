﻿using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _damage;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _equip;

    public void Set(Weapon weapon)
    {
        _name.text = weapon.name;
        _damage.text = weapon.Data.Damage.ToString();
        //_icon = weapon.Icon;
    }
}
