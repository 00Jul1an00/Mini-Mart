using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrabItemsState : BaseState
{
    private ShelfProductLogic _shelf;

    public GrabItemsState(NavMeshAgent agent, ShelfProductLogic shelf, StateMachine stateMachine) : base(stateMachine, agent)
    {
        _shelf = shelf;
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
            _shelf.RemoveProduct();
            _stateMachine.ActivateNextState(this);
        }
    }

    public override void ExitState()
    {
    }  
}
