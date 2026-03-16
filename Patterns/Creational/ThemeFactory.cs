namespace ECommerceApp.Patterns.Creational;


public interface IButton { string Render(); }
public interface IPanel { string Render(); }


public class DarkButton : IButton { public string Render() => "Dark Button Rendered"; }
public class DarkPanel : IPanel { public string Render() => "Dark Panel Rendered"; } 


public class LightButton : IButton { public string Render() => "Light Button Rendered"; }
public class LightPanel : IPanel { public string Render() => "Light Panel Rendered"; }


public interface IGUIFactory
{
    IButton CreateButton();
    IPanel CreatePanel(); 
}

public class DarkThemeFactory : IGUIFactory 
{ 
    public IButton CreateButton() => new DarkButton(); 
    public IPanel CreatePanel() => new DarkPanel(); 

public class LightThemeFactory : IGUIFactory 
{ 
    public IButton CreateButton() => new LightButton(); 
    public IPanel CreatePanel() => new LightPanel();  }
}