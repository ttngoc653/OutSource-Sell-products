USE [master]
GO
/****** Object:  Database [SellProduct_DB]    Script Date: 06/04/2022 18:04:49 ******/
CREATE DATABASE [SellProduct_DB] ON  PRIMARY 
( NAME = N'SellProduct_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SellProduct_DB.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SellProduct_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SellProduct_DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SellProduct_DB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SellProduct_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SellProduct_DB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [SellProduct_DB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [SellProduct_DB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [SellProduct_DB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [SellProduct_DB] SET ARITHABORT OFF
GO
ALTER DATABASE [SellProduct_DB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [SellProduct_DB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [SellProduct_DB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [SellProduct_DB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [SellProduct_DB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [SellProduct_DB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [SellProduct_DB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [SellProduct_DB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [SellProduct_DB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [SellProduct_DB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [SellProduct_DB] SET  DISABLE_BROKER
GO
ALTER DATABASE [SellProduct_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [SellProduct_DB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [SellProduct_DB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [SellProduct_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [SellProduct_DB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [SellProduct_DB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [SellProduct_DB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [SellProduct_DB] SET  READ_WRITE
GO
ALTER DATABASE [SellProduct_DB] SET RECOVERY SIMPLE
GO
ALTER DATABASE [SellProduct_DB] SET  MULTI_USER
GO
ALTER DATABASE [SellProduct_DB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [SellProduct_DB] SET DB_CHAINING OFF
GO
USE [SellProduct_DB]
GO
/****** Object:  Table [dbo].[CATEGORIES]    Script Date: 06/04/2022 18:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIES](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[cat_parent] [int] NULL,
	[detail] [text] NULL,
 CONSTRAINT [PK_CATEGORIES] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CUSTOMERS]    Script Date: 06/04/2022 18:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUSTOMERS](
	[phone] [nchar](16) NOT NULL,
	[name] [nvarchar](50) NULL,
	[address] [nvarchar](max) NULL,
 CONSTRAINT [PK_CUSTOMERS] PRIMARY KEY CLUSTERED 
(
	[phone] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MANUFACTURERES]    Script Date: 06/04/2022 18:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MANUFACTURERES](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[detail] [text] NULL,
 CONSTRAINT [PK_MANUFACTURERES] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MANAGERS]    Script Date: 06/04/2022 18:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MANAGERS](
	[account] [nvarchar](64) NOT NULL,
	[name] [nvarchar](max) NULL,
	[password] [nvarchar](max) NOT NULL,
	[phone] [nvarchar](16) NOT NULL,
	[email] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
	[type] [nvarchar](50) NULL,
	[is_disable] [bit] NULL,
	[comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_MANAGERS] PRIMARY KEY CLUSTERED 
(
	[account] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MADEINS]    Script Date: 06/04/2022 18:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MADEINS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[location] [nvarchar](max) NULL,
	[detail] [text] NULL,
 CONSTRAINT [PK_MADEIN] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROMOTIONS]    Script Date: 06/04/2022 18:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROMOTIONS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](32) NOT NULL,
	[title] [nvarchar](max) NOT NULL,
	[detail] [text] NOT NULL,
	[date_start] [datetime] NULL,
	[date_end] [datetime] NULL,
	[type] [nchar](10) NOT NULL,
	[percent_discount] [decimal](4, 2) NULL,
	[discount] [int] NULL,
	[is_stop] [bit] NOT NULL,
	[is_hide] [bit] NOT NULL,
	[amount] [int] NULL,
 CONSTRAINT [PK_PROMOTIONS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTS]    Script Date: 06/04/2022 18:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nchar](10) NULL,
	[name] [nvarchar](max) NOT NULL,
	[price] [int] NULL,
	[price_sale] [int] NULL,
	[describe] [nvarchar](max) NULL,
	[detail] [text] NULL,
	[avatar] [nvarchar](128) NULL,
	[amount_current] [int] NULL,
	[madein] [int] NULL,
	[manufacturer] [int] NULL,
	[is_hide] [bit] NOT NULL,
 CONSTRAINT [PK_PRODUCTS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ORDERS]    Script Date: 06/04/2022 18:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORDERS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[time] [datetime] NOT NULL,
	[customer] [nchar](16) NOT NULL,
	[promotion] [int] NULL,
	[total] [int] NULL,
	[comment] [text] NULL,
 CONSTRAINT [PK_ORDERS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SETTINGS]    Script Date: 06/04/2022 18:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SETTINGS](
	[name] [nvarchar](128) NOT NULL,
	[value] [nvarchar](max) NULL,
	[account] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_SETTINGS] PRIMARY KEY CLUSTERED 
(
	[name] ASC,
	[account] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ACTIONS]    Script Date: 06/04/2022 18:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACTIONS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idref] [nvarchar](64) NOT NULL,
	[time] [datetime] NULL,
	[detail] [text] NULL,
	[manager] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_ACTIONS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLASSIFIES]    Script Date: 06/04/2022 18:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLASSIFIES](
	[category] [int] NOT NULL,
	[product] [int] NOT NULL,
 CONSTRAINT [PK_CLASSIFIES] PRIMARY KEY CLUSTERED 
(
	[category] ASC,
	[product] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CARTS]    Script Date: 06/04/2022 18:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CARTS](
	[idorder] [int] NOT NULL,
	[idproduct] [int] NOT NULL,
	[amount] [int] NOT NULL,
	[price] [int] NOT NULL,
 CONSTRAINT [PK_CARTS] PRIMARY KEY CLUSTERED 
(
	[idorder] ASC,
	[idproduct] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HISTORIES]    Script Date: 06/04/2022 18:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HISTORIES](
	[idorder] [int] NOT NULL,
	[datetime] [datetime] NOT NULL,
	[detail] [text] NULL,
	[act] [text] NULL,
 CONSTRAINT [PK_HISTORIES] PRIMARY KEY CLUSTERED 
(
	[idorder] ASC,
	[datetime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Default [DF_PRODUCTS_price]    Script Date: 06/04/2022 18:04:52 ******/
ALTER TABLE [dbo].[PRODUCTS] ADD  CONSTRAINT [DF_PRODUCTS_price]  DEFAULT ((0)) FOR [price]
GO
/****** Object:  Default [DF_PRODUCTS_is_hide]    Script Date: 06/04/2022 18:04:52 ******/
ALTER TABLE [dbo].[PRODUCTS] ADD  CONSTRAINT [DF_PRODUCTS_is_hide]  DEFAULT ((0)) FOR [is_hide]
GO
/****** Object:  ForeignKey [FK_CATEGORIES_CATEGORIES]    Script Date: 06/04/2022 18:04:52 ******/
ALTER TABLE [dbo].[CATEGORIES]  WITH CHECK ADD  CONSTRAINT [FK_CATEGORIES_CATEGORIES] FOREIGN KEY([cat_parent])
REFERENCES [dbo].[CATEGORIES] ([id])
GO
ALTER TABLE [dbo].[CATEGORIES] CHECK CONSTRAINT [FK_CATEGORIES_CATEGORIES]
GO
/****** Object:  ForeignKey [FK_PRODUCTS_MADEINS]    Script Date: 06/04/2022 18:04:52 ******/
ALTER TABLE [dbo].[PRODUCTS]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTS_MADEINS] FOREIGN KEY([madein])
REFERENCES [dbo].[MADEINS] ([id])
GO
ALTER TABLE [dbo].[PRODUCTS] CHECK CONSTRAINT [FK_PRODUCTS_MADEINS]
GO
/****** Object:  ForeignKey [FK_PRODUCTS_MANUFACTURERES]    Script Date: 06/04/2022 18:04:52 ******/
ALTER TABLE [dbo].[PRODUCTS]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTS_MANUFACTURERES] FOREIGN KEY([manufacturer])
REFERENCES [dbo].[MANUFACTURERES] ([id])
GO
ALTER TABLE [dbo].[PRODUCTS] CHECK CONSTRAINT [FK_PRODUCTS_MANUFACTURERES]
GO
/****** Object:  ForeignKey [FK_ORDERS_CUSTOMERS]    Script Date: 06/04/2022 18:04:52 ******/
ALTER TABLE [dbo].[ORDERS]  WITH CHECK ADD  CONSTRAINT [FK_ORDERS_CUSTOMERS] FOREIGN KEY([customer])
REFERENCES [dbo].[CUSTOMERS] ([phone])
GO
ALTER TABLE [dbo].[ORDERS] CHECK CONSTRAINT [FK_ORDERS_CUSTOMERS]
GO
/****** Object:  ForeignKey [FK_ORDERS_PROMOTIONS]    Script Date: 06/04/2022 18:04:52 ******/
ALTER TABLE [dbo].[ORDERS]  WITH CHECK ADD  CONSTRAINT [FK_ORDERS_PROMOTIONS] FOREIGN KEY([promotion])
REFERENCES [dbo].[PROMOTIONS] ([id])
GO
ALTER TABLE [dbo].[ORDERS] CHECK CONSTRAINT [FK_ORDERS_PROMOTIONS]
GO
/****** Object:  ForeignKey [FK_SETTINGS_MANAGERS]    Script Date: 06/04/2022 18:04:52 ******/
ALTER TABLE [dbo].[SETTINGS]  WITH CHECK ADD  CONSTRAINT [FK_SETTINGS_MANAGERS] FOREIGN KEY([account])
REFERENCES [dbo].[MANAGERS] ([account])
GO
ALTER TABLE [dbo].[SETTINGS] CHECK CONSTRAINT [FK_SETTINGS_MANAGERS]
GO
/****** Object:  ForeignKey [FK_ACTIONS_MANAGERS1]    Script Date: 06/04/2022 18:04:52 ******/
ALTER TABLE [dbo].[ACTIONS]  WITH CHECK ADD  CONSTRAINT [FK_ACTIONS_MANAGERS1] FOREIGN KEY([manager])
REFERENCES [dbo].[MANAGERS] ([account])
GO
ALTER TABLE [dbo].[ACTIONS] CHECK CONSTRAINT [FK_ACTIONS_MANAGERS1]
GO
/****** Object:  ForeignKey [FK_CLASSIFIES_CATEGORIES]    Script Date: 06/04/2022 18:04:52 ******/
ALTER TABLE [dbo].[CLASSIFIES]  WITH CHECK ADD  CONSTRAINT [FK_CLASSIFIES_CATEGORIES] FOREIGN KEY([category])
REFERENCES [dbo].[CATEGORIES] ([id])
GO
ALTER TABLE [dbo].[CLASSIFIES] CHECK CONSTRAINT [FK_CLASSIFIES_CATEGORIES]
GO
/****** Object:  ForeignKey [FK_CLASSIFIES_PRODUCTS]    Script Date: 06/04/2022 18:04:52 ******/
ALTER TABLE [dbo].[CLASSIFIES]  WITH CHECK ADD  CONSTRAINT [FK_CLASSIFIES_PRODUCTS] FOREIGN KEY([product])
REFERENCES [dbo].[PRODUCTS] ([id])
GO
ALTER TABLE [dbo].[CLASSIFIES] CHECK CONSTRAINT [FK_CLASSIFIES_PRODUCTS]
GO
/****** Object:  ForeignKey [FK_CARTS_ORDERS]    Script Date: 06/04/2022 18:04:52 ******/
ALTER TABLE [dbo].[CARTS]  WITH CHECK ADD  CONSTRAINT [FK_CARTS_ORDERS] FOREIGN KEY([idorder])
REFERENCES [dbo].[ORDERS] ([id])
GO
ALTER TABLE [dbo].[CARTS] CHECK CONSTRAINT [FK_CARTS_ORDERS]
GO
/****** Object:  ForeignKey [FK_CARTS_PRODUCTS]    Script Date: 06/04/2022 18:04:52 ******/
ALTER TABLE [dbo].[CARTS]  WITH CHECK ADD  CONSTRAINT [FK_CARTS_PRODUCTS] FOREIGN KEY([idproduct])
REFERENCES [dbo].[PRODUCTS] ([id])
GO
ALTER TABLE [dbo].[CARTS] CHECK CONSTRAINT [FK_CARTS_PRODUCTS]
GO
/****** Object:  ForeignKey [FK_HISTORIES_ORDERS]    Script Date: 06/04/2022 18:04:52 ******/
ALTER TABLE [dbo].[HISTORIES]  WITH CHECK ADD  CONSTRAINT [FK_HISTORIES_ORDERS] FOREIGN KEY([idorder])
REFERENCES [dbo].[ORDERS] ([id])
GO
ALTER TABLE [dbo].[HISTORIES] CHECK CONSTRAINT [FK_HISTORIES_ORDERS]
GO
