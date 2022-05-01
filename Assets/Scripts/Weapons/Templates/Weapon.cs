using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected Player _player;
    [SerializeField] protected RuntimeAnimatorController _characterController;
    [SerializeField] protected LayerMask _layerMask;
    [SerializeField] protected WeaponData _data;

    protected Collider[] _targets;
    protected IEnumerator _attackCoroutine;

    public WeaponData Data => _data;
    public RuntimeAnimatorController CharacterController => _characterController;

    public virtual void Attack()
    {
        foreach (var target in _targets)
            ApplyDamage(target.transform.GetComponent<Enemy>());
    }

    public virtual void AttackWithOffset(float number){}

    public void SetPlayerInfo(Player player)
    {
        _player = player;
    }

    protected void ApplyDamage(Enemy enemy)
    {
        enemy.TakeDamage(_data.Damage);
    }
}
