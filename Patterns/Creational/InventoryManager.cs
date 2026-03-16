namespace ECommerceApp.Patterns.Creational;

public sealed class InventoryManager
{
    private static InventoryManager? _instance;
    private static readonly object _lock = new object();
    private List<string> _products = new();

    private InventoryManager() { }

    public static InventoryManager Instance
    {
        get
        {
            lock (_lock)
            {
                return _instance ??= new InventoryManager();
            }
        }
    }

    public void AddStock(string item) => _products.Add(item);
    public List<string> GetStock() => _products;
}