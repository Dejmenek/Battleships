using Battleships.Domain.Identity;
using System.Reflection;

namespace Battleships.ArchitectureTests;
public abstract class BaseTest
{
    protected static readonly Assembly DomainAssembly = typeof(ApplicationUser).Assembly;
    protected static readonly Assembly ApplicationAssembly = typeof(Application.DependencyInjection).Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(Infrastructure.DependencyInjection).Assembly;
    protected static readonly Assembly ApiAssembly = typeof(API.DependencyInjection).Assembly;
}
