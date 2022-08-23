using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerStateMachine : StateMachine
{
    [SerializeField] private Transform _shelfPos;
    [SerializeField] private Transform _cashBoxPos;
    [SerializeField] private Transform _exitPos;

    private void Awake()
    {
        _states = new List<BaseState>()
        {
            new MoveToShelfState(_shelfPos, _agent),
            new GrabItemsState(),
            new MoveToCashBoxState(_cashBoxPos, _agent),
            new MoveToExitState(_exitPos, _agent)
        };
    }
}
