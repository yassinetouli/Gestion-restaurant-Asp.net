# Gestion Restaurant – ASP.NET

A restaurant management web application built with **ASP.NET Core** and **C#**.
It combines a responsive restaurant website with an admin dashboard to manage the restaurant's content and activity.

> Project solution: `Glovvo_Yassine_Touli.sln` · Web project: `SiteWeb`

## Features

<!-- Adjust this list to match what your app really does -->
- Responsive public website for the restaurant (Bootstrap)
- Admin dashboard (SB Admin 2 template) with tables and charts
- Management of restaurant data (menu, orders, customers, ...)
- Clean, mobile-friendly interface

## Tech Stack

| Layer      | Technology                                   |
|------------|----------------------------------------------|
| Backend    | C#, ASP.NET Core                             |
| Database   | Microsoft SQL Server                         |
| Frontend   | HTML, CSS, JavaScript, Bootstrap             |
| UI / Admin | SB Admin 2, Font Awesome, DataTables, Chart.js |
| IDE        | Visual Studio                                |

## Project Structure

```
Gestion-restaurant-Asp.net/
├── Glovvo_Yassine_Touli.sln   # Visual Studio solution
├── SiteWeb/                   # ASP.NET web project
│   ├── Controllers/           # MVC controllers (handle requests, return views)
│   ├── Views/                 # Razor views (.cshtml) for the UI
│   ├── Models/                # View models used by the views
│   ├── Entity/                # Entity classes mapped to database tables
│   ├── Data/                  # Database context (Entity Framework Core)
│   ├── Migrations/            # EF Core migrations (database schema history)
│   ├── Repos/                 # Repositories (data access layer)
│   ├── Services/              # Business logic layer
│   ├── listenumes/            # Enumerations used across the app
│   ├── Properties/            # Launch settings
│   ├── fonts/                 # Custom fonts
│   ├── wwwroot/               # Static files (css, js, images)
│   └── Program.cs             # Application entry point and service configuration
└── .gitignore
```

## Getting Started

### Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/) with the **ASP.NET and web development** workload
- [.NET SDK](https://dotnet.microsoft.com/download) (the version targeted by the project)
- [Microsoft SQL Server](https://www.microsoft.com/sql-server) (Express edition or LocalDB is enough) and, optionally, SQL Server Management Studio (SSMS)


## Author

**Yassine Touli** – [@yassinetouli](https://github.com/yassinetouli)
