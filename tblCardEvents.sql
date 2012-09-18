USE [dbWhist]
GO

/****** Object:  Table [dbo].[tbl_cardEvents]    Script Date: 17-09-2012 14:39:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_cardEvents](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[playDate] [nvarchar](50) NOT NULL,
	[hostID] [int] NOT NULL,
	[description] [ntext] NULL,
 CONSTRAINT [PK_tbl_cardEvents] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[tbl_cardEvents]  WITH CHECK ADD  CONSTRAINT [FK_tbl_cardEvents_tbl_users1] FOREIGN KEY([id])
REFERENCES [dbo].[tbl_users] ([id])
GO

ALTER TABLE [dbo].[tbl_cardEvents] CHECK CONSTRAINT [FK_tbl_cardEvents_tbl_users1]
GO

