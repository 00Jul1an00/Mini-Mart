using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkersStateMachine : StateMachine
{
    private Transform _firstPos;
    private Transform _secondPos;

    public Worker Worker { get; private set; }
}
