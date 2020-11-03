USE [dar-e-arqam-pwd-isb]
GO

/****** Object:  Table [dbo].[Teachers]    Script Date: 5/21/2014 9:12:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Teachers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[t_id] [varchar](256) NULL,
	[name] [varchar](300) NULL,
	[dob] [varchar](100) NULL,
	[cnic] [varchar](25) NULL,
	[gender] [varchar](50) NULL,
	[email] [varchar](200) NULL,
	[contact] [varchar](60) NULL,
	[alt_contact] [varchar](60) NULL,
	[type] [varchar](80) NULL,
	[desig] [varchar](80) NULL,
	[dj] [varchar](100) NULL,
	[spcl_in_sbjct] [varchar](300) NULL,
	[gurdian_name] [varchar](300) NULL,
	[gurdian_cnic] [varchar](25) NULL,
	[addr] [varchar](1500) NULL,
	[active_id] [varchar](10) NULL,
	[del_id] [varchar](10) NULL,
	[date] [varchar](80) NULL,
	[month] [varchar](80) NULL,
	[year] [varchar](80) NULL,
	[time] [varchar](80) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


