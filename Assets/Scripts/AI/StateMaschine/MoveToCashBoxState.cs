using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToCashBoxState : MoveToTargetBaseState
{
    public MoveToCashBoxState(Transform target, NavMeshAgent agent, StateMachine stateMachine) : base(target, agent, stateMachine) { }

    public override void EnterState()
    {
        _agent.destination = _target.position;
    }

    public override void UpdateState()
    {
        if (CheckDistance())
        {
            _stateMachine.StartCoroutine(DelayBetweenStates(1));
            _stateMachine.ActivateNextState(this);
        }
    }

    public override void ExitState()
    {
        _stateMachine.StopCoroutine(DelayBetweenStates(1));
    }  
}
