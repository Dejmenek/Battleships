using Battleships.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Battleships.IntegrationTests;

[Collection(nameof(IntegrationTestCollection))]
public abstract class BaseTest(IntegrationTestWebAppFactory factory) : IAsyncLifetime
{
    protected readonly IntegrationTestWebAppFactory Factory = factory;
    private IServiceScope? _scope;
    protected ApplicationDbContext DbContext = null!;

    public virtual async Task InitializeAsync()
    {
        _scope = Factory.Services.CreateScope();
        DbContext = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await DbContext.Database.EnsureDeletedAsync();
        await DbContext.Database.MigrateAsync();
    }

    public virtual Task DisposeAsync()
    {
        DbContext?.Dispose();
        _scope?.Dispose();
        return Task.CompletedTask;
    }
}
