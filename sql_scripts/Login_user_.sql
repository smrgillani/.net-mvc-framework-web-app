USE [dar-e-arqam-pwd-isb]
GO

/****** Object:  Table [dbo].[Login_user]    Script Date: 5/21/2014 9:10:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Login_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[p_id] [varchar](4000) NULL,
	[t_id] [varchar](4000) NULL,
	[username] [varchar](4000) NULL,
	[password] [varchar](4000) NULL,
	[user_type] [varchar](4000) NULL,
	[date] [varchar](100) NULL,
	[month] [varchar](100) NULL,
	[year] [varchar](100) NULL,
	[time] [varchar](100) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


