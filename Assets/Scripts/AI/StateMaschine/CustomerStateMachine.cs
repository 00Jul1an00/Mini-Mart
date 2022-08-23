using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerStateMachine : StateMachine
{
    [SerializeField] private Transform _shelfPos;
    [SerializeField] private Transform _cashBoxPos;
    [SerializeField] private Transform _exitPos;
    public Customer Customer { get; private set; }

    private ProductSO _itemToGrab;

    private void Awake()
    {
        Customer = GetComponent<Customer>();
        _itemToGrab = Customer._debugProduct;

        _states = new List<BaseState>()
        {
            new MoveToShelfState(_shelfPos, _agent, this),
            new GrabItemsState(_itemToGrab, this, _agent),
            new MoveToCashBoxState(_cashBoxPos, _agent, this),
            new MoveToExitState(_exitPos, _agent, this)
        };
    }

    private void FillStatesList()
    {

    }
}
