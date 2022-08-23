using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerStateMachine : StateMachine
{
    [SerializeField] private Transform _cashBoxPos;
    [SerializeField] private Transform _exitPos;
    
    private ShelfProductLogic[] _shelfs;

    public Customer Customer { get; private set; }

    private void Start()
    {
        _shelfs = FindObjectsOfType<ShelfProductLogic>();
        Customer = GetComponent<Customer>();
        FillStatesList();
        _states.Add(new MoveToCashBoxState(_cashBoxPos, _agent, this));
        _states.Add(new MoveToExitState(_exitPos, _agent, this));

        _currentState = _states[0];
        _currentState.EnterState();
    }

    private void FillStatesList()
    {
        _states = new List<BaseState>();
        foreach (var item in Customer.WishList)
        {
            foreach (var shelf in _shelfs)
            {
                if(item == shelf.ProductType)
                {
                    _states.Add(new MoveToShelfState(shelf.NavMeshWayPoint, _agent, this));
                    _states.Add(new GrabItemsState(_agent, shelf,this));
                    break;
                }
            }
        }
        
    }
}
