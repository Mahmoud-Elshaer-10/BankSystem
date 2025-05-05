# BankSystem

A Windows Forms desktop application for managing bank clients and accounts, built with C# and .NET. Features a 3-tier architecture (SQL Server, ASP.NET Core API, WinForms), dynamic form resizing, dynamic filtering, real-time validation, and keyboard shortcuts for a polished, user-friendly experience.

---

## 🧩 Features

### 🏗️ 3-Tier Architecture

- **Data Access**: SQL Server with optimized stored procedures (`SET NOCOUNT ON`, parameterized queries).
- **Business Logic**: ASP.NET Core RESTful API (`C_API`) for client/account CRUD and summary operations.
- **Presentation**:
  - Windows Forms UI (`D_WinFormsApp`) with responsive forms.
  - Console app (`TestConsoleApp`) for testing business logic.

### 🖥️ Main Dashboard (`MainForm`)

- One-click navigation to client and account lists.

### 👤 Client Management

- List, add, edit, delete clients (`ClientListForm`, `ClientForm`).
- Real-time filtering by name, email, phone, address using reflection-based dynamic dropdowns.
- Validation via `ErrorProvider`:
  - Full name (required).
  - Email format (`user@domain.com`).
  - Phone format (`123-456-7890`).
  - Address.

### 💰 Account Management

- List, add, edit, delete accounts (`AccountListForm`, `AccountForm`).
- Filter by client ID, balance with ~500ms debounced search.
- Validation:
  - Balance ≥ 0.
  - Client ID verified via API.

### 🧑‍💻 UX Enhancements

- **Custom Controls**: `MyButton` with icons, padding, consistent sizing.
- **Real-Time Feedback**: `ErrorProvider` shows errors next to fields, clears on fix.
- **Keyboard Shortcuts**:
  - `Alt+A` (Add), `Alt+E` (Edit), `Alt+D` (Delete), `Alt+S` (Show).
  - Tooltips and context menus display shortcuts.
- **Dynamic Resizing**: Forms resize to fit `DataGridView` content, respecting initial width to keep controls visible.
- **Multi-Monitor Support**: Forms center on the current monitor using `Screen.FromControl`.
- **Clock Display**: Real-time clock pinned to top-right corner of all forms.
- **TopMost Forms**: Stay focused during data entry.

### 🔗 API Integration

- Efficient CRUD operations via `ApiClient` (HTTP calls to ASP.NET Core API).

### 🧪 Testing

- `TestConsoleApp` validates business logic and API integration.

### 🧾 Version Control

- Managed with Git for collaborative development and change tracking.

---

## 🧰 Technologies

- **Frontend**: C#, Windows Forms, .NET Core.
- **Backend**: ASP.NET Core Web API.
- **Database**: SQL Server with stored procedures.
- **Tools**: Visual Studio 2022, Git.

---

## ⚙️ Prerequisites

- .NET Framework (4.8) or .NET (6.0+).
- Visual Studio 2022 (or compatible IDE).
- SQL Server (local or remote).
- ASP.NET Core API running (default: `https://localhost:7153`).

---

## 🛠️ Setup

1. **Clone Repository**:

   ```bash
   git clone <repository-url>
   cd BankSystem
   ```

2. **Database**:

   - Create a SQL Server database (e.g., `BankSystemDB`).
   - Run script BankSystem.sql to set up tables and stored procedures.
   - Update connection string in `C_API/appsettings.json`.

3. **API**:

   - Open `C_API/C_API.sln` in Visual Studio.
   - Build and run (`F5`). Ensure API runs at `https://localhost:7153`.

4. **WinForms App**:

   - Open `D_WinFormsApp/BankSystem.sln`.
   - Update `ApiClient.cs` base URL if needed (`https://localhost:7153`).
   - Build (`Ctrl+Shift+B`) and run (`F5`). `MainForm` opens.

5. **Console Testing (Optional)**:

   - Open `TestConsoleApp/TestConsoleApp.sln`.
   - Build and run to test business logic.

---

## ▶️ Usage

### 🔹 MainForm

- Click “Clients” (`Alt+C`) or “Accounts” (`Alt+A`) to navigate.

### 🔹 ClientListForm

- **Filter**: Type in search box, select field (e.g., “Full Name”) from dropdown.
- **Actions**: Add (`Alt+A`), Edit (`Alt+E`), Delete (`Alt+D`), Show Accounts (`Alt+S`).
- **Records**: Dynamic count (`Records: N`).

### 🔹 ClientForm

- Enter name, email, phone, address.
- Errors appear next to fields (e.g., “Invalid phone format”), clear on fix.
- Save (`Alt+S`), Cancel (`Alt+C`).

### 🔹 AccountListForm

- Filter by client ID, balance.
- Actions: Add (`Alt+A`), Edit (`Alt+E`), Delete (`Alt+D`), Show Client (`Alt+S`).

### 🔹 AccountForm

- Enter balance, client ID (API-verified).
- Save (`Alt+S`), Cancel (`Alt+C`). Errors for invalid client or negative balance.

---

## 📁 Project Structure

- **A_DataAccess**: SQL Server access, stored procedures, connection logic.
- **C_API**: ASP.NET Core API for client/account CRUD.
- **D_WinFormsApp**:
  - **Forms**:
    - `MainForm.cs`: App entry point.
    - `ClientListForm.cs`, `AccountListForm.cs`: Filtered grids.
    - `ClientForm.cs`, `AccountForm.cs`: Data entry with validation.
    - `MyForm.cs`: Base form (clock, `ErrorProvider`, resizing, multi-monitor, `TopMost`, tooltips).
  - **Controls**:
    - `MyButton.cs`: Styled buttons with icons.
    - `MyDataGridView.cs`: Custom grid for data display.
  - **Helpers**:
    - `ApiClient.cs`: HTTP client for API calls.
    - `FormMode.cs`: Enum for add/edit modes.
  - **Models**:
    - `Client.cs`: ClientID, FullName, Email, Phone, Address, CreatedAt (nullable).
    - `Account.cs`: AccountID, ClientID, Balance.
- **TestConsoleApp**: Console app for logic tests.

---

## 📝 Notes

- **Validation**: Real-time checks (email, balance, client ID) via `ErrorProvider`, clears on field exit.
- **Filters**: Reflection-based dropdowns, debounced (~300ms) for efficient API calls.
- **Resizing**: Forms dynamically adjust to `DataGridView` content, with anchoring fixes to prevent width issues.
- **Shortcuts**: Buttons/context menus show shortcuts (e.g., “Add (Alt+A)”) with tooltips.
- **Performance**: Optimized SQL, efficient API calls, single-call resizing.

---

## 🚀 Future Improvements

- Add `TransactionListForm` for deposits/withdrawals.
- Validate duplicate emails or client IDs via API.
- Add user authentication (login form).

---

## 🙌 Contributing

Contributions are welcome! Please fork the repository, create a feature branch, and submit a pull request with clear descriptions of changes.

---

## 📧 Contact

For questions or feedback, reach out via GitHub Issues or [email@example.com].