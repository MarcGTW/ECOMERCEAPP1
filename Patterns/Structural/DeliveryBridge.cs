namespace ECommerceApp.Patterns.Structural;

// Реализация
public interface IDeliveryVendor { string Deliver(); }
public class FedexVendor : IDeliveryVendor { public string Deliver() => "via FedEx"; }

// Абстракция
public abstract class DeliveryType
{
    protected IDeliveryVendor _vendor;
    protected DeliveryType(IDeliveryVendor vendor) => _vendor = vendor;
    public abstract string Process();
}

public class ExpressDelivery : DeliveryType
{
    public ExpressDelivery(IDeliveryVendor vendor) : base(vendor) { }
    public override string Process() => $"Express delivery {_vendor.Deliver()}";
}