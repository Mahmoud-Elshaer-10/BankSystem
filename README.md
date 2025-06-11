# BankSystem

A Windows Forms desktop application for managing bank clients, accounts, and transactions, built with C# and .NET 8. Uses a 3-tier architecture (Data Access, Business, WinForms Presentation) with an ASP.NET Core API, offering dynamic filtering, dynamic form resizing, real-time validation, and intuitive UX.

## Features

- **3-Tier Architecture with API**: SQL Server Data Access via optimized stored procedures (`SET NOCOUNT ON` to reduce network traffic, parameterized queries), Business logic, WinForms UI, and RESTful API.
- **Client Management**: Add, edit, delete, and filter clients by ID, name, email, phone, or address; view related accounts; enforce unique email/phone.
- **Account Management**: Add, edit, delete, and filter accounts by ID, client, or balance; view related client or transactions.
- **Transaction Management**: Create (Deposit, Withdraw, Transfer) and view transactions, filter by account, type, amount, or date.
- **Dashboard**: View summary metrics (total clients, accounts, transactions, total/average balance).
- **Dynamic Filtering**: Real-time filtering using reflection-based dynamic dropdowns, debounced (~300ms) search with field dropdowns (e.g., Client ID, Transaction Date).
- **Dynamic Resizing**: Forms resize to fit `DataGridView` content, respecting initial width to keep controls visible.
- **Real-Time Validation**: ErrorProvider for inputs (e.g., email format, 10-digit phone, positive amount, valid client/account IDs).
- **UX Enhancements**: Custom grid/button, shortcuts (Alt+A to add, Alt+E to edit, Escape to close), resizable forms, multi-monitor support, real-time clock, sortable grids, CSV export, context menus, double-click navigation.
- **Input Restrictions**: Numeric fields (e.g., Amount) allow digits and single .; phone fields allow digits, -, (, ), space; IDs allow digits.
- **API Integration**: CRUD via HTTP calls to `https://localhost:7153/api`.
- **Version Control**: Managed with Git.

## API Endpoints

Base URL: `https://localhost:7153/api`

- **Client**:
  - `GET /Client/paged`
  - `GET /Client/{id}`
  - `GET /Client/Filter`
  - `GET /Client/Summary`
  - `POST /Client`
  - `PUT /Client/{id}`
  - `DELETE /Client/{id}`
- **Account**:
  - `GET /Account/paged`
  - `GET /Account/ByClient/{clientId}`
  - `GET /Account/{id}`
  - `GET /Account/Summary`
  - `POST /Account`
  - `PUT /Account/{id}`
  - `DELETE /Account/{id}`
- **Transaction**:
  - `GET /Transaction/paged`
  - `GET /Transaction/ByAccount/{fromAccountId}`
  - `GET /Transaction/Summary`
  - `POST /Transaction`

## Database

SQL Server (BankSystem):

- **Tables**:
  - `Clients` (ID, FullName, Email, Phone, Address, CreatedAt)
  - `Accounts` (ID, ClientID, Balance, CreatedAt)
  - `TransactionsBase` (ID, FromAccountID, TransactionTypeID, Amount, ToAccountID, Date)
  - `TransactionTypes` (TransactionTypeID, TransactionTypeName: Deposit, Withdraw, Transfer)
- **Views**:
  - `Transactions`: Mimics original `Transactions` table, exposing `TransactionType` as a string by joining `TransactionsBase` and `TransactionTypes`.
- **Triggers**:
  - `TR_Transactions_Insert`: `INSTEAD OF INSERT` on `Transactions` view; maps `TransactionType` string to `TransactionTypeID`, inserts into `TransactionsBase`, returns `TransactionID`.
  - `TR_Transactions_Update`: `INSTEAD OF UPDATE` on `Transactions` view; updates `TransactionsBase` with mapped `TransactionTypeID`.
  - `TR_Transactions_Delete`: `INSTEAD OF DELETE` on `Transactions` view; deletes from `TransactionsBase`.
- **Unused**: `Currencies`, `Users`, `LoginHistory`
- **Stored Procedures**: CRUD, paged/filtered queries (e.g., `GetClientsPaged`, `AddTransaction`), summaries (e.g., `GetAccountSummary`)
- **Constraints**: Foreign keys with cascade delete, unique `TransactionTypeName` in `TransactionTypes`

## Technologies

- **Frontend**: C#, Windows Forms, .NET 8.0
- **Backend**: ASP.NET Core Web API
- **Data Access**: SQL Server 2022, stored procedures, Microsoft.Data.SqlClient
- **Tools**: Swagger, Visual Studio 2022, Git

## Prerequisites

- Visual Studio 2022
- SQL Server
- ASP.NET Core API running (`https://localhost:7153`)

## Setup

1. **Clone Repository**:
   ```bash
   git clone <repository-url>
   cd BankSystem
   ```
2. **Database**:
   - Create database (`BankSystem`).
   - Run `BankSystem.sql` for tables, views, triggers, procedures, and sample data.
   - Update connection string in `C_API/appsettings.json` (e.g., `Server=.;Database=BankSystem;Integrated Security=True;`).
3. **API and WinForms**:
   - Open `BankSystem.sln`.
   - Ensure `ApiClient.cs` uses `https://localhost:7153/api`.
   - Select `WinForms + API` profile.
   - Build and run (F5).

## Usage

From `MainForm`:

- **Clients**: Add, edit, delete, filter, or view accounts of selected client (Alt+C).
- **Accounts**: Add, edit, delete, filter, view client/transactions (Alt+A).
- **Transactions**: Create, view, filter by account/type/date (Alt+T).
- **Dashboard**: View summary stats (Alt+D).
  Use shortcuts (Alt+A, Alt+E, Escape), filter by typing, sort grids, export to CSV, double-click to navigate (e.g., clients to accounts, accounts to transactions), or use context menus.

## Architecture

- **Data Access**: Repository pattern with stored procedures
- **Business**: Entity-based CRUD logic
- **API**: RESTful endpoints for data operations
- **Presentation**: WinForms UI with custom controls (sortable grids, formatted buttons), forms, and API integration

## Notes

- **Validation**: UI enforces unique email/phone, valid IDs, and transaction formats; API adds further checks.
- **Performance**: Paginated API calls, debounced searches.
- **Database Normalization**: `TransactionTypes` and `TransactionsBase` with `Transactions` view ensure efficient storage and app compatibility.
- **API Schema**: Available via Swagger UI.

## Future Improvements

- Add authentication using `Users` table.
- Support currency conversions with `Currencies` table.

## Contributing

Fork, create feature branch, submit pull request.

## Contact

Use GitHub Issues or [email@example.com].