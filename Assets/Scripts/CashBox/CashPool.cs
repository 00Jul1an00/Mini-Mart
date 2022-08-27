using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CashPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private bool AutoExpand;
    [SerializeField] private Transform _container;
    private int _currentCashCount = 0;
    private List<GameObject> _pool;

    public CashPool (GameObject prefab, int count, Transform container)
    {
        _prefab = prefab;
        _container = container;
        CreatePool(count);
    }

    private void Start()
    {
        CreatePool(20);
        _container.position = new Vector3(3.3f, 0.5346045f, -38.33943f);
    }
    private void Update()
    {
        RenderCash();
    }

    private void CreatePool(int count)
    {
        _pool = new List<GameObject>();
        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private GameObject CreateObject(bool isActiveOnStart = false)
    {
        var createdObject = UnityEngine.Object.Instantiate(_prefab, _container);
        createdObject.transform.position = _container.position;
        createdObject.SetActive(isActiveOnStart); 
        _pool.Add(createdObject); ;
        return createdObject;
    }

    private bool HasFreeElement(out GameObject element)
    {
        foreach (var obj in _pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                element = obj;
                obj.gameObject.SetActive(true);
                return true;
            }
        }
        element = null;
        return false;
    }

    private GameObject GetFreeElement()
    {
        if(HasFreeElement(out var element))
        {
            return element;
        }

        if(AutoExpand)
        {
            return CreateObject(true);
        }
        else
        {
            throw new Exception("Нема");
        }

    }

    private void RenderCash()
    {      
        if (_currentCashCount < CashBox.CashBoxMoney)
        {
            if (_currentCashCount % 50 == 0)
            {

            }
            GetFreeElement();
            _currentCashCount += 10;
        }
    }
}
