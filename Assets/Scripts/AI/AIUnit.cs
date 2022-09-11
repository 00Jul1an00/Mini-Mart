using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIUnit : MonoBehaviour
{
    public float Speed { get { return _agent.speed; } set { _agent.speed = value; } }
    public bool isStopped { get { return _agent.isStopped; } set { _agent.isStopped = value; } }
    public float remainingDistance { get { return _agent.remainingDistance; } }

    [SerializeField] private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        AIManager.Instance.Units.Add(this);
    }

    public void MoveTo(Vector3 pos)
    {
        _agent.SetDestination(pos);
    }
}
