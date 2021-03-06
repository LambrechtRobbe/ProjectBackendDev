USE [master]
GO
/****** Object:  Database [aspnet-WickedQuiz]    Script Date: 5/3/2020 10:46:02 PM ******/
CREATE DATABASE [aspnet-WickedQuiz]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'aspnet-WickedQuiz', FILENAME = N'C:\Users\robbe\aspnet-WickedQuiz.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'aspnet-WickedQuiz_log', FILENAME = N'C:\Users\robbe\aspnet-WickedQuiz_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [aspnet-WickedQuiz] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [aspnet-WickedQuiz].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [aspnet-WickedQuiz] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET ARITHABORT OFF 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET  ENABLE_BROKER 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET  MULTI_USER 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [aspnet-WickedQuiz] SET DB_CHAINING OFF 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [aspnet-WickedQuiz] SET QUERY_STORE = OFF
GO
USE [aspnet-WickedQuiz]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [aspnet-WickedQuiz]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/3/2020 10:46:02 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 5/3/2020 10:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[Id] [uniqueidentifier] NOT NULL,
	[AnswerName] [nvarchar](50) NOT NULL,
	[Correct] [int] NOT NULL,
	[QuestionId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 5/3/2020 10:46:02 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/3/2020 10:46:02 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/3/2020 10:46:02 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/3/2020 10:46:02 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/3/2020 10:46:02 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/3/2020 10:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
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
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](100) NULL,
	[About] [nvarchar](250) NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[DateRegistered] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 5/3/2020 10:46:02 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 5/3/2020 10:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[Id] [uniqueidentifier] NOT NULL,
	[QuestionName] [nvarchar](100) NOT NULL,
	[QuizId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quizzes]    Script Date: 5/3/2020 10:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quizzes](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Difficulty] [int] NOT NULL,
	[QuestionCount] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[ApplicationUserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Quizzes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scores]    Script Date: 5/3/2020 10:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scores](
	[Id] [uniqueidentifier] NOT NULL,
	[FinalScore] [int] NOT NULL,
	[MaxScore] [int] NOT NULL,
	[DateFinished] [datetime2](7) NOT NULL,
	[ApplicationUserId] [nvarchar](450) NULL,
	[QuizId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Scores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200503132247_initmodels', N'3.1.3')
GO
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'f974a8bb-15dc-41fc-a5cc-02b7cbe11f7d', N'Soviet Union', 0, N'75b2639e-c129-43a8-9839-65ca0602c1f0')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'98500134-d881-46b8-b06a-10a0c0c48379', N'Tall', 0, N'40f345f3-edf8-4ba2-8a9f-02ee0e43313a')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'4c70808c-dfb8-493e-bc26-10e72b7f6609', N'Robin Williams', 0, N'210bb0dc-4cca-4952-b57a-b724700b4fa5')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'f6d60558-e799-4ada-b8c9-1252cc2d5408', N'Stealing', 0, N'5d3f393a-b5b2-4e54-997e-d99710fb9fcb')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'bcdb8331-e07e-4566-81f0-14f8588e2960', N'Hairy', 0, N'40f345f3-edf8-4ba2-8a9f-02ee0e43313a')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'44b78966-152b-4949-8e0d-1669c7b32d90', N'The Fox and the Hound', 0, N'd04a49d8-14ba-4461-afa7-a09386616e2a')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'ae70fafd-4e2b-4ee6-baaf-1b8d0e553e13', N'Peach', 0, N'c98a5705-7d4b-4a39-b12c-c45505d205c7')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'dcfef38d-abb5-4f44-9ceb-2032ab883efc', N'Slacking', 1, N'5d3f393a-b5b2-4e54-997e-d99710fb9fcb')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'bda5b59f-7d75-423c-af79-21b28ce67224', N'You''re wrong. I am your father.', 0, N'8350dbaf-4985-42fc-9ba1-7f15327073d9')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'77bb86db-03bf-42d2-90b1-270a92a93453', N'1997', 1, N'13ee4926-6272-4470-8867-ee8a2c7b0a5c')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'd17ebdde-97eb-4ecc-8188-2de284050709', N'The Moon', 0, N'757db611-0e57-4942-afa5-daaaafdb1d30')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'77ef3804-d057-45a9-a75c-31103e9341d8', N'Poland', 0, N'75b2639e-c129-43a8-9839-65ca0602c1f0')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'7b910511-9a34-4124-aa9a-3460a8702822', N'Edgar Wright', 1, N'a4bf5a83-581d-4ade-97d2-138be0619755')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'77c9d1ee-5502-4070-850d-35e4dd9dba56', N'Jimmy', 0, N'88a2bdfd-2e84-4c58-9c67-4e7a29e4acf6')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'777b275a-2359-4cec-8b50-36b451e2b9a0', N'CGI Effect', 0, N'c2862293-0520-473f-aad2-f8f5e42ba17e')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'0e4f7b7d-1242-4671-a935-37fa37edb7fa', N'Caramel', 0, N'fedb0644-a2c9-446a-a191-48c62b56dd43')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'7881a2ef-9c78-41ef-b31d-3819cf0eeb41', N'A Tight Rope', 1, N'757db611-0e57-4942-afa5-daaaafdb1d30')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'6eea4331-79d6-4071-9bcb-38e8a5bbbd12', N'A medical procedure', 0, N'd0cdcc52-b0bb-46e0-bec1-43eba07b08e7')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'68c0f4d2-d475-43b2-8b5b-3c24e93f19cb', N'Rosh Hashanah', 1, N'99323cda-305d-4af1-945d-f471dff6aa7a')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'5f63c960-ea2e-4f9d-8037-3c9769a38ea4', N'A dance', 1, N'd0cdcc52-b0bb-46e0-bec1-43eba07b08e7')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'5451e859-bfcd-48f7-b652-3ef7658c0580', N'John F. Kennedy', 1, N'e487c09b-259a-4786-b453-cabd64f373ca')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'0c2c711c-625f-4f87-88fa-444b0d2dffd6', N'The Little Mermaid', 0, N'd04a49d8-14ba-4461-afa7-a09386616e2a')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'508b6fb1-11b4-42d8-9b95-44ceabf2e0c6', N'Balls', 0, N'757db611-0e57-4942-afa5-daaaafdb1d30')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'050a963c-59bc-4c8f-b352-44cf65e2fcc5', N'Plum', 1, N'c98a5705-7d4b-4a39-b12c-c45505d205c7')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'e6e12418-987b-439e-ba81-45a640190dd0', N'Chris Miller', 0, N'a4bf5a83-581d-4ade-97d2-138be0619755')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'c127220a-6574-4dd6-84ac-473c4fe53475', N'Another Bites the Dust', 0, N'd99c75fa-b0d0-40e4-b0d9-68f35cd6c6eb')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'5c798822-84db-4c74-b97c-475314433fdb', N'United States of America', 0, N'75b2639e-c129-43a8-9839-65ca0602c1f0')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'fec84346-6e44-4e44-9588-4aca5357991f', N'Jason Dip', 0, N'45f69431-92f9-4cdc-ae85-e175524132e7')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'2875a590-1615-46e9-aafc-4d11391da4de', N'Akan', 1, N'88a2bdfd-2e84-4c58-9c67-4e7a29e4acf6')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'6629521e-34e3-4f43-ae9f-4d27f80b53d6', N'Henry', 0, N'88a2bdfd-2e84-4c58-9c67-4e7a29e4acf6')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'17c56ccf-6a54-4474-bdf8-4e8dabd1ce20', N'Pauly Shore', 0, N'210bb0dc-4cca-4952-b57a-b724700b4fa5')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'bfc04be1-e6bb-403f-8794-547e3bb27b7d', N'Rude', 0, N'40f345f3-edf8-4ba2-8a9f-02ee0e43313a')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'10271eed-2840-4b4d-9b43-55062fe986e6', N'Estelle', 0, N'88a2bdfd-2e84-4c58-9c67-4e7a29e4acf6')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'2280e04e-72dc-4ac6-8065-57769dd08f03', N'Pear', 0, N'c98a5705-7d4b-4a39-b12c-c45505d205c7')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'efb70083-860a-4bd8-ace6-63e103a1bc86', N'Phil Lord', 0, N'a4bf5a83-581d-4ade-97d2-138be0619755')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'f6a6f56c-c2d1-4314-b56d-64eaea1cc0d2', N'Luke, I am your father.', 0, N'8350dbaf-4985-42fc-9ba1-7f15327073d9')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'aa67dd00-5f64-4ef9-8fc2-64fd3f4dd031', N'Paint', 0, N'c2862293-0520-473f-aad2-f8f5e42ba17e')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'fd93717d-2566-4170-81a4-6702b2e7e932', N'The Aristocats', 1, N'd04a49d8-14ba-4461-afa7-a09386616e2a')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'2c5c876b-bbcb-4e1e-90a5-67a78b5b0d3b', N'A sport', 0, N'd0cdcc52-b0bb-46e0-bec1-43eba07b08e7')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'359e3b62-379a-4d6a-805c-68af777b76c6', N'A language', 0, N'd0cdcc52-b0bb-46e0-bec1-43eba07b08e7')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'9b4954a1-0f03-4fc7-8c1f-6aa50976c45f', N'Succoss', 0, N'99323cda-305d-4af1-945d-f471dff6aa7a')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'd86fdb73-fd0b-470c-bb63-772c00f6cbeb', N'Kentucky Fresh Cheese', 0, N'24874f23-0862-4a7c-9045-d29f8cc0c204')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'0a3109e0-6942-4310-90e6-7c7855f260a0', N'Abraham Lincoln', 0, N'e487c09b-259a-4786-b453-cabd64f373ca')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'ff142263-d3a5-4e5d-b8ab-7d09bdef67a2', N'Cheating', 0, N'5d3f393a-b5b2-4e54-997e-d99710fb9fcb')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'cb14f905-4295-4cbf-9a0c-7d2b5c58f434', N'Gelatin', 1, N'c2862293-0520-473f-aad2-f8f5e42ba17e')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'e20e6337-4162-4de1-ac23-7ee599dabdb8', N'We Will Rock You', 0, N'd99c75fa-b0d0-40e4-b0d9-68f35cd6c6eb')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'5a9e24c0-2a7f-48f1-9b8b-85504c62c9de', N'Eric Mabius', 0, N'45f69431-92f9-4cdc-ae85-e175524132e7')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'fe386725-e478-46bc-a861-88fc59860bd7', N'Theodore Roosevelt', 0, N'e487c09b-259a-4786-b453-cabd64f373ca')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'70407a2f-aef0-4aa9-aee6-8b8a0607c2a6', N'Kibbled Freaky Cow', 0, N'24874f23-0862-4a7c-9045-d29f8cc0c204')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'38ce6c73-2d4c-4d43-8331-8c4fc846887f', N'1998', 0, N'13ee4926-6272-4470-8867-ee8a2c7b0a5c')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'85429dad-d700-4665-a4ed-8f2165155d7c', N'Clyde', 1, N'7e65c2e6-d701-4e04-9ffb-b340c24278b2')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'5066eb2e-4c8c-45c0-ac21-935daca3fff0', N'Tay', 0, N'7e65c2e6-d701-4e04-9ffb-b340c24278b2')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'8ce9666b-2694-4d47-b833-947779b57413', N'Dee', 0, N'7e65c2e6-d701-4e04-9ffb-b340c24278b2')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'82379258-bba9-4ddc-8ba2-9633703597f9', N'Dye', 0, N'c2862293-0520-473f-aad2-f8f5e42ba17e')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'366fb8ae-d49a-456c-a368-97f9c7e35343', N'Apple', 0, N'c98a5705-7d4b-4a39-b12c-c45505d205c7')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'a4c5d74a-f4cd-4b21-9418-9b7ef929bc46', N'Matthew Taylor', 1, N'45f69431-92f9-4cdc-ae85-e175524132e7')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'c5141458-9f7a-4b81-acc6-a9ee6d3e738d', N'Thomas Jefferson', 0, N'e487c09b-259a-4786-b453-cabd64f373ca')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'799b685a-2679-4386-8549-ae654d300f9c', N'Funny', 0, N'40f345f3-edf8-4ba2-8a9f-02ee0e43313a')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'd389ef3d-10f0-4432-b10a-b8ad5e229d27', N'Candy', 0, N'fedb0644-a2c9-446a-a191-48c62b56dd43')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'0adabbdf-be97-49ef-a427-bb545226b417', N'Don''t Stop Me Now', 1, N'd99c75fa-b0d0-40e4-b0d9-68f35cd6c6eb')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'f9ed645a-7f98-4b34-aa2f-be543a23d63b', N'1996', 0, N'13ee4926-6272-4470-8867-ee8a2c7b0a5c')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'c27e2a6e-9498-437b-984e-c09c96165067', N'Tweed', 0, N'7e65c2e6-d701-4e04-9ffb-b340c24278b2')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'ca4d487a-54b9-4b3e-90eb-c6a012adc613', N'Elul', 0, N'99323cda-305d-4af1-945d-f471dff6aa7a')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'32a9226b-fd7a-481e-a557-c9c2c512a5ec', N'Kiwi Food Cut', 0, N'24874f23-0862-4a7c-9045-d29f8cc0c204')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'75ff4e79-ddf6-4014-a189-ca47c6a18996', N'Jonathan Freeman', 0, N'210bb0dc-4cca-4952-b57a-b724700b4fa5')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'8a54868c-ad53-413d-a8e6-cab2150c8385', N'1999', 0, N'13ee4926-6272-4470-8867-ee8a2c7b0a5c')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'fd8064ce-e3ab-45c0-b1ee-cb4f854a3240', N'Smoking', 0, N'5d3f393a-b5b2-4e54-997e-d99710fb9fcb')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'766ce063-f10a-46f8-9e7e-cd24684143dd', N'Brighton Rock', 0, N'd99c75fa-b0d0-40e4-b0d9-68f35cd6c6eb')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'b30f3436-eef6-4ebe-92f4-ceb559646c55', N'Seth Rogan', 0, N'a4bf5a83-581d-4ade-97d2-138be0619755')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'7f00f82d-2821-4082-a524-cf8255c00104', N'Broken Glass', 0, N'757db611-0e57-4942-afa5-daaaafdb1d30')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'4832dcea-b810-462c-9ff8-d3cd1f75bee9', N'One Hundred and One Dalmatians', 0, N'd04a49d8-14ba-4461-afa7-a09386616e2a')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'88dbd9f9-215e-4c9b-bb1b-eb8071b63969', N'Gilbert Gottfried', 1, N'210bb0dc-4cca-4952-b57a-b724700b4fa5')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'da034d7c-0bef-45ca-87b9-edc0f8865305', N'India', 1, N'75b2639e-c129-43a8-9839-65ca0602c1f0')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'6f45d7f3-7dc8-4a13-ad72-ee873c750b2d', N'The truth is that I am your father.', 0, N'8350dbaf-4985-42fc-9ba1-7f15327073d9')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'532e76f7-8b37-415a-b788-f263051fd2e8', N'Kentucky Fried Chicken', 1, N'24874f23-0862-4a7c-9045-d29f8cc0c204')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'9b453806-81e9-4796-9dfe-f3ee4ba3c540', N'Sugar', 1, N'fedb0644-a2c9-446a-a191-48c62b56dd43')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'd5058b02-2975-46ff-a216-f4f4f3d26652', N'No. I am your father.', 1, N'8350dbaf-4985-42fc-9ba1-7f15327073d9')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'dee9fdac-ea8e-4e61-8e8b-f702747c9c63', N'Honey', 0, N'fedb0644-a2c9-446a-a191-48c62b56dd43')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'7af52c39-955f-42b4-920d-fc86911ac932', N'Jimmy Matts', 0, N'45f69431-92f9-4cdc-ae85-e175524132e7')
INSERT [dbo].[Answers] ([Id], [AnswerName], [Correct], [QuestionId]) VALUES (N'3dd4435b-690a-421c-906b-fd2fa1d16763', N'New Year', 0, N'99323cda-305d-4af1-945d-f471dff6aa7a')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'580be298-8ccb-4c11-8103-137cae49c632', N'Administrator', N'ADMINISTRATOR', N'55e1cad9-4fa2-4e97-a685-f986c4a6e238')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'a5ba3254-2e80-4ce5-8fd0-2b3f2a1185a7', N'User', N'USER', N'a32544d1-35a6-4938-b0ad-75e38e88f13c')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4adb7b5d-5e00-4bf7-b378-5e4933a1f7ca', N'580be298-8ccb-4c11-8103-137cae49c632')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'549f1bcc-df1c-4306-997c-5da9999a017a', N'a5ba3254-2e80-4ce5-8fd0-2b3f2a1185a7')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [About], [DateOfBirth], [DateRegistered]) VALUES (N'4adb7b5d-5e00-4bf7-b378-5e4933a1f7ca', N'Docent@MCT', N'DOCENT@MCT', N'Docent@MCT', N'DOCENT@MCT', 0, N'AQAAAAEAACcQAAAAEDJvPu0U76cBTOlN4TIH2P6yX4wcU+Jq4JCHuVQwa33TRhIM5E1JJst2UpvMt8mb9Q==', N'JG6C3QK2TALXITABQ4QP6ET6QWG3SQWG', N'd6c3985a-3d75-4976-9746-26a511ce5004', NULL, 0, 0, NULL, 1, 0, N'Docent', NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2020-05-03T15:23:49.3401593' AS DateTime2))
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [About], [DateOfBirth], [DateRegistered]) VALUES (N'549f1bcc-df1c-4306-997c-5da9999a017a', N'QuizUser@MCT', N'QUIZUSER@MCT', N'QuizUser@MCT', N'QUIZUSER@MCT', 0, N'AQAAAAEAACcQAAAAEEQpn8UJ/heTghdifxAWIgg+4ONBtSJOwai1LNDYRnvVY3NFm8t4X/OXixbji+tdmg==', N'MUZCB7M4PLTE5YHPCXTOKMYR2CTAD7WU', N'6045af59-a82b-4ff9-833b-4e95bb45fe50', NULL, 0, 0, NULL, 1, 0, N'QuizUser', NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2020-05-03T15:23:49.5078632' AS DateTime2))
GO
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'40f345f3-edf8-4ba2-8a9f-02ee0e43313a', N'What is the defining characteristic of someone who is described as hirsute?', N'eea1bfd7-132e-49e2-866c-602df63afd69')
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'a4bf5a83-581d-4ade-97d2-138be0619755', N'Who was the director of "Scott Pilgrim vs. the World (2010)"?', N'7f1a0fb8-e134-4640-bcf8-4f192b83197f')
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'd0cdcc52-b0bb-46e0-bec1-43eba07b08e7', N'What is dabbing?', N'eea1bfd7-132e-49e2-866c-602df63afd69')
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'fedb0644-a2c9-446a-a191-48c62b56dd43', N'What was Marilyn Monroe`s characters first name in the film "Some Like It Hot"?', N'7f1a0fb8-e134-4640-bcf8-4f192b83197f')
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'88a2bdfd-2e84-4c58-9c67-4e7a29e4acf6', N'What is the name of the villian in the 2015 Russian-American Sci-Fi Movie "Hardcore Henry";', N'7f1a0fb8-e134-4640-bcf8-4f192b83197f')
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'75b2639e-c129-43a8-9839-65ca0602c1f0', N'What country saw a world record 315 million voters turn out for elections on May 20, 1991?', N'eea1bfd7-132e-49e2-866c-602df63afd69')
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'd99c75fa-b0d0-40e4-b0d9-68f35cd6c6eb', N'What Queen song plays during the final fight scene of the film "Hardcore Henry"?', N'7f1a0fb8-e134-4640-bcf8-4f192b83197f')
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'8350dbaf-4985-42fc-9ba1-7f15327073d9', N'Darth Vaders famous reveal to Luke is iconic. But which of these is the right one?', N'7f1a0fb8-e134-4640-bcf8-4f192b83197f')
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'd04a49d8-14ba-4461-afa7-a09386616e2a', N'Which of these Disney classics was released in 1970?', N'7f1a0fb8-e134-4640-bcf8-4f192b83197f')
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'7e65c2e6-d701-4e04-9ffb-b340c24278b2', N'Which river flows through the Scottish city of Glasgow?', N'eea1bfd7-132e-49e2-866c-602df63afd69')
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'210bb0dc-4cca-4952-b57a-b724700b4fa5', N'Which stand-up comedian voiced the talking parrot "iago" in Disney''s 1992 adaptation of Aladdin?', N'7f1a0fb8-e134-4640-bcf8-4f192b83197f')
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'c98a5705-7d4b-4a39-b12c-c45505d205c7', N'According to the nursery rhyme, what fruit did Little Jack Horner pull out of his Christmas pie?', N'eea1bfd7-132e-49e2-866c-602df63afd69')
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'e487c09b-259a-4786-b453-cabd64f373ca', N'Which of the following presidents is not on Mount Rushmore?', N'eea1bfd7-132e-49e2-866c-602df63afd69')
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'24874f23-0862-4a7c-9045-d29f8cc0c204', N'What do the letters of the fast food chain KFC stand for?', N'eea1bfd7-132e-49e2-866c-602df63afd69')
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'5d3f393a-b5b2-4e54-997e-d99710fb9fcb', N'If you are caught Goldbricking, what are you doing wrong', N'eea1bfd7-132e-49e2-866c-602df63afd69')
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'757db611-0e57-4942-afa5-daaaafdb1d30', N'What does a funambulist walk on?', N'eea1bfd7-132e-49e2-866c-602df63afd69')
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'45f69431-92f9-4cdc-ae85-e175524132e7', N'Who plays the Nemesis in the Resident Evil movies?', N'7f1a0fb8-e134-4640-bcf8-4f192b83197f')
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'13ee4926-6272-4470-8867-ee8a2c7b0a5c', N'What year did the James Cameron film "Titanic" come out in theaters?', N'7f1a0fb8-e134-4640-bcf8-4f192b83197f')
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'99323cda-305d-4af1-945d-f471dff6aa7a', N'What is the name of the Jewish New Year?', N'eea1bfd7-132e-49e2-866c-602df63afd69')
INSERT [dbo].[Questions] ([Id], [QuestionName], [QuizId]) VALUES (N'c2862293-0520-473f-aad2-f8f5e42ba17e', N'The 1939 movie "The Wizard of Oz" contained a horse that changed color, what material did they use?', N'7f1a0fb8-e134-4640-bcf8-4f192b83197f')
GO
INSERT [dbo].[Quizzes] ([Id], [Name], [Description], [Difficulty], [QuestionCount], [DateCreated], [ApplicationUserId]) VALUES (N'7f1a0fb8-e134-4640-bcf8-4f192b83197f', N'MovieQuizzz', N'this quiz is all about movies', 1, 10, CAST(N'2020-05-03T18:17:50.1390743' AS DateTime2), N'4adb7b5d-5e00-4bf7-b378-5e4933a1f7ca')
INSERT [dbo].[Quizzes] ([Id], [Name], [Description], [Difficulty], [QuestionCount], [DateCreated], [ApplicationUserId]) VALUES (N'eea1bfd7-132e-49e2-866c-602df63afd69', N'General quiz', N'dit is een quiz die over alle categorieen kan gaan', 0, 10, CAST(N'2020-05-03T15:26:21.1970520' AS DateTime2), N'4adb7b5d-5e00-4bf7-b378-5e4933a1f7ca')
GO
INSERT [dbo].[Scores] ([Id], [FinalScore], [MaxScore], [DateFinished], [ApplicationUserId], [QuizId]) VALUES (N'83b5697d-6b9d-40bf-80fc-0aded45713f3', 8, 10, CAST(N'2020-05-03T21:31:38.8162501' AS DateTime2), N'549f1bcc-df1c-4306-997c-5da9999a017a', N'7f1a0fb8-e134-4640-bcf8-4f192b83197f')
INSERT [dbo].[Scores] ([Id], [FinalScore], [MaxScore], [DateFinished], [ApplicationUserId], [QuizId]) VALUES (N'c8552f74-24bb-418c-875b-637b0ad663e9', 9, 10, CAST(N'2020-05-03T18:22:47.4828746' AS DateTime2), N'4adb7b5d-5e00-4bf7-b378-5e4933a1f7ca', N'7f1a0fb8-e134-4640-bcf8-4f192b83197f')
INSERT [dbo].[Scores] ([Id], [FinalScore], [MaxScore], [DateFinished], [ApplicationUserId], [QuizId]) VALUES (N'dc15f633-60d4-427f-bdc5-9f5d226b224a', 8, 10, CAST(N'2020-05-03T21:42:33.8094564' AS DateTime2), N'4adb7b5d-5e00-4bf7-b378-5e4933a1f7ca', N'7f1a0fb8-e134-4640-bcf8-4f192b83197f')
INSERT [dbo].[Scores] ([Id], [FinalScore], [MaxScore], [DateFinished], [ApplicationUserId], [QuizId]) VALUES (N'f762c20e-6257-45dc-9658-a5157ee20154', 6, 10, CAST(N'2020-05-03T21:32:56.9539602' AS DateTime2), N'549f1bcc-df1c-4306-997c-5da9999a017a', N'eea1bfd7-132e-49e2-866c-602df63afd69')
INSERT [dbo].[Scores] ([Id], [FinalScore], [MaxScore], [DateFinished], [ApplicationUserId], [QuizId]) VALUES (N'645b7711-7901-4534-9279-f612880af4a1', 7, 10, CAST(N'2020-05-03T18:19:09.9740414' AS DateTime2), N'4adb7b5d-5e00-4bf7-b378-5e4933a1f7ca', N'eea1bfd7-132e-49e2-866c-602df63afd69')
GO
/****** Object:  Index [IX_Answers_QuestionId]    Script Date: 5/3/2020 10:46:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Answers_QuestionId] ON [dbo].[Answers]
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 5/3/2020 10:46:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 5/3/2020 10:46:03 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 5/3/2020 10:46:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 5/3/2020 10:46:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 5/3/2020 10:46:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 5/3/2020 10:46:03 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 5/3/2020 10:46:03 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Questions_QuizId]    Script Date: 5/3/2020 10:46:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Questions_QuizId] ON [dbo].[Questions]
(
	[QuizId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Quizzes_ApplicationUserId]    Script Date: 5/3/2020 10:46:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Quizzes_ApplicationUserId] ON [dbo].[Quizzes]
(
	[ApplicationUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Scores_ApplicationUserId]    Script Date: 5/3/2020 10:46:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Scores_ApplicationUserId] ON [dbo].[Scores]
(
	[ApplicationUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Scores_QuizId]    Script Date: 5/3/2020 10:46:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Scores_QuizId] ON [dbo].[Scores]
(
	[QuizId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Questions_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Questions_QuestionId]
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
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Quizzes_QuizId] FOREIGN KEY([QuizId])
REFERENCES [dbo].[Quizzes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Quizzes_QuizId]
GO
ALTER TABLE [dbo].[Quizzes]  WITH CHECK ADD  CONSTRAINT [FK_Quizzes_AspNetUsers_ApplicationUserId] FOREIGN KEY([ApplicationUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Quizzes] CHECK CONSTRAINT [FK_Quizzes_AspNetUsers_ApplicationUserId]
GO
ALTER TABLE [dbo].[Scores]  WITH CHECK ADD  CONSTRAINT [FK_Scores_AspNetUsers_ApplicationUserId] FOREIGN KEY([ApplicationUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Scores] CHECK CONSTRAINT [FK_Scores_AspNetUsers_ApplicationUserId]
GO
ALTER TABLE [dbo].[Scores]  WITH CHECK ADD  CONSTRAINT [FK_Scores_Quizzes_QuizId] FOREIGN KEY([QuizId])
REFERENCES [dbo].[Quizzes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Scores] CHECK CONSTRAINT [FK_Scores_Quizzes_QuizId]
GO
USE [master]
GO
ALTER DATABASE [aspnet-WickedQuiz] SET  READ_WRITE 
GO
