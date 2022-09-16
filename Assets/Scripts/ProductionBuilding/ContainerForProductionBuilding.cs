using System.Collections;
using UnityEngine;

public class ContainerForProductionBuilding : ProductsObjectPool
{
    //добавить методы подбора предметов для игрока

    [SerializeField] private float _animationDuration = 1f;

    private Coroutine _coroutine;

    public int ProductsInContainerQuantity => Index;

    private void Start()
    {
        Init();
    }
}
