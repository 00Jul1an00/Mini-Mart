using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public IReadOnlyList<Product> Products;
    public static GameManager Instance { get; private set; } 

    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        Products = new List<Product>()
        {
            new Wheat() { IsAvailable = true },
            new Tomato() { IsAvailable = true },
        };
    }
}
