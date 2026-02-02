using Battleships.Application.Abstractions.CQRS;
using NetArchTest.Rules;

namespace Battleships.ArchitectureTests;
public class ApplicationLayerRules : BaseTest
{
    [Fact]
    public void Application_Interfaces_Should_BeIn_Abstractions_Namespace()
    {
        // Act
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .AreInterfaces()
            .And()
            .DoNotHaveNameMatching("ICommand$|IQuery$")
            .Should()
            .ResideInNamespace("Battleships.Application.Abstractions")
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, "Application interfaces should be in Abstractions namespace");
    }

    [Fact]
    public void Application_Commands_Should_BeImmutable()
    {
        // Act
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommand))
            .Should()
            .BeImmutable()
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, "Commands should be immutable");
    }

    [Fact]
    public void Application_Queries_Should_BeImmutable()
    {
        // Act
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(IQuery<>))
            .Should()
            .BeImmutable()
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, "Queries should be immutable");
    }
}
