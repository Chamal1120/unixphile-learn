# Unixphile Learn

A lightweight Learning Management System (LMS). The goal is to keep it super smooth on low end hardware, modular, secure and 100% csharp. 

> [!WARNING]
> This application is currently in early development. Do not use it in production environments.

## Stack
- **Blazor Server**
- **Microsoft Minimal APIs**
- **EF Core**
- **Microsoft SQL Server**
- **TailwindCSS with daisyUI**

## Getting Started

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
- Microsoft SQL Server
- SQL Server Management Studio  or sqlcmd (optional, for database inspection)
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

## License
This project is licensed under the MIT License.
