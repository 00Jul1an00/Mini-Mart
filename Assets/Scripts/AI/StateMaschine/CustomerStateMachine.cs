using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerStateMachine : StateMachine
{
    private Transform _cashBoxPos;
    private Transform _exitPos;

    public Customer Customer { get; private set; }

    private void Start()
    {
        _cashBoxPos = FindObjectOfType<CashBox>().transform;
        _exitPos = FindObjectOfType<Exit>().transform;
        Customer = GetComponent<Customer>();

        FillStatesList();
        _states.Add(new MoveToCashBoxState(_cashBoxPos, _agent, this));
        _states.Add(new MoveToExitState(_exitPos, _agent, this));

        _currentState = _states[0];
        _currentState.EnterState();
    }

    private void FillStatesList()
    {
        foreach (var item in Customer.WishList)
        {
            var shelf = GameManager.Instance.Shelfs[item];

            _states.Add(new MoveToShelfState(shelf.transform, _agent, this));
            _states.Add(new GrabItemsState(_agent, shelf, this));
        }       
    }
}
