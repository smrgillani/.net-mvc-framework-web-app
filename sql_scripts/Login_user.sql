USE [dar-e-arqam-pwd-isb]
GO
/****** Object:  Table [dbo].[Login_user]    Script Date: 6/15/2019 1:07:34 AM ******/
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
SET IDENTITY_INSERT [dbo].[Login_user] ON 

INSERT [dbo].[Login_user] ([id], [p_id], [t_id], [username], [password], [user_type], [date], [month], [year], [time]) VALUES (1, N'1', N'1', N'skr', N'123', N'admin', N'02-03-2014', N'Mar', N'2014', N'20:22:21')
SET IDENTITY_INSERT [dbo].[Login_user] OFF
