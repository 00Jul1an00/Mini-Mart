using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porter : Worker
{
    [SerializeField] private Product _productType;
    [SerializeField] private int _inventoryCapacity;

    public int InventoryCapacity => _inventoryCapacity;

    private Stack<Product> _inventoryStack = new();

    public void TakeProuduct()
    {
        if (_inventoryStack.Count <= _inventoryCapacity)
            _inventoryStack.Push(_productType);
    }

    public void PutProduct()
    {
        if (_inventoryStack.Count > 0)
            _inventoryStack.Pop();
    }
}
