using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowToBattleTransition : Transition
{
    [SerializeField] private float _detectionDistance = 4f;

    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) < _detectionDistance)
        {
            NeedTransit = true;
        }
    }
}
