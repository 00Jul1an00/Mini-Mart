using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PutItemState : BaseState
{
    private ProductsObjectPool _productContainer;
    private Porter _porter;

    public PutItemState(AIUnit agent, ProductsObjectPool productContainer, PortersStateMachine stateMachine) : base(stateMachine, agent) 
    {
        _productContainer = productContainer;
        _porter = stateMachine.Porter;
    }

    public override void EnterState()
    {
    }

    public override void UpdateState()
    {
        bool canPut = false;

        for(int i = 0; i < _porter.InventoryCapacity; i++)
        {
            if (_productContainer.CanAddProduct && _porter.CanPutProduct)
            {
                _porter.PutProduct();
                _productContainer.AddProduct();
                canPut = true;
            }
        }

        if(canPut)
            _stateMachine.ActivateNextState();
    }

    public override void ExitState()
    {
    }
}
