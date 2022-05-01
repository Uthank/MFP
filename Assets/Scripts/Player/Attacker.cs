using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayerMask;

    private string _animationAttack = "Attack";
    private Weapon _weapon;
    private PlayerInput _input;
    private Player _player;
    private Animator _animator;

    public float Damage { get; private set; }

    private void Awake()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
        _input = new PlayerInput();
        _input.Player.Attack.performed += ctx => StartAttackAnimation();
        _input.Enable();
    }

    public void SetWeapon(Weapon weapon)
    {
        _weapon = Instantiate(weapon, transform);
        _weapon.SetPlayerInfo(_player);
    }

    public void Attack()
    {
        _weapon.Attack();
    }

    public void AttackWithOffset(float number)
    {
        _weapon.AttackWithOffset(number);
    }

    private void StartAttackAnimation()
    {
        if (_player.IsInputEnabled == true)
        {
            _animator.SetTrigger(_animationAttack);
        }
    }
}
