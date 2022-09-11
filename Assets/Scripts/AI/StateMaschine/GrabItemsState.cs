using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrabItemsState : BaseState
{
    private readonly ProductsObjectPool _productContainer;

    public GrabItemsState(AIUnit agent, ProductsObjectPool productContainer, StateMachine stateMachine) : base(stateMachine, agent)
    {
        _productContainer = productContainer;
    }

    public override void EnterState()
    {
    }

    public override void UpdateState()
    {
        if (_stateMachine is CustomerStateMachine customerStateMachine)
        {   
            if(_productContainer.CanRemoveProduct)
            {
                _productContainer.TryRemoveProduct();
                customerStateMachine.Customer.GrabProduct();
                _stateMachine.ActivateNextState();
            }
        }
        else if (_stateMachine is PortersStateMachine portersStateMachine)
        {
            bool isGrabed = false;

            for (int i = 0; i < portersStateMachine.Porter.InventoryCapacity; i++)
            {
                if (_productContainer.CanRemoveProduct && portersStateMachine.Porter.CanTakeProduct)
                {
                    _productContainer.TryRemoveProduct();
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
