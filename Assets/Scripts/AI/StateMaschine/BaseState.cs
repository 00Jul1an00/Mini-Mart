using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseState
{
    protected StateMachine _stateMachine;
    protected NavMeshAgent _agent;

    public BaseState(StateMachine stateMachine, NavMeshAgent agent)
    {
        _stateMachine = stateMachine;
        _agent = agent;
    }

    protected IEnumerator DelayBetweenStates(float animationDuration)
    {
        _agent.isStopped = true;
        yield return new WaitForSeconds(animationDuration);
        _agent.isStopped = false;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public virtual void ExitState() { }
}
