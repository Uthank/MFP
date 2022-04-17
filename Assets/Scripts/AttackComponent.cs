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

    public void SetAttackPattern(Weapon weapon)
    {
        _damage = weapon.Damage;
        gameObject.AddComponent(System.Type.GetType(weapon.GetComponent<AttackPattern>().GetType() + ",Assembly-CSharp"));
        _attackPattern = GetComponent<AttackPattern>();

        if (weapon.Particles != null)
            _attackPattern.Particles = weapon.Particles;
    }

    private void Attack()
    {
        _attackPattern.Attack();
    }
}
