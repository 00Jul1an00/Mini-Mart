using System.Collections;
using UnityEngine;

public class ContainerForProductionBuilding : ProductsObjectPool
{
    //добавить методы подбора предметов для игрока

    [SerializeField] private float _animationDuration = 1f;

    public int ProductsInContainerQuantity => Index;

    private bool _isNotCalled;

    private void Start()
    {
        Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMover player) && _isNotCalled)
        {
            print("enter2");
            _isNotCalled = false;
            StartCoroutine(WaitForEndAnimationDelay(player));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMover player))
        {
            print("exit2");
            _isNotCalled = true;
            StopCoroutine(WaitForEndAnimationDelay(player));
        }    
    }

    private IEnumerator WaitForEndAnimationDelay(PlayerMover player)
    {
        if (CanAddProduct)
        {
            yield return new WaitForSeconds(_animationDuration);
            TryAddProduct();
            player.PutProduct(_productType);
        }
    }
}
