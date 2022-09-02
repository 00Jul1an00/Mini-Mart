using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PutItemState : BaseState
{
    private ShelfProductLogic _shelf;
    private Porter _porter;

    public PutItemState(NavMeshAgent agent, ShelfProductLogic shelf, PortersStateMachine stateMachine) : base(stateMachine, agent) 
    {
        _shelf = shelf;
        _porter = stateMachine.Porter;
    }

    public override void EnterState()
    {
    }

    public override void UpdateState()
    {
        for(int i = 0; i < _porter.InventoryCapacity; i++)
        {
            if (_shelf.CanAddProduct && _porter.CanPutProduct)
            {
                _porter.TryPutProduct();
                _shelf.TryAddProduct();
            }
        }

        _stateMachine.ActivateNextState();
    }

    public override void ExitState()
    {
    }
}
