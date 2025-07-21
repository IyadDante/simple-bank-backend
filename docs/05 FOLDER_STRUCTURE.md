BankingApp/
│
├── BankingApp.sln                --> Solution file
│
├── BankingApp.Shared/           --> Shared DTOs, constants, base types
│   ├── BankingApp.Shared.csproj
│   └── DTOs/
│       ├── UserDto.cs
│       ├── AccountDto.cs
│       └── TransactionDto.cs
│
├── BankingApp.Services/         --> Folder containing all microservices
│   ├── AuthService/
    │    ├── Controllers/
    │    │   └── AuthController.cs
    │    ├── Models/
    │    │   └── User.cs
    │    ├── Interfaces/
    │    │   └── IAuthService.cs
    │    ├── Services/
    │    │   └── AuthService.cs
    │    ├── Program.cs
    │    ├── AuthService.csproj
│   │
│   ├── AccountService/
│   │   ├── AccountService.csproj
│   │   └── ...
│   │
│   ├── TransactionService/
│   │   ├── TransactionService.csproj
│   │   └── ...
│   │
│   ├── ReportingService/
│   │   ├── ReportingService.csproj
│   │   └── ...
│   │
│   └── NotificationService/
│       ├── NotificationService.csproj
│       └── ...
│
├── BankingApp.API/              --> The API Gateway (ASP.NET Core Web API)
│   ├── BankingApp.API.csproj
│   └── ...
│
├── BankingApp.Client/           --> Optional (for Web or Mobile frontend)
│   └── (React, Blazor, etc.)
│
├── docs/                        --> Documentation files
│   ├── ARCHITECTURE.md
│   ├── TECH_STACK.md
│   └── ...
│
├── README.md                    # Project overview and setup guide
├── ARCHITECTURE.md              # System design, diagrams, communication structure
├── TECH_STACK.md                # Justification for each technology used
├── ROADMAP.md                   # Project phases and milestones
├── FOLDER_STRUCTURE.md          # This exact file showing folder layout

