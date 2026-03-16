namespace ECommerceApp.Patterns.Creational;

public abstract class OrderPrototype
{
    public abstract OrderPrototype Clone();
}

public class ReusableOrder : OrderPrototype
{
    public string TemplateName { get; set; }
    public List<string> Items { get; set; } = new();

    public ReusableOrder(string name) => TemplateName = name;

    public override OrderPrototype Clone()
    {
        
        var clone = new ReusableOrder(this.TemplateName);
        
        
        clone.Items = new List<string>(this.Items);
        
        return clone;
    }
}