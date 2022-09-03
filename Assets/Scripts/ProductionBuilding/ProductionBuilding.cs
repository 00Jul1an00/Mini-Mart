using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ProductionBuilding : ProductsObjectPool
{
    [SerializeField] private int _slotCost;
    [SerializeField] private int _costMultiplair;

    [SerializeField] private SlotTriggerChecker _triggerCheker;
    [SerializeField] private Product _requaireProductForProduction;

    private int _activeSlotsForProduction = 2;
    private WaitForSeconds _delayForProduce;
 
    public Product RequaireProductForProduction => _requaireProductForProduction;

    private void Start()
    {
        Init();
        _delayForProduce = new WaitForSeconds(ProductType.DelayForProduce);
        StartCoroutine(ProduceProduct());
    }

    private void OnEnable()
    {
        _triggerCheker.PlayerEnteredInTrigger += OnPlayerEnterInTrigger;
    }

    private void OnDisable()
    {
        _triggerCheker.PlayerEnteredInTrigger -= OnPlayerEnterInTrigger;
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



    //Покупка слотов для производства, зависим от скрипта Money
    private void BuySlotForProduction()
    {
        if(Money.PlayerMoney >= _slotCost)
        {
            Money.SpendMoney(_slotCost);
            _slotCost *= _costMultiplair;
        }
    }

    private void OnPlayerEnterInTrigger()
    {
        BuySlotForProduction();
    }
}
