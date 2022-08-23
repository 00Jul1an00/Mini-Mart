using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItemsState : BaseState
{
    public override void EnterState(StateMachine stateMachine)
    {
        Debug.Log("from GrabState");
    }

    public override void ExitState(StateMachine stateMachine)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        throw new System.NotImplementedException();
    }
}
