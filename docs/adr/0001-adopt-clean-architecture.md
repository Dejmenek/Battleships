# Adopt Clean Architecture

## Status

Accepted

## Context

The Battleships project requires a software architecture that supports maintainability, testability, and clear separation of concerns. As the application grows, we need an architecture that:

- Keeps business logic independent of external frameworks and UI
- Enables easy testing of business rules without external dependencies
- Allows flexibility in changing technologies (databases, web frameworks, external services)
- Provides clear boundaries between different layers of the application
- Supports multiple deployment targets (API, Web)

## Decision

We will adopt Clean Architecture as the foundational architectural pattern for the Battleships project.

The implementation will be organized into the following layers:

### Domain Layer (`Battleships.Domain`)
- Contains enterprise business rules and entities
- No dependencies on other layers or external frameworks
- Houses core domain models, value objects, and domain services

### Application Layer (`Battleships.Application`)
- Contains application-specific business rules and use cases
- Depends only on the Domain layer
- Orchestrates the flow of data between external layers and domain
- Defines interfaces for infrastructure concerns (repositories, external services)
- Contains DTOs, commands, queries, and their handlers

### Infrastructure Layer (`Battleships.Infrastructure`)
- Implements interfaces defined in the Application layer
- Contains data access implementations (repositories, database context)
- Integrates with external services and frameworks
- Depends on Application layer

### Presentation Layers
- **API Layer (`Battleships.API`)**: RESTful API implementation
- **Web Layer (`Battleships.Web`)**: Web UI implementation
- Both depend on Application layer
- Handle HTTP concerns, routing, and user interface
- Transform DTOs to/from HTTP requests/responses

### Shared Layer (`Battleships.Shared`)
- Contains cross-cutting concerns and utilities
- Used by multiple layers when appropriate

## Consequences

### Positive

- **Testability**: Business logic can be tested in isolation without external dependencies
- **Flexibility**: Easy to swap out infrastructure components (e.g., change database providers)
- **Maintainability**: Clear separation of concerns makes code easier to understand and modify
- **Independence**: Domain logic doesn't depend on UI, database, or external frameworks
- **Multiple Interfaces**: Can easily support both API and Web frontends sharing the same business logic
- **SOLID Principles**: Architecture naturally encourages adherence to SOLID principles

### Negative

- **Complexity**: More abstractions and layers compared to a simple layered architecture
- **Initial Setup**: Requires more upfront effort to establish proper layer separation

### Neutral

- **More Projects**: Solution contains multiple projects for each layer, increasing solution complexity
