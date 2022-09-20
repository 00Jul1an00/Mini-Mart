using System.Collections;
using UnityEngine;

public class ContainerForProductionBuilding : ProductsObjectPool
{
    [SerializeField] private float _animationDuration = 1f;

    public int ProductsInContainerQuantity => Index;

    private void Start()
    {
        Init();
    }
}
