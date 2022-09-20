using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInteracter : MonoBehaviour
{
    [SerializeField] protected float _animationDuration = 2f;

    protected ProductsObjectPool _building;
    protected PlayerInventory _player;
    private Coroutine _coroutine;

    private void Start()
    {
        _building = GetComponent<ProductsObjectPool>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerInventory player))
        {
            if(_player == null)
                _player = player;

            _coroutine = StartCoroutine(WaitForAnimationEnd(SetActionsBehaivor()));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerInventory player))
            StopCoroutine(_coroutine);
    }

    protected abstract Tuple<Action, Action<Product>> SetActionsBehaivor();

    protected abstract bool SetConditions();

    private IEnumerator WaitForAnimationEnd(Tuple<Action, Action<Product>> actions)
    {
        while (SetConditions())
        {
            yield return new WaitForSeconds(_animationDuration);
            actions.Item1();
            actions.Item2(_building.ProductType);
        }
    }
}
