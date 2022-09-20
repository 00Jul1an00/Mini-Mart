using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porter : Worker, IIncreaseInventory
{
    [SerializeField] private Product _productType;
    [SerializeField] private int _inventoryCapacity;
    [SerializeField] private bool _isProductionToShelf;
    [SerializeField] private GameObject _holdZone;
    [SerializeField] private float _speedIncreaseOn;
    public bool CanTakeProduct { get { return _inventoryStack.Count < _inventoryCapacity; } private set { } }
    public bool CanPutProduct { get { return _inventoryStack.Count > 0; } private set { } }
    public  bool IsProductionToShelf => _isProductionToShelf;
    public Product ProductType => _productType;
    public int InventoryCapacity => _inventoryCapacity;

    private Stack<Product> _inventoryStack = new();
    private AIUnit _unit;

    private void Start()
    {
        _unit = GetComponent<AIUnit>();
    }

    public void TakeProduct()
    {
        if (CanTakeProduct)
        {
            _inventoryStack.Push(_productType);
        }
    }

    public void PutProduct()
    {
        if (CanPutProduct)
            _inventoryStack.Pop();
    }

    public void IncreaseSpeed()
    {
        _unit.Speed += _speedIncreaseOn;
    }

    public void IncreseInventory()
    {
        _inventoryCapacity++;
    }
}
