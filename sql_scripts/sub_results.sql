USE [dar-e-arqam-pwd-isb]
GO

/****** Object:  Table [dbo].[sub_results]    Script Date: 5/21/2014 9:12:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[sub_results](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[r_id] [varchar](100) NULL,
	[name] [varchar](2000) NULL,
	[publish] [varchar](100) NULL,
	[date] [varchar](100) NULL,
	[month] [varchar](100) NULL,
	[year] [varchar](100) NULL,
	[time] [varchar](100) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


