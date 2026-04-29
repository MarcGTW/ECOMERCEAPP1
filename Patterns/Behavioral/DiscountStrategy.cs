namespace ECommerceApp.Patterns.Behavioral;

public interface IDiscountStrategy { double Apply(double price); } //Это общая форма для всех скидок и он должен иметь метод Apply

public class ChristmasDiscount : IDiscountStrategy { public double Apply(double p) => p * 0.9; } // 10% скидка на Рождество

public class NoDiscount : IDiscountStrategy { public double Apply(double p) => p; } // Нет скидки

public class DiscountContext
{
    private IDiscountStrategy _strategy = new NoDiscount();// контекст не знает какая скидка работатет 
    public void SetStrategy(IDiscountStrategy s) => _strategy = s; // ключевой момент мы можем подсуунуть любую логику 
    public double Calculate(double p) => _strategy.Apply(p); // применяем стратегию к цене 
}