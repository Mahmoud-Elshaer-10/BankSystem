# BankSystem

A simple banking application built to demonstrate C# skills for an entry-level developer role.

## Features

- Manage clients and accounts with CRUD operations.
- 3-tier architecture: Data Access (SQL Server), Business Logic, and Presentation (API + WinForms).
- RESTful API using ASP.NET Core.
- Windows Forms desktop UI for client and account management.
- Console app for testing account business logic.
- Optimized with SET NOCOUNT ON; and custom row tracking
- Used Git for version control

## Technologies

- C#, .NET
- SQL Server with stored procedures
- ASP.NET Core Web API
- Windows Forms

## How to Run

1. Set up a SQL Server database and update the connection string in `A_DataAccess`.
2. Run the `C_API` project to start the API (default: `https://localhost:7153`).
3. Run the `D_WinFormsApp` project to launch the desktop app.
4. Optionally, run `TestConsoleApp` to test account operations via console.
