using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToExitState : MoveToTargetBaseState
{
    public MoveToExitState(Transform target, NavMeshAgent agent, StateMachine stateMachine) : base(target, agent, stateMachine) { }

    public override void EnterState()
    {
        _agent.destination = _target.position;
    }

    public override void UpdateState()
    {
        if (CheckDistance())
            Debug.Log("exit");
    }

    public override void ExitState()
    {
    } 
}
