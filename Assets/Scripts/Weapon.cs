using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class Weapon : Item
{
    [SerializeField] protected float _damage;
    [SerializeField] protected GameObject _model = null;
    [SerializeField] protected GameObject _particles = null;

    public float Damage => _damage;
    public GameObject Model => _model;
    public GameObject Particles => _particles;
}
