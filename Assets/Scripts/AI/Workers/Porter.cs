using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porter : Worker
{
    [SerializeField] private Product _productType;
    [SerializeField] private int _inventoryCapacity;

    public bool CanTakeProduct { get { return _inventoryStack.Count < _inventoryCapacity; } private set { } }
    public bool CanPutProduct { get { return _inventoryStack.Count > 0; } private set { } }

    public Product ProductType => _productType;
    public int InventoryCapacity => _inventoryCapacity;

    private Stack<Product> _inventoryStack = new();

    public void TryTakeProduct()
    {
        if (CanTakeProduct)
            _inventoryStack.Push(_productType);
    }

    public void TryPutProduct()
    {
        if (CanPutProduct)
            _inventoryStack.Pop();
    }
}