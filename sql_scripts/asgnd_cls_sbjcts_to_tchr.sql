USE [dar-e-arqam-pwd-isb]
GO

/****** Object:  Table [dbo].[asgnd_cls_sbjcts_to_tchr]    Script Date: 5/21/2014 9:09:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[asgnd_cls_sbjcts_to_tchr](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[T_id] [varchar](400) NULL,
	[classsubject_id] [varchar](400) NULL,
	[date] [varchar](100) NULL,
	[month] [varchar](100) NULL,
	[year] [varchar](100) NULL,
	[time] [varchar](100) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


