namespace ECommerceApp.Patterns.Structural;

public interface IOrderService { double GetTotalPrice(); }

public class BaseOrder : IOrderService { public double GetTotalPrice() => 100.0; }

public abstract class OrderDecorator : IOrderService
{
    protected IOrderService _order;
    public OrderDecorator(IOrderService order) => _order = order;
    public virtual double GetTotalPrice() => _order.GetTotalPrice();
}

public class PriorityShippingDecorator : OrderDecorator
{
    public PriorityShippingDecorator(IOrderService order) : base(order) { }
    public override double GetTotalPrice() => base.GetTotalPrice() + 25.0; // Доп. сбор
}