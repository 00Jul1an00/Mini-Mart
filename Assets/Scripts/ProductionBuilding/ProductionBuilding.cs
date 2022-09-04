using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ProductionBuilding : ProductsObjectPool
{
    [SerializeField] private int _slotCost;
    [SerializeField] private int _costMultiplair;

    [SerializeField] private SlotTriggerChecker _triggerChecker;
    [SerializeField] private ContainerForProductionBuilding _containerForRequireProduct;

    private int _activeSlotsForProduction = 2;
    private WaitForSeconds _delayForProduce;

    public ContainerForProductionBuilding ContainerForRequireProduct => _containerForRequireProduct;
    public Product RequaireProductForProduction => _containerForRequireProduct.ProductType;

    private void Start()
    {
        Init();
        _delayForProduce = new WaitForSeconds(ProductType.DelayForProduce);
        StartCoroutine(ProduceProduct());
    }

    private void OnEnable()
    {
        _triggerChecker.PlayerEnteredInTrigger += OnPlayerEnterInTrigger;
    }

    private void OnDisable()
    {
        _triggerChecker.PlayerEnteredInTrigger -= OnPlayerEnterInTrigger;
    }

    private IEnumerator ProduceProduct()
    {
        while (true)
        {
            yield return _delayForProduce;

            if (Index >= _activeSlotsForProduction)
                continue;

            if (RequaireProductForProduction != null && RequaireProductForProduction.gameObject.activeSelf)
            {
                if (_containerForRequireProduct.ProductsInContainerQuantity > 0)
                {
                    _containerForRequireProduct.TryRemoveProduct();
                    TryAddProduct();
                }
            }
            else
            {
                TryAddProduct();
            }            
        }
    }


    //Покупка слотов для производства, зависим от скрипта Money
    private void BuySlotForProduction()
    {
        if (Money.PlayerMoney >= _slotCost)
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
