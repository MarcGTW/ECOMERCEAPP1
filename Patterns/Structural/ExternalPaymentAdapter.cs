namespace ECommerceApp.Patterns.Structural;

// Интерфейс, который ожидает наша система
public interface ITargetPayment { string Process(double amount); }

// Сторонняя библиотека с другим интерфейсом (Adaptee)
public class LegacyPaymentSystem { public string MakePayment(string val) => $"Legacy Pay: {val}"; }

// Адаптер через АГРЕГАЦИЮ
public class PaymentAdapter : ITargetPayment
{
    // Объект передается извне, а не создается внутри
    private readonly LegacyPaymentSystem _legacySystem;

    // Конструктор принимает уже созданный объект
    public PaymentAdapter(LegacyPaymentSystem legacySystem)
    {
        _legacySystem = legacySystem;
    }

    public string Process(double amount) => 
        _legacySystem.MakePayment(amount.ToString("C"));
}