USE [dar-e-arqam-pwd-isb]
GO

/****** Object:  Table [dbo].[achievements]    Script Date: 5/21/2014 9:08:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[achievements](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](2000) NULL,
	[detail] [varchar](4000) NULL,
	[picture] [varchar](200) NULL,
	[publish] [varchar](100) NULL,
	[trash] [varchar](100) NULL,
	[date] [varchar](100) NULL,
	[month] [varchar](100) NULL,
	[year] [varchar](100) NULL,
	[time] [varchar](100) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


