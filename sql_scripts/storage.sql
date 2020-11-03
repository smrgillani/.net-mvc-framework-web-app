USE [dar-e-arqam-pwd-isb]
GO

/****** Object:  Table [dbo].[storage]    Script Date: 5/21/2014 9:11:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[storage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](2000) NULL,
	[user_file] [varchar](200) NULL,
	[session_username] [varchar](500) NULL,
	[session_user_id] [varchar](500) NULL,
	[trash] [varchar](100) NULL,
	[date] [varchar](100) NULL,
	[month] [varchar](100) NULL,
	[year] [varchar](100) NULL,
	[time] [varchar](100) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


