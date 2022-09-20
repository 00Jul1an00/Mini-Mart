using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToCashBoxState : MoveToTargetBaseState
{
    private CashBox _cashBox;
    private Customer _customer;
    private bool _isNotYetCalled = true;
    private bool _canBeServed;
    private int _queuePosition;

    public MoveToCashBoxState(Transform target, AIUnit agent, CustomerStateMachine stateMachine, CashBox cashBox) : base(target, agent, stateMachine) 
    {
        _customer = stateMachine.Customer;
        _cashBox = cashBox;
    }

    public override void EnterState()
    {
        for (int i = 0; i < _cashBox.QueuePositions.Count; i++)
        {
            if (_cashBox.QueuePositions[i].IsFree(_agent))
            {
                _agent.MoveTo(_cashBox.QueuePositions[i].position);
                return;
            }
        }
        //danger
        EnterState();
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
