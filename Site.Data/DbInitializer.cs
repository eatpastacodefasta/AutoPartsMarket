namespace Site.Data;

public class DbInitializer
{
    public static void Initialize(ApplicationContext context)
    {
        context.Database.EnsureCreated();
    }
}
