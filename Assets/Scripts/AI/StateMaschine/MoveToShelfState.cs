using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToShelfState : MoveToTargetBaseState
{
    public MoveToShelfState(Transform target, NavMeshAgent agent, StateMachine stateMachine) : base(target, agent, stateMachine) { }

    public override void EnterState()
    {
        _agent.destination = _target.position + ((Vector3)Random.insideUnitCircle);
        Debug.Log(_agent.destination);
    }
    public override void UpdateState()
    {
        if (CheckDistance())
        {
            _stateMachine.StartCoroutine(DelayBetweenStates(1));
            _stateMachine.ActivateNextState();
        }
    }

    public override void ExitState()
    {
        _stateMachine.StopCoroutine(DelayBetweenStates(1));
    }
}
