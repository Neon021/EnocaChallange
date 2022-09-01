# This is the source code of the [Movie Web app and it's Api I made in .NET6 w/ ASP.NET CORE MVC and MinimalApi](https://github.com/Neon021/MovieApp)


- [Overview](#overview)
- [Application Architecture](#application-architecture)
- [Technologies](#technologies)
- [Architecture](#architecture)
- [Usage](#usage)
- [VS Extensions](#vscode-extensions)

# Overview

<p>This is one of my initial projects for that it has weak data access layer, however it fully supports CRUD operations and as a bonus it comes with an Api</p>

# Application Architecture
- I've used MVC Model -which stands for Model,Controller and View- for the <code>WebApplication</code> on this project.
- Later on I've added a <code>MinimalApi</code> with *Repostiory* pattern in order to ensure uncoupling between services and scalability.

# Technologies
- ASP.NET CORE 6
- Entity Framework Core
- SQL Server

# Usage
Simply `git clone https://github.com/Neon021/MovieApp.git` and `dotnet run --project MovieApp

# VS Extensions
- [Entity Framework](https://github.com/dotnet/ef6) - EF Core is a data access API that allows you to interact with the database using .NET POCOs (Plain Old CLR Objects) and strongly-typed LINQ.`
