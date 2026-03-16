//создание 

namespace ECommerceApp.Patterns.Creational;

public abstract class Product { public abstract string GetDescription(); }

public class Clothing : Product { public override string GetDescription() => "Стильное худи"; }
public class Shoes : Product { public override string GetDescription() => "Кроссовки для бега"; }

public abstract class ProductCreator
{
    public abstract Product Create();
}
// реализация 
public class ClothingCreator : ProductCreator { public override Product Create() => new Clothing(); }
public class ShoesCreator : ProductCreator { public override Product Create() => new Shoes(); }