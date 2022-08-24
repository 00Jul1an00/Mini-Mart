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
        foreach(var p in _productsOnShelf)
            AddProduct();
    }

    public void AddProduct()
    {
        if(Index < _productsOnShelf.Count)
            SetActiveStatusForProduct(true);
    }

    public void RemoveProduct()
    {
        if (Index > 0)
            SetActiveStatusForProduct(false);
        else
            print("false");
    }
}
