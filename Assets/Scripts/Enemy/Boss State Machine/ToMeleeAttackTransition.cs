using UnityEngine;

public class ToMeleeAttackTransition : Transition
{
    [SerializeField] private float _detectionDistance = 7f;

    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) < _detectionDistance)
        {
            NeedTransit = true;
        }
    }
}
