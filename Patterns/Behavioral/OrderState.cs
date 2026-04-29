namespace ECommerceApp.Patterns.Behavioral;

public abstract class State { public abstract void Handle(OrderContext ctx); }

public class NewState : State { public override void Handle(OrderContext ctx) => ctx.SetState(new PaidState()); }
public class PaidState : State { public override void Handle(OrderContext ctx) => Console.WriteLine("Заказ уже оплачен."); }

public class OrderContext
{
    private State _state = new NewState();
    public void SetState(State s) => _state = s;
    public void Next() => _state.Handle(this);
}