using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class MoveToExitState : MoveToTargetBaseState
{
    public static event UnityAction IsDestroy;

    public MoveToExitState(Transform target, NavMeshAgent agent, StateMachine stateMachine) : base(target, agent, stateMachine) { }

    public override void EnterState()
    {
        _agent.destination = _target.position;
    }

    public override void UpdateState()
    {
        if (CheckDistance())
        {
            MonoBehaviour.Destroy(_agent.gameObject);
            IsDestroy?.Invoke();
        }
    }

    public override void ExitState()
    {        
    } 
}
