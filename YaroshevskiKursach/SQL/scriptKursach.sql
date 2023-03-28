USE [master]
GO
/****** Object:  Database [Yaroshevski1]    Script Date: 3/28/2023 9:09:34 AM ******/
CREATE DATABASE [Yaroshevski1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Yaroshevski1', FILENAME = N'D:\Express\MSSQL15.SQLEXPRESS\MSSQL\DATA\Yaroshevski1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Yaroshevski1_log', FILENAME = N'D:\Express\MSSQL15.SQLEXPRESS\MSSQL\DATA\Yaroshevski1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Yaroshevski1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Yaroshevski1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Yaroshevski1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Yaroshevski1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Yaroshevski1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Yaroshevski1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Yaroshevski1] SET ARITHABORT OFF 
GO
ALTER DATABASE [Yaroshevski1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Yaroshevski1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Yaroshevski1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Yaroshevski1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Yaroshevski1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Yaroshevski1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Yaroshevski1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Yaroshevski1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Yaroshevski1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Yaroshevski1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Yaroshevski1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Yaroshevski1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Yaroshevski1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Yaroshevski1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Yaroshevski1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Yaroshevski1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Yaroshevski1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Yaroshevski1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Yaroshevski1] SET  MULTI_USER 
GO
ALTER DATABASE [Yaroshevski1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Yaroshevski1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Yaroshevski1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Yaroshevski1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Yaroshevski1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Yaroshevski1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Yaroshevski1] SET QUERY_STORE = OFF
GO
USE [Yaroshevski1]
GO
/****** Object:  Table [dbo].[AvailabilityInternet]    Script Date: 3/28/2023 9:09:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvailabilityInternet](
	[IdAvailabilityInternet] [int] IDENTITY(1,1) NOT NULL,
	[IdStore] [int] NOT NULL,
	[IdStaff] [int] NOT NULL,
	[QuantityAvailabilityInternet] [int] NOT NULL,
 CONSTRAINT [PK_AvailabilityInternet] PRIMARY KEY CLUSTERED 
(
	[IdAvailabilityInternet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AvailabilityLocal]    Script Date: 3/28/2023 9:09:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvailabilityLocal](
	[IdAvailabilityLocal] [int] IDENTITY(1,1) NOT NULL,
	[IdStore] [int] NOT NULL,
	[IdStaff] [int] NOT NULL,
	[QuantityAvailabilityLocal] [int] NOT NULL,
 CONSTRAINT [PK_AvailabilityLocal] PRIMARY KEY CLUSTERED 
(
	[IdAvailabilityLocal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clothes]    Script Date: 3/28/2023 9:09:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clothes](
	[IdClothes] [int] IDENTITY(1,1) NOT NULL,
	[IdCollection] [int] NOT NULL,
	[IdSeason] [int] NOT NULL,
	[IdTypeOfClothing] [int] NOT NULL,
	[PhotoClothes] [image] NOT NULL,
	[IdGender] [int] NOT NULL,
 CONSTRAINT [PK_Clothes] PRIMARY KEY CLUSTERED 
(
	[IdClothes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Collection]    Script Date: 3/28/2023 9:09:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Collection](
	[IdCollection] [int] IDENTITY(1,1) NOT NULL,
	[NameCollection] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Collection] PRIMARY KEY CLUSTERED 
(
	[IdCollection] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 3/28/2023 9:09:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[IdGender] [int] IDENTITY(1,1) NOT NULL,
	[NameGender] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[IdGender] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/28/2023 9:09:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[IdProduct] [int] IDENTITY(1,1) NOT NULL,
	[AllAboutProduct] [nvarchar](max) NOT NULL,
	[PriceForOneUnitProduct] [decimal](10, 2) NOT NULL,
	[IdClothes] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[IdProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 3/28/2023 9:09:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[IdRole] [int] IDENTITY(1,1) NOT NULL,
	[NameRole] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 3/28/2023 9:09:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[IdSale] [int] IDENTITY(1,1) NOT NULL,
	[DateSale] [date] NOT NULL,
	[QuantitySale] [int] NOT NULL,
	[IdStaff] [int] NOT NULL,
 CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED 
(
	[IdSale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Season]    Script Date: 3/28/2023 9:09:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Season](
	[IdSeason] [int] IDENTITY(1,1) NOT NULL,
	[NameSeason] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Season] PRIMARY KEY CLUSTERED 
(
	[IdSeason] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 3/28/2023 9:09:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[IdStaff] [int] IDENTITY(1,1) NOT NULL,
	[LastNameStaff] [nvarchar](25) NOT NULL,
	[FirstNameStaff] [nvarchar](30) NOT NULL,
	[MiddleNameStaff] [nvarchar](50) NULL,
	[PhoneNubmerStaff] [int] NOT NULL,
	[EmailStaff] [nvarchar](75) NOT NULL,
	[IdUser] [int] NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[IdStaff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 3/28/2023 9:09:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[IdStore] [int] IDENTITY(1,1) NOT NULL,
	[IdProduct] [int] NOT NULL,
	[IdStaff] [int] NOT NULL,
	[NumberOfProductsStore] [int] NOT NULL,
	[TotalCostStore] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[IdStore] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfClothing]    Script Date: 3/28/2023 9:09:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfClothing](
	[IdTypeOfClothing] [int] IDENTITY(1,1) NOT NULL,
	[IdViewIdOfClothing] [int] NOT NULL,
	[NameIdTypeOfClothing] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_TypeOfClothing] PRIMARY KEY CLUSTERED 
(
	[IdTypeOfClothing] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/28/2023 9:09:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[LoginUser] [nvarchar](25) NOT NULL,
	[PasswordUser] [nvarchar](49) NOT NULL,
	[IdRole] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ViewOfClothing]    Script Date: 3/28/2023 9:09:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ViewOfClothing](
	[IdViewIdOfClothing] [int] IDENTITY(1,1) NOT NULL,
	[NameIdViewIdOfClothing] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_ViewOfClothing] PRIMARY KEY CLUSTERED 
(
	[IdViewIdOfClothing] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Collection] ON 

INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (1, N'Бархатные тяги')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (2, N'Maison Martin Margiela')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (3, N'Christian Dior')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (4, N'Raf Simons')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (5, N'Dior Homme')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (6, N'Lanvin')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (7, N'Helmut Lang')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (8, N'Alexander McQueen')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (9, N'Maison Martin Margiela')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (10, N'Alexander McQueen')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (11, N'Prada')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (12, N'Christian Dior')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (13, N'J.W. Anderson')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (14, N'Celine')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (15, N'Maison Margiela Artisanal')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (16, N'Vetements')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (17, N'Gucci')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (18, N'Balanceiaga')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (19, N'Dries van Noten')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (20, N'Louis Vuitton')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (21, N'Haute Couture')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (22, N'Pret-a-Porter')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (23, N'Capsule collection')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (24, N'Fall')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (25, N'Pre-fall')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (26, N'Cruise')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (27, N'Color basic')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (28, N'Bad Badtz')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (29, N'Scally Milano')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (30, N'89-Squad')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (31, N'Модная одежка')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (32, N'Коллекционер')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (33, N'Uniq Mod')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (34, N'Модняшка')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (35, N'Дом Моды
')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (36, N'Mega Shine')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (37, N'Star Shine')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (38, N'Your Shine')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (39, N'New Bow')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (40, N'Выбор естьь')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (41, N'Иодные овечки')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (42, N'Мега остров')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (43, N'Модум')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (44, N'Островок вещей')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (45, N'Модный фасончик')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (46, N'Fashionista')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (47, N'Your Clothes')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (48, N'New Diva')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (49, N'Your Diva')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (50, N'Mmodochka')
INSERT [dbo].[Collection] ([IdCollection], [NameCollection]) VALUES (51, N'Mods')
SET IDENTITY_INSERT [dbo].[Collection] OFF
GO
SET IDENTITY_INSERT [dbo].[Gender] ON 

INSERT [dbo].[Gender] ([IdGender], [NameGender]) VALUES (1, N'Мужская')
INSERT [dbo].[Gender] ([IdGender], [NameGender]) VALUES (2, N'Женская')
INSERT [dbo].[Gender] ([IdGender], [NameGender]) VALUES (3, N'Детская')
INSERT [dbo].[Gender] ([IdGender], [NameGender]) VALUES (4, N'Унисекс')
SET IDENTITY_INSERT [dbo].[Gender] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([IdRole], [NameRole]) VALUES (2, N'Администратор')
INSERT [dbo].[Role] ([IdRole], [NameRole]) VALUES (3, N'Директор')
INSERT [dbo].[Role] ([IdRole], [NameRole]) VALUES (4, N'Заведующий склада')
INSERT [dbo].[Role] ([IdRole], [NameRole]) VALUES (5, N'Сотрудник')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Season] ON 

INSERT [dbo].[Season] ([IdSeason], [NameSeason]) VALUES (1, N'Весна')
INSERT [dbo].[Season] ([IdSeason], [NameSeason]) VALUES (2, N'Лето')
INSERT [dbo].[Season] ([IdSeason], [NameSeason]) VALUES (3, N'Осень')
INSERT [dbo].[Season] ([IdSeason], [NameSeason]) VALUES (4, N'Зима')
INSERT [dbo].[Season] ([IdSeason], [NameSeason]) VALUES (5, N'Весна-Лето')
INSERT [dbo].[Season] ([IdSeason], [NameSeason]) VALUES (6, N'Лето-Осень')
INSERT [dbo].[Season] ([IdSeason], [NameSeason]) VALUES (7, N'Осень-Зима')
INSERT [dbo].[Season] ([IdSeason], [NameSeason]) VALUES (8, N'Зима-Весна')
INSERT [dbo].[Season] ([IdSeason], [NameSeason]) VALUES (9, N'Всесезонная')
SET IDENTITY_INSERT [dbo].[Season] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeOfClothing] ON 

INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (1, 1, N'Туфли')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (2, 1, N'Мокасины')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (4, 1, N'Эспадрильи')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (5, 1, N'Шлепанцы')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (6, 1, N'Сандали')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (7, 1, N'Кроссовки')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (8, 1, N'Кеды')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (9, 1, N'Ботинки')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (10, 1, N'Сапоги')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (11, 1, N'Балетки')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (12, 1, N'Босоножки')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (13, 1, N'Ботильоны')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (14, 1, N'Домашняя обувь')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (15, 2, N'Футболки')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (16, 2, N'Шорты')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (17, 2, N'Брюки')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (18, 2, N'Джинсы')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (19, 2, N'Рубашки')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (20, 2, N'Пиджаки')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (21, 2, N'Костюмы')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (22, 2, N'Блузы')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (23, 2, N'Платья')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (24, 2, N'Топы')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (25, 2, N'Бриджи')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (27, 2, N'Юбки')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (28, 2, N'Комбинезоны')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (29, 2, N'Жакеты')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (30, 2, N'Жилеты')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (31, 10, N'Свитеры')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (32, 10, N'Джемперы')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (33, 10, N'Пуловеры')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (34, 10, N'Кофты')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (35, 10, N'Гольфы')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (36, 10, N'Туники')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (37, 10, N'Регланы')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (38, 3, N'Пуховики')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (39, 3, N'Куртки')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (40, 3, N'Пальто')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (41, 3, N'Ветровки')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (42, 3, N'Жилеты')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (43, 3, N'Плащи')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (44, 4, N'Сумки')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (45, 4, N'Рюкзаки')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (47, 4, N'Барсетки')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (48, 4, N'Портфели')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (49, 4, N'Портмоне')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (50, 4, N'Клатчи')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (51, 4, N'Кошельки')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (52, 11, N'Головные уборы')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (53, 11, N'Перчатки')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (55, 11, N'Шарфы')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (56, 11, N'Ремни')
INSERT [dbo].[TypeOfClothing] ([IdTypeOfClothing], [IdViewIdOfClothing], [NameIdTypeOfClothing]) VALUES (57, 11, N'Платки')
SET IDENTITY_INSERT [dbo].[TypeOfClothing] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([IdUser], [LoginUser], [PasswordUser], [IdRole]) VALUES (1, N'2', N'2', 2)
INSERT [dbo].[User] ([IdUser], [LoginUser], [PasswordUser], [IdRole]) VALUES (2, N'3', N'3', 3)
INSERT [dbo].[User] ([IdUser], [LoginUser], [PasswordUser], [IdRole]) VALUES (3, N'4', N'4', 4)
INSERT [dbo].[User] ([IdUser], [LoginUser], [PasswordUser], [IdRole]) VALUES (4, N'5', N'5', 5)
INSERT [dbo].[User] ([IdUser], [LoginUser], [PasswordUser], [IdRole]) VALUES (6, N'DrLoki', N'LegkiyPorol', 3)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[ViewOfClothing] ON 

INSERT [dbo].[ViewOfClothing] ([IdViewIdOfClothing], [NameIdViewIdOfClothing]) VALUES (1, N'Обувь')
INSERT [dbo].[ViewOfClothing] ([IdViewIdOfClothing], [NameIdViewIdOfClothing]) VALUES (2, N'Одежда')
INSERT [dbo].[ViewOfClothing] ([IdViewIdOfClothing], [NameIdViewIdOfClothing]) VALUES (3, N'Верхняя одежда')
INSERT [dbo].[ViewOfClothing] ([IdViewIdOfClothing], [NameIdViewIdOfClothing]) VALUES (4, N'Сумки')
INSERT [dbo].[ViewOfClothing] ([IdViewIdOfClothing], [NameIdViewIdOfClothing]) VALUES (5, N'Очки')
INSERT [dbo].[ViewOfClothing] ([IdViewIdOfClothing], [NameIdViewIdOfClothing]) VALUES (6, N'Деним')
INSERT [dbo].[ViewOfClothing] ([IdViewIdOfClothing], [NameIdViewIdOfClothing]) VALUES (7, N'Спортивная одежда')
INSERT [dbo].[ViewOfClothing] ([IdViewIdOfClothing], [NameIdViewIdOfClothing]) VALUES (8, N'Пляжная одежда')
INSERT [dbo].[ViewOfClothing] ([IdViewIdOfClothing], [NameIdViewIdOfClothing]) VALUES (9, N'Нижнее бельё')
INSERT [dbo].[ViewOfClothing] ([IdViewIdOfClothing], [NameIdViewIdOfClothing]) VALUES (10, N'Трикотаж')
INSERT [dbo].[ViewOfClothing] ([IdViewIdOfClothing], [NameIdViewIdOfClothing]) VALUES (11, N'Аксессуары')
INSERT [dbo].[ViewOfClothing] ([IdViewIdOfClothing], [NameIdViewIdOfClothing]) VALUES (12, N'Купальники')
INSERT [dbo].[ViewOfClothing] ([IdViewIdOfClothing], [NameIdViewIdOfClothing]) VALUES (13, N'Домашняя одежда')
INSERT [dbo].[ViewOfClothing] ([IdViewIdOfClothing], [NameIdViewIdOfClothing]) VALUES (14, N'Украшения')
SET IDENTITY_INSERT [dbo].[ViewOfClothing] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_NameRole_Role]    Script Date: 3/28/2023 9:09:35 AM ******/
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [UK_NameRole_Role] UNIQUE NONCLUSTERED 
(
	[NameRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UK_PhoneNumberStaff_Staff]    Script Date: 3/28/2023 9:09:35 AM ******/
ALTER TABLE [dbo].[Staff] ADD  CONSTRAINT [UK_PhoneNumberStaff_Staff] UNIQUE NONCLUSTERED 
(
	[PhoneNubmerStaff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_EmailStaff_Staff]    Script Date: 3/28/2023 9:09:35 AM ******/
CREATE NONCLUSTERED INDEX [UK_EmailStaff_Staff] ON [dbo].[Staff]
(
	[EmailStaff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_LoginUser_User]    Script Date: 3/28/2023 9:09:35 AM ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UK_LoginUser_User] UNIQUE NONCLUSTERED 
(
	[LoginUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AvailabilityInternet]  WITH CHECK ADD  CONSTRAINT [FK_AvailabilityInternet_Staff] FOREIGN KEY([IdStaff])
REFERENCES [dbo].[Staff] ([IdStaff])
GO
ALTER TABLE [dbo].[AvailabilityInternet] CHECK CONSTRAINT [FK_AvailabilityInternet_Staff]
GO
ALTER TABLE [dbo].[AvailabilityInternet]  WITH CHECK ADD  CONSTRAINT [FK_AvailabilityInternet_Store] FOREIGN KEY([IdStore])
REFERENCES [dbo].[Store] ([IdStore])
GO
ALTER TABLE [dbo].[AvailabilityInternet] CHECK CONSTRAINT [FK_AvailabilityInternet_Store]
GO
ALTER TABLE [dbo].[AvailabilityLocal]  WITH CHECK ADD  CONSTRAINT [FK_AvailabilityLocal_Staff] FOREIGN KEY([IdStaff])
REFERENCES [dbo].[Staff] ([IdStaff])
GO
ALTER TABLE [dbo].[AvailabilityLocal] CHECK CONSTRAINT [FK_AvailabilityLocal_Staff]
GO
ALTER TABLE [dbo].[AvailabilityLocal]  WITH CHECK ADD  CONSTRAINT [FK_AvailabilityLocal_Store] FOREIGN KEY([IdStore])
REFERENCES [dbo].[Store] ([IdStore])
GO
ALTER TABLE [dbo].[AvailabilityLocal] CHECK CONSTRAINT [FK_AvailabilityLocal_Store]
GO
ALTER TABLE [dbo].[Clothes]  WITH CHECK ADD  CONSTRAINT [FK_Clothes_Collection] FOREIGN KEY([IdCollection])
REFERENCES [dbo].[Collection] ([IdCollection])
GO
ALTER TABLE [dbo].[Clothes] CHECK CONSTRAINT [FK_Clothes_Collection]
GO
ALTER TABLE [dbo].[Clothes]  WITH CHECK ADD  CONSTRAINT [FK_Clothes_Gender] FOREIGN KEY([IdGender])
REFERENCES [dbo].[Gender] ([IdGender])
GO
ALTER TABLE [dbo].[Clothes] CHECK CONSTRAINT [FK_Clothes_Gender]
GO
ALTER TABLE [dbo].[Clothes]  WITH CHECK ADD  CONSTRAINT [FK_Clothes_Season] FOREIGN KEY([IdSeason])
REFERENCES [dbo].[Season] ([IdSeason])
GO
ALTER TABLE [dbo].[Clothes] CHECK CONSTRAINT [FK_Clothes_Season]
GO
ALTER TABLE [dbo].[Clothes]  WITH CHECK ADD  CONSTRAINT [FK_Clothes_TypeOfClothing] FOREIGN KEY([IdTypeOfClothing])
REFERENCES [dbo].[TypeOfClothing] ([IdTypeOfClothing])
GO
ALTER TABLE [dbo].[Clothes] CHECK CONSTRAINT [FK_Clothes_TypeOfClothing]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Clothes] FOREIGN KEY([IdClothes])
REFERENCES [dbo].[Clothes] ([IdClothes])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Clothes]
GO
ALTER TABLE [dbo].[Sale]  WITH CHECK ADD  CONSTRAINT [FK_Sale_Staff] FOREIGN KEY([IdStaff])
REFERENCES [dbo].[Staff] ([IdStaff])
GO
ALTER TABLE [dbo].[Sale] CHECK CONSTRAINT [FK_Sale_Staff]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_User]
GO
ALTER TABLE [dbo].[Store]  WITH CHECK ADD  CONSTRAINT [FK_Store_Product] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Product] ([IdProduct])
GO
ALTER TABLE [dbo].[Store] CHECK CONSTRAINT [FK_Store_Product]
GO
ALTER TABLE [dbo].[Store]  WITH CHECK ADD  CONSTRAINT [FK_Store_Staff] FOREIGN KEY([IdStaff])
REFERENCES [dbo].[Staff] ([IdStaff])
GO
ALTER TABLE [dbo].[Store] CHECK CONSTRAINT [FK_Store_Staff]
GO
ALTER TABLE [dbo].[TypeOfClothing]  WITH CHECK ADD  CONSTRAINT [FK_TypeOfClothing_ViewOfClothing] FOREIGN KEY([IdViewIdOfClothing])
REFERENCES [dbo].[ViewOfClothing] ([IdViewIdOfClothing])
GO
ALTER TABLE [dbo].[TypeOfClothing] CHECK CONSTRAINT [FK_TypeOfClothing_ViewOfClothing]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([IdRole])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [Yaroshevski1] SET  READ_WRITE 
GO
