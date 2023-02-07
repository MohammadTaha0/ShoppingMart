USE [master]
GO
/****** Object:  Database [ShoppingMart]    Script Date: 2/7/2023 12:34:48 PM ******/
CREATE DATABASE [ShoppingMart]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShoppingMart', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShoppingMart.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShoppingMart_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShoppingMart_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ShoppingMart] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShoppingMart].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShoppingMart] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShoppingMart] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShoppingMart] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShoppingMart] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShoppingMart] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShoppingMart] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShoppingMart] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShoppingMart] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShoppingMart] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShoppingMart] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShoppingMart] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShoppingMart] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShoppingMart] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShoppingMart] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShoppingMart] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShoppingMart] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShoppingMart] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShoppingMart] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShoppingMart] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShoppingMart] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShoppingMart] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShoppingMart] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShoppingMart] SET RECOVERY FULL 
GO
ALTER DATABASE [ShoppingMart] SET  MULTI_USER 
GO
ALTER DATABASE [ShoppingMart] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShoppingMart] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShoppingMart] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShoppingMart] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShoppingMart] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShoppingMart] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShoppingMart', N'ON'
GO
ALTER DATABASE [ShoppingMart] SET QUERY_STORE = ON
GO
ALTER DATABASE [ShoppingMart] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ShoppingMart]
GO
/****** Object:  Table [dbo].[tbl_inv]    Script Date: 2/7/2023 12:34:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_inv](
	[invId] [bigint] IDENTITY(1,1) NOT NULL,
	[invNum] [bigint] NULL,
	[brcId] [bigint] NULL,
	[price] [decimal](18, 0) NULL,
	[qty] [int] NULL,
	[date] [datetime] NULL,
 CONSTRAINT [PK_tbl_inv] PRIMARY KEY CLUSTERED 
(
	[invId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_order]    Script Date: 2/7/2023 12:34:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_order](
	[orderId] [bigint] IDENTITY(192550,1) NOT NULL,
	[invId] [bigint] NULL,
	[price] [decimal](18, 0) NULL,
	[paidPrice] [decimal](18, 0) NULL,
	[status] [int] NULL,
	[date] [datetime] NULL,
 CONSTRAINT [PK_tbl_order] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_products]    Script Date: 2/7/2023 12:34:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_products](
	[product_id] [bigint] IDENTITY(1,1) NOT NULL,
	[barcode] [varchar](50) NULL,
	[product_name] [varchar](50) NULL,
	[price] [bigint] NULL,
	[venId] [bigint] NULL,
	[quan] [int] NULL,
	[date] [datetime] NULL,
 CONSTRAINT [PK_tbl_products_1] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_register]    Script Date: 2/7/2023 12:34:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_register](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[username] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[mob] [varchar](50) NULL,
	[role] [int] NULL,
	[date] [datetime] NULL,
 CONSTRAINT [PK_tbl_register] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_role]    Script Date: 2/7/2023 12:34:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_role](
	[role] [int] NULL,
	[name] [varchar](50) NULL,
	[date] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_vendor]    Script Date: 2/7/2023 12:34:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_vendor](
	[vendorId] [int] IDENTITY(1,1) NOT NULL,
	[venName] [varchar](50) NULL,
	[venCon] [varchar](50) NULL,
	[venAdd] [varchar](50) NULL,
	[date] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_vendor] PRIMARY KEY CLUSTERED 
(
	[vendorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_inv] ADD  CONSTRAINT [DF_tbl_inv_date]  DEFAULT (getdate()) FOR [date]
GO
ALTER TABLE [dbo].[tbl_order] ADD  CONSTRAINT [DF_tbl_order_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[tbl_order] ADD  CONSTRAINT [DF_tbl_order_date]  DEFAULT (getdate()) FOR [date]
GO
ALTER TABLE [dbo].[tbl_products] ADD  CONSTRAINT [DF_tbl_products_date]  DEFAULT (getdate()) FOR [date]
GO
ALTER TABLE [dbo].[tbl_register] ADD  CONSTRAINT [DF_tbl_register_date]  DEFAULT (getdate()) FOR [date]
GO
ALTER TABLE [dbo].[tbl_role] ADD  CONSTRAINT [DF_tbl_role_date]  DEFAULT (getdate()) FOR [date]
GO
ALTER TABLE [dbo].[tbl_vendor] ADD  CONSTRAINT [DF_tbl_vendor_date]  DEFAULT (getdate()) FOR [date]
GO
USE [master]
GO
ALTER DATABASE [ShoppingMart] SET  READ_WRITE 
GO
