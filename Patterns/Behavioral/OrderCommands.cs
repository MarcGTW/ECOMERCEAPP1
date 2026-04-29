namespace ECommerceApp.Patterns.Behavioral;

public interface ICommand 
{ 
    void Execute(); // выполнение действия 
    void Undo(); // Добавляем метод для отмены
}

// Команда размещения заказа
public class PlaceOrderCommand : ICommand
{
    private readonly string _id;
    public PlaceOrderCommand(string id) => _id = id;
    
    public void Execute() => Console.WriteLine($"[Command] Заказ {_id} размещен в базе.");
    public void Undo() => Console.WriteLine($"[Undo] Заказ {_id} удален из базы.");
}

// Команда применения скидки (интеграция со Strategy)
public class ApplyDiscountCommand : ICommand
{
    private readonly string _orderId;
    private readonly double _amount;

    public ApplyDiscountCommand(string orderId, double amount)
    {
        _orderId = orderId;
        _amount = amount;
    }

    public void Execute() => Console.WriteLine($"[Command] Скидка {_amount}% применена к заказу {_orderId}.");
    public void Undo() => Console.WriteLine($"[Undo] Скидка {_amount}% отменена для заказа {_orderId}.");
}

// Команда изменения адреса доставки (Bridge/State)
public class ChangeDeliveryCommand : ICommand
{
    private readonly string _newAddress;
    private string _oldAddress = "Склад (самовывоз)";

    public ChangeDeliveryCommand(string newAddress) => _newAddress = newAddress;

    public void Execute() => Console.WriteLine($"[Command] Адрес доставки изменен на: {_newAddress}.");
    public void Undo() => Console.WriteLine($"[Undo] Адрес возвращен на: {_oldAddress}.");
}  // чтобы команда Undo могла вернуть старое значение, мы сохраняем его внутри команды

public class CommandInvoker
{
    private readonly Stack<ICommand> _history = new(); // Используем стек для удобного Undo

    public void Run(ICommand cmd) 
    { 
        cmd.Execute(); 
        _history.Push(cmd); 
    }

    public void CancelLastAction()
    {
        if (_history.Count > 0)
        {
            var cmd = _history.Pop();
            cmd.Undo();
        }
        else
        {
            Console.WriteLine("Нет действий для отмены.");
        }
    }
}