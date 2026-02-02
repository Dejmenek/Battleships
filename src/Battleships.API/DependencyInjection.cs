namespace Battleships.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddSignalR();
        services.AddEndpointsApiExplorer();

        services.AddProblemDetails();

        return services;
    }
}
