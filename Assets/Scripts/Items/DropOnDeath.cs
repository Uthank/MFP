using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DropOnDeath : MonoBehaviour
{
    [SerializeField] private DropWrapper _dropWrapper;
    [SerializeField] private Weapon _drop;

    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.Dying += DropItem;
    }

    private void OnDisable()
    {
        _enemy.Dying -= DropItem;
    }

    private void DropItem()
    {
        DropWrapper dropWrapper = Instantiate(_dropWrapper, transform.position, Quaternion.identity);
        dropWrapper._drop = _drop;
    }
}
