using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyProductionBuilding : SlotTriggerChecker
{
    [SerializeField] private ProductionBuilding _productionBuilding;
    [SerializeField] private float _cost;
    [SerializeField] private List<GameObject> _portersBuyZones;

    private void Start()
    {
        _productionBuilding.gameObject.SetActive(false);
        GameManager.Instance.Shelfs[_productionBuilding.ProductType].gameObject.SetActive(false);

        foreach (var zone in _portersBuyZones)
            zone.gameObject.SetActive(false);
    }

    private void OnEnable() => this.PlayerEnteredInTrigger += OnPlayerEnterInTrigger;

    private void OnDisable() => this.PlayerEnteredInTrigger -= OnPlayerEnterInTrigger;

    private void OnPlayerEnterInTrigger()
    {
        if(_cost < Money.PlayerMoney)
        {
            _productionBuilding.gameObject.SetActive(true);
            GameManager.Instance.Shelfs[_productionBuilding.ProductType].gameObject.SetActive(true);
            GameManager.Instance.ActivateProduct(_productionBuilding.ProductType);

            foreach (var zone in _portersBuyZones)
                zone.gameObject.SetActive(true);

            Destroy(this.gameObject);
        }
    }
}
