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
    }

    public override void UpdateState()
    {
        if (_stateMachine is CustomerStateMachine customerStateMachine)
        {   
            if(_shelf.TryRemoveProduct())
            {
                customerStateMachine.Customer.GrabProduct();
                _stateMachine.ActivateNextState(this);
            }
        }
        else if (_stateMachine is PortersStateMachine portersStateMachine)
        {
            bool isGrabed = false;

            for (int i = 0; i < portersStateMachine.Porter.InventoryCapacity; i++)
            {
                if (_shelf.TryRemoveProduct())
                {
                    portersStateMachine.Porter.PutProduct();
                    isGrabed = true;
                }
            }

            if(isGrabed)
                _stateMachine.ActivateNextState(this);
        }
    }

    public override void ExitState()
    {
    }
}
