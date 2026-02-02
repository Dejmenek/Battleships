# Battleships 🚢

A modern, real-time multiplayer implementation of the classic Battleship game built with ASP.NET and SignalR.

## Table of Contents

- [About](#about)
- [Features](#features)
- [Technologies](#technologies)
- [Architecture](#architecture)
- [Getting Started](#getting-started)
- [Gameplay](#gameplay)
- [Things Learned](#things-learned)
- [Used Resources](#used-resources)
- [License](#license)

## About

Battleships is a web-based implementation of the classic Battleship board game featuring real-time online multiplayer functionality. Players can register, create or join game rooms (public or private), and engage in strategic naval warfare while chatting with opponents. The project emphasizes clean architecture, server-authoritative game state, and real-time synchronization using SignalR.

This MVP (Minimum Viable Product) focuses on delivering core gameplay mechanics with proper rule enforcement, real-time communication, and a scalable backend foundation for future enhancements.

## Features

### Core Gameplay
- **Classic Battleship Rules**: 10×10 grid with standard ship set (Carrier, Battleship, Cruiser, Submarine, Destroyer)
- **2-Player Real-Time Matches**: Strict turn-based gameplay with server-side validation
- **Ship Placement**: Manual placement or randomization with reset capability during setup
- **Turn Timer**: Per-player time limits to keep games moving
- **Game State Synchronization**: Real-time updates across both players using SignalR
- **Win/Loss Detection**: Automatic game end when all ships are sunk

### Room Management
- **Public Rooms**: Join any available public game from the lobby
- **Private Rooms**: Create code-protected rooms for playing with friends
- **Auto-Close**: Rooms automatically close when all players leave
- **Rejoin Support**: Reconnect to active games within a 5-minute window

### User Management
- **Authentication**: Username/email/password registration and login
- **Guest Access**: Anonymous users can join public rooms (limited features)
- **Single Active Game**: Users can only participate in one game at a time
- **Account Persistence**: User profiles and game history stored in database

### Chat System
- **In-Game Chat**: Real-time messaging during all game phases
- **Rate Limiting**: Protection against spam and abuse
- **Authenticated Only**: Chat restricted to registered users
- **Toxic Behavior Reporting**: Built-in reporting mechanism (MVP: reported messages optionally stored)

### Security & Anti-Cheat
- **Server-Authoritative Game Logic**: All rules enforced on the backend
- **Turn Validation**: Out-of-turn actions rejected
- **Ship Placement Validation**: Overlap, spacing, and boundary checks
- **Private Room Protection**: Admin kick functionality for unauthorized access attempts
- **Inactivity Timeouts**: Automatic removal of inactive players

### Technical Features
- **Clean Architecture**: Separation of concerns with Domain, Application, Infrastructure, and API layers
- **CQRS Pattern**: Clear separation of commands and queries without mediator frameworks
- **Real-Time Communication**: SignalR for instant gameplay and chat updates
- **Persistent Storage**: Entity Framework Core with SQL Server
- **Comprehensive Testing**: Unit, integration, architecture, and end-to-end tests
- **Containerization**: Docker support for consistent deployment
- **Cloud Deployment**: Azure-ready with scalability considerations

## Technologies

### Backend
- **ASP.NET Core** - Web API framework using Minimal APIs
- **SignalR** - Real-time communication framework
- **Entity Framework Core** - ORM for database access
- **SQL Server** - Relational database
- **FluentValidation** - Input validation library
- **Scrutor** - Assembly scanning and decoration

### Frontend
- **Razor Pages** - Server-side rendering with C#
- **Tailwind CSS** - Utility-first CSS framework
- **SignalR Client** - JavaScript client for real-time updates

### Testing
- **XUnit** - Unit testing framework
- **TestContainers** - Integration testing with containerized dependencies
- **Playwright** - End-to-end browser testing
- **Architecture Tests** - Dependency rule enforcement

### DevOps & Deployment
- **Docker** - Containerization
- **Azure** - Cloud hosting platform
- **Git** - Version control

## Architecture

The project follows **Clean Architecture** principles with clear separation of concerns

### Key Architectural Decisions
- **Server-Authoritative**: All game logic and state validation occurs on the server
- **CQRS Without MediatR**: Explicit command and query handling for clarity
- **No Domain Logic in Hubs**: API layer handles only routing and validation
- **Real-Time First**: SignalR used for game state updates and player interactions
- **Fail Fast**: Invalid inputs and illegal state transitions rejected immediately

## Getting Started

### Prerequisites
- .NET 9.0 SDK
- SQL Server (LocalDB or full instance)
- Docker (optional)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/Dejmenek/Battleships.git
   cd Battleships
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Set up the database**
   ```bash
   dotnet ef database update --project src/Battleships.Infrastructure
   ```

4. **Run API**
   ```bash
   dotnet run --project src/Battleships.API
   ```
5. **Run Web App**
   ```bash
   dotnet run --project src/Battleships.Web
   ```

5. **Access the application**
   - API: `https://localhost:7020`
   - Web UI: `https://localhost:7247`

### Running with Docker

```bash
docker-compose up
```

### Running Tests

```bash
# All tests
dotnet test

# Unit tests only
dotnet test tests/Battleships.UnitTests

# Integration tests
dotnet test tests/Battleships.IntegrationTests

# End-to-end tests
dotnet test tests/Battleships.EndTests

# Architecture tests
dotnet test tests/Battleships.ArchitectureTests
```

## Gameplay

### How to Play

1. **Register or Login**: Create an account or continue as guest (limited features)
2. **Join or Create a Room**: 
   - Browse public rooms in the lobby
   - Create a private room with a unique code
   - Share the code with friends for private matches
3. **Place Your Ships**: 
   - Manually drag and drop ships onto your board
   - Use "Randomize" for automatic placement
   - Use "Reset" to clear and start over
   - Click "Ready" when satisfied with placement
4. **Take Turns**: 
   - Wait for your turn
   - Click a cell on opponent's board to fire
   - Watch for hit, miss, or sunk feedback
   - Wait for opponent's turn
5. **Win the Game**: Sink all enemy ships before they sink yours!

### Game Rules
- **Board**: 10×10 grid per player
- **Ships**: Carrier (5), Battleship (4), Cruiser (3), Submarine (3), Destroyer (2)
- **Placement Rules**: 
  - Ships must stay within boundaries
  - No overlapping
  - Minimum one-cell spacing between ships
- **Turn Rules**: 
  - Strict alternating turns
  - One shot per turn
  - No extra turn on hit
- **Win Condition**: First player to sink all opponent ships wins

## Things Learned

_To be documented throughout development..._

## Used Resources

_To be documented throughout development..._

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.