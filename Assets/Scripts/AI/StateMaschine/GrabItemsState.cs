using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrabItemsState : BaseState
{
    private Product _itemToGrab;
    private Shelf _shelf;

    public GrabItemsState(Product itemToGrab, StateMachine stateMachine, NavMeshAgent agent) : base(stateMachine, agent)
    {
        _itemToGrab = itemToGrab;
    }

    public override void EnterState()
    {
        Debug.Log("from GrabState");
    }

    public override void UpdateState()
    {
        if (_stateMachine is CustomerStateMachine)
        {
            CustomerStateMachine customerStateMachine = (CustomerStateMachine)_stateMachine;
            customerStateMachine.Customer.GrabProduct();
            _stateMachine.ActivateNextState(this);
        }
    }

    public override void ExitState()
    {
    }  
}
