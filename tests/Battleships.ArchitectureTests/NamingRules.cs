using Battleships.Application.Abstractions.CQRS;
using NetArchTest.Rules;

namespace Battleships.ArchitectureTests;
public class NamingRules : BaseTest
{
    [Fact]
    public void CommandHandlers_Should_HaveNameEndingWithHandler()
    {
        // Act
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommand))
            .Or()
            .HaveNameMatching(".*CommandHandler$")
            .Should()
            .HaveNameEndingWith("Handler")
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, "Command handlers should end with 'Handler'");
    }

    [Fact]
    public void QueryHandlers_Should_HaveNameEndingWithHandler()
    {
        // Act
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .HaveNameMatching(".*QueryHandler$")
            .Should()
            .HaveNameEndingWith("Handler")
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, "Query handlers should end with 'Handler'");
    }

    [Fact]
    public void Interfaces_Should_StartWithI()
    {
        // Act
        var result = Types.InAssemblies([DomainAssembly, ApplicationAssembly, InfrastructureAssembly])
            .That()
            .AreInterfaces()
            .Should()
            .HaveNameStartingWith("I")
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, "All interfaces should start with 'I'");
    }
}
