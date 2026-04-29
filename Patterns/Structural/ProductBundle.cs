namespace ECommerceApp.Patterns.Structural;

public abstract class CatalogComponent { public abstract double GetPrice(); }

public class SingleProduct : CatalogComponent
{
    private double _price;
    public SingleProduct(double price) => _price = price;
    public override double GetPrice() => _price;
}

public class ProductBundle : CatalogComponent
{
    private List<CatalogComponent> _components = new();
    public void Add(CatalogComponent c) => _components.Add(c);
    public override double GetPrice() => _components.Sum(x => x.GetPrice());
}