using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfProductLogic : MonoBehaviour
{
    [SerializeField] private Product _productType;
    [SerializeField] private int _capacity;
    [SerializeField] private Transform _navMeshWayPoint;

    private List<Product> _productsOnShelf;

    public Transform NavMeshWayPoint => _navMeshWayPoint;
    public int ItemsQuantity { get { return _productsOnShelf.Count; } }
    public Product ProductType => _productType;

    private void Start()
    {
        _productsOnShelf = new List<Product>(_capacity);
        AddProduct();
    }

    public void AddProduct()
    {
        if (_productsOnShelf.Count < _capacity)
            _productsOnShelf.Add(_productType);
    }

    public void RemoveProduct()
    {
        if (_productsOnShelf.Count > 0)
            _productsOnShelf.Remove(_productType);
    }
}
