using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseState
{
    protected StateMachine _stateMachine;
    protected ObstacleAgent _agent;

    public BaseState(StateMachine stateMachine, ObstacleAgent agent)
    {
        _stateMachine = stateMachine;
        _agent = agent;
    }

    protected virtual IEnumerator DelayBetweenStates(float animationDuration)
    {
        _agent.StopAgent();
        yield return new WaitForSeconds(animationDuration);
        _agent.ResumeAgent();
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public virtual void ExitState() { }
}
