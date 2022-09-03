using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class ProductsObjectPool : MonoBehaviour
{
    [SerializeField] protected Product _productType;
    [SerializeField] private Transform[] _spawnPoints;

    public bool CanAddProduct { get { return Index < _productsInObjectPool.Count; } private set { } }
    public bool CanRemoveProduct { get { return Index > 0; } private set { } }

    protected List<Product> _productsInObjectPool = new();
    protected int Index { get; private set; }

    public Product ProductType => _productType;

    protected void Init()
    {
        int capacity = _spawnPoints.Length;

        for(int i = 0; i < capacity; i++)
        {
            Product product = Instantiate(_productType, _spawnPoints[i].position, Quaternion.identity, transform);
            product.gameObject.SetActive(false);
            _productsInObjectPool.Add(product);
        }
    }

    protected void SetActiveStatusForProduct(bool status)
    {
        if(!status)
            Index--;

        _productsInObjectPool[Index].gameObject.SetActive(status);
        
        if (status)
            Index++; 
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
