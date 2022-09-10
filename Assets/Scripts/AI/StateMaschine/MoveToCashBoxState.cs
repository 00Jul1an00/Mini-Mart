using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToCashBoxState : MoveToTargetBaseState
{
    private CashBox _cashBox;
    private Customer _customer;
    private bool _isCalled = true;

    public MoveToCashBoxState(Transform target, ObstacleAgent agent, CustomerStateMachine stateMachine, CashBox cashBox) : base(target, agent, stateMachine) 
    {
        _customer = stateMachine.Customer;
        _cashBox = cashBox;
    }

    public override void EnterState()
    {
        _agent.SetDestionation(_target.position);
    }

    public override void UpdateState()
    {
        if (_agent.IsReachedDestination && _isCalled)
        {
            _stateMachine.StartCoroutine(DelayBetweenStates(1));
            _isCalled = false;
        }
    }

    public override void ExitState()
    {
        _customer.PayForProducts(_cashBox);
        _stateMachine.StopCoroutine(DelayBetweenStates(1));
    }

    protected override IEnumerator DelayBetweenStates(float animationDuration)
    {
        yield return base.DelayBetweenStates(animationDuration);
        _stateMachine.ActivateNextState();
    }
}
