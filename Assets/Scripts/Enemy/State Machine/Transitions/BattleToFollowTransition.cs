using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleToFollowTransition : Transition
{
    [SerializeField] private float _detectionDistance = 3.5f;

    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) > _detectionDistance)
        {
            NeedTransit = true;
        }
    }
}
