USE [master]
GO
/****** Object:  Database [armas_db]    Script Date: 03/07/2024 01:15:51 a. m. ******/
CREATE DATABASE [armas_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'armas_db', FILENAME = N'C:\SQLData\armas_db.mdf' , SIZE = 8192KB , MAXSIZE = 102400KB , FILEGROWTH = 2048KB )
 LOG ON 
( NAME = N'armas_db_log', FILENAME = N'C:\SQLData\Logs\armas_db_log.ldf' , SIZE = 2048KB , MAXSIZE = 102400KB , FILEGROWTH = 2048KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [armas_db] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [armas_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [armas_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [armas_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [armas_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [armas_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [armas_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [armas_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [armas_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [armas_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [armas_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [armas_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [armas_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [armas_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [armas_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [armas_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [armas_db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [armas_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [armas_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [armas_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [armas_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [armas_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [armas_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [armas_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [armas_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [armas_db] SET  MULTI_USER 
GO
ALTER DATABASE [armas_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [armas_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [armas_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [armas_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [armas_db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [armas_db] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [armas_db] SET QUERY_STORE = ON
GO
ALTER DATABASE [armas_db] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [armas_db]
GO
/****** Object:  Table [dbo].[armeria]    Script Date: 03/07/2024 01:15:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[armeria](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[Fabricante] [varchar](50) NOT NULL,
	[Modelo] [varchar](50) NOT NULL,
	[NumeroSerie] [varchar](50) NOT NULL,
	[PesoBase] [float] NOT NULL,
	[CalibreMunicion] [int] NOT NULL,
	[MaterialesConstruccion] [varchar](50) NOT NULL,
	[Precio] [float] NOT NULL,
	[Capacidad] [int] NOT NULL,
	[Accesorios] [varchar](50) NOT NULL,
	[Cadencia] [int] NULL,
 CONSTRAINT [PK_armeria] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[armeria] ON 

INSERT [dbo].[armeria] ([id], [Tipo], [Fabricante], [Modelo], [NumeroSerie], [PesoBase], [CalibreMunicion], [MaterialesConstruccion], [Precio], [Capacidad], [Accesorios], [Cadencia]) VALUES (1, N'PistolaSemiautomatica', N'Colt', N'M1911', N'CT39261', 1.13, 1, N'[0]', 539.99, 7, N'[2]', NULL)
INSERT [dbo].[armeria] ([id], [Tipo], [Fabricante], [Modelo], [NumeroSerie], [PesoBase], [CalibreMunicion], [MaterialesConstruccion], [Precio], [Capacidad], [Accesorios], [Cadencia]) VALUES (2, N'PistolaSemiautomatica', N'Heckler & Koch', N'VP9-B', N'HK15678', 0.72, 8, N'[3]', 649.99, 17, N'[]', NULL)
INSERT [dbo].[armeria] ([id], [Tipo], [Fabricante], [Modelo], [NumeroSerie], [PesoBase], [CalibreMunicion], [MaterialesConstruccion], [Precio], [Capacidad], [Accesorios], [Cadencia]) VALUES (3, N'PistolaSemiautomatica', N'Glock', N'G19 Gen 5', N'GK93627', 0.68, 8, N'[3]', 679.99, 15, N'[0]', NULL)
INSERT [dbo].[armeria] ([id], [Tipo], [Fabricante], [Modelo], [NumeroSerie], [PesoBase], [CalibreMunicion], [MaterialesConstruccion], [Precio], [Capacidad], [Accesorios], [Cadencia]) VALUES (4, N'FusilAsalto', N'ArmaLite', N'AR-15', N'AR26758', 2.97, 7, N'[1]', 1100, 20, N'[2,3]', 200)
INSERT [dbo].[armeria] ([id], [Tipo], [Fabricante], [Modelo], [NumeroSerie], [PesoBase], [CalibreMunicion], [MaterialesConstruccion], [Precio], [Capacidad], [Accesorios], [Cadencia]) VALUES (5, N'FusilAsalto', N'WILSON COMBAT', N'WC-15', N'WC87341', 2.81, 7, N'[1]', 1343.29, 30, N'[1,4]', 180)
INSERT [dbo].[armeria] ([id], [Tipo], [Fabricante], [Modelo], [NumeroSerie], [PesoBase], [CalibreMunicion], [MaterialesConstruccion], [Precio], [Capacidad], [Accesorios], [Cadencia]) VALUES (6, N'FusilAsalto', N'Sig Sauer', N'MCX Spear', N'SG35979', 4.17, 12, N'[0,3]', 4199.99, 20, N'[6]', 150)
INSERT [dbo].[armeria] ([id], [Tipo], [Fabricante], [Modelo], [NumeroSerie], [PesoBase], [CalibreMunicion], [MaterialesConstruccion], [Precio], [Capacidad], [Accesorios], [Cadencia]) VALUES (7, N'EscopetaBombeo', N'Stevens', N'320', N'SV98463', 3.27, 13, N'[0,3]', 207, 5, N'[]', NULL)
INSERT [dbo].[armeria] ([id], [Tipo], [Fabricante], [Modelo], [NumeroSerie], [PesoBase], [CalibreMunicion], [MaterialesConstruccion], [Precio], [Capacidad], [Accesorios], [Cadencia]) VALUES (8, N'EscopetaBombeo', N'Mossberg', N'Maverick 88', N'MS64673', 2.4, 13, N'[0,2]', 242.99, 6, N'[5]', NULL)
INSERT [dbo].[armeria] ([id], [Tipo], [Fabricante], [Modelo], [NumeroSerie], [PesoBase], [CalibreMunicion], [MaterialesConstruccion], [Precio], [Capacidad], [Accesorios], [Cadencia]) VALUES (9, N'EscopetaBombeo', N'Remington', N'870', N'RM89734', 3.2, 15, N'[0,2]', 506, 3, N'[1,2]', NULL)
SET IDENTITY_INSERT [dbo].[armeria] OFF
GO
USE [master]
GO
ALTER DATABASE [armas_db] SET  READ_WRITE 
GO
