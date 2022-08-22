using UnityEngine;
using UnityEngine.AI;

public abstract class BaseState
{
    protected Transform _target;
    protected NavMeshAgent _agent;
    protected StateMachine _stateMachine;

    public BaseState(Transform target, NavMeshAgent agent, StateMachine stateMachine)
    {
        _target = target;
        _agent = agent;
        _stateMachine = stateMachine;
    }

    public abstract void StartState();
    public abstract void StopState();
}
