using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfProductLogic : ShelfProductsObjectPool
{
    [SerializeField] private Transform _navMeshWayPoint;

    public Transform NavMeshWayPoint => _navMeshWayPoint;
    public Product ProductType => _productType;

    public bool AddProduct()
    {
        if(Index < _productsOnShelf.Count)
            SetActiveStatusForProduct(true);

        return Index < _productsOnShelf.Count;
    }

    public bool TryRemoveProduct()
    {
        if (Index > 0)
            SetActiveStatusForProduct(false);

        return Index > 0;
    }
}
