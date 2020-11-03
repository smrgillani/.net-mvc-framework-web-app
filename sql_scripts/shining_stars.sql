USE [dar-e-arqam-pwd-isb]
GO

/****** Object:  Table [dbo].[shining_stars]    Script Date: 5/21/2014 9:11:42 PM ******/
DROP TABLE [dbo].[shining_stars]
GO

/****** Object:  Table [dbo].[shining_stars]    Script Date: 5/21/2014 9:11:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[shining_stars](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](2000) NULL,
	[star_type] [varchar](400) NULL,
	[achvmnt] [varchar](1000) NULL,
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


