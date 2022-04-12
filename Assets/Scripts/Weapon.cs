using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class Weapon : Item
{
    [SerializeField] protected WeaponTypes _type;
    [SerializeField] protected float _damage;
    [SerializeField] protected GameObject _prefab = null;

    public WeaponTypes Type => _type;
    public float Damage => _damage;
    public GameObject Prefab => _prefab;
}
