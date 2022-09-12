using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CashPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;   
    [SerializeField] private Transform _container;

    private float _posX, _posY, _posZ;
    private int _currentCashCount = 0;
    private List<GameObject> _pool;
    private CashBox _cashBox;   
    
    private void Start()
    {
        _cashBox = GetComponent<CashBox>();
        _posX = 3.3f;
        _posY = 0.5346044f;
        _posZ = -38.333f;
        _container.position = new Vector3(_posX, _posY, _posZ);
        CreatePool(20);
    }
    
    private void CreatePool(int count)
    {
        _pool = new List<GameObject>();
        for (int i = 0; i < count; i++)
        {
            for (int z = 0; z < 3; z++)
            {
                for (int x = 0; x < 5; x++)
                {
                    CreateObject(_posX, _posY, _posZ);
                    _posX += 0.2f;
                }
                _posX -= 1f;
                _posZ -= 0.3f;
            }
            _posZ += 0.9f;
            _posY += 0.069f;
        }
    }

    private GameObject CreateObject(float x, float y, float z, bool isActiveOnStart = false)
    {
        var createdObject = UnityEngine.Object.Instantiate(_prefab, _container);

        createdObject.transform.position = new Vector3(x, y, z);
        createdObject.SetActive(isActiveOnStart); 
        _pool.Add(createdObject); ;
        return createdObject;
    }

    public void RenderCash()
    {
        int packCount = _cashBox.CashBoxMoney / 10;
        for (int i = 0; i < packCount; i++)
        {                       
            if(_container.GetChild(i).gameObject.activeSelf == false)
            {
                _container.GetChild(i).gameObject.SetActive(true);
            }
            
        }
    }

    public void DisableCash()
    {
        for (int i = 0; i < _container.childCount; i++)
        {
            _container.GetChild(i).gameObject.SetActive(false);
        }
    }

    

    

   
}
