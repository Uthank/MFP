using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DropOnDeath : MonoBehaviour
{
    [SerializeField] private GameObject _dropWrapper;
    [SerializeField] private GameObject _drop;

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
        var dropWrapper = Instantiate(_dropWrapper, transform.position, Quaternion.identity);
        dropWrapper.GetComponent<DropWrapper>()._drop = _drop;
    }
}
