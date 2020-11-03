USE [dar-e-arqam-pwd-isb]
GO

/****** Object:  Table [dbo].[result_details]    Script Date: 5/21/2014 9:11:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[result_details](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sub_r_id] [varchar](2000) NULL,
	[student_id] [varchar](2000) NULL,
	[subject_id] [varchar](2000) NULL,
	[total_marks] [varchar](2000) NULL,
	[obtain_marks] [varchar](2000) NULL,
	[status] [varchar](2000) NULL,
	[date] [varchar](100) NULL,
	[month] [varchar](100) NULL,
	[year] [varchar](100) NULL,
	[time] [varchar](100) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


