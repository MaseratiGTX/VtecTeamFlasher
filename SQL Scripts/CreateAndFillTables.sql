IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](255) NOT NULL,
	[Lastname] [nvarchar](255) NOT NULL,
	[MiddleName] [nvarchar](255) NULL,
	[Enabled] [bit] NOT NULL,
	[UserType] [nvarchar](100) NOT NULL,
	[PasswordHash] [nvarchar](255) NULL,
	[Login] [nvarchar](255) NOT NULL,
	[City] [nvarchar](255) NULL,
	[Phone] [nvarchar](50) NULL,
	[Skype] [nvarchar](100) NULL,
	[VK] [nvarchar](255) NULL,
	[Viber] [bit] NULL,
	[WhatsApp] [bit] NULL,
	[OpenModules] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


INSERT INTO [dbo].[Users]
           ([FirstName]
           ,[Lastname]
           ,[MiddleName]
           ,[Enabled]
           ,[UserType]
           ,[PasswordHash]
           ,[Login])
     VALUES
           ('Admin'
           ,'Adminov'
           ,'Adminovich'
           ,1
           ,'superadmin'
           ,'dSPGKr23Yoxana2Pl9jYxcBA7eNlNeUxqKN0i2yufgA='
           ,'admin')
GO



IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ReflashHistory_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[ReflashHistory]'))
ALTER TABLE [dbo].[ReflashHistory] DROP CONSTRAINT [FK_ReflashHistory_Users]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReflashHistory]') AND type in (N'U'))
DROP TABLE [dbo].[ReflashHistory]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ReflashHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ReslashFileName] [nvarchar](255) NOT NULL,
	[Vin] [nvarchar](255) NOT NULL,
	[Cvn] [nvarchar](255) NOT NULL,
	[StockCalibration] [nvarchar](255) NOT NULL,
	[ReflashStatus] [int] NOT NULL,
	[PaymentStatus] [int] NOT NULL,
	[ReflashDateTime] [datetime] NOT NULL,
	[Severity] [int] NULL,
	[Price] [nvarchar](100) NULL,
 CONSTRAINT [PK_ReflashHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ReflashHistory]  WITH CHECK ADD  CONSTRAINT [FK_ReflashHistory_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[ReflashHistory] CHECK CONSTRAINT [FK_ReflashHistory_Users]
GO



IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Requests_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Requests]'))
ALTER TABLE [dbo].[Requests] DROP CONSTRAINT [FK_Requests_Users]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Requests]') AND type in (N'U'))
DROP TABLE [dbo].[Requests]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Requests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StockFile] [varbinary](max) NULL,
	[EcuCode] [nvarchar](50) NOT NULL,
	[RequestStatus] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[RequestDateTime] [datetime] NOT NULL,
	[AdditionalMessage] [nvarchar](255) NULL,
	[StockFileName] [nvarchar](255) NULL,
	[Car] [nvarchar](50) NULL,
	[Vin] [nvarchar](100) NULL,
 CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Users]
GO



IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Review_ReflashHistory]') AND parent_object_id = OBJECT_ID(N'[dbo].[Review]'))
ALTER TABLE [dbo].[Review] DROP CONSTRAINT [FK_Review_ReflashHistory]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Review]') AND type in (N'U'))
DROP TABLE [dbo].[Review]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Review](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReflashHistoryId] [int] NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[SourceUrl] [nvarchar](150) NULL,
	[UserReview] [nvarchar](max) NOT NULL,
	[ReviewDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_ReflashHistory] FOREIGN KEY([ReflashHistoryId])
REFERENCES [dbo].[ReflashHistory] ([Id])
GO

ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_ReflashHistory]
GO






