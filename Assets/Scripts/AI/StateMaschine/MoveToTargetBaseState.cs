using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MoveToTargetBaseState : BaseState
{
    protected Transform _target;
    protected float _distance = .5f;

    public MoveToTargetBaseState(Transform target, ObstacleAgent agent, StateMachine stateMachine) : base(stateMachine, agent)
    {
        _target = target;
    }

    //protected bool CheckDistance()
    //{
    //    return _agent.CheckDistance(_distance);
    //}   
}
