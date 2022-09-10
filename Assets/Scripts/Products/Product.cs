using UnityEngine;

public abstract class Product : MonoBehaviour
{
    [SerializeField] protected int _cost;
    [SerializeField] protected float _delayForProduce;

    public float DelayForProduce => _delayForProduce;
    public int Cost => _cost;
    public bool IsAvailable { get; set; }
}
