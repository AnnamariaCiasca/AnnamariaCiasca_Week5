USE [master]
GO
/****** Object:  Database [GestoreTask]    Script Date: 8/27/2021 1:07:32 PM ******/
CREATE DATABASE [GestoreTask]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GestoreTask', FILENAME = N'C:\Users\annamaria.ciasca\GestoreTask.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GestoreTask_log', FILENAME = N'C:\Users\annamaria.ciasca\GestoreTask_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GestoreTask] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GestoreTask].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GestoreTask] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GestoreTask] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GestoreTask] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GestoreTask] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GestoreTask] SET ARITHABORT OFF 
GO
ALTER DATABASE [GestoreTask] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GestoreTask] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GestoreTask] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GestoreTask] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GestoreTask] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GestoreTask] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GestoreTask] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GestoreTask] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GestoreTask] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GestoreTask] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GestoreTask] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GestoreTask] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GestoreTask] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GestoreTask] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GestoreTask] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GestoreTask] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GestoreTask] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GestoreTask] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GestoreTask] SET  MULTI_USER 
GO
ALTER DATABASE [GestoreTask] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GestoreTask] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GestoreTask] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GestoreTask] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GestoreTask] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GestoreTask] SET QUERY_STORE = OFF
GO
USE [GestoreTask]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [GestoreTask]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 8/27/2021 1:07:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[Titolo] [nvarchar](50) NOT NULL,
	[Descrizione] [nvarchar](100) NOT NULL,
	[DataScadenza] [datetime] NOT NULL,
	[Importanza] [int] NOT NULL,
	[Terminato] [bit] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Task] ON 

INSERT [dbo].[Task] ([Titolo], [Descrizione], [DataScadenza], [Importanza], [Terminato], [Id]) VALUES (N'Visita', N'Dentistica', CAST(N'2021-12-10T00:00:00.000' AS DateTime), 2, 0, 1)
INSERT [dbo].[Task] ([Titolo], [Descrizione], [DataScadenza], [Importanza], [Terminato], [Id]) VALUES (N'Esame', N'Analisi 2', CAST(N'2021-10-22T00:00:00.000' AS DateTime), 1, 0, 2)
INSERT [dbo].[Task] ([Titolo], [Descrizione], [DataScadenza], [Importanza], [Terminato], [Id]) VALUES (N'Studiare', N'Capitolo 3 di Analisi 2', CAST(N'2021-09-25T00:00:00.000' AS DateTime), 1, 1, 4)
INSERT [dbo].[Task] ([Titolo], [Descrizione], [DataScadenza], [Importanza], [Terminato], [Id]) VALUES (N'Uscita', N'Aperitivo', CAST(N'2021-08-28T00:00:00.000' AS DateTime), 3, 0, 5)
INSERT [dbo].[Task] ([Titolo], [Descrizione], [DataScadenza], [Importanza], [Terminato], [Id]) VALUES (N'Cena', N'Riunione di famiglia', CAST(N'2021-09-09T00:00:00.000' AS DateTime), 2, 0, 6)
INSERT [dbo].[Task] ([Titolo], [Descrizione], [DataScadenza], [Importanza], [Terminato], [Id]) VALUES (N'Studiare', N'Capitolo 4 di Analisi 2', CAST(N'2021-09-30T00:00:00.000' AS DateTime), 1, 0, 7)
INSERT [dbo].[Task] ([Titolo], [Descrizione], [DataScadenza], [Importanza], [Terminato], [Id]) VALUES (N'Studiare', N'Capitolo 2 di Analisi 2', CAST(N'2021-08-31T00:00:00.000' AS DateTime), 1, 1, 8)
INSERT [dbo].[Task] ([Titolo], [Descrizione], [DataScadenza], [Importanza], [Terminato], [Id]) VALUES (N'Estetista', N'Ceretta', CAST(N'2021-09-14T00:00:00.000' AS DateTime), 2, 0, 9)
INSERT [dbo].[Task] ([Titolo], [Descrizione], [DataScadenza], [Importanza], [Terminato], [Id]) VALUES (N'Visita', N'Oculistica', CAST(N'2021-08-27T00:00:00.000' AS DateTime), 2, 1, 10)
SET IDENTITY_INSERT [dbo].[Task] OFF
GO
USE [master]
GO
ALTER DATABASE [GestoreTask] SET  READ_WRITE 
GO
