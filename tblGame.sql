USE [dbWhist]
GO

/****** Object:  Table [dbo].[tbl_game]    Script Date: 17-09-2012 14:40:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_game](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cardEventID] [int] NOT NULL,
	[player1ID] [int] NOT NULL,
	[player2ID] [int] NOT NULL,
	[player3ID] [int] NOT NULL,
	[player4ID] [int] NOT NULL,
	[contract] [nchar](10) NOT NULL,
	[win] [int] NOT NULL,
	[player1Result] [bit] NOT NULL,
	[player2Result] [bit] NOT NULL,
	[player3Result] [bit] NOT NULL,
	[player4Result] [bit] NOT NULL,
	[contractPlayerID] [int] NOT NULL,
	[contractPlayer2ID] [int] NULL,
 CONSTRAINT [PK_tbl_game] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tbl_game]  WITH CHECK ADD  CONSTRAINT [FK_tbl_game_tbl_users1] FOREIGN KEY([id])
REFERENCES [dbo].[tbl_users] ([id])
GO

ALTER TABLE [dbo].[tbl_game] CHECK CONSTRAINT [FK_tbl_game_tbl_users1]
GO

