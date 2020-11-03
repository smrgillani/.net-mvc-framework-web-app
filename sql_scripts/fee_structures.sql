USE [dar-e-arqam-pwd-isb]
GO

/****** Object:  Table [dbo].[fee_structures]    Script Date: 5/21/2014 9:10:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[fee_structures](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name_of_level] [varchar](2000) NULL,
	[reg_fee] [varchar](2000) NULL,
	[monthly_fee] [varchar](2000) NULL,
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


