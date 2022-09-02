using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrabItemsState : BaseState
{
    private readonly ShelfProductLogic _shelf;
    private readonly ProductionBuilding _productionBuilding;

    public GrabItemsState(NavMeshAgent agent, ProductsObjectPool productLocation, StateMachine stateMachine) : base(stateMachine, agent)
    {
        if(productLocation is ShelfProductLogic shelf)
            _shelf = shelf;
        else if(productLocation is ProductionBuilding building)
            _productionBuilding = building;
    }

    public override void EnterState()
    {
    }

    public override void UpdateState()
    {
        if (_stateMachine is CustomerStateMachine customerStateMachine)
        {   
            if(_shelf.CanRemoveProduct)
            {
                _shelf.TryRemoveProduct();
                customerStateMachine.Customer.GrabProduct();
                _stateMachine.ActivateNextState();
            }
        }
        else if (_stateMachine is PortersStateMachine portersStateMachine)
        {
            bool isGrabed = false;

            for (int i = 0; i < portersStateMachine.Porter.InventoryCapacity; i++)
            {
                if (_productionBuilding.CanRemoveProduct && portersStateMachine.Porter.CanTakeProduct)
                {
                    _productionBuilding.TryRemoveProduct();
                    portersStateMachine.Porter.TryTakeProduct();
                    isGrabed = true;
                }
                else if(!portersStateMachine.Porter.CanTakeProduct)
                {
                    isGrabed = true;
                }
            }

            if(isGrabed)
                _stateMachine.ActivateNextState();
        }
    }

    public override void ExitState()
    {
    }
}
