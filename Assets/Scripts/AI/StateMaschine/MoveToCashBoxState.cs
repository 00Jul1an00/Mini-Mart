using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToCashBoxState : MoveToTargetBaseState
{
    private CashBox _cashBox;
    private Customer _customer;
    private bool _isNotYetCalled = true;

    public MoveToCashBoxState(Transform target, AIUnit agent, CustomerStateMachine stateMachine, CashBox cashBox) : base(target, agent, stateMachine) 
    {
        _customer = stateMachine.Customer;
        _cashBox = cashBox;
    }

    public override void EnterState()
    {
        AIManager.Instance.MakeAgentsCircleTarget(_target.transform, _agent);
    }

    public override void UpdateState()
    {
        if (CheckDistance() && _isNotYetCalled && _cashBox.CanBeServed)
        {
            _stateMachine.StartCoroutine(DelayBetweenStates(_cashBox.TimeToServe));
            _isNotYetCalled = false;
        }
    }

    public override void ExitState()
    {
        _customer.PayForProducts(_cashBox);
        _stateMachine.StopCoroutine(DelayBetweenStates(_cashBox.TimeToServe));
    }

    protected override IEnumerator DelayBetweenStates(float animationDuration)
    {
        yield return base.DelayBetweenStates(animationDuration);
        
        if (!_cashBox.CanBeServed)
        {
            _isNotYetCalled = true;
            yield break;
        }

        _stateMachine.ActivateNextState();
    }
}
