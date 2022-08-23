using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public IReadOnlyList<Product> AvailableProducts;
    public static GameManager Instance { get; private set; } 

    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        AvailableProducts = new List<Product>()
        {
            new Wheat() { IsAvailable = true },
            new Tomato() { IsAvailable = true },
        };
    }
}
