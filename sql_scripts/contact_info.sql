USE [dar-e-arqam-pwd-isb]
GO

/****** Object:  Table [dbo].[contact_info]    Script Date: 5/21/2014 9:09:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[contact_info](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](4000) NULL,
	[contact_c] [varchar](200) NULL,
	[contact_p] [varchar](200) NULL,
	[contact_e] [varchar](200) NULL,
	[contact_w] [varchar](200) NULL,
	[contact_l] [varchar](4000) NULL,
	[contact_a] [varchar](4000) NULL,
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


