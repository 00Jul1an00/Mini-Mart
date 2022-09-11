using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CashPool))]
public class CashBox : MonoBehaviour
{
    [SerializeField] private GameObject _playerZone;
    
    public Transform CashTransform;

    private float _moneyTakeDistance = 3f;
    private bool _isCashierBought;
    private bool _isCustomerServed;
    private CashPool _cashPool;

    public static int CashBoxMoney { get; private set; } = 0;

    private void Start()
    {
        CashTransform = GetComponent<Transform>();
        _cashPool = GetComponent<CashPool>();
    }
    private IEnumerator ServingClient()
    {
        yield return new WaitForSeconds(3);
    }
    private void Update()
    {
        TakeMoney();
        print(CashBoxMoney + " " + Money.PlayerMoney);       
    }
    private bool OnTriggerEnter(Collider other) // если шо, коллайдер висит на родителе, а не на дочернем квадрате
    {
        if (other.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            print("работает");
            StartCoroutine(ServingClient());
            return _isCustomerServed = true;           
        }      
        else
        {
            return _isCustomerServed = false;
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
}
