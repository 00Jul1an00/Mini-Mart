using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(NavMeshObstacle))]
public class ObstacleAgent : MonoBehaviour
{
    [SerializeField] private float _carvingTime = .5f;
    [SerializeField] private float _carvingMoveThreshold = .1f;

    public bool IsReachedDestination { get; private set; } = false;
    public float Speed { get { return _agent.speed; } set { _agent.speed = value; } }

    private NavMeshAgent _agent;
    private NavMeshObstacle _obstacle;

    private float _lastMoveTime;
    private Vector3 _lastPosition;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _obstacle = GetComponent<NavMeshObstacle>();
        _obstacle.enabled = false;
        _obstacle.carveOnlyStationary = false;
        _obstacle.carving = true;
        _lastPosition = transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(_lastPosition, transform.position) > _carvingMoveThreshold)
        {
            _lastMoveTime = Time.time;
            _lastPosition = transform.position;
        }

        if(_lastMoveTime + _carvingTime < Time.time)
        {
            _agent.enabled = false;
            _obstacle.enabled = true;
        }

        //if (_agent.enabled && _agent.path != null)
        //{            
        //    if (_agent.remainingDistance < .5f)
        //        IsReachedDestination = true;
        //    else
        //        IsReachedDestination = false;
        //}
    }

    private IEnumerator MoveAgent(Vector3 pos)
    {
        _obstacle.enabled = false;
        yield return null;
        _agent.enabled = true;
        _agent.SetDestination(pos);
    }

    private IEnumerator EnableAgent()
    {
        _obstacle.enabled = false;
        yield return null;
        _agent.enabled = true;
        _agent.isStopped = false;
    }

    public void SetDestionation(Vector3 pos)
    {
        
        _lastMoveTime = Time.time;
        _lastPosition = transform.position;
        StartCoroutine(MoveAgent(pos));
    }

    public bool CheckDistance(float distanceToCheck)
    {
        _obstacle.enabled = false;
        StartCoroutine(EnableAgent());
        return _agent.remainingDistance < distanceToCheck;
    }

    public void StopAgent()
    {
        if(_agent.enabled)
            _agent.isStopped = true;
        _agent.enabled = false;
        _obstacle.enabled = true;
    }

    public void ResumeAgent()
    {
        StartCoroutine(EnableAgent());
    }
}
