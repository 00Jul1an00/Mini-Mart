using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ProductionBuilding : ProductsObjectPool
{
    [SerializeField] private int _slotCost;
    [SerializeField] private int _costMultiplair;

    [SerializeField] private ContainerForProductionBuilding _containerForRequireProduct;

    private SlotTriggerChecker _triggerChecker;
    private SlotTriggerChecker[] _triggerCheckers;
    private int _activeSlotsForProduction = 2;
    private WaitForSeconds _delayForProduce;   

    public ContainerForProductionBuilding ContainerForRequireProduct => _containerForRequireProduct;
    public Product RequaireProductForProduction => _containerForRequireProduct.ProductType;

    private void Start()
    {
        Init();
        _delayForProduce = new WaitForSeconds(ProductType.DelayForProduce);
        _triggerCheckers = SetStartStatusToSlots();      
    }

    private void OnEnable()
    {
        StartCoroutine(ProduceProduct());
    }

    private SlotTriggerChecker[] SetStartStatusToSlots()
    {
        SlotTriggerChecker[] triggers = GetComponentsInChildren<SlotTriggerChecker>();

        foreach (var trigger in triggers)
            trigger.gameObject.SetActive(false);

        for (int i = 0; i < _activeSlotsForProduction; i++)
        {
            Destroy(triggers[i].gameObject);
        }

        _triggerChecker = triggers[_activeSlotsForProduction];
        _triggerChecker.gameObject.SetActive(true);
        _triggerChecker.PlayerEnteredInTrigger += OnPlayerEnterInTrigger;

        return triggers;
    }

    private IEnumerator ProduceProduct()
    {
        while (true)
        {
            yield return _delayForProduce;

            if (Index >= _activeSlotsForProduction)
                continue;

            if (RequaireProductForProduction != null)
            {
                if (_containerForRequireProduct.ProductsInContainerQuantity > 0)
                {
                    _containerForRequireProduct.RemoveProduct();
                    AddProduct();
                }
            }
            else
            {
                AddProduct();
            }            
        }
    }


    //Покупка слотов для производства, зависим от скрипта Money
    private void BuySlotForProduction()
    {
        if (Money.PlayerMoney >= _slotCost)
        {
            _triggerChecker.PlayerEnteredInTrigger -= OnPlayerEnterInTrigger;
            Destroy(_triggerChecker.gameObject);
            Money.SpendMoney(_slotCost);
            _slotCost *= _costMultiplair;
            _activeSlotsForProduction++;

            if (_activeSlotsForProduction < _triggerCheckers.Length)
            {
                _triggerChecker = _triggerCheckers[_activeSlotsForProduction];
                _triggerChecker.gameObject.SetActive(true);
                _triggerChecker.PlayerEnteredInTrigger += OnPlayerEnterInTrigger;
            }
            else
                _triggerCheckers = null;
        }
    }

    private void OnPlayerEnterInTrigger()
    {
        BuySlotForProduction();
    }
}
