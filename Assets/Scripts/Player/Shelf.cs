using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shelf : MonoBehaviour
{
    [SerializeField] private GameObject _spendZone;
    [SerializeField] private int ShelfCost;
    private bool _isShelfBought;

    private event UnityAction<int> MoneyChanged;

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out PlayerMover player) && Money.PlayerMoney >= ShelfCost)
        {
            Money.SpendMoney(ShelfCost);
            print(Money.PlayerMoney);
        }
        else
        {
            print("У вас не хватает денег!");
        }


            

        

    }
}
