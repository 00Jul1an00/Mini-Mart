using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToShelfState : MoveToTargetBaseState
{
    public MoveToShelfState(Transform target, AIUnit agent, StateMachine stateMachine) : base(target, agent, stateMachine) { }

    public override void EnterState()
    {
        AIManager.Instance.MakeAgentsCircleTarget(_target.transform, _agent);
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
