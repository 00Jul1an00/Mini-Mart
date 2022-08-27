using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ProductionBuilding : ProductsObjectPool
{
    public bool CanRemoveProduct { get { return Index > 0; } private set { } }

    private WaitForSeconds _delayForProduce;

    private int _activeSlotsForProduction = 2;


    private void Start()
    {
        Init();
        _delayForProduce = new WaitForSeconds(ProductType.DelayForProduce);
        StartCoroutine(ProduceProduct());
    }

    private IEnumerator ProduceProduct()
    {
        while (true)
        {
            
            yield return _delayForProduce;

            if (Index < _activeSlotsForProduction)
                SetActiveStatusForProduct(true);

        }
        
    }

    public void TryRemoveProduct()
    {
        if (CanRemoveProduct)
            SetActiveStatusForProduct(false);
    }

    private void BuySlotForProduction()
    {

    }

}
