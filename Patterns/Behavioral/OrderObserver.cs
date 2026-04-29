namespace ECommerceApp.Patterns.Behavioral;

public interface IObserver { void Update(string status); }

public class CustomerNotification : IObserver 
{ 
    public void Update(string s) => Console.WriteLine($"Клиенту: Статус заказа изменен на {s}"); 
}

public class OrderSubject
{  // список всех активных подписчиков на изменения статуса заказа
    private List<IObserver> _observers = new();
    // метод регестрации подписчика
    public void Attach(IObserver o) => _observers.Add(o);
    // оповещение всех подписчкиов о изменении статуса заказа, и выхываем update 
    public void Notify(string status) => _observers.ForEach(o => o.Update(status));
}