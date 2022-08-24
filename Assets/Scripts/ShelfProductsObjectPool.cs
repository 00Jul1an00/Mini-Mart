using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShelfProductsObjectPool : MonoBehaviour
{
    [SerializeField] protected Product _productType;
    [SerializeField] private Transform[] _spawnPoints;

    protected List<Product> _productsOnShelf = new();

    protected int Index { get; private set; } = -1;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        int capacity = _spawnPoints.Length;

        for(int i = 0; i < capacity; i++)
        {
            Product product = Instantiate(_productType, _spawnPoints[i].position, Quaternion.identity, transform);
            product.gameObject.SetActive(false);
            _productsOnShelf.Add(product);
        }
    }

    protected void SetActiveStatusForProduct(bool status)
    {
        if (status)
            Index++;       

            _productsOnShelf[Index].gameObject.SetActive(status);

        if (!status)
            Index--;
    }
}
