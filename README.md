# SmartBudget
---
SmartBudget is a clean, production-ready .NET 8 Web API designed to help people track expenses, manage budgets, and make sense of their finances.
It’s not just another demo project. it’s a foundation that shows how real-world backend systems should be structured, tested, and shipped.
---

## Overview

The goal behind SmartBudget is to build something practical and maintainable.
It follows clean architecture principles, separates concerns clearly, and avoids unnecessary complexity.
---
## Features

- Built with .NET 8 and ASP.NET Core Web API
- Entity Framework Core with PostgreSQL
- Layered architecture (API, Application, Core, Infrastructure)
- JWT-based authentication
- Serilog for structured logging
- Docker and Docker Compose for containerized deployment
- Unit tests with xUnit
---
## Quickstart
1. Install .NET 8 SDK and Docker.
2. From repo root:
   ```bash
   dotnet restore
   dotnet build
   ```
3. From `src/SmartBudget.Api`:
   - Add migrations (example):
     ```bash
     dotnet tool install --global dotnet-ef
     dotnet ef migrations add Initial --project ../SmartBudget.Infrastructure --startup-project .
     dotnet ef database update --project ../SmartBudget.Infrastructure --startup-project .
     ```
   - Run:
     ```bash
     dotnet run
     ```
4. Or: `docker compose up --build`