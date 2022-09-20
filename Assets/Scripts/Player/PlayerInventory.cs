using System.Collections.Generic;

public class PlayerInventory : IIncreaseInventory
{
    private Stack<Product> _inventory = new();
    private int _capacity = 2;

    public bool CanTakeProduct { get { return _inventory.Count < _capacity; } }
    public bool CanPutProduct { get { return _inventory.Count > 0; } }
    public Product NextProductInInventory { get { return _inventory.Peek(); } }

    public void TakeProduct(Product product)
    {
        if (CanTakeProduct)
            _inventory.Push(product);
    }

    public void PutProduct(Product product)
    {
        if ((CanPutProduct && NextProductInInventory == product))
            _inventory.Pop();
    }

    public void IncreseInventory()
    {
        _capacity++;
    }
}
