using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class BossBattleRouteState : State
{
    private int _attackCount;
    private int _dice;

    private void Awake()
    {
        _attackCount = Transitions.Count;
    }

    private void Update()
    {
        ChooseAttack();
    }

    private void ChooseAttack()
    {
        _dice = Random.Range(0, _attackCount);
        Transitions[_dice].NeedTransit = true;
    }
}
