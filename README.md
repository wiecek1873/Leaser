# Backend of Leaser Application

The server provides an appropriate web api, which allows renting items. Backend of application is based on clean architecture. You can browse the api through Swagger UI.

Build with:

- .NET 5.0
- ASP.NET Core
- Entity Framework
- Swagger UI
- Microsoft SQL Server
- Visual Studio 2019
- Visual Studio Code

## How to run server

1. Create file **appsettings.json** with the same settings as in **appsettings.defualt.json** in RentalApp.WebApi folder.

2. Set in appsetting.json settings:

- `"RentalAppCS"` - connection string for MSQL database
- `"Key"` - key for JWT Token
- `"TokenLifeTime"` - life time for JWT Token

3. To build the server in folder **scripts** run PowerShell script:

#### `.\dotnet-build.ps1`

4. To run the server in folder **scripts** run PowerShell script:

#### `.\dotnet-run.ps1`

Application will be listen on:

- `http://localhost:5000`

or:

- `https://localhost:5001`

5. Browse api using Swagger UI

- `http://localhost:5000/swagger/index.html`

or:

- `https://localhost:5001/swagger/index.html`
