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

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMover player))
        {     
            _coroutine = StartCoroutine(WaitForEndAnimationDelay(player));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMover player))
        {
            print("exit2");
            StopCoroutine(_coroutine);
        }    
    }

    private IEnumerator WaitForEndAnimationDelay(PlayerMover player)
    {
        while (CanAddProduct)
        {
            yield return new WaitForSeconds(_animationDuration);

            if (player.TryPutProduct(_productType))
                AddProduct();
            else
                yield break;
        }
    }
}
