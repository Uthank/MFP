using UnityEngine;

[RequireComponent(typeof(Player))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayerMask;

    private string _animationAttack = "Attack";
    private Weapon _weapon;
    private float _damage;
    private PlayerInput _input;
    private Player _player;
    private Animator _animator;

    public float Damage => _damage;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
        _input = new PlayerInput();
        _input.Player.Attack.performed += ctx => Attack();
        _input.Enable();
    }

    public void SetWeapon(Weapon weapon)
    {
        _weapon = Instantiate(weapon, transform);
        _weapon.SetPlayerInfo(_player);
    }

    public void TriggerAttack()
    {
        _weapon.TriggerAttack();
    }

    public void TriggerAttackWithFloat(float number)
    {
        _weapon.TriggerAttackWithFloat(number);
    }

    private void Attack()
    {
        if (_player.IsInputEnabled == true)
        {
            _animator.SetTrigger(_animationAttack);
        }
    }
}
