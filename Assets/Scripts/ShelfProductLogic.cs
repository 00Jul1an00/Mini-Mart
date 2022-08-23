using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfProductLogic : MonoBehaviour
{
    [SerializeField] private Product _productType;
    [SerializeField] private int _capacity;

    private List<Product> _productsOnShelf;

    public Product ProductType => _productType;
    //public IReadOnlyList<Product> ProductsOnShelf { get; private set; }

    private void Start()
    {
        _productsOnShelf = new List<Product>(_capacity);
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
