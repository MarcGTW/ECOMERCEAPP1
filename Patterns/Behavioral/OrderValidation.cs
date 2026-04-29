namespace ECommerceApp.Patterns.Behavioral;
// класс обработичк 
public abstract class Handler
{
    protected Handler? Successor;
    // связь звеньев ёсть, но она устанавливается извне, а не жестко внутри класса
    public void SetSuccessor(Handler s) => Successor = s;
    // абстракный метод обработки запроса, который должен быть реализован в конкретных обработчиках
    public abstract void Process(string request);
}
// проверка наличия товара на складе
public class StockHandler : Handler
{
    public override void Process(string req)
    {
        if (req.Contains("InStock")) Successor?.Process(req);
        else Console.WriteLine("Ошибка: Товара нет на складе");
    }
}