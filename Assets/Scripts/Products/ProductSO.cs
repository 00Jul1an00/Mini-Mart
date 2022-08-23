using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Product", menuName = "Product", order = 1)]
public class ProductSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _cost;
    [SerializeField] private List<ProductSO> _needFor;
    [SerializeField] private ProductSO _makesFrom;

    public bool IsAvailable;
    public string Name => _name;
    public int Cost => _cost;
    public IReadOnlyList<ProductSO> NeedFor => _needFor;
    public ProductSO MakesFrom => _makesFrom;
}
