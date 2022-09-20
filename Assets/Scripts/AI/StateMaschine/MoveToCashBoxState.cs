using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToCashBoxState : MoveToTargetBaseState
{
    private CashBox _cashBox;
    private Customer _customer;
    private bool _isNotYetCalled = true;
    private int _posInQueue = -1;

    public MoveToCashBoxState(Transform target, AIUnit agent, CustomerStateMachine stateMachine, CashBox cashBox) : base(target, agent, stateMachine) 
    {
        _customer = stateMachine.Customer;
        _cashBox = cashBox;
    }

    public override void EnterState()
    {
        _posInQueue = _cashBox.PosInQueue;

        if (_cashBox.QueuePositions.Count <= _posInQueue)
            Debug.Log("Queue too big");
        else
            _agent.MoveTo(_cashBox.QueuePositions[_cashBox.PosInQueue++].position);
            
        _cashBox.CustomerWasServed += OnCustomerWasServed;
    }

    protected override bool CheckDistance()
    {
        if (_posInQueue == 0)
        {
            if (Vector3.Distance(_agent.transform.position.normalized, _cashBox.QueuePositions[0].position.normalized) < .03f)
                return true;
        }

        return false;
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
        _cashBox.CustomerWasServed -= OnCustomerWasServed;
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

    private void OnCustomerWasServed()
    {
        if (_posInQueue <= 0)
            return;

        if (_posInQueue >= _cashBox.QueuePositions.Count)
            --_posInQueue;
        else
            _agent.MoveTo(_cashBox.QueuePositions[--_posInQueue].position);
    }
}
