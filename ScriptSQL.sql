USE [master]
GO
/****** Object:  Database [AutoPlac1]    Script Date: 6/30/2019 17:25:17 ******/
CREATE DATABASE [AutoPlac1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AutoPlac1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\AutoPlac1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AutoPlac1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\AutoPlac1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AutoPlac1] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AutoPlac1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AutoPlac1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AutoPlac1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AutoPlac1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AutoPlac1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AutoPlac1] SET ARITHABORT OFF 
GO
ALTER DATABASE [AutoPlac1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AutoPlac1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AutoPlac1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AutoPlac1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AutoPlac1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AutoPlac1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AutoPlac1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AutoPlac1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AutoPlac1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AutoPlac1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AutoPlac1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AutoPlac1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AutoPlac1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AutoPlac1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AutoPlac1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AutoPlac1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AutoPlac1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AutoPlac1] SET RECOVERY FULL 
GO
ALTER DATABASE [AutoPlac1] SET  MULTI_USER 
GO
ALTER DATABASE [AutoPlac1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AutoPlac1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AutoPlac1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AutoPlac1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AutoPlac1] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AutoPlac1', N'ON'
GO
ALTER DATABASE [AutoPlac1] SET QUERY_STORE = OFF
GO
USE [AutoPlac1]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [AutoPlac1]
GO
/****** Object:  Table [dbo].[Prodata_vozila]    Script Date: 6/30/2019 17:25:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prodata_vozila](
	[IDVozila] [int] NOT NULL,
	[Marka] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Godiste] [int] NOT NULL,
	[Cena] [int] NOT NULL,
	[Boja] [nvarchar](50) NOT NULL,
	[BrojSedista] [int] NOT NULL,
	[TipGoriva] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Prodata_vozila] PRIMARY KEY CLUSTERED 
(
	[IDVozila] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Radnik]    Script Date: 6/30/2019 17:25:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Radnik](
	[IDRadnika] [int] NOT NULL,
	[Ime] [nvarchar](50) NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[JMBG] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Radnik] PRIMARY KEY CLUSTERED 
(
	[IDRadnika] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ugovor]    Script Date: 6/30/2019 17:25:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ugovor](
	[BrojUgovora] [int] NOT NULL,
	[Marka] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Godiste] [int] NOT NULL,
	[Cena] [int] NOT NULL,
	[Boja] [nvarchar](50) NOT NULL,
	[ImeKupca] [nvarchar](50) NOT NULL,
	[PrezimeKupca] [nvarchar](50) NOT NULL,
	[ImeProdavca] [nvarchar](50) NOT NULL,
	[PrezimeProdavca] [nvarchar](50) NOT NULL,
	[JBMGKupca] [nvarchar](50) NOT NULL,
	[IDRadnika] [int] NOT NULL,
	[IDProdatogVozila] [int] NOT NULL,
 CONSTRAINT [PK_Ugovor] PRIMARY KEY CLUSTERED 
(
	[BrojUgovora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vozilo]    Script Date: 6/30/2019 17:25:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vozilo](
	[IDVozila] [int] NOT NULL,
	[Marka] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Godiste] [int] NOT NULL,
	[Cena] [int] NOT NULL,
	[Boja] [nvarchar](50) NULL,
	[BrojSedista] [int] NOT NULL,
	[TipGoriva] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Vozilo] PRIMARY KEY CLUSTERED 
(
	[IDVozila] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Prodata_vozila] ([IDVozila], [Marka], [Model], [Godiste], [Cena], [Boja], [BrojSedista], [TipGoriva]) VALUES (1, N'a', N'320d', 1, 1, N'asdsad', 1, N'asdas')
INSERT [dbo].[Prodata_vozila] ([IDVozila], [Marka], [Model], [Godiste], [Cena], [Boja], [BrojSedista], [TipGoriva]) VALUES (4, N'BMW', N'320d', 2005, 2000, N'crna', 5, N'dizel')
INSERT [dbo].[Radnik] ([IDRadnika], [Ime], [Prezime], [JMBG]) VALUES (1, N'Jovan', N'Travica', N'2344335676513')
INSERT [dbo].[Radnik] ([IDRadnika], [Ime], [Prezime], [JMBG]) VALUES (2, N'Milos', N'Terzic', N'2344335676519')
INSERT [dbo].[Ugovor] ([BrojUgovora], [Marka], [Model], [Godiste], [Cena], [Boja], [ImeKupca], [PrezimeKupca], [ImeProdavca], [PrezimeProdavca], [JBMGKupca], [IDRadnika], [IDProdatogVozila]) VALUES (1, N'Marcedes', N'320d', 2345, 3452, N'crna', N'Milos', N'Milosevic', N'Danilo', N'asdad', N'1204994172635', 1, 1)
INSERT [dbo].[Vozilo] ([IDVozila], [Marka], [Model], [Godiste], [Cena], [Boja], [BrojSedista], [TipGoriva]) VALUES (1, N'Marcedes', N'320d', 3453, 3334, N'crna', 3, N'dizel')
INSERT [dbo].[Vozilo] ([IDVozila], [Marka], [Model], [Godiste], [Cena], [Boja], [BrojSedista], [TipGoriva]) VALUES (2, N'345', N'320d', 3421, 3332, N'crna', 4, N'dizel')
INSERT [dbo].[Vozilo] ([IDVozila], [Marka], [Model], [Godiste], [Cena], [Boja], [BrojSedista], [TipGoriva]) VALUES (3, N'Marcedes', N'320d', 2344, 32453, N'crna', 5, N'dizel')
INSERT [dbo].[Vozilo] ([IDVozila], [Marka], [Model], [Godiste], [Cena], [Boja], [BrojSedista], [TipGoriva]) VALUES (4, N'Marcedes', N'320d', 3244, 4324, N'crna', 4, N'dizel')
ALTER TABLE [dbo].[Ugovor]  WITH CHECK ADD  CONSTRAINT [FK_Ugovor_Prodata_vozila] FOREIGN KEY([IDProdatogVozila])
REFERENCES [dbo].[Prodata_vozila] ([IDVozila])
GO
ALTER TABLE [dbo].[Ugovor] CHECK CONSTRAINT [FK_Ugovor_Prodata_vozila]
GO
ALTER TABLE [dbo].[Ugovor]  WITH CHECK ADD  CONSTRAINT [FK_Ugovor_Radnik] FOREIGN KEY([IDRadnika])
REFERENCES [dbo].[Radnik] ([IDRadnika])
GO
ALTER TABLE [dbo].[Ugovor] CHECK CONSTRAINT [FK_Ugovor_Radnik]
GO
USE [master]
GO
ALTER DATABASE [AutoPlac1] SET  READ_WRITE 
GO
