using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public abstract class StateMachine : MonoBehaviour
{ 
    [SerializeField] protected NavMeshAgent _agent;

    protected List<BaseState> _states;
    protected BaseState _currentState;

    private int _index;

    private void Start()
    {   
        _index = 0;
        _currentState = _states[_index];
        _currentState.EnterState();
    }

    private void Update()
    {
        _currentState.UpdateState();
    }

    public void ActivateNextState(object sender)
    {
        if (sender is BaseState)
        {
            if (_index < _states.Count)
                _index++;
            else
                _index = 0;

            _currentState.ExitState();            
            _currentState = _states[_index];
            _currentState.EnterState();
        }
        else
        {
            throw new Exception();
        }    
    }
}
