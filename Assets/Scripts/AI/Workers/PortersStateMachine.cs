public class PortersStateMachine : StateMachine
{
    public Porter Porter { get; private set; }

    private void Start()
    {
        Porter = GetComponent<Porter>();
        _agent.speed = Porter.Speed;

        SetStates();

        _currentState = _states[0];
        _currentState.EnterState();
    }

    private void SetStates()
    {
        var productionBuilding = GameManager.Instance.ProductionBuildings[Porter.ProductType];
        var shelf = GameManager.Instance.Shelfs[Porter.ProductType];

        _states.Add(new MoveToShelfState(productionBuilding.transform, _agent, this));
        _states.Add(new GrabItemsState(_agent, productionBuilding, this));
        _states.Add(new MoveToShelfState(shelf.NavMeshWayPoint, _agent, this));
        _states.Add(new PutItemState(_agent, shelf, this));
    }
}
