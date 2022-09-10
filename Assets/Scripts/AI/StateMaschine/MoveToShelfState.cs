using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToShelfState : MoveToTargetBaseState
{
    public MoveToShelfState(Transform target, ObstacleAgent agent, StateMachine stateMachine) : base(target, agent, stateMachine) { }

    public override void EnterState()
    {
        _agent.SetDestionation(_target.position + ((Vector3)Random.insideUnitCircle));
    }
    public override void UpdateState()
    {
        if (_agent.IsReachedDestination)
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
