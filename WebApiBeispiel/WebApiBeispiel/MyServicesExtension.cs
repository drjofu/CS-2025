namespace WebApiBeispiel
{
  public static class MyServicesExtension
  {
    public static IServiceCollection AddMyServices(this IServiceCollection services)
    {
      services.AddSingleton<IVerwaltung, Verwaltung>();
      services.AddSingleton<INameCalculator, NameCalculator>();

      return services;
    }
  }
}
