using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] public ProductSO _debugProduct;
    [SerializeField] private int _wishListMaxCapacity;

    private int _wishListCapacity;
    private List<ProductSO> _inventoryList = new List<ProductSO>();
    private List<ProductSO> _wishList = new List<ProductSO>();

    private void Start()
    {
        _wishListCapacity = Random.Range(1, _wishListMaxCapacity);
        RandomWishList();
    }

    public void GrabProduct()
    {
        ProductSO product = _wishList[0];
        _inventoryList.Add(product);
        _wishList.Remove(product);
        //print(_inventoryList[0]);
        //print(_wishList.Count);
    }

    //%
    public bool TryGrabProduct()
    {
        return true;
    }

    private void RandomWishList()
    {
        for(int i = 0; i < _wishListCapacity; i++)
        {
            
            _wishList[i] = new ProductSO();
        }
    }
}
