using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] public Product _debugProduct;
    [SerializeField] private int _wishListMaxCapacity;

    private int _wishListCapacity;
    private List<Product> _inventoryList = new List<Product>();
    private List<Product> _wishList = new List<Product>();

    private void Start()
    {
        _wishListCapacity = Random.Range(1, _wishListMaxCapacity);
        RandomWishList();
    }

    public void GrabProduct()
    {
        Product product = _wishList[0];
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
            while(true)
            {
                int randomNum = Random.Range(0, GameManager.Instance.AvailableProducts.Count);
                Product product = GameManager.Instance.AvailableProducts[randomNum];

                if (product.IsAvailable)
                {
                    _wishList.Add(product);
                    break;
                }
            }
        }
    }
}
