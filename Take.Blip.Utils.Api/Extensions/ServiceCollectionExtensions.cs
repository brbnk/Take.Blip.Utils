using Take.Blip.Utils.Facade.Date;
using Take.Blip.Utils.Facade.Date.Interfaces;

namespace Take.Blip.Utils.Api.Extensions;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddFacadeDependencies(this IServiceCollection service)
  {
    service.AddScoped<IDateHandlerFacade, DateHandlerFacade>();
    return service;
  }
}