using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public abstract class StateMachine : MonoBehaviour
{
    [SerializeField] protected AIUnit _agent;

    protected List<BaseState> _states = new();
    protected BaseState _currentState;

    private int _index = 0;

    private void Update()
    {
        _currentState.UpdateState();
    }

    public void ActivateNextState()
    {
        if (_index < _states.Count - 1)
            _index++;
        else
            _index = 0;

        _currentState.ExitState();
        _currentState = _states[_index];
        _currentState.EnterState();
    }
}
