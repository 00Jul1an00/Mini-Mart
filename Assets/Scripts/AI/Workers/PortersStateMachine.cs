using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortersStateMachine : StateMachine
{
    [SerializeField] private ShelfProductLogic _firstShelf;
    [SerializeField] private ShelfProductLogic _secondShelf;

    public Porter Porter { get; private set; }

    private void Awake()
    {
        Porter = GetComponent<Porter>();
        _agent.speed = Porter.Speed;

        _states.Add(new MoveToShelfState(_firstShelf.transform, _agent, this));
        _states.Add(new GrabItemsState(_agent, _firstShelf, this));
        _states.Add(new MoveToShelfState(_secondShelf.transform, _agent, this));
        _states.Add(new PutItemState(_agent, _secondShelf, this));

        _currentState = _states[0];
        _currentState.EnterState();
    }
}
