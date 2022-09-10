using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private int _wishListMaxCapacity;

    private int _wishListCapacity;
    private List<Product> _inventoryList = new List<Product>();
    private List<Product> _wishList = new List<Product>();

    public IReadOnlyList<Product> WishList { get; private set; }
   
    public void Init(object sender)
    {
        if(sender is CustomerSpawner)
        {
            _wishListCapacity = Random.Range(1, _wishListMaxCapacity);
            RandomWishList();
            WishList = _wishList;
        }
        else
        {
            throw new System.Exception("Called not from spawner");
        }
        
    }

    public void GrabProduct()
    {
        if(_wishList.Count > 0)
        {
            Product product = _wishList[0];
            _inventoryList.Add(product);
            _wishList.Remove(product);
        }
        else
        {
            throw new System.Exception("WishList is Empty");
        }
    }

    public void PayForProducts(CashBox cashBox)
    {
        int sum = 0;

        foreach (var product in _inventoryList)
            sum += product.Cost;

        cashBox.MoneySetter(sum, this);
    }

    private void RandomWishList()
    {
        for (int i = 0; i < _wishListCapacity; i++)
        {
            while(true)
            {
                int randomNum = Random.Range(0, GameManager.Instance.Products.Count);
                Product product = GameManager.Instance.Products[randomNum];

                if (product.IsAvailable)
                {
                    _wishList.Add(product);
                    break;
                }
            }
        }
    }
}
