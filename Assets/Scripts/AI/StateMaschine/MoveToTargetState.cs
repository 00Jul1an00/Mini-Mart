using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTargetState : BaseState
{
    public MoveToTargetState(Transform target, NavMeshAgent agent, StateMachine stateMachine) : base(target, agent, stateMachine) { }

    public override void StartState()
    {
        _agent.destination = _target.position;

        if (_agent.remainingDistance < 1f)
            Debug.Log("arrived");
            //stateMachine.SwichState<>();
    }

    public override void StopState()
    {
        Debug.Log("stoped");
    }
}
