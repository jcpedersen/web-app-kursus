/****** Object:  Table [dbo].[ChatLogSet]    Script Date: 08/31/2012 12:45:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChatLogSet]') AND type in (N'U'))
DROP TABLE [dbo].[ChatLogSet]
GO
/****** Object:  Table [dbo].[ChatLogSet]    Script Date: 08/31/2012 12:45:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChatLogSet]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ChatLogSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ChatMessage] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Createdate] [datetime] NOT NULL,
	[FromUserName] [nvarchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ToUserName] [nvarchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_ChatLogSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[ChatLogSet] ON
INSERT [dbo].[ChatLogSet] ([Id], [ChatMessage], [Createdate], [FromUserName], [ToUserName]) VALUES (8, N'asasd', CAST(0x0000A0BE00D092F1 AS DateTime), N'', N'')
SET IDENTITY_INSERT [dbo].[ChatLogSet] OFF
