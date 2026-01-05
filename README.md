📘 README – BACKEND

technical_test_sigma_backend

📌 Description

Backend API built with .NET, C#, SQL Server and Entity Framework Core.
Provides endpoints to register customers, manage payments, query customer status, and activate/deactivate customers.
Follows a layered architecture inspired by Clean Architecture.

🛠️ Technologies

.NET (latest LTS)

C#

ASP.NET Core Web API

Entity Framework Core

SQL Server

Dependency Injection

Swagger

HubSpot CRM (integration example)

🏗️ Architecture

The project is structured using a layered architecture:

API → Application → Domain
          ↑
   Infrastructure


API: Controllers and HTTP handling

Application: Business logic and services

Domain: Core entities and enums

Infrastructure: Database access and external services

📦 Main Features

Customer registration (3-step form support)

Address and payment management

Customer status query

Activate / deactivate customer

CRM integration (HubSpot)

DTO-based communication

🗄️ Database

Uses SQL Server with Entity Framework Core (Code First).

Run migrations
dotnet ef migrations add InitialCreate
dotnet ef database update

🚀 Run the project
dotnet restore
dotnet run


Swagger UI will be available at:

https://localhost:<port>/swagger

🔐 Environment Variables

Create a .env file in the root:

HUBSPOT_BASE_URL=your_url
HUBSPOT_ACCESS_TOKEN=your_token

👤 Author

Juan Manuel Sanchez
