CREATE DATABASE [UserDocumentDB];
GO

USE [UserDocumentDB]
GO

CREATE TABLE [dbo].[User](
	[UserID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] [nvarchar](200) NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT(1),
	[CreatedDate] [datetime] NOT NULL DEFAULT(GETDATE())
)
GO

CREATE TABLE [dbo].[Document](
	[DocumentID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[FileName] [nvarchar](500) NOT NULL,
	[Path] [nvarchar](1000) NOT NULL,
	[UserID] [int] references [User](UserID),
	[IsActive] [bit] NOT NULL DEFAULT(1),
	[CreatedDate] [datetime] NOT NULL DEFAULT(GETDATE())
)
GO
