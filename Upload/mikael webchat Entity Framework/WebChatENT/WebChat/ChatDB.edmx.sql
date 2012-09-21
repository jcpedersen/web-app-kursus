
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/31/2012 10:11:37
-- Generated from EDMX file: C:\Projects\WebChat\WebChat\ChatDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ChatDB1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ChatLogSet'
CREATE TABLE [dbo].[ChatLogSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ChatMessage] nvarchar(255)  NOT NULL,
    [Createdate] datetime  NOT NULL,
    [FromUserName] nvarchar(30)  NOT NULL,
    [ToUserName] nvarchar(30)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ChatLogSet'
ALTER TABLE [dbo].[ChatLogSet]
ADD CONSTRAINT [PK_ChatLogSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------