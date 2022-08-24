using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfProductLogic : ShelfProductsObjectPool
{
    [SerializeField] private Transform _navMeshWayPoint;

    public Transform NavMeshWayPoint => _navMeshWayPoint;
    public Product ProductType => _productType;

    private void Start()
    {
    }

    public void AddProduct()
    {
        if(Index < _productsOnShelf.Count)
            SetActiveStatusForProduct(true);
    }

    public bool TryRemoveProduct()
    {
        if (Index > 0)
            SetActiveStatusForProduct(false);

        return Index > 0;
    }
}
