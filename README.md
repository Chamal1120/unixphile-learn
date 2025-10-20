# Unixphile Learn

A lightweight Learning Management System (LMS). The goal is to make it usable on low end hardware, modular, secure and a maintainable 100% csharp codebase. 

> [!WARNING]
> This application is currently in early development.

- A preview deployed on Azure App Services + Azure SQL can be viewed from [this link](https://unixphile-learn-cne3hjbbb7bnbwdg.canadacentral-01.azurewebsites.net) (uses F1 tier for now, so be patient).
- Check [TODO](/TODO.md) for progress.

## Stack
- **Blazor Server with Minimal APIs**
- **EF Core**
- **Microsoft SQL Server**
- **Auth0**
- **TailwindCSS with daisyUI**

## Getting Started

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
- Microsoft SQL Server
- sqlcmd or SQL Server Management Studio (optional, for database inspection)
- Dotnet ef CLI (use `dotnet tool install --global dotnet-ef`)
- Node and npm (only for TailwindCSS generation)

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/Chamal1120/unixphile-learn.git
   ```
2. Navigate to the project directory:
   ```bash
   cd unixphile-learn
   ```
3. Restore dependencies:
   ```bash
   dotnet restore && npm ci
   ```
4. Set up the database:
   - Ensure your SQL Server instance is running and accessible.
   - Update the connection string in `appsettings.Development.json` to point to your SQL Server instance.
   - Apply migrations to create the database schema:
     ```bash
     dotnet ef database update
     ```

### Running the Application
1. Build the project:
   ```bash
   dotnet build
   ```
2. Run the application with hot reloading:
   ```bash
   dotnet watch
   ```
3. Update TailwindCSS along with hot reloading (run in a seperate terminal):
   ```bash
   npm run dev watch:css
   ```
3. Navigate to the URL displayed in the terminal.

## Deployment
Refer [deployment guide](./deployment-guide.md).

## License
Refer [MIT License](/LICENSE).
