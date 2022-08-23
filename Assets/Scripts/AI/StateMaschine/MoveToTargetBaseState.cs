using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MoveToTargetBaseState : BaseState
{
    protected Transform _target;

    public MoveToTargetBaseState(Transform target, NavMeshAgent agent, StateMachine stateMachine) : base(stateMachine, agent)
    {
        _target = target;
    }

    protected virtual bool CheckDistance()
    {
        return _agent.remainingDistance < 1f;
    }   
}
