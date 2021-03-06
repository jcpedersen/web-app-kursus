/****** Object:  ForeignKey [FK_EntKampEntKampRunde]    Script Date: 08/30/2012 14:47:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EntKampEntKampRunde]') AND parent_object_id = OBJECT_ID(N'[dbo].[EntKampRundeSet]'))
ALTER TABLE [dbo].[EntKampRundeSet] DROP CONSTRAINT [FK_EntKampEntKampRunde]
GO
/****** Object:  ForeignKey [FK_RobotKamp]    Script Date: 08/30/2012 14:47:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RobotKamp]') AND parent_object_id = OBJECT_ID(N'[dbo].[EntKampSet]'))
ALTER TABLE [dbo].[EntKampSet] DROP CONSTRAINT [FK_RobotKamp]
GO
/****** Object:  ForeignKey [FK_RobotKamp1]    Script Date: 08/30/2012 14:47:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RobotKamp1]') AND parent_object_id = OBJECT_ID(N'[dbo].[EntKampSet]'))
ALTER TABLE [dbo].[EntKampSet] DROP CONSTRAINT [FK_RobotKamp1]
GO
/****** Object:  ForeignKey [FK_RobotRobotRunde]    Script Date: 08/30/2012 14:47:14 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RobotRobotRunde]') AND parent_object_id = OBJECT_ID(N'[dbo].[EntRobotRundeDataSet]'))
ALTER TABLE [dbo].[EntRobotRundeDataSet] DROP CONSTRAINT [FK_RobotRobotRunde]
GO
/****** Object:  Table [dbo].[EntKampRundeSet]    Script Date: 08/30/2012 14:47:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EntKampRundeSet]') AND type in (N'U'))
DROP TABLE [dbo].[EntKampRundeSet]
GO
/****** Object:  Table [dbo].[EntKampSet]    Script Date: 08/30/2012 14:47:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EntKampSet]') AND type in (N'U'))
DROP TABLE [dbo].[EntKampSet]
GO
/****** Object:  Table [dbo].[EntRobotRundeDataSet]    Script Date: 08/30/2012 14:47:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EntRobotRundeDataSet]') AND type in (N'U'))
DROP TABLE [dbo].[EntRobotRundeDataSet]
GO
/****** Object:  Table [dbo].[EntRobotSet]    Script Date: 08/30/2012 14:47:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EntRobotSet]') AND type in (N'U'))
DROP TABLE [dbo].[EntRobotSet]
GO
/****** Object:  Table [dbo].[EntRobotSet]    Script Date: 08/30/2012 14:47:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EntRobotSet]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EntRobotSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Navn] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Tab] [int] NOT NULL,
	[Sejre] [int] NOT NULL,
	[Uafgjort] [int] NOT NULL,
	[Liv] [int] NOT NULL,
 CONSTRAINT [PK_EntRobotSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[EntRobotSet] ON
INSERT [dbo].[EntRobotSet] ([Id], [Navn], [Tab], [Sejre], [Uafgjort], [Liv]) VALUES (1, N'Mikael', 3, 5, 2, 17)
INSERT [dbo].[EntRobotSet] ([Id], [Navn], [Tab], [Sejre], [Uafgjort], [Liv]) VALUES (2, N'Rolf', 5, 3, 2, 15)
SET IDENTITY_INSERT [dbo].[EntRobotSet] OFF
/****** Object:  Table [dbo].[EntRobotRundeDataSet]    Script Date: 08/30/2012 14:47:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EntRobotRundeDataSet]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EntRobotRundeDataSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Skjold] [int] NOT NULL,
	[Vaaben] [int] NOT NULL,
	[RobotId] [int] NOT NULL,
 CONSTRAINT [PK_EntRobotRundeDataSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[EntRobotRundeDataSet]') AND name = N'IX_FK_RobotRobotRunde')
CREATE NONCLUSTERED INDEX [IX_FK_RobotRobotRunde] ON [dbo].[EntRobotRundeDataSet] 
(
	[RobotId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
SET IDENTITY_INSERT [dbo].[EntRobotRundeDataSet] ON
INSERT [dbo].[EntRobotRundeDataSet] ([Id], [Skjold], [Vaaben], [RobotId]) VALUES (1, 3, 2, 1)
INSERT [dbo].[EntRobotRundeDataSet] ([Id], [Skjold], [Vaaben], [RobotId]) VALUES (3, 1, 3, 1)
INSERT [dbo].[EntRobotRundeDataSet] ([Id], [Skjold], [Vaaben], [RobotId]) VALUES (4, 0, 2, 1)
INSERT [dbo].[EntRobotRundeDataSet] ([Id], [Skjold], [Vaaben], [RobotId]) VALUES (5, 3, 1, 1)
INSERT [dbo].[EntRobotRundeDataSet] ([Id], [Skjold], [Vaaben], [RobotId]) VALUES (6, 1, 1, 1)
INSERT [dbo].[EntRobotRundeDataSet] ([Id], [Skjold], [Vaaben], [RobotId]) VALUES (7, 3, 3, 1)
INSERT [dbo].[EntRobotRundeDataSet] ([Id], [Skjold], [Vaaben], [RobotId]) VALUES (8, 1, 3, 1)
INSERT [dbo].[EntRobotRundeDataSet] ([Id], [Skjold], [Vaaben], [RobotId]) VALUES (9, 0, 2, 2)
INSERT [dbo].[EntRobotRundeDataSet] ([Id], [Skjold], [Vaaben], [RobotId]) VALUES (10, 1, 2, 2)
INSERT [dbo].[EntRobotRundeDataSet] ([Id], [Skjold], [Vaaben], [RobotId]) VALUES (11, 3, 3, 2)
INSERT [dbo].[EntRobotRundeDataSet] ([Id], [Skjold], [Vaaben], [RobotId]) VALUES (12, 3, 1, 2)
INSERT [dbo].[EntRobotRundeDataSet] ([Id], [Skjold], [Vaaben], [RobotId]) VALUES (13, 3, 0, 2)
INSERT [dbo].[EntRobotRundeDataSet] ([Id], [Skjold], [Vaaben], [RobotId]) VALUES (14, 1, 1, 2)
INSERT [dbo].[EntRobotRundeDataSet] ([Id], [Skjold], [Vaaben], [RobotId]) VALUES (15, 3, 2, 2)
INSERT [dbo].[EntRobotRundeDataSet] ([Id], [Skjold], [Vaaben], [RobotId]) VALUES (16, 1, 0, 2)
SET IDENTITY_INSERT [dbo].[EntRobotRundeDataSet] OFF
/****** Object:  Table [dbo].[EntKampSet]    Script Date: 08/30/2012 14:47:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EntKampSet]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EntKampSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Dato] [datetime] NOT NULL,
	[RobotId1] [int] NOT NULL,
	[RobotId2] [int] NOT NULL,
 CONSTRAINT [PK_EntKampSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[EntKampSet]') AND name = N'IX_FK_RobotKamp')
CREATE NONCLUSTERED INDEX [IX_FK_RobotKamp] ON [dbo].[EntKampSet] 
(
	[RobotId1] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[EntKampSet]') AND name = N'IX_FK_RobotKamp1')
CREATE NONCLUSTERED INDEX [IX_FK_RobotKamp1] ON [dbo].[EntKampSet] 
(
	[RobotId2] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[EntKampRundeSet]    Script Date: 08/30/2012 14:47:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EntKampRundeSet]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EntKampRundeSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rundenr] [int] NOT NULL,
	[Udfald] [nvarchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[EntKampId] [int] NOT NULL,
 CONSTRAINT [PK_EntKampRundeSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[EntKampRundeSet]') AND name = N'IX_FK_EntKampEntKampRunde')
CREATE NONCLUSTERED INDEX [IX_FK_EntKampEntKampRunde] ON [dbo].[EntKampRundeSet] 
(
	[EntKampId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  ForeignKey [FK_EntKampEntKampRunde]    Script Date: 08/30/2012 14:47:14 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EntKampEntKampRunde]') AND parent_object_id = OBJECT_ID(N'[dbo].[EntKampRundeSet]'))
ALTER TABLE [dbo].[EntKampRundeSet]  WITH CHECK ADD  CONSTRAINT [FK_EntKampEntKampRunde] FOREIGN KEY([EntKampId])
REFERENCES [dbo].[EntKampSet] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EntKampEntKampRunde]') AND parent_object_id = OBJECT_ID(N'[dbo].[EntKampRundeSet]'))
ALTER TABLE [dbo].[EntKampRundeSet] CHECK CONSTRAINT [FK_EntKampEntKampRunde]
GO
/****** Object:  ForeignKey [FK_RobotKamp]    Script Date: 08/30/2012 14:47:14 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RobotKamp]') AND parent_object_id = OBJECT_ID(N'[dbo].[EntKampSet]'))
ALTER TABLE [dbo].[EntKampSet]  WITH CHECK ADD  CONSTRAINT [FK_RobotKamp] FOREIGN KEY([RobotId1])
REFERENCES [dbo].[EntRobotSet] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RobotKamp]') AND parent_object_id = OBJECT_ID(N'[dbo].[EntKampSet]'))
ALTER TABLE [dbo].[EntKampSet] CHECK CONSTRAINT [FK_RobotKamp]
GO
/****** Object:  ForeignKey [FK_RobotKamp1]    Script Date: 08/30/2012 14:47:14 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RobotKamp1]') AND parent_object_id = OBJECT_ID(N'[dbo].[EntKampSet]'))
ALTER TABLE [dbo].[EntKampSet]  WITH CHECK ADD  CONSTRAINT [FK_RobotKamp1] FOREIGN KEY([RobotId2])
REFERENCES [dbo].[EntRobotSet] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RobotKamp1]') AND parent_object_id = OBJECT_ID(N'[dbo].[EntKampSet]'))
ALTER TABLE [dbo].[EntKampSet] CHECK CONSTRAINT [FK_RobotKamp1]
GO
/****** Object:  ForeignKey [FK_RobotRobotRunde]    Script Date: 08/30/2012 14:47:14 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RobotRobotRunde]') AND parent_object_id = OBJECT_ID(N'[dbo].[EntRobotRundeDataSet]'))
ALTER TABLE [dbo].[EntRobotRundeDataSet]  WITH CHECK ADD  CONSTRAINT [FK_RobotRobotRunde] FOREIGN KEY([RobotId])
REFERENCES [dbo].[EntRobotSet] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RobotRobotRunde]') AND parent_object_id = OBJECT_ID(N'[dbo].[EntRobotRundeDataSet]'))
ALTER TABLE [dbo].[EntRobotRundeDataSet] CHECK CONSTRAINT [FK_RobotRobotRunde]
GO
