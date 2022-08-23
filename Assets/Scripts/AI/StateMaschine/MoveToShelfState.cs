using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToShelfState : MoveToTargetBaseState
{
    public MoveToShelfState(Transform target, NavMeshAgent agent) : base(target, agent) { }

    public override void EnterState(StateMachine stateMachine)
    {
        _agent.destination = _target.position;
    }
    public override void UpdateState(StateMachine stateMachine)
    {
        if (CheckDistance())
            stateMachine.SwichState<GrabItemsState>();
    }

    public override void ExitState(StateMachine stateMachine)
    {
        Debug.Log("Exit");
    }


    protected override bool CheckDistance()
    {
        return _agent.remainingDistance < 1f;
    }
}
