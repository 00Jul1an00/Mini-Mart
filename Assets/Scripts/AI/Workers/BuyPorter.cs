using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPorter : SlotTriggerChecker
{
    [SerializeField] private Porter _porter;
    [SerializeField] private float _cost;

    private void OnEnable()
    {
        _porter.gameObject.SetActive(false);
        this.PlayerEnteredInTrigger += OnPlayerEnteredInTrigger;
    }

    private void OnDisable() => this.PlayerEnteredInTrigger -= OnPlayerEnteredInTrigger;

    private void OnPlayerEnteredInTrigger()
    {
        _porter.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }
}
