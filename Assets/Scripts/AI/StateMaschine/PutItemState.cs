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
        Debug.Log("From PutItem State");
    }

    public override void UpdateState()
    {
        for(int i = 0; i < _porter.InventoryCapacity; i++)
        {
            if (_shelf.TryAddProduct())
            {
                _porter.PutProduct();
            }
        }

        _stateMachine.ActivateNextState(this);
    }

    public override void ExitState()
    {
    }
}
