using System.Collections;
using UnityEngine;

public class BowPattern : AttackPattern
{
    [SerializeField] private float _attackDuration = 1;
    [SerializeField] private GameObject _arrow;
    [SerializeField] private Vector3 _shootOffset = new Vector3(1.5f, 0, 0);

    private Vector3 _arrowStartPosition;

    public override void Awake()
    {
        _animationAttack = "AttackBow";
        base.Awake();
    }

    protected override IEnumerator HitPattern()
    {
        yield return new WaitForSeconds(14f / 45f * _attackDuration);
        CreateArrow();
        yield return new WaitForSeconds(10f / 45f * _attackDuration);
        CreateArrow();
        yield return new WaitForSeconds(9f / 45f * _attackDuration);
        CreateArrow();
        _attackCoroutine = null;
    }

    private void CreateArrow()
    {
        GameObject arrow = Instantiate(_arrow, transform.position + (transform.rotation * _shootOffset), transform.rotation);
        arrow.GetComponent<Arrow>().Damage = _damage;
        Debug.Log(_damage);
    }
}
