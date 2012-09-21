
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/28/2012 12:32:36
-- Generated from EDMX file: C:\Projects\Robotspil Entity Access\WebApplication1\ModelRobot.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RobotENTdb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RobotRobotRunde]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EntRobotRundeDataSet] DROP CONSTRAINT [FK_RobotRobotRunde];
GO
IF OBJECT_ID(N'[dbo].[FK_RobotKamp]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EntKampSet] DROP CONSTRAINT [FK_RobotKamp];
GO
IF OBJECT_ID(N'[dbo].[FK_RobotKamp1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EntKampSet] DROP CONSTRAINT [FK_RobotKamp1];
GO
IF OBJECT_ID(N'[dbo].[FK_EntKampEntKampRunde]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EntKampRundeSet] DROP CONSTRAINT [FK_EntKampEntKampRunde];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[EntRobotSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntRobotSet];
GO
IF OBJECT_ID(N'[dbo].[EntRobotRundeDataSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntRobotRundeDataSet];
GO
IF OBJECT_ID(N'[dbo].[EntKampSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntKampSet];
GO
IF OBJECT_ID(N'[dbo].[EntKampRundeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntKampRundeSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'EntRobotSet'
CREATE TABLE [dbo].[EntRobotSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Navn] nvarchar(100)  NOT NULL,
    [Tab] int  NOT NULL,
    [Sejre] int  NOT NULL,
    [Uafgjort] int  NOT NULL,
    [Liv] int  NOT NULL
);
GO

-- Creating table 'EntRobotRundeDataSet'
CREATE TABLE [dbo].[EntRobotRundeDataSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Skjold] int  NOT NULL,
    [Vaaben] int  NOT NULL,
    [RobotId] int  NOT NULL
);
GO

-- Creating table 'EntKampSet'
CREATE TABLE [dbo].[EntKampSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Dato] datetime  NOT NULL,
    [RobotId1] int  NOT NULL,
    [RobotId2] int  NOT NULL
);
GO

-- Creating table 'EntKampRundeSet'
CREATE TABLE [dbo].[EntKampRundeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Rundenr] int  NOT NULL,
    [Udfald] nvarchar(1)  NOT NULL,
    [EntKampId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'EntRobotSet'
ALTER TABLE [dbo].[EntRobotSet]
ADD CONSTRAINT [PK_EntRobotSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EntRobotRundeDataSet'
ALTER TABLE [dbo].[EntRobotRundeDataSet]
ADD CONSTRAINT [PK_EntRobotRundeDataSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EntKampSet'
ALTER TABLE [dbo].[EntKampSet]
ADD CONSTRAINT [PK_EntKampSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EntKampRundeSet'
ALTER TABLE [dbo].[EntKampRundeSet]
ADD CONSTRAINT [PK_EntKampRundeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RobotId] in table 'EntRobotRundeDataSet'
ALTER TABLE [dbo].[EntRobotRundeDataSet]
ADD CONSTRAINT [FK_RobotRobotRunde]
    FOREIGN KEY ([RobotId])
    REFERENCES [dbo].[EntRobotSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RobotRobotRunde'
CREATE INDEX [IX_FK_RobotRobotRunde]
ON [dbo].[EntRobotRundeDataSet]
    ([RobotId]);
GO

-- Creating foreign key on [RobotId1] in table 'EntKampSet'
ALTER TABLE [dbo].[EntKampSet]
ADD CONSTRAINT [FK_RobotKamp]
    FOREIGN KEY ([RobotId1])
    REFERENCES [dbo].[EntRobotSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RobotKamp'
CREATE INDEX [IX_FK_RobotKamp]
ON [dbo].[EntKampSet]
    ([RobotId1]);
GO

-- Creating foreign key on [RobotId2] in table 'EntKampSet'
ALTER TABLE [dbo].[EntKampSet]
ADD CONSTRAINT [FK_RobotKamp1]
    FOREIGN KEY ([RobotId2])
    REFERENCES [dbo].[EntRobotSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RobotKamp1'
CREATE INDEX [IX_FK_RobotKamp1]
ON [dbo].[EntKampSet]
    ([RobotId2]);
GO

-- Creating foreign key on [EntKampId] in table 'EntKampRundeSet'
ALTER TABLE [dbo].[EntKampRundeSet]
ADD CONSTRAINT [FK_EntKampEntKampRunde]
    FOREIGN KEY ([EntKampId])
    REFERENCES [dbo].[EntKampSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EntKampEntKampRunde'
CREATE INDEX [IX_FK_EntKampEntKampRunde]
ON [dbo].[EntKampRundeSet]
    ([EntKampId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------