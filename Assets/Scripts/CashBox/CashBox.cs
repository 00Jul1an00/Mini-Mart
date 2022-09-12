using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CashPool))]
public class CashBox : MonoBehaviour
{
    [SerializeField] private GameObject _playerZone;
    [SerializeField] private SlotTriggerChecker _slotTriggerChecker;
    [SerializeField] private Cashier _cashier;
    [SerializeField] private float _cashierCost;
    [SerializeField] private Transform _positionForCashier;

    public Transform CashTransform;

    public bool CanBeServed { get; private set; }
    public float TimeToServe { get; private set; } = 3f;

    private bool _cashierIsBought;
    private float _moneyTakeDistance = 3f;
    private CashPool _cashPool;

    public int CashBoxMoney { get; private set; } = 0;

    private void Start()
    {
        CashTransform = GetComponent<Transform>();
        _cashPool = GetComponent<CashPool>();
    }

    private void Update()
    {
        TakeMoney();
        print(CashBoxMoney + " " + Money.PlayerMoney);
        print(CanBeServed);
    }

    private void OnEnable() => _slotTriggerChecker.PlayerEnteredInTrigger += OnPlayerEnterInTrigger;

    private void OnDisable() => _slotTriggerChecker.PlayerEnteredInTrigger -= OnPlayerEnterInTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(!_cashierIsBought)
        {
            if (other.TryGetComponent(out PlayerMover player))
                CanBeServed = true;
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if(!_cashierIsBought)
        {
            if (other.TryGetComponent(out PlayerMover player))
                CanBeServed = false;
        } 
    }

    private void TakeMoney()
    {
        float distance = (PlayerMover.PlayerTransform.position - CashTransform.position).magnitude;
        if (distance < _moneyTakeDistance)
        {
            Money.AddMoney(CashBoxMoney);
            CashBoxMoney = 0;
            _cashPool.DisableCash();
        }       
    }

    private void OnPlayerEnterInTrigger()
    {
        if(_cashierCost < Money.PlayerMoney)
        {
            Destroy(_slotTriggerChecker.gameObject);
            Instantiate(_cashier, _positionForCashier.position, Quaternion.identity, transform);
            _cashierIsBought = true;
            CanBeServed = true;
            TimeToServe /= 2;
        } 
    }

    public void MoneySetter(int money, object objectChanger)
    {
        if (objectChanger is Customer && money > 0)
        {
            CashBoxMoney += money;
            _cashPool.RenderCash();
        }
    }

}
