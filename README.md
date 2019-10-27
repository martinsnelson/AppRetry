DotNet
dotnet new webapi -n AppRetry.API -f netcoreapp2.2

Swagger
dotnet add package Swashbuckle.AspNetCore --version 4.0.1

CSharp Analyzers Mvc Api
dotnet add package Microsoft.AspNetCore.Mvc.Api.Analyzers --version 2.2.0

AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 5.0.1

Migrations
dotnet add package: Microsoft.EntityFrameworkCore.Tools.DotNet 

dotnet ef migrations add Inicial 

dotnet ef database update

// "applicationUrl": "https://localhost:5001;http://localhost:5000",