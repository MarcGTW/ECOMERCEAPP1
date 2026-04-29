using ECommerceApp.Patterns.Creational;
using ECommerceApp.Patterns.Behavioral;

namespace ECommerceApp.Patterns.Structural;

public class OrderFacade
{
    private readonly OrderBuilder _builder = new();
    private readonly CommandInvoker _invoker = new();
    private readonly StockHandler _stock = new(); // Из Chain of Responsibility
    private readonly PaymentAdapter _payment;

    public OrderFacade(PaymentAdapter payment)
    {
        _payment = payment;
        
        // Настраиваем цепочку проверок (Chain of Responsibility)
        // В будущем сюда можно добавить PaymentHandler и т.д.
    }

    public string PlaceComplexOrder(string itemName, double price, string address, bool isGift)
    {
        // 1. Проверка склада (Chain of Responsibility)
        // Если товара нет, цепочка прервется
        _stock.Process("InStock"); 

        // 2. Сборка объекта заказа (Builder)
        var builder = _builder.AddItem(itemName)
                             .SetAddress(address);
        
        if (isGift) builder.MarkAsGift();
        
        var order = builder.Build();

        // 3. Выполнение оплаты через стороннюю систему (Adapter + Agregation)
        string paymentStatus = _payment.Process(price);

        // 4. Регистрация действия в истории (Command)
        var command = new PlaceOrderCommand(Guid.NewGuid().ToString().Substring(0, 8));
        _invoker.Run(command);

        return $"[Facade] {paymentStatus}. Заказ для {order.ShippingAddress} оформлен. " +
               $"Товаров: {order.Items.Count}. Подарок: {(order.IsGift ? "Да" : "Нет")}.";
    }
}