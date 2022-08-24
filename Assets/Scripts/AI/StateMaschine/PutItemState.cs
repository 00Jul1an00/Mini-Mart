using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PutItemState : BaseState
{
    private ShelfProductLogic _shelf;

    public PutItemState(NavMeshAgent agent, ShelfProductLogic shelf, StateMachine stateMachine) : base(stateMachine, agent) 
    {
        _shelf = shelf;
    }

    public override void EnterState()
    {
        Debug.Log("from PutState");
    }

    public override void UpdateState()
    {
        
    }
}
