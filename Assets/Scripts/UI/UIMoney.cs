using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMoney : MonoBehaviour
{
    private TMP_Text _moneyText;
    void Start()
    {
        _moneyText = GetComponent<TMP_Text>();
        _moneyText.text = Money.PlayerMoney.ToString();
    }

    private void OnEnable()
    {
        Money.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        Money.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _moneyText.text = money.ToString();
    }
}
