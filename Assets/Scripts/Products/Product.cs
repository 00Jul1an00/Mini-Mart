using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Product : MonoBehaviour
{
    [SerializeField] protected int _cost;

    public bool IsAvailable;

    protected virtual void Produce(float delay) { }
}
