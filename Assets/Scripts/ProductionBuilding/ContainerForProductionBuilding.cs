public class ContainerForProductionBuilding : ProductsObjectPool
{
    public int ProductsInContainerQuantity => Index;

    private void Start()
    {
        Init();
    }
}
