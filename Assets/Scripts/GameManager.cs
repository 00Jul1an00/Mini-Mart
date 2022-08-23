using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Product> _products;

    public IReadOnlyList<Product> Products;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        Products = _products;
    }
}
