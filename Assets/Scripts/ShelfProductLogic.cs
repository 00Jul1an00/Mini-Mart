using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfProductLogic : ProductsObjectPool
{
    [SerializeField] private Transform _navMeshWayPoint;

    public Transform NavMeshWayPoint => _navMeshWayPoint;

    private void Start()
    {
        Init();
    }
}
