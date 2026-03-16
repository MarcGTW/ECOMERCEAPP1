namespace ECommerceApp.Patterns.Creational;

public class Order
{
    public List<string> Items = new();
    public string ShippingAddress = "";
    public bool IsGift = false;
    public string DeliveryType = "Standard"; 
}


public class OrderBuilder
{
    private Order _order = new();
    
    public OrderBuilder AddItem(string item) { _order.Items.Add(item); return this; }
    public OrderBuilder SetAddress(string addr) { _order.ShippingAddress = addr; return this; }
    public OrderBuilder MarkAsGift() { _order.IsGift = true; return this; }
    public OrderBuilder SetDelivery(string type) { _order.DeliveryType = type; return this; }
    
    public Order Build()
    {
        var result = _order;
        _order = new Order(); 
        return result;
    }
}

public class OrderDirector
{
    private readonly OrderBuilder _builder;

    public OrderDirector(OrderBuilder builder) => _builder = builder;

    
    public void ConstructGiftOrder(string item)
    {
        _builder.AddItem(item)
                .SetAddress("Chisinau, Moldova") 
                .MarkAsGift()
                .SetDelivery("Express");
    }

    
    public void ConstructStandardOrder(string item, string address)
    {
        _builder.AddItem(item)
                .SetAddress(address)
                .SetDelivery("Standard");
    }
}