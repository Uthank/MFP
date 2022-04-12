using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class AttackComponent : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayerMask;

    private AttackPattern _attackPattern;
    private float _damage;
    private PlayerInput _input;

    public LayerMask EnemyLayerMask => _enemyLayerMask;
    public float Damage => _damage;

    private void Awake()
    {
        _input = new PlayerInput();
        _input.Player.Attack.performed += ctx => Attack();
        _input.Enable();
    }

    public void SetAttack(Weapon weapon)
    {
        _damage = weapon.Damage;

        switch (weapon.Type)
        {
            case WeaponTypes.None:
                _attackPattern = gameObject.GetComponent<UnarmedPattern>();
                break;
            case WeaponTypes.Bow:
                _attackPattern = gameObject.GetComponent<BowPattern>();
                break;
            case WeaponTypes.Sword:
                _attackPattern = gameObject.GetComponent<SwordPattern>();
                break;
            case WeaponTypes.Spear:
                _attackPattern = gameObject.GetComponent<SpearPattern>();
                break;
            case WeaponTypes.Hammer:
                _attackPattern = gameObject.GetComponent<HammerPattern>();
                break;
        }
    }

    private void Attack()
    {
        _attackPattern.Attack();
    }
}
