# Battleships MVP — Product Requirements Document (PRD)

## 1. Overview & Purpose

### Product Overview
Battleships is a web-based implementation of the classic Battleship game with real-time online multiplayer. Users can register and log in, create public or private game rooms, and play Battleship matches while chatting with other players. The MVP focuses on core gameplay and multiplayer functionality, with room for future expansion.

### Purpose
This project demonstrates building a real-time multiplayer web application with a strong backend focus, showcasing architecture, scalability considerations, and real-time communication.

---

## 2. Goals & Success Criteria

### Primary Goals
- Real-time multiplayer Battleship gameplay
- User authentication and persistent accounts
- Public and private game rooms
- In-game chat with rate limiting
- Clean, intuitive web UI
- Scalable backend architecture

### MVP Success Criteria
- Full Battleship match playable without errors or cheating
- Game state correctly synchronized between players
- Ship randomization and reset during setup
- Public and private room creation
- Private room admin can kick users attempting to brute-force access
- Chat available for authenticated users with rate limiting
- Turn timer enforced
- Application deployed and accessible externally

---

## 3. Target Users

### Primary User Groups
- Casual players
- Friends playing private matches
- Recruiters and technical reviewers

### Usage Patterns
- Short, casual matches
- Mix of public and private rooms
- Optional guest access for public games

---

## 4. Core Gameplay & Rules

### Game Board
- Size: 10×10
- Each player has a hidden ship board

### Ships
- Carrier (5)
- Battleship (4)
- Cruiser (3)
- Submarine (3)
- Destroyer (2)

### Setup Phase
- Manual or random ship placement
- Reset allowed before readiness confirmation
- Ships:
  - Must be within bounds
  - Must not overlap
  - Must maintain at least one-cell spacing
- Ready confirmation locks placement
- Inactivity may result in removal

### Turn Rules
- Strict alternating turns
- One shot per turn
- No extra turn on hit
- Actions allowed only during active turn

### Win Condition
- All opponent ships sunk

### Invalid Actions
- Shooting the same cell twice
- Acting out of turn
- Multiple shots per turn
- Changing ship placement after readiness
- Viewing opponent ships
- Invalid ship placement

---

## 5. User Experience & Flows

### Authentication
- Username/email/password or external provider
- Guests:
  - Can join public rooms
  - Cannot create rooms
  - Cannot use chat

### Lobby
- List of public rooms
- Create room (public/private) for authenticated users
- Join via room code for private rooms

### Chat
- Available pre-game, in-game, and post-game
- Authenticated users only
- Rate-limited

### Setup Phase UI
- Player board
- Available ships
- Randomize and reset buttons
- Ready confirmation

### In-Game UI
- Player and opponent boards
- Turn indicator
- Per-player turn timer
- Player ship health summary
- Opponent ship list (no health)
- Clear hit/miss/sunk feedback

---

## 6. Features & Requirements (MVP)

### Rooms & Matchmaking
- 2-player rooms only
- One active game per user
- Auto-close room when all players leave
- Rejoin allowed within 5 minutes
- Turn timer paused during disconnect
- Public/private rooms (auth users only)
- Guests can join public rooms only

### Gameplay
- Server-side rule enforcement
- Persistent active game state

### Chat
- Authenticated users only
- Rate-limited
- Toxic behavior reporting
- Optional storage of reported messages

### Security & Anti-Abuse
- Server-side validation for all actions
- Private room admin can kick players
- Inactivity timeouts
- Prevention of cheating and invalid actions

---

## 7. Technical Assumptions & Constraints

### Frontend
- Razor Pages (C#)
- Tailwind CSS
- SignalR client

### Backend
- ASP.NET Web API (C#)
- SignalR for real-time communication
- Entity Framework Core
- SQL Server
- FluentValidation
- Scrutor
- XUnit
- TestContainers
- Playwright
- Docker

### Hosting / Deployment
- Azure
- Containerized deployment

### Real-Time Communication
- SignalR for gameplay and chat

### Persistence
- SQL Server for:
  - Users
  - Rooms
  - Active games
  - Optional reported chat messages

### Security
- Turn enforcement
- Ship placement validation
- Private room code protection
- Chat rate limiting
- User reporting

### Scalability (Future)
- Load balancer in front of API
- Multiple API instances
- SignalR backplane or Azure SignalR Service
- Scalable SQL Server setup

---

## 8. Open Questions & Risks

### Open Questions
- Exact rejoin timeout duration (default: 5 minutes)
- Chat persistence scope (reported messages only)
- Private room code complexity
- High concurrency handling

### Risks
- Player disconnects
- Cheating attempts
- Resource limits in MVP setup
- Scope creep
- Browser compatibility issues