# .NET 6 API

A RESTful API built with .NET 6 and C#, backed by MongoDB. Follows a clean architecture pattern with controllers, DTOs, entities, and a repository layer.

## Built With

- [.NET 6](https://dotnet.microsoft.com/) — framework
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) — language
- [MongoDB](https://www.mongodb.com/) — database

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [MongoDB](https://www.mongodb.com/try/download/community) running locally or a connection string

## Getting Started

```bash
git clone https://github.com/Malcom-Maynard/.NET6API.git
cd .NET6API
```

Update `appsettings.json` with your MongoDB connection string, then run:

```bash
dotnet run
```

## Project Structure

```
.NET6API/
├── Controllers/       # API endpoints
├── Dtos/              # Data transfer objects
├── Entities/          # Domain models
├── Repositories/      # Data access layer
├── Settings/          # Configuration models
├── Extensions.cs      # Service registration extensions
├── Program.cs         # App entry point
└── appsettings.json   # App configuration
```
