using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//сделать абстрактным и додумать логику наследования
public class PlayerInteracter : MonoBehaviour
{
    [SerializeField] private float _animationDuration = 2f;

    protected Action _action;

    private ProductsObjectPool _building;
    private Coroutine _coroutine;

    private void Start()
    {
        _building = GetComponent<ProductsObjectPool>();

        //For test
        _action = _building.RemoveProduct;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out PlayerMover player))
        {       
            _coroutine = StartCoroutine(WaitForAnimationEnd(player, _building.CanRemoveProduct));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMover player))
        {
            print("exit");
            StopCoroutine(_coroutine);
        }
    }

    protected IEnumerator WaitForAnimationEnd(PlayerMover player, bool condition)
    {
        while (condition && player.CanTakeProduct)
        {
            yield return new WaitForSeconds(_animationDuration);
            print("enter");
            _action();
            player.TakeProduct(_building.ProductType);
            
        }
    }
}
