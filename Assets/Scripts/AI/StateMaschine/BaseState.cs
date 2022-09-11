using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseState
{
    protected StateMachine _stateMachine;
    protected AIUnit _agent;

    public BaseState(StateMachine stateMachine, AIUnit agent)
    {
        _stateMachine = stateMachine;
        _agent = agent;
    }

    protected virtual IEnumerator DelayBetweenStates(float animationDuration)
    {
        _agent.isStopped = true;
        yield return new WaitForSeconds(animationDuration);
        _agent.isStopped = false;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public virtual void ExitState() { }
}
