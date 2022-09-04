using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Product> _products;

    public IReadOnlyDictionary<Product, ShelfProductLogic> Shelfs { get; private set; }
    public IReadOnlyDictionary<Product, ProductionBuilding> ProductionBuildings { get; private set; }
    public IReadOnlyDictionary<Product, ProductionBuilding> RequireProductForProductionBuildings { get; private set; }

    public IReadOnlyList<Product> Products { get; private set; }

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        Products = _products;
        Shelfs = FillProductLocationsDictionary<ShelfProductLogic>();
        ProductionBuildings = FillProductLocationsDictionary<ProductionBuilding>();
        RequireProductForProductionBuildings = FillRequireProductForProductionDictionary();
    }

    private IReadOnlyDictionary<Product, T> FillProductLocationsDictionary<T>() where T : ProductsObjectPool
    {
        Dictionary<Product, T> productsLocation = new();
        var allShelfs = FindObjectsOfType<T>();

        foreach (var product in Products)
        {   
            foreach(var shelf in allShelfs)
            {
                if (product == shelf.ProductType)
                {
                    productsLocation.Add(product, shelf);
                }
            }
        }

        return productsLocation;
    }

    private IReadOnlyDictionary<Product, ProductionBuilding> FillRequireProductForProductionDictionary()
    {
        Dictionary<Product, ProductionBuilding> requaireProduct = new();

        foreach(var building in ProductionBuildings.Values)
        {
            Product product = building.RequaireProductForProduction;

            if(product != null)
                requaireProduct.Add(product, building);
        }

        return requaireProduct;
    }
}
