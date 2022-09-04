using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashBox : MonoBehaviour
{
    [SerializeField] private GameObject _playerZone;
    public Transform CashTransform;
    private float _moneyTakeDistance = 2f;
    private bool _isCashierBought;
    public static int CashBoxMoney { get; private set; } = 0;
    private bool _isCustomerServed;

    private void Start()
    {
        CashTransform = GetComponent<Transform>();
    }
    private IEnumerator ServingClient()
    {
        yield return new WaitForSeconds(3);
    }
    private void Update()
    {
        TakeMoney();
        
    }
    private bool OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
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
        if (objectChanger is MoveToCashBoxState && money > 0)
        {
            CashBoxMoney += money;
        }
    }

    private void TakeMoney()
    {
        float distance = (PlayerMover.PlayerTransform.position - CashTransform.position).magnitude;
        if (distance < _moneyTakeDistance)
        {
            Money.AddMoney(CashBoxMoney);
            CashBoxMoney = 0;
            
        }    
        
    }

    

    
}
