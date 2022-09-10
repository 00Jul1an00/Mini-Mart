using UnityEngine;

public class PortersStateMachine : StateMachine
{
    public Porter Porter { get; private set; }

    private void Start()
    {
        Porter = GetComponent<Porter>();
        _agent.Speed = Porter.Speed;

        SetStates();

        _currentState = _states[0];
        _currentState.EnterState();
    }

    private void SetStates()
    {
        ProductsObjectPool firstPoint = null;
        ProductsObjectPool secondPoint = null;

        if (Porter.IsProductionToShelf)
        {
            firstPoint = GameManager.Instance.ProductionBuildings[Porter.ProductType];
            secondPoint = GameManager.Instance.Shelfs[Porter.ProductType];
        }
        else
        {
            firstPoint = GameManager.Instance.ProductionBuildings[Porter.ProductType];
            secondPoint = GameManager.Instance.RequireProductContainer[Porter.ProductType];
        }

        _states.Add(new MoveToShelfState(firstPoint.transform, _agent, this));
        _states.Add(new GrabItemsState(_agent, firstPoint, this));
        _states.Add(new MoveToShelfState(secondPoint.transform, _agent, this));
        _states.Add(new PutItemState(_agent, secondPoint, this));
    }
}
