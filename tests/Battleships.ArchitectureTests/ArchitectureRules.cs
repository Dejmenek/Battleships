using NetArchTest.Rules;

namespace Battleships.ArchitectureTests;

public class ArchitectureRules : BaseTest
{
    [Fact]
    public void API_Should_DependOn_Application()
    {
        // Act
        var result = Types.InAssembly(ApiAssembly)
            .Should()
            .HaveDependencyOn(ApplicationAssembly.GetName().Name)
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, "API layer should depend on Application layer");
    }

    [Fact]
    public void All_Layers_Should_Have_DependencyInjection_Class()
    {
        // Act
        var applicationHasDI = Types.InAssembly(ApplicationAssembly)
            .That()
            .HaveName("DependencyInjection")
            .GetTypes()
            .Any();

        var infrastructureHasDI = Types.InAssembly(InfrastructureAssembly)
            .That()
            .HaveName("DependencyInjection")
            .GetTypes()
            .Any();

        var apiHasDI = Types.InAssembly(ApiAssembly)
            .That()
            .HaveName("DependencyInjection")
            .GetTypes()
            .Any();

        // Assert
        Assert.True(applicationHasDI, "Application layer should have a DependencyInjection class");
        Assert.True(infrastructureHasDI, "Infrastructure layer should have a DependencyInjection class");
        Assert.True(apiHasDI, "API layer should have a DependencyInjection class");
    }

    [Fact]
    public void Domain_ShouldNotHaveDependencyOn_Application()
    {
        // Act
        var result = Types.InAssembly(DomainAssembly)
            .Should()
            .NotHaveDependencyOn(ApplicationAssembly.GetName().Name)
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, "Domain layer should not depend on Application layer");
    }

    [Fact]
    public void Domain_ShouldNotHaveDependencyOn_Infrastructure()
    {
        // Act
        var result = Types.InAssembly(DomainAssembly)
            .Should()
            .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, "Domain layer should not depend on Infrastructure layer");
    }

    [Fact]
    public void Domain_ShouldNotHaveDependencyOn_API()
    {
        // Act
        var result = Types.InAssembly(DomainAssembly)
            .Should()
            .NotHaveDependencyOn(ApiAssembly.GetName().Name)
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, "Domain layer should not depend on API layer");
    }

    [Fact]
    public void Application_ShouldNotHaveDependencyOn_Infrastructure()
    {
        // Act
        var result = Types.InAssembly(ApplicationAssembly)
            .Should()
            .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, "Application layer should not depend on Infrastructure layer");
    }

    [Fact]
    public void Application_ShouldNotHaveDependencyOn_API()
    {
        // Act
        var result = Types.InAssembly(ApplicationAssembly)
            .Should()
            .NotHaveDependencyOn(ApiAssembly.GetName().Name)
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, "Application layer should not depend on API layer");
    }

    [Fact]
    public void Application_Should_DependOn_Domain()
    {
        // Act
        var result = Types.InAssembly(ApplicationAssembly)
            .Should()
            .HaveDependencyOn(DomainAssembly.GetName().Name)
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, "Application layer should depend on Domain layer");
    }

    [Fact]
    public void Infrastructure_Should_DependOn_Application()
    {
        // Act
        var result = Types.InAssembly(InfrastructureAssembly)
            .Should()
            .HaveDependencyOn(ApplicationAssembly.GetName().Name)
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, "Infrastructure layer should depend on Application layer");
    }

    [Fact]
    public void Infrastructure_ShouldNotHaveDependencyOn_API()
    {
        // Act
        var result = Types.InAssembly(InfrastructureAssembly)
            .Should()
            .NotHaveDependencyOn(ApiAssembly.GetName().Name)
            .GetResult();

        // Assert
        Assert.True(result.IsSuccessful, "Infrastructure layer should not depend on API layer");
    }
}
