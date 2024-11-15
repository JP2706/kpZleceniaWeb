USE [master]
GO
/****** Object:  Database [kpZleceniaWeb]    Script Date: 11.11.2024 16:58:28 ******/
CREATE DATABASE [kpZleceniaWeb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'kpZleceniaWeb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\kpZleceniaWeb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'kpZleceniaWeb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\kpZleceniaWeb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [kpZleceniaWeb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [kpZleceniaWeb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [kpZleceniaWeb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [kpZleceniaWeb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [kpZleceniaWeb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [kpZleceniaWeb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [kpZleceniaWeb] SET ARITHABORT OFF 
GO
ALTER DATABASE [kpZleceniaWeb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [kpZleceniaWeb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [kpZleceniaWeb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [kpZleceniaWeb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [kpZleceniaWeb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [kpZleceniaWeb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [kpZleceniaWeb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [kpZleceniaWeb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [kpZleceniaWeb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [kpZleceniaWeb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [kpZleceniaWeb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [kpZleceniaWeb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [kpZleceniaWeb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [kpZleceniaWeb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [kpZleceniaWeb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [kpZleceniaWeb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [kpZleceniaWeb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [kpZleceniaWeb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [kpZleceniaWeb] SET  MULTI_USER 
GO
ALTER DATABASE [kpZleceniaWeb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [kpZleceniaWeb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [kpZleceniaWeb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [kpZleceniaWeb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [kpZleceniaWeb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [kpZleceniaWeb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [kpZleceniaWeb] SET QUERY_STORE = OFF
GO
USE [kpZleceniaWeb]
GO
/****** Object:  UserDefinedFunction [dbo].[FuncAdres]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[FuncAdres] (@k varchar(50), @p varchar(50), @m varchar(50), @u varchar(50), @d varchar(50), @l varchar(50) ) RETURNS varchar(500)
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- k.adr_kod, k.adr_poczta, k.adr_miejscowosc, k.adr_ulica, k.adr_dom, k.adr_lokal
-- Budowanie adresu w jednej lini ...
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
AS
BEGIN
	declare @adres as varchar(500)
set @adres=ltrim(
		case when rtrim(isnull(@k,'') + ' ' + isnull(@p,''))='' then '' else  isnull(@k,'') + ' ' + isnull(@p,'') + ' , ' end + 
		case when isnull(@u,'')='' then isnull(@m,'') else @u end + ' ' + isnull(@d,'') + 
		case when isnull(@l,'')='' then '' else '/' + @l end
		)

RETURN @adres

END
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppCombo]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppCombo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Forms] [varchar](50) NOT NULL,
	[Combo] [varchar](50) NOT NULL,
	[Zrodlo] [varchar](2000) NOT NULL,
 CONSTRAINT [PK_AppCombo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](200) NULL,
	[LastName] [nvarchar](200) NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[RefreshTokenExpiryTime] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[RegisterDateTime] [datetime2](7) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Firma]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Firma](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nazwa] [nvarchar](200) NOT NULL,
	[NIP] [nvarchar](10) NOT NULL,
	[Adres] [nvarchar](1200) NOT NULL,
	[Telefon] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[KodPocztowy] [nvarchar](200) NOT NULL,
	[Miejscowosc] [nvarchar](200) NOT NULL,
	[NumerDomu] [nvarchar](200) NOT NULL,
	[NumerLokalu] [nvarchar](200) NOT NULL,
	[Poczta] [nvarchar](200) NOT NULL,
	[Ulica] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Firma] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Klient]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Imie] [nvarchar](100) NULL,
	[Nazwisko] [nvarchar](100) NULL,
	[Nazwa] [nvarchar](200) NULL,
	[Tel] [nvarchar](50) NULL,
 CONSTRAINT [PK_Klient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypUrzadzenia]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypUrzadzenia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nazwa] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_TypUrzadzenia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zlecenie]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zlecenie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Symbol] [nvarchar](300) NOT NULL,
	[Urzadzenie] [nvarchar](300) NOT NULL,
	[NumerSer] [nvarchar](300) NULL,
	[OpisUsterki] [nvarchar](300) NOT NULL,
	[Opis] [nvarchar](300) NULL,
	[DataPrzyjecie] [datetime2](7) NOT NULL,
	[DataRozpoczRealizacji] [datetime2](7) NULL,
	[DataZakRealizacji] [datetime2](7) NULL,
	[DataWydania] [datetime2](7) NULL,
	[ZlecenieStatusId] [int] NOT NULL,
	[KlientId] [int] NOT NULL,
	[TypUrzadzeniaId] [int] NOT NULL,
	[ApplicationUserId] [nvarchar](450) NOT NULL,
	[DataModyfikacji] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Zlecenie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZlecenieStatus]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZlecenieStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nazwa] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_ZlecenieStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 11.11.2024 16:58:28 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 11.11.2024 16:58:28 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 11.11.2024 16:58:28 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 11.11.2024 16:58:28 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 11.11.2024 16:58:28 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 11.11.2024 16:58:28 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 11.11.2024 16:58:28 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Zlecenie_ApplicationUserId]    Script Date: 11.11.2024 16:58:28 ******/
CREATE NONCLUSTERED INDEX [IX_Zlecenie_ApplicationUserId] ON [dbo].[Zlecenie]
(
	[ApplicationUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Zlecenie_KlientId]    Script Date: 11.11.2024 16:58:28 ******/
CREATE NONCLUSTERED INDEX [IX_Zlecenie_KlientId] ON [dbo].[Zlecenie]
(
	[KlientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Zlecenie_TypUrzadzeniaId]    Script Date: 11.11.2024 16:58:28 ******/
CREATE NONCLUSTERED INDEX [IX_Zlecenie_TypUrzadzeniaId] ON [dbo].[Zlecenie]
(
	[TypUrzadzeniaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Zlecenie_ZlecenieStatusId]    Script Date: 11.11.2024 16:58:28 ******/
CREATE NONCLUSTERED INDEX [IX_Zlecenie_ZlecenieStatusId] ON [dbo].[Zlecenie]
(
	[ZlecenieStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Firma] ADD  DEFAULT (N'') FOR [KodPocztowy]
GO
ALTER TABLE [dbo].[Firma] ADD  DEFAULT (N'') FOR [Miejscowosc]
GO
ALTER TABLE [dbo].[Firma] ADD  DEFAULT (N'') FOR [NumerDomu]
GO
ALTER TABLE [dbo].[Firma] ADD  DEFAULT (N'') FOR [NumerLokalu]
GO
ALTER TABLE [dbo].[Firma] ADD  DEFAULT (N'') FOR [Poczta]
GO
ALTER TABLE [dbo].[Firma] ADD  DEFAULT (N'') FOR [Ulica]
GO
ALTER TABLE [dbo].[Zlecenie] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DataModyfikacji]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Zlecenie]  WITH CHECK ADD  CONSTRAINT [FK_Zlecenie_AspNetUsers_ApplicationUserId] FOREIGN KEY([ApplicationUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Zlecenie] CHECK CONSTRAINT [FK_Zlecenie_AspNetUsers_ApplicationUserId]
GO
ALTER TABLE [dbo].[Zlecenie]  WITH CHECK ADD  CONSTRAINT [FK_Zlecenie_Klient_KlientId] FOREIGN KEY([KlientId])
REFERENCES [dbo].[Klient] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Zlecenie] CHECK CONSTRAINT [FK_Zlecenie_Klient_KlientId]
GO
ALTER TABLE [dbo].[Zlecenie]  WITH CHECK ADD  CONSTRAINT [FK_Zlecenie_TypUrzadzenia_TypUrzadzeniaId] FOREIGN KEY([TypUrzadzeniaId])
REFERENCES [dbo].[TypUrzadzenia] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Zlecenie] CHECK CONSTRAINT [FK_Zlecenie_TypUrzadzenia_TypUrzadzeniaId]
GO
ALTER TABLE [dbo].[Zlecenie]  WITH CHECK ADD  CONSTRAINT [FK_Zlecenie_ZlecenieStatus_ZlecenieStatusId] FOREIGN KEY([ZlecenieStatusId])
REFERENCES [dbo].[ZlecenieStatus] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Zlecenie] CHECK CONSTRAINT [FK_Zlecenie_ZlecenieStatus_ZlecenieStatusId]
GO
/****** Object:  StoredProcedure [dbo].[pAddEditFirma]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pAddEditFirma]
@Id int,
@Nip nvarchar(10),
@Nazwa nvarchar(200),
@Telefon nvarchar(30),
@Email nvarchar(50),
@Ulica nvarchar(50),
@NumerDomu nvarchar(50),
@NumerLokalu nvarchar(50),
@Miejscowosc nvarchar(50),
@KodPocztowy nvarchar(50),
@Poczta nvarchar(50),

@Blad smallint		= -255		OUT,
@Info varchar(250)	= ''		OUT
AS
DECLARE @nl varchar(2)			= CHAR(10) + CHAR(13)
DECLARE @Adres varchar(200) = '';
BEGIN
	SET NOCOUNT ON;

	EXEC @Adres = dbo.FuncAdres @KodPocztowy, @Poczta, @Miejscowosc, @Ulica, @NumerDomu, @NumerLokalu

	IF (@Id = 0)
		BEGIN
			INSERT INTO Firma (Nazwa, NIP, Adres, Telefon, Email, Ulica, NumerDomu, NumerLokalu, Miejscowosc, KodPocztowy, Poczta)
			VALUES
			(@Nazwa, @Nip, @Adres, @Telefon, @Email, @Ulica, @NumerDomu, @NumerLokalu, @Miejscowosc, @KodPocztowy, @Poczta)
		END 
	ELSE
		BEGIN
			IF NOT EXISTS( SELECT TOP 1 * FROM Firma WHERE Id = @Id)
			BEGIN
				SET @Blad = -100
				SET @Info = 'Brak firmy o takim Id w bazie danych.'
				RETURN @Blad  
			END
			UPDATE Firma
			SET Nazwa=@Nazwa, NIP=@Nip, Adres = @Adres, @Telefon=@Telefon, Email=@Email, Ulica=@Ulica, NumerDomu=@NumerDomu, NumerLokalu=@NumerLokalu, Miejscowosc=@Miejscowosc, KodPocztowy = @KodPocztowy, @Poczta = @Poczta
			WHERE Id = @Id
		END
SET @Blad = 0
SET @Info = ''
RETURN @Blad    
   
END
GO
/****** Object:  StoredProcedure [dbo].[pAddEditZlecenie]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pAddEditZlecenie]
@Id int,
@Symbol nvarchar(300),
@Urzadzenie nvarchar(300),
@NumerSer nvarchar(300),
@OpisUsterki nvarchar(300),
@Opis nvarchar(300),
@DataPrzyjecie datetime,
@DataRozpoczRealizacji datetime = NULL,
@DataZakRealizacji datetime = NULL,
@DataWydania datetime = NULL,
@ZlecenieStatusId int,
@KlientId int,
@TypUrzadzeniaId int,
@ApplicationUserId nvarchar(450),

@Blad smallint		= -255		OUT,
@Info varchar(250)	= ''		OUT
AS
DECLARE @nl varchar(2)			= CHAR(10) + CHAR(13)
BEGIN
	SET NOCOUNT ON;
	IF (@Id = 0)
		BEGIN
			INSERT INTO Zlecenie (Symbol, Urzadzenie, NumerSer,  OpisUsterki, 
			Opis, DataPrzyjecie, DataRozpoczRealizacji, DataZakRealizacji, DataWydania,
			ZlecenieStatusId, KlientId, TypUrzadzeniaId, ApplicationUserId)
			VALUES
			(@Symbol, @Urzadzenie, @NumerSer, @OpisUsterki, 
			@Opis, @DataPrzyjecie, @DataRozpoczRealizacji, @DataZakRealizacji, @DataWydania, 
			 @ZlecenieStatusId, @KlientId, @TypUrzadzeniaId, @ApplicationUserId)
		END 
	ELSE
		BEGIN
		IF NOT EXISTS( SELECT TOP 1 * FROM Zlecenie WHERE Id = @Id)
			BEGIN
				SET @Blad = -100
				SET @Info = 'Brak zlecenia o takim Id w bazie danych.'
				RETURN @Blad  
			END
			UPDATE Zlecenie 
			SET Symbol=@Symbol, Urzadzenie=@Urzadzenie, NumerSer= @NumerSer, OpisUsterki=@OpisUsterki, 
			Opis=@Opis, DataPrzyjecie=@DataPrzyjecie, DataRozpoczRealizacji=@DataRozpoczRealizacji, DataZakRealizacji=@DataZakRealizacji, DataWydania=@DataWydania,
			 ZlecenieStatusId=@ZlecenieStatusId, KlientId=@KlientId, 
			TypUrzadzeniaId=@TypUrzadzeniaId, ApplicationUserId=@ApplicationUserId
			WHERE Id = @Id
		END

SET @Blad = 0
SET @Info = ''
RETURN @Blad    
END

GO
/****** Object:  StoredProcedure [dbo].[pAppCombo]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[pAppCombo]
@forms varchar(30)	= '',
@combo varchar(30)	= ''
AS
DECLARE @zrodlo varchar(2000)	= ''
BEGIN
SET NOCOUNT ON;
-----------------------------------------------------------------------------------------------------
    SELECT TOP 1 @zrodlo = Zrodlo FROM dbo.AppCombo WHERE (Forms=@forms) AND (Combo=@combo)
-----------------------------------------------------------------------------------------------------
	EXECUTE(@zrodlo)
-----------------------------------------------------------------------------------------------------
END
GO
/****** Object:  StoredProcedure [dbo].[pGetCzyKlientMaZlecenia]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pGetCzyKlientMaZlecenia]
@KlientId int,
@CzyMa bit out
AS
BEGIN
	SET NOCOUNT ON;
	IF EXISTS (SELECT TOP 1  * FROM Zlecenie WHERE KlientId = @KlientId)
	BEGIN
	SET @CzyMa = 1
	END
	ELSE
	BEGIN
	SET @CzyMa = 0
	END
	
RETURN @CzyMa
END
GO
/****** Object:  StoredProcedure [dbo].[pGetKlientLastZlecenia]    Script Date: 11.11.2024 16:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pGetKlientLastZlecenia]
@KlientId int,
@Ile int
AS
BEGIN
	SET NOCOUNT ON;

     SELECT TOP (@Ile) Zlecenie.Id, Symbol, Urzadzenie, NumerSer, OpisUsterki, Opis, DataPrzyjecie, DataRozpoczRealizacji, DataZakRealizacji, DataWydania, ZlecenieStatusId, 
 KlientId, TypUrzadzeniaId, ApplicationUserId, DataModyfikacji, kl.Id AS Id_k, kl.Imie, kl.Nazwisko, kl.Nazwa, kl.Tel, zs.Nazwa as ZlecenieStatus FROM Zlecenie 
	INNER JOIN Klient AS kl ON kl.Id = Zlecenie.KlientId
	INNER JOIN ZlecenieStatus as zs ON zs.Id = Zlecenie.ZlecenieStatusId
	WHERE Zlecenie.Id IN (SELECT Id FROM Zlecenie WHERE KlientId = @KlientId)  ORDER BY DataPrzyjecie DESC
END
GO
USE [master]
GO
ALTER DATABASE [kpZleceniaWeb] SET  READ_WRITE 
GO
