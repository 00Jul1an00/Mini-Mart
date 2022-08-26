using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashBox : MonoBehaviour
{
    [SerializeField] private GameObject _playerZone;
    public Transform CashTransform;
    private Vector3 _moneyTakeDistance = new Vector3(2,0,2);
    private bool _isCashierBought;
    public int Money { get; private set; }
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
        print(_isCustomerServed);
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
            Money += money;
        }
    }

    private void TakeMoney()
    {
        //if(Vector3.Distance(PlayerMover.PlayerTransform.position, CashTransform.position) < _moneyTakeDistance)
        //{

        //}

        
    }

    

    
}
