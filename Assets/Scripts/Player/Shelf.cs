using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shelf : MonoBehaviour
{
    [SerializeField] private GameObject _spendZone;
    [SerializeField] private int ShelfCost;

    private event UnityAction<int> MoneyChanged;

    private void Start()
    {
        
    }
    private void Update()
    {
        OnTriggerEnter(_spendZone.)
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out PlayerMover player) && Money.PlayerMoney >= ShelfCost)
        {
            print("работает");
        }
            

        

    }
}
