using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CashPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private bool AutoExpand;
    [SerializeField] private Transform _container;
    private float _posX, _posY, _posZ;
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
        _posX = 3.3f;
        _posY = 0.5346044f;
        _posZ = -38.333f;
        _container.position = new Vector3(_posX, _posY, _posZ);
        CreatePool(20);
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
        for (int z = 0; z < 5; z++)
        {
            for (int x = 0; x < 5; x++)
            {
               
                _posX += 0.2f;               
            }
        }
        createdObject.transform.position.x += 2f;
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
        
       
    }
}
