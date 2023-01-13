using EventsMan.Application.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EventsMan.Application;

public static class DependencyInjectionRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}