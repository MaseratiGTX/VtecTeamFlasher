/****** Object:  Table [dbo].[Users]    Script Date: 02/03/2016 13:21:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO

USE [VtecTeamFlasher]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 02/03/2016 13:21:48 ******/
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





