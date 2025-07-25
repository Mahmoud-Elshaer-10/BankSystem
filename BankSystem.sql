USE [master]
GO
/****** Object:  Database [BankSystem]    Script Date: 6/11/2025 5:43:34 PM ******/
CREATE DATABASE [BankSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BankSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BankSystem.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BankSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BankSystem_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BankSystem] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BankSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BankSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BankSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BankSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BankSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BankSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [BankSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BankSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BankSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BankSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BankSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BankSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BankSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BankSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BankSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BankSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BankSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BankSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BankSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BankSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BankSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BankSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BankSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BankSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [BankSystem] SET  MULTI_USER 
GO
ALTER DATABASE [BankSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BankSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BankSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BankSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BankSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BankSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BankSystem', N'ON'
GO
ALTER DATABASE [BankSystem] SET QUERY_STORE = ON
GO
ALTER DATABASE [BankSystem] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BankSystem]
GO
/****** Object:  Table [dbo].[TransactionTypes]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionTypes](
	[TransactionTypeID] [int] NOT NULL,
	[TransactionTypeName] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TransactionTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionsBase]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionsBase](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[FromAccountID] [int] NOT NULL,
	[TransactionTypeID] [int] NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[ToAccountID] [int] NULL,
	[TransactionDate] [datetime] NULL,
 CONSTRAINT [PK__Transact__55433A4B1CC3B508] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Transactions]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 9. Create view to mimic original Transactions table
CREATE VIEW [dbo].[Transactions]
AS
SELECT 
    t.TransactionID,
    t.FromAccountID,
    tt.TransactionTypeName AS TransactionType,
    t.Amount,
    t.ToAccountID,
    t.TransactionDate
FROM TransactionsBase t
JOIN TransactionTypes tt ON t.TransactionTypeID = tt.TransactionTypeID;
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[Balance] [decimal](10, 2) NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK__Accounts__349DA58609D2E814] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](255) NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currencies](
	[CurrencyID] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyCode] [nvarchar](3) NOT NULL,
	[CurrencyName] [nvarchar](50) NULL,
	[ExchangeRate] [decimal](18, 6) NOT NULL,
	[LastUpdated] [datetime] NULL,
 CONSTRAINT [PK__Currenci__14470B1067205E2F] PRIMARY KEY CLUSTERED 
(
	[CurrencyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginHistory]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginHistory](
	[LoginID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[LoginTime] [datetime] NULL,
	[IPAddress] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[LoginID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
	[Role] [nvarchar](20) NULL,
	[Permissions] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK__Users__1788CCAC13C6FC65] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (4, 3, CAST(400.00 AS Decimal(10, 2)), CAST(N'2025-03-30T17:08:16.093' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (5, 4, CAST(-100.00 AS Decimal(10, 2)), CAST(N'2025-03-30T17:08:16.093' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (6, 5, CAST(1200.25 AS Decimal(10, 2)), CAST(N'2025-03-30T17:08:16.093' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (7, 6, CAST(750.60 AS Decimal(10, 2)), CAST(N'2025-03-30T17:08:16.093' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (8, 7, CAST(-55.00 AS Decimal(10, 2)), CAST(N'2025-03-30T17:08:16.093' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (9, 8, CAST(200.00 AS Decimal(10, 2)), CAST(N'2025-03-30T17:08:16.093' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (10, 9, CAST(3300.40 AS Decimal(10, 2)), CAST(N'2025-03-30T17:08:16.093' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (11, 10, CAST(-600.00 AS Decimal(10, 2)), CAST(N'2025-03-30T17:08:16.093' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (14, 3, CAST(320.00 AS Decimal(10, 2)), CAST(N'2025-03-30T17:38:16.820' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (15, 4, CAST(5000.00 AS Decimal(10, 2)), CAST(N'2025-03-30T17:38:16.820' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (16, 5, CAST(1200.25 AS Decimal(10, 2)), CAST(N'2025-03-30T17:38:16.820' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (17, 6, CAST(750.60 AS Decimal(10, 2)), CAST(N'2025-03-30T17:38:16.820' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (18, 7, CAST(6000.90 AS Decimal(10, 2)), CAST(N'2025-03-30T17:38:16.820' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (19, 8, CAST(200.00 AS Decimal(10, 2)), CAST(N'2025-03-30T17:38:16.820' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (20, 9, CAST(3300.40 AS Decimal(10, 2)), CAST(N'2025-03-30T17:38:16.820' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (21, 9, CAST(400.00 AS Decimal(10, 2)), CAST(N'2025-03-30T17:38:16.820' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (60, 3, CAST(2500.75 AS Decimal(10, 2)), CAST(N'2025-05-20T09:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (61, 4, CAST(1800.50 AS Decimal(10, 2)), CAST(N'2025-04-25T14:30:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (62, 5, CAST(3200.25 AS Decimal(10, 2)), CAST(N'2025-03-15T11:15:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (63, 6, CAST(-200.80 AS Decimal(10, 2)), CAST(N'2025-02-10T16:45:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (64, 7, CAST(4500.30 AS Decimal(10, 2)), CAST(N'2025-01-05T08:20:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (65, 8, CAST(1200.60 AS Decimal(10, 2)), CAST(N'2024-12-20T13:10:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (66, 9, CAST(2800.90 AS Decimal(10, 2)), CAST(N'2024-11-15T10:50:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (67, 10, CAST(600.45 AS Decimal(10, 2)), CAST(N'2024-10-10T15:25:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (68, 59, CAST(1500.75 AS Decimal(10, 2)), CAST(N'2025-05-20T09:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (69, 59, CAST(3200.50 AS Decimal(10, 2)), CAST(N'2025-05-15T14:30:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (70, 60, CAST(850.25 AS Decimal(10, 2)), CAST(N'2025-04-25T14:30:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (71, 61, CAST(4200.00 AS Decimal(10, 2)), CAST(N'2025-03-15T11:15:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (72, 62, CAST(600.80 AS Decimal(10, 2)), CAST(N'2025-02-10T16:45:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (73, 62, CAST(2800.30 AS Decimal(10, 2)), CAST(N'2025-02-05T08:20:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (74, 63, CAST(1200.60 AS Decimal(10, 2)), CAST(N'2025-01-05T08:20:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (75, 64, CAST(5000.00 AS Decimal(10, 2)), CAST(N'2024-12-20T13:10:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (76, 65, CAST(300.45 AS Decimal(10, 2)), CAST(N'2024-11-15T10:50:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (77, 65, CAST(1800.90 AS Decimal(10, 2)), CAST(N'2024-11-10T15:25:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (78, 66, CAST(2500.75 AS Decimal(10, 2)), CAST(N'2024-10-10T15:25:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (79, 67, CAST(3200.50 AS Decimal(10, 2)), CAST(N'2024-09-05T12:40:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (80, 68, CAST(850.25 AS Decimal(10, 2)), CAST(N'2024-08-01T17:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (81, 68, CAST(4200.00 AS Decimal(10, 2)), CAST(N'2024-07-25T09:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (82, 69, CAST(600.80 AS Decimal(10, 2)), CAST(N'2024-07-15T09:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (83, 70, CAST(-150.30 AS Decimal(10, 2)), CAST(N'2024-06-20T14:30:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (84, 71, CAST(1200.60 AS Decimal(10, 2)), CAST(N'2025-05-10T10:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (85, 72, CAST(5000.00 AS Decimal(10, 2)), CAST(N'2025-04-05T15:45:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (86, 72, CAST(300.45 AS Decimal(10, 2)), CAST(N'2025-03-30T12:30:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (87, 73, CAST(1800.90 AS Decimal(10, 2)), CAST(N'2025-03-01T12:30:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (88, 74, CAST(2500.75 AS Decimal(10, 2)), CAST(N'2025-02-15T09:15:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (89, 75, CAST(-400.50 AS Decimal(10, 2)), CAST(N'2025-01-10T14:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (90, 76, CAST(850.25 AS Decimal(10, 2)), CAST(N'2024-12-05T11:20:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (91, 76, CAST(4200.00 AS Decimal(10, 2)), CAST(N'2024-11-30T16:50:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (92, 77, CAST(600.80 AS Decimal(10, 2)), CAST(N'2024-11-27T16:50:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (93, 78, CAST(2800.30 AS Decimal(10, 2)), CAST(N'2024-11-10T13:40:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (94, 79, CAST(1200.60 AS Decimal(10, 2)), CAST(N'2024-10-15T13:50:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (95, 80, CAST(5000.00 AS Decimal(10, 2)), CAST(N'2024-09-20T10:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (96, 80, CAST(300.45 AS Decimal(10, 2)), CAST(N'2024-09-15T11:15:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (97, 81, CAST(1800.90 AS Decimal(10, 2)), CAST(N'2024-08-25T15:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (98, 82, CAST(2500.75 AS Decimal(10, 2)), CAST(N'2024-07-25T12:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (99, 83, CAST(3200.50 AS Decimal(10, 2)), CAST(N'2025-05-15T14:45:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (100, 84, CAST(850.25 AS Decimal(10, 2)), CAST(N'2025-04-20T11:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (101, 84, CAST(4200.00 AS Decimal(10, 2)), CAST(N'2025-04-15T16:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (102, 85, CAST(-250.80 AS Decimal(10, 2)), CAST(N'2025-03-25T14:30:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (103, 86, CAST(2800.30 AS Decimal(10, 2)), CAST(N'2025-02-28T13:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (104, 87, CAST(1200.60 AS Decimal(10, 2)), CAST(N'2025-01-25T10:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (105, 88, CAST(5000.00 AS Decimal(10, 2)), CAST(N'2024-12-30T14:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (106, 89, CAST(300.45 AS Decimal(10, 2)), CAST(N'2024-12-10T12:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (107, 90, CAST(1800.90 AS Decimal(10, 2)), CAST(N'2024-11-25T10:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (108, 90, CAST(2500.75 AS Decimal(10, 2)), CAST(N'2024-11-20T11:30:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (109, 91, CAST(3200.50 AS Decimal(10, 2)), CAST(N'2024-11-10T14:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (110, 92, CAST(850.25 AS Decimal(10, 2)), CAST(N'2024-10-25T11:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (111, 93, CAST(4200.00 AS Decimal(10, 2)), CAST(N'2024-10-05T16:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (112, 94, CAST(600.80 AS Decimal(10, 2)), CAST(N'2024-09-25T13:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (113, 94, CAST(-300.30 AS Decimal(10, 2)), CAST(N'2024-09-20T14:30:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (114, 95, CAST(2800.30 AS Decimal(10, 2)), CAST(N'2024-09-10T10:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (115, 96, CAST(1200.60 AS Decimal(10, 2)), CAST(N'2024-08-30T15:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (116, 97, CAST(5000.00 AS Decimal(10, 2)), CAST(N'2024-08-15T12:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (117, 98, CAST(300.45 AS Decimal(10, 2)), CAST(N'2024-08-05T09:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (118, 98, CAST(1800.90 AS Decimal(10, 2)), CAST(N'2024-07-31T10:30:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (119, 99, CAST(2520.75 AS Decimal(10, 2)), CAST(N'2024-07-25T14:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (120, 59, CAST(3200.50 AS Decimal(10, 2)), CAST(N'2025-05-10T09:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (121, 60, CAST(850.25 AS Decimal(10, 2)), CAST(N'2025-04-20T14:30:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (122, 61, CAST(4200.00 AS Decimal(10, 2)), CAST(N'2025-03-10T11:15:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (123, 63, CAST(600.80 AS Decimal(10, 2)), CAST(N'2025-01-01T16:45:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (124, 64, CAST(-200.30 AS Decimal(10, 2)), CAST(N'2024-12-15T08:20:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (125, 66, CAST(1200.60 AS Decimal(10, 2)), CAST(N'2024-10-05T13:10:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (126, 67, CAST(5000.00 AS Decimal(10, 2)), CAST(N'2024-09-01T10:50:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (127, 69, CAST(300.45 AS Decimal(10, 2)), CAST(N'2024-07-10T15:25:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (128, 71, CAST(1800.90 AS Decimal(10, 2)), CAST(N'2025-05-05T12:40:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (129, 73, CAST(2500.75 AS Decimal(10, 2)), CAST(N'2025-02-25T17:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (130, 75, CAST(3200.50 AS Decimal(10, 2)), CAST(N'2025-01-05T09:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (131, 77, CAST(850.25 AS Decimal(10, 2)), CAST(N'2024-11-20T14:30:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (132, 79, CAST(4200.00 AS Decimal(10, 2)), CAST(N'2024-10-10T10:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (133, 81, CAST(600.80 AS Decimal(10, 2)), CAST(N'2024-08-20T15:45:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (134, 83, CAST(-150.60 AS Decimal(10, 2)), CAST(N'2025-05-01T12:30:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (135, 85, CAST(2800.30 AS Decimal(10, 2)), CAST(N'2025-03-20T09:15:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (136, 87, CAST(1200.60 AS Decimal(10, 2)), CAST(N'2025-01-15T14:00:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (137, 89, CAST(5000.00 AS Decimal(10, 2)), CAST(N'2024-12-05T11:20:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (138, 91, CAST(300.45 AS Decimal(10, 2)), CAST(N'2024-11-05T16:50:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (139, 93, CAST(1800.90 AS Decimal(10, 2)), CAST(N'2024-10-01T13:40:00.000' AS DateTime))
INSERT [dbo].[Accounts] ([AccountID], [ClientID], [Balance], [CreatedAt]) VALUES (142, 3, CAST(999.00 AS Decimal(10, 2)), CAST(N'2025-06-11T17:25:52.800' AS DateTime))
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (3, N'Michael Johnson', N'michael@example.com', N'555-123-4564', N'789 Oak St', CAST(N'2025-03-30T16:50:59.257' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (4, N'Emily Davis', N'emily@example.com', N'444-987-6546', N'101 Pine St', CAST(N'2025-03-30T16:50:59.257' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (5, N'Chris Brown', N'chris@example.com', N'333-654-9872', N'202 Maple St', CAST(N'2025-03-30T16:50:59.257' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (6, N'Sarah Wilson', N'sarah@example.com', N'222-321-6547', N'303 Cedar St', CAST(N'2025-03-30T16:50:59.257' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (7, N'David Miller', N'david@example.com', N'111-789-1232', N'404 Birch St', CAST(N'2025-03-30T16:50:59.257' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (8, N'Laura Moore', N'laura@example.com', N'666-987-3213', N'505 Walnut St', CAST(N'2025-03-30T16:50:59.257' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (9, N'Kevin Taylor', N'kevin@example.com', N'777-654-7828', N'606 Cherry St', CAST(N'2025-03-30T16:50:59.257' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (10, N'Emma White', N'emma@example.com', N'888-123-9876', N'707 Spruce St', CAST(N'2025-03-30T16:50:59.257' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (11, N'John Doe', N'johndoe@example.com', N'123-456-7890', N'123 Main St', CAST(N'2025-03-30T21:51:28.233' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (59, N'Robert Wilson', N'robert.wilson@email.com', N'555-234-5678', N'808 Laurel St, Bloomington, IL 61701', CAST(N'2025-05-20T09:00:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (60, N'Sophia Garcia', N'sophia.garcia@email.com', N'555-345-6789', N'909 Magnolia Dr, Peoria, IL 61604', CAST(N'2025-04-25T14:30:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (61, N'Thomas Clark', N'thomas.clark@email.com', N'555-456-7890', N'1010 Chestnut Ave, Rockford, IL 61101', CAST(N'2025-03-15T11:15:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (62, N'Isabella Lee', N'isabella.lee@email.com', N'555-567-8901', N'1111 Willow Rd, Joliet, IL 60435', CAST(N'2025-02-10T16:45:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (63, N'Daniel Martinez', N'daniel.martinez@email.com', N'555-678-9012', N'1212 Sycamore Ln, Aurora, IL 60504', CAST(N'2025-01-05T08:20:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (64, N'Olivia Brown', N'olivia.brown@email.com', N'555-789-0123', N'1313 Cedar Ct, Naperville, IL 60540', CAST(N'2024-12-20T13:10:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (65, N'James Taylor', N'james.taylor@email.com', N'555-890-1234', N'1414 Birch St, Elgin, IL 60123', CAST(N'2024-11-15T10:50:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (66, N'Charlotte Davis', N'charlotte.davis@email.com', N'555-901-2345', N'1515 Oakwood Dr, Waukegan, IL 60085', CAST(N'2024-10-10T15:25:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (67, N'William Anderson', N'william.anderson@email.com', N'555-012-3456', N'1616 Maple Pl, Champaign, IL 61820', CAST(N'2024-09-05T12:40:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (68, N'Amelia Thomas', N'amelia.thomas@email.com', N'555-123-4567', N'1717 Pine St, Springfield, IL 62701', CAST(N'2024-08-01T17:00:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (69, N'Ethan Walker', N'ethan.walker@email.com', N'555-234-5679', N'1818 Elm St, Decatur, IL 62521', CAST(N'2024-07-15T09:00:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (70, N'Ava Rodriguez', N'ava.rodriguez@email.com', N'555-345-6780', N'1919 Oak Dr, Quincy, IL 62301', CAST(N'2024-06-20T14:30:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (71, N'Liam Harris', N'liam.harris@email.com', N'555-456-7891', N'2020 Cedar Rd, Moline, IL 61265', CAST(N'2025-05-10T10:00:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (72, N'Mia Lewis', N'mia.lewis@email.com', N'555-567-8902', N'2121 Birch Ave, Evanston, IL 60201', CAST(N'2025-04-05T15:45:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (73, N'Noah Young', N'noah.young@email.com', N'555-678-9013', N'2222 Maple St, Skokie, IL 60077', CAST(N'2025-03-01T12:30:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (74, N'Emma Allen', N'emma.allen@email.com', N'555-789-0124', N'2323 Pine Ct, Cicero, IL 60804', CAST(N'2025-02-15T09:15:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (75, N'Lucas King', N'lucas.king@email.com', N'555-890-1235', N'2424 Oak Ln, Berwyn, IL 60402', CAST(N'2025-01-10T14:00:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (76, N'Harper Wright', N'harper.wright@email.com', N'555-901-2346', N'2525 Elm Dr, Oak Park, IL 60302', CAST(N'2024-12-05T11:20:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (77, N'Mason Scott', N'mason.scott@email.com', N'555-012-3457', N'2626 Cedar St, Schaumburg, IL 60193', CAST(N'2024-11-01T16:50:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (78, N'Evelyn Green', N'evelyn.green@email.com', N'555-123-4568', N'2727 Birch Rd, Palatine, IL 60067', CAST(N'2024-10-15T13:40:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (79, N'Logan Adams', N'logan.adams@email.com', N'555-234-5670', N'2828 Maple Ave, Arlington Heights, IL 60005', CAST(N'2024-09-20T10:25:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (80, N'Aria Baker', N'aria.baker@email.com', N'555-345-6781', N'2929 Pine Dr, Des Plaines, IL 60018', CAST(N'2024-08-25T15:10:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (81, N'Jacob Nelson', N'jacob.nelson@email.com', N'555-456-7892', N'3030 Oak St, Mount Prospect, IL 60056', CAST(N'2024-07-30T12:00:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (82, N'Scarlett Carter', N'scarlett.carter@email.com', N'555-567-8903', N'3131 Elm Ct, Wheaton, IL 60187', CAST(N'2024-07-05T09:30:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (83, N'Benjamin Hill', N'benjamin.hill@email.com', N'555-678-9014', N'3232 Cedar Ln, Glenview, IL 60025', CAST(N'2025-05-15T14:45:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (84, N'Chloe Mitchell', N'chloe.mitchell@email.com', N'555-789-0125', N'3333 Birch St, Lombard, IL 60148', CAST(N'2025-04-20T11:15:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (85, N'Henry Perez', N'henry.perez@email.com', N'555-890-1236', N'3434 Maple Rd, Downers Grove, IL 60515', CAST(N'2025-03-25T16:30:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (86, N'Zoe Roberts', N'zoe.roberts@email.com', N'555-901-2347', N'3535 Pine Ave, Bolingbrook, IL 60440', CAST(N'2025-02-28T13:00:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (87, N'Jack Turner', N'jack.turner@email.com', N'555-012-3458', N'3636 Oak Dr, Tinley Park, IL 60477', CAST(N'2025-01-25T10:10:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (88, N'Lily Phillips', N'lily.phillips@email.com', N'555-123-4569', N'3737 Elm St, Orland Park, IL 60462', CAST(N'2024-12-30T15:25:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (89, N'Owen Campbell', N'owen.campbell@email.com', N'555-234-5671', N'3838 Cedar Rd, Hoffman Estates, IL 60192', CAST(N'2024-12-10T12:50:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (90, N'Grace Parker', N'grace.parker@email.com', N'555-345-6782', N'3939 Birch Ln, Buffalo Grove, IL 60089', CAST(N'2024-11-25T09:40:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (91, N'Samuel Evans', N'samuel.evans@email.com', N'555-456-7893', N'4040 Maple Ct, Carol Stream, IL 60188', CAST(N'2024-11-10T14:20:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (92, N'Hannah Edwards', N'hannah.edwards@email.com', N'555-567-8904', N'4141 Pine St, Streamwood, IL 60107', CAST(N'2024-10-25T11:00:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (93, N'Alexander Collins', N'alexander.collins@email.com', N'555-678-9015', N'4242 Oak Ave, Hanover Park, IL 60133', CAST(N'2024-10-05T16:15:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (94, N'Victoria Stewart', N'victoria.stewart@email.com', N'555-789-0126', N'4343 Elm Dr, Addison, IL 60101', CAST(N'2024-09-25T13:30:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (95, N'Michael Sanchez', N'michael.sanchez@email.com', N'555-890-1237', N'4444 Cedar St, Woodridge, IL 60517', CAST(N'2024-09-10T10:45:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (96, N'Abigail Morris', N'abigail.morris@email.com', N'555-901-2348', N'4545 Birch Rd, Romeoville, IL 60446', CAST(N'2024-08-30T15:00:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (97, N'David Rogers', N'david.rogers@email.com', N'555-012-3459', N'4646 Maple Ln, Plainfield, IL 60586', CAST(N'2024-08-15T12:10:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (98, N'Ella Reed', N'ella.reed@email.com', N'555-123-4570', N'4747 Pine Ct, Oswego, IL 60543', CAST(N'2024-08-05T09:25:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (99, N'Joseph Cook', N'joseph.cook@email.com', N'555-234-5672', N'4848 Oak St, Yorkville, IL 60560', CAST(N'2024-07-25T14:40:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (100, N'Sofia Bailey', N'sofia.bailey@email.com', N'555-345-6783', N'4949 Elm Dr, St. Charles, IL 60175', CAST(N'2024-07-15T11:55:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (101, N'Andrew Rivera', N'andrew.rivera@email.com', N'555-456-7894', N'5050 Cedar Ave, Geneva, IL 60134', CAST(N'2024-07-05T16:30:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (102, N'Avery Ward', N'avery.ward@email.com', N'555-567-8905', N'5151 Birch St, Batavia, IL 60510', CAST(N'2024-06-25T13:45:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (103, N'Matthew Gray', N'matthew.gray@email.com', N'555-678-9016', N'5252 Maple Rd, West Chicago, IL 60185', CAST(N'2024-06-15T10:00:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (104, N'Layla Griffin', N'layla.griffin@email.com', N'555-789-0127', N'5353 Pine Ln, Warrenville, IL 60555', CAST(N'2024-06-10T15:15:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (105, N'Christopher Bell', N'christopher.bell@email.com', N'555-890-1238', N'5454 Oak Ct, Lisle, IL 60532', CAST(N'2024-06-05T12:30:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (106, N'Natalie Ross', N'natalie.ross@email.com', N'555-901-2349', N'5555 Elm St, Darien, IL 60561', CAST(N'2024-06-01T09:45:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (107, N'Ryan Murphy', N'ryan.murphy@email.com', N'555-012-3460', N'5656 Cedar Dr, Burr Ridge, IL 60527', CAST(N'2025-05-25T14:00:00.000' AS DateTime))
INSERT [dbo].[Clients] ([ClientID], [FullName], [Email], [Phone], [Address], [CreatedAt]) VALUES (108, N'Leah Foster', N'leah.foster@email.com', N'555-123-4571', N'5757 Birch Ave, Hinsdale, IL 60521', CAST(N'2025-05-27T11:20:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[TransactionsBase] ON 

INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (3, 6, 1, CAST(500.00 AS Decimal(10, 2)), NULL, CAST(N'2025-03-30T17:38:16.823' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (6, 4, 3, CAST(1000.00 AS Decimal(10, 2)), 7, CAST(N'2025-03-30T17:38:16.823' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (7, 5, 2, CAST(300.00 AS Decimal(10, 2)), NULL, CAST(N'2025-03-30T17:38:16.823' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (8, 4, 1, CAST(100.00 AS Decimal(10, 2)), NULL, CAST(N'2025-05-06T20:25:30.417' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (12, 4, 2, CAST(200.00 AS Decimal(10, 2)), NULL, CAST(N'2025-05-07T19:18:10.927' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (13, 4, 1, CAST(300.00 AS Decimal(10, 2)), NULL, CAST(N'2025-05-19T19:45:44.940' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (31, 4, 1, CAST(750.25 AS Decimal(10, 2)), NULL, CAST(N'2025-05-25T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (32, 5, 2, CAST(200.50 AS Decimal(10, 2)), NULL, CAST(N'2025-05-20T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (33, 6, 3, CAST(500.00 AS Decimal(10, 2)), 14, CAST(N'2025-05-15T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (34, 7, 1, CAST(1200.75 AS Decimal(10, 2)), NULL, CAST(N'2025-05-10T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (35, 8, 2, CAST(100.30 AS Decimal(10, 2)), NULL, CAST(N'2025-05-05T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (36, 9, 1, CAST(800.60 AS Decimal(10, 2)), NULL, CAST(N'2025-04-30T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (37, 10, 3, CAST(300.45 AS Decimal(10, 2)), 15, CAST(N'2025-04-25T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (38, 11, 1, CAST(1500.90 AS Decimal(10, 2)), NULL, CAST(N'2025-04-20T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (39, 14, 2, CAST(400.25 AS Decimal(10, 2)), NULL, CAST(N'2025-04-15T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (40, 15, 1, CAST(2000.50 AS Decimal(10, 2)), NULL, CAST(N'2025-04-10T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (41, 16, 1, CAST(600.75 AS Decimal(10, 2)), NULL, CAST(N'2025-04-05T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (42, 17, 2, CAST(150.20 AS Decimal(10, 2)), NULL, CAST(N'2025-03-30T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (43, 18, 3, CAST(1000.00 AS Decimal(10, 2)), 4, CAST(N'2025-03-25T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (44, 19, 1, CAST(900.30 AS Decimal(10, 2)), NULL, CAST(N'2025-03-20T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (45, 20, 2, CAST(250.60 AS Decimal(10, 2)), NULL, CAST(N'2025-03-15T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (46, 21, 1, CAST(1100.45 AS Decimal(10, 2)), NULL, CAST(N'2025-03-10T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (47, 60, 1, CAST(1300.90 AS Decimal(10, 2)), NULL, CAST(N'2025-03-05T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (48, 61, 2, CAST(300.25 AS Decimal(10, 2)), NULL, CAST(N'2025-02-28T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (49, 62, 3, CAST(700.50 AS Decimal(10, 2)), 16, CAST(N'2025-02-25T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (50, 63, 1, CAST(850.75 AS Decimal(10, 2)), NULL, CAST(N'2025-02-20T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (51, 64, 1, CAST(950.20 AS Decimal(10, 2)), NULL, CAST(N'2025-02-15T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (52, 65, 2, CAST(200.30 AS Decimal(10, 2)), NULL, CAST(N'2025-02-10T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (53, 66, 1, CAST(1400.60 AS Decimal(10, 2)), NULL, CAST(N'2025-02-05T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (54, 67, 3, CAST(400.45 AS Decimal(10, 2)), 17, CAST(N'2025-01-31T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (55, 68, 1, CAST(1600.90 AS Decimal(10, 2)), NULL, CAST(N'2025-01-25T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (56, 69, 2, CAST(350.25 AS Decimal(10, 2)), NULL, CAST(N'2025-01-20T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (57, 70, 1, CAST(1800.50 AS Decimal(10, 2)), NULL, CAST(N'2025-01-15T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (58, 71, 1, CAST(650.75 AS Decimal(10, 2)), NULL, CAST(N'2025-01-10T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (59, 72, 2, CAST(100.20 AS Decimal(10, 2)), NULL, CAST(N'2025-01-05T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (60, 73, 3, CAST(800.30 AS Decimal(10, 2)), 18, CAST(N'2024-12-31T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (61, 74, 1, CAST(1200.60 AS Decimal(10, 2)), NULL, CAST(N'2024-12-25T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (62, 75, 1, CAST(700.45 AS Decimal(10, 2)), NULL, CAST(N'2024-12-20T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (63, 76, 2, CAST(250.90 AS Decimal(10, 2)), NULL, CAST(N'2024-12-15T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (64, 77, 1, CAST(900.25 AS Decimal(10, 2)), NULL, CAST(N'2024-12-10T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (65, 78, 3, CAST(600.50 AS Decimal(10, 2)), 19, CAST(N'2024-12-05T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (66, 79, 1, CAST(1100.75 AS Decimal(10, 2)), NULL, CAST(N'2024-11-30T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (67, 80, 2, CAST(300.20 AS Decimal(10, 2)), NULL, CAST(N'2024-11-25T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (68, 81, 1, CAST(1300.30 AS Decimal(10, 2)), NULL, CAST(N'2024-11-20T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (69, 82, 1, CAST(1500.60 AS Decimal(10, 2)), NULL, CAST(N'2024-11-15T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (70, 83, 2, CAST(400.45 AS Decimal(10, 2)), NULL, CAST(N'2024-11-10T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (71, 84, 3, CAST(200.90 AS Decimal(10, 2)), 20, CAST(N'2024-11-05T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (72, 85, 1, CAST(1700.25 AS Decimal(10, 2)), NULL, CAST(N'2024-10-31T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (73, 86, 1, CAST(800.50 AS Decimal(10, 2)), NULL, CAST(N'2024-10-25T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (74, 87, 2, CAST(150.75 AS Decimal(10, 2)), NULL, CAST(N'2024-10-20T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (75, 88, 1, CAST(900.20 AS Decimal(10, 2)), NULL, CAST(N'2024-10-15T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (76, 89, 3, CAST(1000.30 AS Decimal(10, 2)), 21, CAST(N'2024-10-10T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (77, 90, 1, CAST(1100.60 AS Decimal(10, 2)), NULL, CAST(N'2024-10-05T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (78, 91, 1, CAST(1200.45 AS Decimal(10, 2)), NULL, CAST(N'2024-09-30T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (79, 92, 2, CAST(200.90 AS Decimal(10, 2)), NULL, CAST(N'2024-09-25T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (80, 93, 1, CAST(1300.25 AS Decimal(10, 2)), NULL, CAST(N'2024-09-20T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (81, 94, 3, CAST(300.50 AS Decimal(10, 2)), 60, CAST(N'2024-09-15T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (82, 95, 1, CAST(1400.75 AS Decimal(10, 2)), NULL, CAST(N'2024-09-10T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (83, 96, 2, CAST(250.20 AS Decimal(10, 2)), NULL, CAST(N'2024-09-05T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (84, 97, 1, CAST(1500.30 AS Decimal(10, 2)), NULL, CAST(N'2024-08-31T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (85, 98, 1, CAST(1600.60 AS Decimal(10, 2)), NULL, CAST(N'2024-08-25T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (86, 99, 2, CAST(300.45 AS Decimal(10, 2)), NULL, CAST(N'2024-08-20T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (87, 100, 3, CAST(400.90 AS Decimal(10, 2)), 61, CAST(N'2024-08-15T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (88, 101, 1, CAST(1700.25 AS Decimal(10, 2)), NULL, CAST(N'2024-08-10T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (89, 102, 1, CAST(800.50 AS Decimal(10, 2)), NULL, CAST(N'2024-08-05T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (90, 103, 2, CAST(100.75 AS Decimal(10, 2)), NULL, CAST(N'2024-07-31T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (91, 104, 1, CAST(900.20 AS Decimal(10, 2)), NULL, CAST(N'2024-07-25T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (92, 105, 3, CAST(2000.30 AS Decimal(10, 2)), 62, CAST(N'2024-07-20T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (93, 106, 1, CAST(1000.60 AS Decimal(10, 2)), NULL, CAST(N'2024-07-15T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (94, 107, 1, CAST(1100.45 AS Decimal(10, 2)), NULL, CAST(N'2024-07-10T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (95, 108, 2, CAST(150.90 AS Decimal(10, 2)), NULL, CAST(N'2024-07-05T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (96, 109, 1, CAST(1200.25 AS Decimal(10, 2)), NULL, CAST(N'2024-06-30T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (97, 110, 3, CAST(300.50 AS Decimal(10, 2)), 63, CAST(N'2024-06-25T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (98, 111, 1, CAST(1300.75 AS Decimal(10, 2)), NULL, CAST(N'2024-06-20T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (99, 112, 2, CAST(200.20 AS Decimal(10, 2)), NULL, CAST(N'2024-06-15T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (100, 113, 1, CAST(1400.30 AS Decimal(10, 2)), NULL, CAST(N'2024-06-10T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (101, 114, 1, CAST(1500.60 AS Decimal(10, 2)), NULL, CAST(N'2024-06-05T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (102, 115, 2, CAST(250.45 AS Decimal(10, 2)), NULL, CAST(N'2024-06-01T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (103, 116, 3, CAST(400.90 AS Decimal(10, 2)), 64, CAST(N'2025-05-27T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (104, 117, 1, CAST(1600.25 AS Decimal(10, 2)), NULL, CAST(N'2025-05-22T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (105, 118, 1, CAST(1700.50 AS Decimal(10, 2)), NULL, CAST(N'2025-05-17T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (106, 119, 2, CAST(300.75 AS Decimal(10, 2)), NULL, CAST(N'2025-05-12T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (107, 120, 1, CAST(800.20 AS Decimal(10, 2)), NULL, CAST(N'2025-05-07T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (108, 121, 3, CAST(500.30 AS Decimal(10, 2)), 65, CAST(N'2025-05-02T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (109, 122, 1, CAST(900.60 AS Decimal(10, 2)), NULL, CAST(N'2025-04-27T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (110, 123, 1, CAST(1000.45 AS Decimal(10, 2)), NULL, CAST(N'2025-04-22T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (111, 124, 2, CAST(150.90 AS Decimal(10, 2)), NULL, CAST(N'2025-04-17T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (112, 125, 1, CAST(1100.25 AS Decimal(10, 2)), NULL, CAST(N'2025-04-12T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (113, 126, 3, CAST(200.50 AS Decimal(10, 2)), 66, CAST(N'2025-04-07T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (114, 127, 1, CAST(1200.75 AS Decimal(10, 2)), NULL, CAST(N'2025-04-02T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (115, 128, 2, CAST(200.20 AS Decimal(10, 2)), NULL, CAST(N'2025-03-28T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (116, 129, 1, CAST(1300.30 AS Decimal(10, 2)), NULL, CAST(N'2025-03-23T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (117, 130, 1, CAST(1400.60 AS Decimal(10, 2)), NULL, CAST(N'2025-03-18T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (118, 131, 2, CAST(250.45 AS Decimal(10, 2)), NULL, CAST(N'2025-03-13T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (119, 132, 3, CAST(300.90 AS Decimal(10, 2)), 67, CAST(N'2025-03-08T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (120, 133, 1, CAST(1500.25 AS Decimal(10, 2)), NULL, CAST(N'2025-03-03T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (121, 134, 1, CAST(1600.50 AS Decimal(10, 2)), NULL, CAST(N'2025-02-26T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (122, 135, 2, CAST(300.75 AS Decimal(10, 2)), NULL, CAST(N'2025-02-21T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (123, 136, 1, CAST(1700.20 AS Decimal(10, 2)), NULL, CAST(N'2025-02-16T11:15:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (124, 137, 3, CAST(400.30 AS Decimal(10, 2)), 68, CAST(N'2025-02-11T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (125, 138, 1, CAST(800.60 AS Decimal(10, 2)), NULL, CAST(N'2025-02-06T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (126, 139, 1, CAST(900.45 AS Decimal(10, 2)), NULL, CAST(N'2025-02-01T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (127, 4, 2, CAST(150.90 AS Decimal(10, 2)), NULL, CAST(N'2025-01-27T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (128, 5, 1, CAST(1000.25 AS Decimal(10, 2)), NULL, CAST(N'2025-01-22T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (129, 6, 3, CAST(200.50 AS Decimal(10, 2)), 69, CAST(N'2025-01-17T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (130, 7, 1, CAST(1100.75 AS Decimal(10, 2)), NULL, CAST(N'2025-01-12T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (131, 8, 1, CAST(1200.20 AS Decimal(10, 2)), NULL, CAST(N'2025-01-07T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (132, 9, 2, CAST(200.30 AS Decimal(10, 2)), NULL, CAST(N'2025-01-02T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (133, 10, 1, CAST(1300.60 AS Decimal(10, 2)), NULL, CAST(N'2024-12-28T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (134, 11, 3, CAST(300.45 AS Decimal(10, 2)), 70, CAST(N'2024-12-23T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (135, 14, 1, CAST(1400.90 AS Decimal(10, 2)), NULL, CAST(N'2024-12-18T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (136, 15, 2, CAST(250.25 AS Decimal(10, 2)), NULL, CAST(N'2024-12-13T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (137, 16, 1, CAST(1500.50 AS Decimal(10, 2)), NULL, CAST(N'2024-12-08T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (138, 17, 1, CAST(1600.75 AS Decimal(10, 2)), NULL, CAST(N'2024-12-03T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (139, 18, 2, CAST(300.20 AS Decimal(10, 2)), NULL, CAST(N'2024-11-28T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (140, 19, 3, CAST(400.30 AS Decimal(10, 2)), 71, CAST(N'2024-11-23T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (141, 20, 1, CAST(1700.60 AS Decimal(10, 2)), NULL, CAST(N'2024-11-18T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (142, 21, 1, CAST(800.45 AS Decimal(10, 2)), NULL, CAST(N'2024-11-13T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (143, 60, 2, CAST(150.90 AS Decimal(10, 2)), NULL, CAST(N'2024-11-08T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (144, 61, 1, CAST(900.25 AS Decimal(10, 2)), NULL, CAST(N'2024-11-03T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (145, 62, 3, CAST(200.50 AS Decimal(10, 2)), 72, CAST(N'2024-10-29T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (146, 63, 1, CAST(1000.75 AS Decimal(10, 2)), NULL, CAST(N'2024-10-24T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (147, 64, 2, CAST(200.20 AS Decimal(10, 2)), NULL, CAST(N'2024-10-19T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (148, 65, 1, CAST(1100.30 AS Decimal(10, 2)), NULL, CAST(N'2024-10-14T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (149, 66, 1, CAST(1200.60 AS Decimal(10, 2)), NULL, CAST(N'2024-10-09T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (150, 67, 2, CAST(250.45 AS Decimal(10, 2)), NULL, CAST(N'2024-10-04T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (151, 68, 3, CAST(300.90 AS Decimal(10, 2)), 73, CAST(N'2024-09-29T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (152, 69, 1, CAST(1300.25 AS Decimal(10, 2)), NULL, CAST(N'2024-09-24T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (153, 70, 1, CAST(1400.50 AS Decimal(10, 2)), NULL, CAST(N'2024-09-19T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (154, 71, 2, CAST(300.75 AS Decimal(10, 2)), NULL, CAST(N'2024-09-14T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (155, 72, 1, CAST(1500.20 AS Decimal(10, 2)), NULL, CAST(N'2024-09-09T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (156, 73, 3, CAST(400.30 AS Decimal(10, 2)), 74, CAST(N'2024-09-04T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (157, 74, 1, CAST(1600.60 AS Decimal(10, 2)), NULL, CAST(N'2024-08-30T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (158, 75, 1, CAST(1700.45 AS Decimal(10, 2)), NULL, CAST(N'2024-08-25T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (159, 76, 2, CAST(150.90 AS Decimal(10, 2)), NULL, CAST(N'2024-08-20T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (160, 77, 1, CAST(800.25 AS Decimal(10, 2)), NULL, CAST(N'2024-08-15T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (161, 78, 3, CAST(200.50 AS Decimal(10, 2)), 75, CAST(N'2024-08-10T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (162, 79, 1, CAST(900.75 AS Decimal(10, 2)), NULL, CAST(N'2024-08-05T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (163, 80, 2, CAST(200.20 AS Decimal(10, 2)), NULL, CAST(N'2024-07-31T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (164, 81, 1, CAST(1000.30 AS Decimal(10, 2)), NULL, CAST(N'2024-07-26T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (165, 82, 1, CAST(1100.60 AS Decimal(10, 2)), NULL, CAST(N'2024-07-21T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (166, 83, 2, CAST(250.45 AS Decimal(10, 2)), NULL, CAST(N'2024-07-16T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (167, 84, 3, CAST(300.90 AS Decimal(10, 2)), 76, CAST(N'2024-07-11T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (168, 85, 1, CAST(1200.25 AS Decimal(10, 2)), NULL, CAST(N'2024-07-06T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (169, 86, 1, CAST(1300.50 AS Decimal(10, 2)), NULL, CAST(N'2024-07-01T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (170, 87, 2, CAST(300.75 AS Decimal(10, 2)), NULL, CAST(N'2024-06-26T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (171, 88, 1, CAST(1400.20 AS Decimal(10, 2)), NULL, CAST(N'2024-06-21T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (172, 89, 3, CAST(400.30 AS Decimal(10, 2)), 77, CAST(N'2024-06-16T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (173, 90, 1, CAST(1500.60 AS Decimal(10, 2)), NULL, CAST(N'2024-06-11T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (174, 91, 1, CAST(1600.45 AS Decimal(10, 2)), NULL, CAST(N'2024-06-06T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (175, 92, 2, CAST(150.90 AS Decimal(10, 2)), NULL, CAST(N'2024-06-01T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (176, 93, 1, CAST(1700.25 AS Decimal(10, 2)), NULL, CAST(N'2025-05-26T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (177, 94, 3, CAST(200.50 AS Decimal(10, 2)), 78, CAST(N'2025-05-21T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (178, 95, 1, CAST(800.75 AS Decimal(10, 2)), NULL, CAST(N'2025-05-16T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (179, 96, 2, CAST(200.20 AS Decimal(10, 2)), NULL, CAST(N'2025-05-11T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (180, 97, 1, CAST(900.30 AS Decimal(10, 2)), NULL, CAST(N'2025-05-06T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (181, 98, 1, CAST(1000.60 AS Decimal(10, 2)), NULL, CAST(N'2025-05-01T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (182, 99, 2, CAST(250.45 AS Decimal(10, 2)), NULL, CAST(N'2025-04-26T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (183, 100, 3, CAST(300.90 AS Decimal(10, 2)), 79, CAST(N'2025-04-21T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (184, 101, 1, CAST(1100.25 AS Decimal(10, 2)), NULL, CAST(N'2025-04-16T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (185, 102, 1, CAST(1200.50 AS Decimal(10, 2)), NULL, CAST(N'2025-04-11T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (186, 103, 2, CAST(300.75 AS Decimal(10, 2)), NULL, CAST(N'2025-04-06T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (187, 104, 1, CAST(1300.20 AS Decimal(10, 2)), NULL, CAST(N'2025-04-01T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (188, 105, 3, CAST(400.30 AS Decimal(10, 2)), 80, CAST(N'2025-03-27T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (189, 106, 1, CAST(1400.60 AS Decimal(10, 2)), NULL, CAST(N'2025-03-22T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (190, 107, 1, CAST(1500.45 AS Decimal(10, 2)), NULL, CAST(N'2025-03-17T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (191, 108, 2, CAST(150.90 AS Decimal(10, 2)), NULL, CAST(N'2025-03-12T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (192, 109, 1, CAST(1600.25 AS Decimal(10, 2)), NULL, CAST(N'2025-03-07T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (193, 110, 3, CAST(200.50 AS Decimal(10, 2)), 81, CAST(N'2025-03-02T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (194, 111, 1, CAST(1700.75 AS Decimal(10, 2)), NULL, CAST(N'2025-02-25T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (195, 112, 2, CAST(200.20 AS Decimal(10, 2)), NULL, CAST(N'2025-02-20T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (196, 113, 1, CAST(800.30 AS Decimal(10, 2)), NULL, CAST(N'2025-02-15T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (197, 114, 1, CAST(900.60 AS Decimal(10, 2)), NULL, CAST(N'2025-02-10T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (198, 115, 2, CAST(250.45 AS Decimal(10, 2)), NULL, CAST(N'2025-02-05T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (199, 116, 3, CAST(300.90 AS Decimal(10, 2)), 82, CAST(N'2025-01-31T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (200, 117, 1, CAST(1000.25 AS Decimal(10, 2)), NULL, CAST(N'2025-01-26T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (201, 118, 1, CAST(1100.50 AS Decimal(10, 2)), NULL, CAST(N'2025-01-21T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (202, 119, 2, CAST(300.75 AS Decimal(10, 2)), NULL, CAST(N'2025-01-16T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (203, 120, 1, CAST(1200.20 AS Decimal(10, 2)), NULL, CAST(N'2025-01-11T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (204, 121, 3, CAST(400.30 AS Decimal(10, 2)), 83, CAST(N'2025-01-06T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (205, 122, 1, CAST(1300.60 AS Decimal(10, 2)), NULL, CAST(N'2025-01-01T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (206, 123, 1, CAST(1400.45 AS Decimal(10, 2)), NULL, CAST(N'2024-12-27T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (207, 124, 2, CAST(150.90 AS Decimal(10, 2)), NULL, CAST(N'2024-12-22T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (208, 125, 1, CAST(1500.25 AS Decimal(10, 2)), NULL, CAST(N'2024-12-17T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (209, 126, 3, CAST(200.50 AS Decimal(10, 2)), 84, CAST(N'2024-12-12T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (210, 127, 1, CAST(1600.75 AS Decimal(10, 2)), NULL, CAST(N'2024-12-07T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (211, 128, 1, CAST(1700.20 AS Decimal(10, 2)), NULL, CAST(N'2024-12-02T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (212, 129, 2, CAST(200.30 AS Decimal(10, 2)), NULL, CAST(N'2024-11-27T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (213, 130, 1, CAST(800.60 AS Decimal(10, 2)), NULL, CAST(N'2024-11-22T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (214, 131, 3, CAST(300.45 AS Decimal(10, 2)), 85, CAST(N'2024-11-17T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (215, 132, 1, CAST(900.90 AS Decimal(10, 2)), NULL, CAST(N'2024-11-12T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (216, 133, 2, CAST(250.25 AS Decimal(10, 2)), NULL, CAST(N'2024-11-07T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (217, 134, 1, CAST(1000.50 AS Decimal(10, 2)), NULL, CAST(N'2024-11-02T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (218, 135, 1, CAST(1100.75 AS Decimal(10, 2)), NULL, CAST(N'2024-10-28T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (219, 136, 2, CAST(300.20 AS Decimal(10, 2)), NULL, CAST(N'2024-10-23T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (220, 137, 3, CAST(400.30 AS Decimal(10, 2)), 86, CAST(N'2024-10-18T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (221, 138, 1, CAST(1200.60 AS Decimal(10, 2)), NULL, CAST(N'2024-10-13T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (222, 139, 1, CAST(1300.45 AS Decimal(10, 2)), NULL, CAST(N'2024-10-08T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (223, 4, 2, CAST(150.90 AS Decimal(10, 2)), NULL, CAST(N'2024-10-03T11:15:00.000' AS DateTime))
GO
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (224, 5, 1, CAST(1400.25 AS Decimal(10, 2)), NULL, CAST(N'2024-09-28T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (225, 6, 3, CAST(200.50 AS Decimal(10, 2)), 87, CAST(N'2024-09-23T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (226, 7, 1, CAST(1500.75 AS Decimal(10, 2)), NULL, CAST(N'2024-09-18T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (227, 8, 2, CAST(200.20 AS Decimal(10, 2)), NULL, CAST(N'2024-09-13T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (228, 9, 1, CAST(1600.30 AS Decimal(10, 2)), NULL, CAST(N'2024-09-08T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (229, 10, 1, CAST(1700.60 AS Decimal(10, 2)), NULL, CAST(N'2024-09-03T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (230, 11, 2, CAST(250.45 AS Decimal(10, 2)), NULL, CAST(N'2024-08-29T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (231, 14, 3, CAST(300.90 AS Decimal(10, 2)), 88, CAST(N'2024-08-24T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (232, 15, 1, CAST(800.25 AS Decimal(10, 2)), NULL, CAST(N'2024-08-19T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (233, 16, 1, CAST(900.50 AS Decimal(10, 2)), NULL, CAST(N'2024-08-14T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (234, 17, 2, CAST(300.75 AS Decimal(10, 2)), NULL, CAST(N'2024-08-09T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (235, 18, 1, CAST(1000.20 AS Decimal(10, 2)), NULL, CAST(N'2024-08-04T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (236, 19, 3, CAST(400.30 AS Decimal(10, 2)), 89, CAST(N'2024-07-30T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (237, 20, 1, CAST(1100.60 AS Decimal(10, 2)), NULL, CAST(N'2024-07-25T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (238, 21, 1, CAST(1200.45 AS Decimal(10, 2)), NULL, CAST(N'2024-07-20T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (239, 60, 2, CAST(150.90 AS Decimal(10, 2)), NULL, CAST(N'2024-07-15T12:40:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (240, 61, 1, CAST(1300.25 AS Decimal(10, 2)), NULL, CAST(N'2024-07-10T17:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (241, 62, 3, CAST(200.50 AS Decimal(10, 2)), 90, CAST(N'2024-07-05T09:00:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (242, 63, 1, CAST(1400.75 AS Decimal(10, 2)), NULL, CAST(N'2024-06-30T14:30:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (243, 64, 2, CAST(200.20 AS Decimal(10, 2)), NULL, CAST(N'2024-06-25T11:15:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (244, 65, 1, CAST(1500.30 AS Decimal(10, 2)), NULL, CAST(N'2024-06-20T16:45:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (245, 66, 1, CAST(1600.60 AS Decimal(10, 2)), NULL, CAST(N'2024-06-15T08:20:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (246, 67, 2, CAST(250.45 AS Decimal(10, 2)), NULL, CAST(N'2024-06-10T13:10:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (247, 68, 3, CAST(300.90 AS Decimal(10, 2)), 91, CAST(N'2024-06-05T10:50:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (248, 69, 1, CAST(1700.25 AS Decimal(10, 2)), NULL, CAST(N'2024-06-01T15:25:00.000' AS DateTime))
INSERT [dbo].[TransactionsBase] ([TransactionID], [FromAccountID], [TransactionTypeID], [Amount], [ToAccountID], [TransactionDate]) VALUES (250, 6, 1, CAST(100.00 AS Decimal(10, 2)), NULL, NULL)
SET IDENTITY_INSERT [dbo].[TransactionsBase] OFF
GO
INSERT [dbo].[TransactionTypes] ([TransactionTypeID], [TransactionTypeName]) VALUES (1, N'Deposit')
INSERT [dbo].[TransactionTypes] ([TransactionTypeID], [TransactionTypeName]) VALUES (3, N'Transfer')
INSERT [dbo].[TransactionTypes] ([TransactionTypeID], [TransactionTypeName]) VALUES (2, N'Withdraw')
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Username], [PasswordHash], [Role], [Permissions], [CreatedAt]) VALUES (1, N'admin', N'hashedpassword1', NULL, -1, CAST(N'2025-03-30T16:50:59.260' AS DateTime))
INSERT [dbo].[Users] ([UserID], [Username], [PasswordHash], [Role], [Permissions], [CreatedAt]) VALUES (2, N'cashier1', N'hashedpassword2', NULL, 32, CAST(N'2025-03-30T16:50:59.260' AS DateTime))
INSERT [dbo].[Users] ([UserID], [Username], [PasswordHash], [Role], [Permissions], [CreatedAt]) VALUES (3, N'manager', N'hashedpassword3', NULL, 64, CAST(N'2025-03-30T16:50:59.260' AS DateTime))
INSERT [dbo].[Users] ([UserID], [Username], [PasswordHash], [Role], [Permissions], [CreatedAt]) VALUES (4, N'support', N'hashedpassword4', NULL, 17, CAST(N'2025-03-30T16:50:59.260' AS DateTime))
INSERT [dbo].[Users] ([UserID], [Username], [PasswordHash], [Role], [Permissions], [CreatedAt]) VALUES (5, N'auditor', N'hashedpassword5', NULL, 128, CAST(N'2025-03-30T16:50:59.260' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Currenci__408426BF8BC77471]    Script Date: 6/11/2025 5:43:34 PM ******/
ALTER TABLE [dbo].[Currencies] ADD  CONSTRAINT [UQ__Currenci__408426BF8BC77471] UNIQUE NONCLUSTERED 
(
	[CurrencyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Transact__2BE3AC2479DB0C6B]    Script Date: 6/11/2025 5:43:34 PM ******/
ALTER TABLE [dbo].[TransactionTypes] ADD UNIQUE NONCLUSTERED 
(
	[TransactionTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__536C85E472B6E9F9]    Script Date: 6/11/2025 5:43:34 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ__Users__536C85E472B6E9F9] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF__Accounts__Balanc__3D5E1FD2]  DEFAULT ((0)) FOR [Balance]
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF__Accounts__Create__3E52440B]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Clients] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Currencies] ADD  CONSTRAINT [DF__Currencie__LastU__4F7CD00D]  DEFAULT (getdate()) FOR [LastUpdated]
GO
ALTER TABLE [dbo].[LoginHistory] ADD  DEFAULT (getdate()) FOR [LoginTime]
GO
ALTER TABLE [dbo].[TransactionsBase] ADD  CONSTRAINT [DF__Transacti__Trans__4316F928]  DEFAULT (getdate()) FOR [TransactionDate]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__Permissio__5AEE82B9]  DEFAULT ((0)) FOR [Permissions]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__CreatedAt__47DBAE45]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK__Accounts__Client__3C69FB99] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK__Accounts__Client__3C69FB99]
GO
ALTER TABLE [dbo].[LoginHistory]  WITH CHECK ADD  CONSTRAINT [FK__LoginHist__UserI__4AB81AF0] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LoginHistory] CHECK CONSTRAINT [FK__LoginHist__UserI__4AB81AF0]
GO
ALTER TABLE [dbo].[TransactionsBase]  WITH CHECK ADD  CONSTRAINT [FK_TransactionsBase_FromAccountID] FOREIGN KEY([FromAccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TransactionsBase] CHECK CONSTRAINT [FK_TransactionsBase_FromAccountID]
GO
ALTER TABLE [dbo].[TransactionsBase]  WITH CHECK ADD  CONSTRAINT [FK_TransactionsBase_TransactionTypes] FOREIGN KEY([TransactionTypeID])
REFERENCES [dbo].[TransactionTypes] ([TransactionTypeID])
GO
ALTER TABLE [dbo].[TransactionsBase] CHECK CONSTRAINT [FK_TransactionsBase_TransactionTypes]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK__Users__Role__46E78A0C] CHECK  (([Role]='Teller' OR [Role]='Admin'))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK__Users__Role__46E78A0C]
GO
/****** Object:  StoredProcedure [dbo].[AddAccount]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAccount]
    @ClientID INT,
    @Balance DECIMAL(10,2)
AS
BEGIN
SET NOCOUNT ON;
    INSERT INTO Accounts (ClientID, Balance)
    VALUES (@ClientID, @Balance);

    SELECT SCOPE_IDENTITY();
END;
GO
/****** Object:  StoredProcedure [dbo].[AddClient]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddClient]
    @FullName NVARCHAR(100),
    @Email NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Address NVARCHAR(255)
AS
BEGIN
SET NOCOUNT ON;
    INSERT INTO Clients (FullName, Email, Phone, Address)
    VALUES (@FullName, @Email, @Phone, @Address);

    SELECT SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[AddTransaction]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddTransaction]
    @FromAccountID INT,
    @TransactionType NVARCHAR(20),
    @Amount DECIMAL(10,2),
    @ToAccountID INT = NULL,
    @TransactionDate DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @FromBalance DECIMAL(10,2);
    DECLARE @ToBalance DECIMAL(10,2);

    IF @TransactionDate IS NULL SET @TransactionDate = GETDATE();

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Validate FromAccountID exists
        SELECT @FromBalance = Balance FROM Accounts WHERE AccountID = @FromAccountID;
        IF @FromBalance IS NULL
            THROW 50001, 'Invalid FromAccountID.', 1;

        -- Validate ToAccountID for Transfer
        IF @TransactionType = 'Transfer' AND @ToAccountID IS NOT NULL
        BEGIN
            SELECT @ToBalance = Balance FROM Accounts WHERE AccountID = @ToAccountID;
            IF @ToBalance IS NULL
                THROW 50002, 'Invalid ToAccountID.', 1;
        END

        -- Validate sufficient funds for Withdrawal/Transfer
        IF @TransactionType IN ('Withdraw', 'Transfer') AND @FromBalance < @Amount
            THROW 50003, 'Insufficient funds.', 1;

        -- Update balances based on transaction type
        IF @TransactionType = 'Deposit'
            UPDATE Accounts SET Balance = Balance + @Amount WHERE AccountID = @FromAccountID;
        ELSE IF @TransactionType = 'Withdraw'
            UPDATE Accounts SET Balance = Balance - @Amount WHERE AccountID = @FromAccountID;
        ELSE IF @TransactionType = 'Transfer'
        BEGIN
            UPDATE Accounts SET Balance = Balance - @Amount WHERE AccountID = @FromAccountID;
            UPDATE Accounts SET Balance = Balance + @Amount WHERE AccountID = @ToAccountID;
        END

        -- Insert transaction record
        INSERT INTO Transactions (FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate)
        VALUES (@FromAccountID, @TransactionType, @Amount, @ToAccountID, @TransactionDate);

        SELECT SCOPE_IDENTITY();

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteAccount]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteAccount]
    @AccountID INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Accounts
    OUTPUT deleted.AccountID
    WHERE AccountID = @AccountID;
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteClient]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteClient]
    @ClientID INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Clients
    OUTPUT deleted.ClientID
    WHERE ClientID = @ClientID;
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteTransaction]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteTransaction]
    @TransactionID INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Transactions
    OUTPUT deleted.TransactionID
    WHERE TransactionID = @TransactionID;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAccountByID]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAccountByID]
    @AccountID INT
AS
BEGIN
SET NOCOUNT ON;
    SELECT * FROM Accounts WHERE AccountID = @AccountID;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAccountsByClient]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAccountsByClient]
    @ClientID INT
AS
BEGIN
SET NOCOUNT ON;
    SELECT AccountID, ClientID, Balance, CreatedAt
    FROM Accounts
    WHERE ClientID = @ClientID;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAccountsByFilter]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAccountsByFilter]
    @Field NVARCHAR(50),
    @Value NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    IF @Field = '' AND @Value = ''
        SELECT AccountID, ClientID, Balance, CreatedAt FROM Accounts;
    ELSE IF @Field = 'AccountID'
        SELECT AccountID, ClientID, Balance, CreatedAt FROM Accounts WHERE AccountID = CAST(@Value AS INT);
    ELSE IF @Field = 'ClientID'
        SELECT AccountID, ClientID, Balance, CreatedAt FROM Accounts WHERE ClientID = CAST(@Value AS INT);
    ELSE IF @Field = 'Balance'
        SELECT AccountID, ClientID, Balance, CreatedAt FROM Accounts WHERE CAST(Balance AS NVARCHAR(20)) LIKE '%' + @Value + '%';
    ELSE IF @Field = 'CreatedAt'
        SELECT AccountID, ClientID, Balance, CreatedAt FROM Accounts WHERE CAST(CreatedAt AS DATE) = CAST(TRY_CONVERT(DATETIME, @Value) AS DATE);
    ELSE
        SELECT AccountID, ClientID, Balance, CreatedAt FROM Accounts;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAccountsCount]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAccountsCount]
    @Field NVARCHAR(50) = '',
    @Value NVARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;

    IF @Field = '' AND @Value = ''
        SELECT COUNT(*) FROM Accounts;
    ELSE IF @Field = 'AccountID'
        SELECT COUNT(*) FROM Accounts WHERE AccountID = CAST(@Value AS INT);
    ELSE IF @Field = 'ClientID'
        SELECT COUNT(*) FROM Accounts WHERE ClientID = CAST(@Value AS INT);
    ELSE IF @Field = 'Balance'
        SELECT COUNT(*) FROM Accounts WHERE CAST(Balance AS NVARCHAR(100)) LIKE '%' + @Value + '%';
    ELSE IF @Field = 'CreatedAt'
        SELECT COUNT(*) FROM Accounts WHERE CAST(CreatedAt AS DATE) = CAST(TRY_CONVERT(DATETIME, @Value) AS DATE);
    ELSE
        SELECT COUNT(*) FROM Accounts;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAccountsPaged]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAccountsPaged]
    @PageNumber INT,
    @RowsPerPage INT,
    @Field NVARCHAR(50) = '',
    @Value NVARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;

    IF @Field = '' AND @Value = ''
        SELECT AccountID, ClientID, Balance, CreatedAt
        FROM Accounts
        ORDER BY AccountID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
    ELSE IF @Field = 'AccountID'
        SELECT AccountID, ClientID, Balance, CreatedAt
        FROM Accounts
        WHERE AccountID = CAST(@Value AS INT)
        ORDER BY AccountID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
    ELSE IF @Field = 'ClientID'
        SELECT AccountID, ClientID, Balance, CreatedAt
        FROM Accounts
        WHERE ClientID = CAST(@Value AS INT)
        ORDER BY AccountID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
    ELSE IF @Field = 'Balance'
        SELECT AccountID, ClientID, Balance, CreatedAt
        FROM Accounts
        WHERE CAST(Balance AS NVARCHAR(100)) LIKE '%' + @Value + '%'
        ORDER BY AccountID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
    ELSE IF @Field = 'CreatedAt'
        SELECT AccountID, ClientID, Balance, CreatedAt
        FROM Accounts
        WHERE CAST(CreatedAt AS DATE) = CAST(TRY_CONVERT(DATETIME, @Value) AS DATE)
        ORDER BY AccountID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
    ELSE
        SELECT AccountID, ClientID, Balance, CreatedAt
        FROM Accounts
        ORDER BY AccountID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAccountSummary]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAccountSummary]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        COUNT(*) AS TotalAccounts,
        AVG(CAST(Balance AS DECIMAL(18,2))) AS AverageBalance,
        SUM(Balance) AS TotalBalance
    FROM Accounts;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllAccounts]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllAccounts]
AS
BEGIN
SET NOCOUNT ON;
    SELECT * FROM Accounts;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllClients]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Get all clients
CREATE PROCEDURE [dbo].[GetAllClients]
AS
BEGIN
SET NOCOUNT ON;
    SELECT * FROM Clients;
END;

GO
/****** Object:  StoredProcedure [dbo].[GetAllTransactions]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllTransactions]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
    FROM Transactions
    ORDER BY TransactionID;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetClientByID]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Get client details
CREATE PROCEDURE [dbo].[GetClientByID]
    @ClientID INT
AS
BEGIN
SET NOCOUNT ON;
    SELECT * FROM Clients WHERE ClientID = @ClientID;
END;

GO
/****** Object:  StoredProcedure [dbo].[GetClientsByFilter]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetClientsByFilter]
    @Field NVARCHAR(50),
    @Value NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    IF @Field = '' AND @Value = ''
        SELECT ClientID, FullName, Email, Phone, Address, CreatedAt FROM Clients;
    ELSE IF @Field = 'ClientID'
        SELECT ClientID, FullName, Email, Phone, Address, CreatedAt FROM Clients WHERE ClientID = CAST(@Value AS INT);
    ELSE IF @Field = 'FullName'
        SELECT ClientID, FullName, Email, Phone, Address, CreatedAt FROM Clients WHERE FullName LIKE '%' + @Value + '%';
    ELSE IF @Field = 'Email'
        SELECT ClientID, FullName, Email, Phone, Address, CreatedAt FROM Clients WHERE Email LIKE '%' + @Value + '%';
    ELSE IF @Field = 'Phone'
        SELECT ClientID, FullName, Email, Phone, Address, CreatedAt FROM Clients WHERE Phone LIKE '%' + @Value + '%';
    ELSE IF @Field = 'Address'
        SELECT ClientID, FullName, Email, Phone, Address, CreatedAt FROM Clients WHERE Address LIKE '%' + @Value + '%';
    ELSE IF @Field = 'CreatedAt'
        SELECT ClientID, FullName, Email, Phone, Address, CreatedAt FROM Clients WHERE CAST(CreatedAt AS DATE) = CAST(TRY_CONVERT(DATETIME, @Value) AS DATE);
    ELSE
        SELECT ClientID, FullName, Email, Phone, Address, CreatedAt FROM Clients;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetClientsCount]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetClientsCount]
    @Field NVARCHAR(50) = '',
    @Value NVARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;

    IF @Field = '' AND @Value = ''
        SELECT COUNT(*) FROM Clients;
    ELSE IF @Field = 'ClientID'
        SELECT COUNT(*) FROM Clients WHERE ClientID = CAST(@Value AS INT);
    ELSE IF @Field = 'FullName'
        SELECT COUNT(*) FROM Clients WHERE FullName LIKE '%' + @Value + '%';
    ELSE IF @Field = 'Email'
        SELECT COUNT(*) FROM Clients WHERE Email LIKE '%' + @Value + '%';
    ELSE IF @Field = 'Phone'
        SELECT COUNT(*) FROM Clients WHERE Phone LIKE '%' + @Value + '%';
    ELSE IF @Field = 'Address'
        SELECT COUNT(*) FROM Clients WHERE Address LIKE '%' + @Value + '%';
    ELSE IF @Field = 'CreatedAt'
        SELECT COUNT(*) FROM Clients WHERE CAST(CreatedAt AS DATE) = CAST(TRY_CONVERT(DATETIME, @Value) AS DATE);
    ELSE
        SELECT COUNT(*) FROM Clients;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetClientsPaged]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetClientsPaged]
    @PageNumber INT,
    @RowsPerPage INT,
    @Field NVARCHAR(50) = '',
    @Value NVARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;

    IF @Field = '' AND @Value = ''
        SELECT ClientID, FullName, Email, Phone, Address, CreatedAt
        FROM Clients
        ORDER BY ClientID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
    ELSE IF @Field = 'ClientID'
        SELECT ClientID, FullName, Email, Phone, Address, CreatedAt
        FROM Clients
        WHERE ClientID = CAST(@Value AS INT)
        ORDER BY ClientID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
    ELSE IF @Field = 'FullName'
        SELECT ClientID, FullName, Email, Phone, Address, CreatedAt
        FROM Clients
        WHERE FullName LIKE '%' + @Value + '%'
        ORDER BY ClientID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
    ELSE IF @Field = 'Email'
        SELECT ClientID, FullName, Email, Phone, Address, CreatedAt
        FROM Clients
        WHERE Email LIKE '%' + @Value + '%'
        ORDER BY ClientID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
    ELSE IF @Field = 'Phone'
        SELECT ClientID, FullName, Email, Phone, Address, CreatedAt
        FROM Clients
        WHERE Phone LIKE '%' + @Value + '%'
        ORDER BY ClientID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
    ELSE IF @Field = 'Address'
        SELECT ClientID, FullName, Email, Phone, Address, CreatedAt
        FROM Clients
        WHERE Address LIKE '%' + @Value + '%'
        ORDER BY ClientID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
    ELSE IF @Field = 'CreatedAt'
        SELECT ClientID, FullName, Email, Phone, Address, CreatedAt
        FROM Clients
        WHERE CAST(CreatedAt AS DATE) = CAST(TRY_CONVERT(DATETIME, @Value) AS DATE)
        ORDER BY ClientID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
    ELSE
        SELECT ClientID, FullName, Email, Phone, Address, CreatedAt
        FROM Clients
        ORDER BY ClientID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetClientSummary]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetClientSummary]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS TotalClients FROM Clients;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetTransactionByID]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTransactionByID]
    @TransactionID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
    FROM Transactions
    WHERE TransactionID = @TransactionID;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetTransactionsByAccountFiltered]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTransactionsByAccountFiltered]
    @FromAccountID INT,
    @Field NVARCHAR(50) = NULL,
    @Value NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF (@Field IS NULL OR @Field = '') AND (@Value IS NULL OR @Value = '')
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE FromAccountID = @FromAccountID
        ORDER BY TransactionDate DESC;
    ELSE IF @Field = 'TransactionID'
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE FromAccountID = @FromAccountID AND TransactionID = CAST(@Value AS INT)
        ORDER BY TransactionDate DESC;
    ELSE IF @Field = 'FromAccountID'
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE FromAccountID = @FromAccountID AND FromAccountID = CAST(@Value AS INT)
        ORDER BY TransactionDate DESC;
    ELSE IF @Field = 'TransactionType'
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE FromAccountID = @FromAccountID AND TransactionType LIKE '%' + @Value + '%'
        ORDER BY TransactionDate DESC;
    ELSE IF @Field = 'Amount'
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE FromAccountID = @FromAccountID AND CAST(Amount AS NVARCHAR(100)) LIKE '%' + @Value + '%'
        ORDER BY TransactionDate DESC;
    ELSE IF @Field = 'ToAccountID'
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE FromAccountID = @FromAccountID AND ToAccountID = CAST(@Value AS INT)
        ORDER BY TransactionDate DESC;
    ELSE IF @Field = 'TransactionDate'
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE FromAccountID = @FromAccountID AND CAST(TransactionDate AS DATE) = CAST(TRY_CONVERT(DATETIME, @Value) AS DATE)
        ORDER BY TransactionDate DESC;
    ELSE
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE FromAccountID = @FromAccountID
        ORDER BY TransactionDate DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[GetTransactionsByFilter]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTransactionsByFilter]
    @Field NVARCHAR(50),
    @Value NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    IF @Field = '' AND @Value = ''
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        ORDER BY TransactionID;
    ELSE IF @Field = 'TransactionID'
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE TransactionID = CAST(@Value AS INT)
        ORDER BY TransactionID;
    ELSE IF @Field = 'FromAccountID'
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE FromAccountID = CAST(@Value AS INT)
        ORDER BY TransactionID;
    ELSE IF @Field = 'TransactionType'
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE TransactionType LIKE '%' + @Value + '%'
        ORDER BY TransactionID;
    ELSE IF @Field = 'Amount'
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE CAST(Amount AS NVARCHAR(100)) LIKE '%' + @Value + '%'
        ORDER BY TransactionID;
    ELSE IF @Field = 'ToAccountID'
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE ToAccountID = CAST(@Value AS INT)
        ORDER BY TransactionID;
    ELSE IF @Field = 'TransactionDate'
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE CAST(TransactionDate AS DATE) = CAST(TRY_CONVERT(DATETIME, @Value) AS DATE)
        ORDER BY TransactionID;
    ELSE
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        ORDER BY TransactionID;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetTransactionsCount]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTransactionsCount]
    @Field NVARCHAR(50) = '',
    @Value NVARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;

    IF @Field = '' AND @Value = ''
        SELECT COUNT(*) FROM Transactions;
    ELSE IF @Field = 'TransactionID'
        SELECT COUNT(*) FROM Transactions WHERE TransactionID = CAST(@Value AS INT);
    ELSE IF @Field = 'FromAccountID'
        SELECT COUNT(*) FROM Transactions WHERE FromAccountID = CAST(@Value AS INT);
    ELSE IF @Field = 'TransactionType'
        SELECT COUNT(*) FROM Transactions WHERE TransactionType LIKE '%' + @Value + '%';
    ELSE IF @Field = 'Amount'
        SELECT COUNT(*) FROM Transactions WHERE CAST(Amount AS NVARCHAR(100)) LIKE '%' + @Value + '%';
    ELSE IF @Field = 'ToAccountID'
        SELECT COUNT(*) FROM Transactions WHERE ToAccountID = CAST(@Value AS INT);
    ELSE IF @Field = 'TransactionDate'
        SELECT COUNT(*) FROM Transactions WHERE CAST(TransactionDate AS DATE) = CAST(TRY_CONVERT(DATETIME, @Value) AS DATE);
    ELSE
        SELECT COUNT(*) FROM Transactions;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetTransactionsPaged]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTransactionsPaged]
    @PageNumber INT,
    @RowsPerPage INT,
    @Field NVARCHAR(50) = '',
    @Value NVARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;

    IF @Field = '' AND @Value = ''
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        ORDER BY TransactionID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
    ELSE IF @Field = 'TransactionID'
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE TransactionID = CAST(@Value AS INT)
        ORDER BY TransactionID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
    ELSE IF @Field = 'FromAccountID'
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE FromAccountID = CAST(@Value AS INT)
        ORDER BY TransactionID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
    ELSE IF @Field = 'TransactionType'
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE TransactionType LIKE '%' + @Value + '%'
        ORDER BY TransactionID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
    ELSE IF @Field = 'Amount'
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE CAST(Amount AS NVARCHAR(100)) LIKE '%' + @Value + '%'
        ORDER BY TransactionID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
    ELSE IF @Field = 'ToAccountID'
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE ToAccountID = CAST(@Value AS INT)
        ORDER BY TransactionID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
    ELSE IF @Field = 'TransactionDate'
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        WHERE CAST(TransactionDate AS DATE) = CAST(TRY_CONVERT(DATETIME, @Value) AS DATE)
        ORDER BY TransactionID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
    ELSE
        SELECT TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate
        FROM Transactions
        ORDER BY TransactionID
        OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
        FETCH NEXT @RowsPerPage ROWS ONLY;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetTransactionSummary]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTransactionSummary]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS TotalTransactions
    FROM Transactions;
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateAccount]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAccount]
    @AccountID INT,
    @ClientID INT,
    @Balance DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Accounts
    SET ClientID = @ClientID, Balance = @Balance
    OUTPUT inserted.AccountID
    WHERE AccountID = @AccountID;
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateClient]    Script Date: 6/11/2025 5:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateClient]
    @ClientID INT,
    @FullName NVARCHAR(100),
    @Email NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Address NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Clients
    SET FullName = @FullName, Email = @Email, Phone = @Phone, Address = @Address
    OUTPUT inserted.ClientID
    WHERE ClientID = @ClientID;
END;
GO
USE [master]
GO
ALTER DATABASE [BankSystem] SET  READ_WRITE 
GO
