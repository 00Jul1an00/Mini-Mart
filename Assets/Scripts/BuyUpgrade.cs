using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuyUpgrade : SlotTriggerChecker
{
    [SerializeField] private GameObject _upgradeTarget;
    [SerializeField] private UnityEvent _upgradeMethod;
    [SerializeField] private float _cost;

    private void OnEnable() => this.PlayerEnteredInTrigger += OnPlayerEnterInTrigger;

    private void OnDisable() => this.PlayerEnteredInTrigger -= OnPlayerEnterInTrigger;

    private void OnPlayerEnterInTrigger()
    {
        if (Money.PlayerMoney >= _cost)
        {
            _upgradeMethod?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
