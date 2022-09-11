using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyProductionBuilding : SlotTriggerChecker
{
    [SerializeField] private ProductionBuilding _productionBuilding;

    private void Start()
    {
        _productionBuilding.gameObject.SetActive(false);
        GameManager.Instance.Shelfs[_productionBuilding.ProductType].gameObject.SetActive(false);
    }

    private void OnEnable() => this.PlayerEnteredInTrigger += OnPlayerEnterInTrigger;

    private void OnDisable() => this.PlayerEnteredInTrigger -= OnPlayerEnterInTrigger;

    private void OnPlayerEnterInTrigger()
    {
        _productionBuilding.gameObject.SetActive(true);
        GameManager.Instance.Shelfs[_productionBuilding.ProductType].gameObject.SetActive(true);
        Destroy(this.gameObject);
    }
}
