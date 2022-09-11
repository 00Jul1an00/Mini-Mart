using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//сделать абстрактным и додумать логику наследования
public class PlayerInteracter : MonoBehaviour
{
    [SerializeField] private float _animationDuration = 1f;
    
    protected Action _action;

    private ProductsObjectPool _building;
    private bool _isNotYetCalled;

    private void Start()
    {
        _building = GetComponent<ProductsObjectPool>();

        //For test
        _action = _building.TryRemoveProduct;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.TryGetComponent(out PlayerMover player) && _isNotYetCalled)
        {
            print("enter");
            _isNotYetCalled = false;
            StartCoroutine(WaitForAnimationEnd(player, _building.CanRemoveProduct));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.TryGetComponent(out PlayerMover player))
        {
            print("exit");
            _isNotYetCalled = true;
            StartCoroutine(WaitForAnimationEnd(player, _building.CanRemoveProduct));
        }
    }

    protected IEnumerator WaitForAnimationEnd(PlayerMover player, bool condition)
    {
        if(condition)
        {
            yield return new WaitForSeconds(_animationDuration);
            _action();
            player.TakeProduct(_building.ProductType);
        }
        
    }
}
