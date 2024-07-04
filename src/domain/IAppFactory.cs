namespace UiValueInjector.Domain;

public interface IAppFactory
{
    
    public IApp Launch(AppPath path);
}