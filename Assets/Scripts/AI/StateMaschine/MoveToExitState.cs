using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToExitState : MoveToTargetBaseState
{
    public MoveToExitState(Transform target, NavMeshAgent agent) : base(target, agent) { }

    public override void EnterState(StateMachine stateMachine)
    {
    }

    public override void ExitState(StateMachine stateMachine)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        throw new System.NotImplementedException();
    }

    protected override bool CheckDistance()
    {
        throw new System.NotImplementedException();
    }
}
