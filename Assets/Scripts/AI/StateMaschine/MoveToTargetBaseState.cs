using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MoveToTargetBaseState : BaseState
{
    protected Transform _target;
    protected NavMeshAgent _agent;

    public MoveToTargetBaseState(Transform target, NavMeshAgent agent)
    {
        _target = target;
        _agent = agent;
    }

    protected abstract bool CheckDistance();
}
