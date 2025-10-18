# Unixphile Learn

A lightweight Learning Management System (LMS) that I'm developing for future potential courses. The goal is to keep it super smooth on low end hardware, modular, secure and 100% csharp codebase. 

> [!WARNING]
> This application is currently in development. Do not use it in production environments without proper testing and security hardening.

> [!NOTE]
> The database file (`lms.db`) is created in the root directory of the project. Ensure you have write permissions in the project directory.

## Features
- **Blazor Server**
- **Microsoft Minimal APIs**
- **EF Core**
- **SQLite**
- **TailwindCSS**

## Getting Started

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
- SQLite (optional, for database inspection)
- Dotnet ef CLI ( use `dotnet tool install --global dotnet-ef`)

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
   dotnet restore
   ```

4. Database Migration:
   ```bash
   dotnet ef database update
   ```

### Running the Application
1. Build the project:
   ```bash
   dotnet build
   ```
2. Run the application:
   ```bash
   dotnet run
   ```
3. Navigate to the URL displayed in the terminal.

## License
This project is licensed under the MIT License.
