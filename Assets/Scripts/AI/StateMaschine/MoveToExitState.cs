using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class MoveToExitState : MoveToTargetBaseState
{
    public static event UnityAction IsDestroy;

    public MoveToExitState(Transform target, AIUnit agent, StateMachine stateMachine) : base(target, agent, stateMachine) { }

    public override void EnterState()
    {
        AIManager.Instance.MakeAgentsCircleTarget(_target.transform, _agent);
    }

    public override void UpdateState()
    {
        if (CheckDistance())
        {
            MonoBehaviour.Destroy(_agent.gameObject);
            AIManager.Instance.RemoveUnit(_agent);
            IsDestroy?.Invoke();
        }
    }

    public override void ExitState()
    {        
    } 
}
