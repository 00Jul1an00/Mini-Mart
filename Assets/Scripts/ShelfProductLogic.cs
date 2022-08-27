using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfProductLogic : ProductsObjectPool
{
    [SerializeField] private Transform _navMeshWayPoint;

    public Transform NavMeshWayPoint => _navMeshWayPoint;
    public bool CanAddProduct { get { return Index < _productsInObjectPool.Count; } private set { } }
    public bool CanRemoveProduct { get { return Index > 0; } private set { } }


    private void Start()
    {
        Init();
    }

    public void TryAddProduct()
    {
        if (CanAddProduct)
            SetActiveStatusForProduct(true);
    }

    public void TryRemoveProduct()
    {
        if (CanRemoveProduct)
            SetActiveStatusForProduct(false);
    }
}
