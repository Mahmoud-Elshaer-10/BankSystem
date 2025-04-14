# BankSystem

A Windows Forms desktop application for managing bank clients and accounts, built with C# and .NET. Features a 3-tier architecture (SQL Server, ASP.NET Core API, WinForms), dynamic filtering, real-time validation, and keyboard shortcuts for a user-friendly experience.

---

## 🧩 Features

### 🏗️ 3-Tier Architecture

- **Data Access**: SQL Server with stored procedures, optimized using `SET NOCOUNT ON` and custom row tracking.
- **Business Logic**: ASP.NET Core RESTful API (`C_API`) for client/account operations.
- **Presentation**:
  - Windows Forms UI (`D_WinFormsApp`)
  - Console app (`TestConsoleApp`) for testing logic

### 🖥️ Main Dashboard (`MainForm`)

- Access client and account lists with one-click navigation.

### 👤 Client Management

- List, add, edit, delete clients (`ClientListForm`, `ClientForm`)
- Real-time filtering by name, email, phone, address using reflection-based dynamic dropdowns
- Validation with `ErrorProvider`:
  - Full name (required)
  - Email format
  - Phone format (`123-456-7890`)
  - Address

### 💰 Account Management

- List, add, edit, delete accounts (`AccountListForm`, `AccountForm`)
- Filter by client ID, balance with ~500ms debounced search
- Validation:
  - Balance ≥ 0
  - Client ID exists (verified via API)

### 🧑‍💻 UX Enhancements

- Custom buttons (`MyButton`) with icons, padding, consistent size (`86x37`)
- Real-time error feedback via `ErrorProvider` (clears on field exit)
- Keyboard shortcuts:
  - `Alt+A` (Add)
  - `Alt+E` (Edit)
  - `Alt+D` (Delete)
  - Tooltips and context menu entries show shortcuts
- Forms set as `TopMost` to stay focused
- Clock display pinned to the top-right corner of all forms

### 🔗 API Integration

- CRUD operations via HTTP (`ApiClient`) to ASP.NET Core API

### 🧪 Testing

- Console app (`TestConsoleApp`) for business logic validation

### 🧾 Version Control

- Managed with Git for collaborative development

---

## 🧰 Technologies

- **Frontend**: C#, Windows Forms, .NET Framework (4.8) or .NET (6.0+)
- **Backend**: ASP.NET Core Web API
- **Database**: SQL Server with stored procedures
- **Tools**: Visual Studio 2022, Git

---

## ⚙️ Prerequisites

- .NET Framework (4.8) or .NET (6.0+)
- Visual Studio 2022 (or compatible IDE)
- SQL Server (local or remote)
- ASP.NET Core API running (default: `https://localhost:7153`)

---

## 🛠️ Setup

1. **Clone Repository**:

   ```bash
   git clone <repository-url>
   cd BankSystem
   ```

2. **Database**:

   - Create a SQL Server database (e.g., `BankSystemDB`)
   - Run scripts in `A_DataAccess/Scripts` to create tables and stored procedures
   - Update the connection string in `A_DataAccess` (e.g., in `DatabaseHelper.cs`)

3. **API**:

   - Open `C_API/C_API.sln` in Visual Studio
   - Build and run (`F5`)
   - Ensure the API runs at `https://localhost:7153`

4. **WinForms App**:

   - Open `D_WinFormsApp/BankSystem.sln`
   - Update `ApiClient.cs` base URL if needed (e.g., `https://localhost:7153`)
   - Build (`Ctrl+Shift+B`) and run (`F5`) — `MainForm` opens

5. **Console Testing (Optional)**:
   - Open `TestConsoleApp/TestConsoleApp.sln`
   - Build and run to test account logic

---

## ▶️ Usage

### 🔹 MainForm

- Click “Clients” (`Alt+C`) or “Accounts” (`Alt+A`) to view lists

### 🔹 ClientListForm

- **Filter**: Type in search box, select field (e.g., “Full Name”) from dropdown
- **Actions**: Add (`Alt+A`), Edit (`Alt+E`), Delete (`Alt+D`), Show Accounts (`Alt+S`)
- Records count updates dynamically (`Records: N`)

### 🔹 ClientForm

- Enter name, email, phone, address
- Errors show next to fields (e.g., “Invalid phone format”), clear on fix
- Save (`Alt+S`), Cancel (`Alt+C`)

### 🔹 AccountListForm

- Filter by client ID, balance
- Actions: Add (`Alt+A`), Edit (`Alt+E`), Delete (`Alt+D`), Show Client (`Alt+S`)

### 🔹 AccountForm

- Enter balance, client ID (verified via API)
- Save (`Alt+S`), Cancel (`Alt+C`) — shows errors for invalid client or negative balance

---

## 📁 Project Structure

- **A_DataAccess**: SQL Server access, stored procedures, connection logic
- **C_API**: ASP.NET Core API for client/account CRUD
- **D_WinFormsApp**:
  - **Forms**:
    - `MainForm.cs`: App entry point
    - `ClientListForm.cs`, `AccountListForm.cs`: Filtered grids
    - `ClientForm.cs`, `AccountForm.cs`: Data entry with validation
    - `MyForm.cs`: Base form (clock, `ErrorProvider`, `TopMost`, tooltips)
  - **Controls**:
    - `MyButton.cs`: Styled buttons (icons, shortcuts)
  - **Helpers**:
    - `ApiClient.cs`: HTTP client for API calls
    - `FormMode.cs`: Enum for add/edit modes
  - **Models**:
    - `Client.cs`: ClientID, FullName, Email, Phone, Address
    - `Account.cs`: AccountID, ClientID, Balance
- **TestConsoleApp**: Console app for account logic tests

---

## 📝 Notes

- **Validation**: Real-time checks (e.g., email format, balance ≥ 0) via `ErrorProvider`, clears on field exit
- **Filters**: Dynamic dropdowns (reflection-based), debounced (~500ms) for smooth API calls
- **Shortcuts**: Buttons and context menus show shortcuts (e.g., “Add (Alt+A)”) with tooltips
- **Performance**: Optimized SQL with `SET NOCOUNT ON`, efficient API calls

---

## 🚀 Future Improvements

- Add `TransactionListForm` for managing deposits and withdrawals
- Format grid columns (e.g., `$123.45` for balance)
- Validate duplicate emails or client IDs via API
- Add CSV export for clients/accounts
