using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashPool : MonoBehaviour
{
    private GameObject _prefab;
    public bool AutoExpand;
    private Transform _container;
    private List<GameObject> _pool;

    public CashPool (GameObject prefab, int count, Transform container)
    {
        _prefab = prefab;
        _container = container;
        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        _pool = new List<GameObject>(); 
        
    }
}
