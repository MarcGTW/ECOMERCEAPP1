using ECommerceApp.Patterns.Creational;
using ECommerceApp.Patterns.Structural;
using ECommerceApp.Patterns.Behavioral;

var builder = WebApplication.CreateBuilder(args);

// --- РЕГИСТРАЦИЯ ПАТТЕРНОВ В DI-КОНТЕЙНЕРЕ ---
// 1. Регистрируем стороннюю систему (Adaptee)
builder.Services.AddSingleton<LegacyPaymentSystem>();

// 2. Регистрируем Адаптер (через Агрегацию)
builder.Services.AddSingleton<PaymentAdapter>();

// 3. Регистрируем Фасад, который теперь автоматически получит адаптер
builder.Services.AddScoped<OrderFacade>();
// --------------------------------------------

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// 1. Каталог товаров
app.MapGet("/api/shop/products", () => {
    return Results.Ok(new[] {
        new { name = "Шёлковое платье", price = 12000, icon = "👗", description = "Натуральный шёлк высшего качества." },
        new { name = "Худи Oversize", price = 5500, icon = "🧥", description = "Теплый хлопок, свободный крой." },
        new { name = "Джинсы Urban", price = 7200, icon = "👖", description = "Классический деним." },
        new { name = "Рубашка Oxford", price = 4800, icon = "👕", description = "Деловой стиль." },
        new { name = "Кроссовки Dash", price = 9500, icon = "👟", description = "Для бега и жизни." },
        new { name = "Ремень Premium", price = 3200, icon = "🎗️", description = "Кожа ручной выделки." }
    });
});

// 2. Логика оформления (Теперь используем Facade из DI)
app.MapPost("/api/shop/checkout", (CartRequest req, OrderFacade facade) => {
    // [Strategy] - Вычисление суммы
    var subtotal = req.Items.Sum(x => x.Price);
    var discount = new DiscountContext();
    
    if (subtotal > 15000 || req.Items.Count > 3) 
        discount.SetStrategy(new ChristmasDiscount());
    
    var finalPrice = discount.Calculate(subtotal);

    // [Facade] - Вызываем метод фасада, который внутри использует Builder, Command и Adapter
    // Передаем параметры для демонстрации работы всей цепочки
    var facadeResult = facade.PlaceComplexOrder(
        req.Items.FirstOrDefault()?.Name ?? "Item", 
        finalPrice, 
        "Chisinau, Moldova", // Твоя локация
        false
    );

    // [Observer] - Уведомляем систему
    var orderSubject = new OrderSubject();
    orderSubject.Attach(new CustomerNotification());
    orderSubject.Notify("Обработка через GoF завершена");

    return Results.Ok(new { 
        success = true, 
        details = $"{facadeResult} Итоговая сумма: {finalPrice}₽." 
    });
});

app.Run();

public record CartRequest(List<CartItem> Items);
public record CartItem(string Name, double Price);