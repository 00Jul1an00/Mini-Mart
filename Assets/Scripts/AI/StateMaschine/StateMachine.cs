using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class StateMachine : MonoBehaviour, ISwichState
{
    [SerializeField] private Transform _target;

    private NavMeshAgent _agent;
    private List<BaseState> _states;
    private BaseState _currentState;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _states = new List<BaseState>()
        {
            new MoveToTargetState(_target, _agent, this)
        };

        _currentState = _states[0];
    }

    private void Update()
    {
        _currentState.StartState();
    }

    public void SwichState<T>() where T : BaseState
    {
        _currentState.StopState();
        var state = _states.FirstOrDefault(x => x is T);
        _currentState = state;
    }
}
