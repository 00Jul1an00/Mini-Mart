using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porter : Worker
{
    [SerializeField] private Product _productType;
    [SerializeField] private int _inventoryCapacity;
    [SerializeField] private bool _isProductionToShelf;
    [SerializeField] private GameObject _holdZone;

    public bool CanTakeProduct { get { return _inventoryStack.Count < _inventoryCapacity; } private set { } }
    public bool CanPutProduct { get { return _inventoryStack.Count > 0; } private set { } }
    public  bool IsProductionToShelf => _isProductionToShelf;
    public Product ProductType => _productType;
    public int InventoryCapacity => _inventoryCapacity;

    private Stack<Product> _inventoryStack = new();

    public void TakeProduct()
    {
        if (CanTakeProduct)
        {
            _inventoryStack.Push(_productType);
            //ProductInteraction.TakeProduct(_productType, _holdZone);
        }
    }

    public void PutProduct()
    {
        if (CanPutProduct)
            _inventoryStack.Pop();
    }
}
