using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public abstract class StateMachine : MonoBehaviour
{ 
    [SerializeField] protected NavMeshAgent _agent;

    protected List<BaseState> _states;
    protected BaseState _currentState;

    private void Start()
    {     
        _currentState = _states[0];
        _currentState.EnterState(this);
    }

    private void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SwichState<T>() where T : BaseState
    {
        _currentState.ExitState(this);
        BaseState state = _states.FirstOrDefault(x => x is T);
        _currentState = state;
        _currentState.EnterState(this);
    }
}
