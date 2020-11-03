USE [dar-e-arqam-pwd-isb]
GO

/****** Object:  Table [dbo].[Students]    Script Date: 5/21/2014 9:12:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[reg_id] [varchar](256) NULL,
	[name] [varchar](300) NULL,
	[ntnlty] [varchar](200) NULL,
	[grade] [varchar](100) NULL,
	[dob] [varchar](100) NULL,
	[pob] [varchar](100) NULL,
	[gender] [varchar](80) NULL,
	[c_h_addr] [varchar](1000) NULL,
	[p_h_addr] [varchar](1000) NULL,
	[stdnt_h_ph_ll] [varchar](50) NULL,
	[stdnt_pp_s_pic] [varchar](200) NULL,
	[emrgncy_p_name] [varchar](300) NULL,
	[emrgncy_p_rltn] [varchar](100) NULL,
	[emrgncy_p_c_num] [varchar](50) NULL,
	[emrgncy_p_ll_num] [varchar](50) NULL,
	[emrgncy_p_addr] [varchar](50) NULL,
	[emrgncy_p_email] [varchar](100) NULL,
	[father_name] [varchar](300) NULL,
	[ocptn] [varchar](200) NULL,
	[title] [varchar](300) NULL,
	[father_c_num] [varchar](50) NULL,
	[name_of_bsns] [varchar](200) NULL,
	[addr_of_bsns] [varchar](900) NULL,
	[father_email] [varchar](100) NULL,
	[father_ll_num] [varchar](50) NULL,
	[mother_name] [varchar](300) NULL,
	[mother_c_num] [varchar](50) NULL,
	[mother_ll_num] [varchar](50) NULL,
	[first_bro_name] [varchar](300) NULL,
	[first_bro_g] [varchar](100) NULL,
	[scnd_bro_name] [varchar](300) NULL,
	[scnd_bro_g] [varchar](100) NULL,
	[thrd_bro_name] [varchar](300) NULL,
	[thrd_bro_g] [varchar](100) NULL,
	[four_bro_name] [varchar](300) NULL,
	[four_bro_g] [varchar](100) NULL,
	[psn] [varchar](500) NULL,
	[doa] [varchar](80) NULL,
	[loi] [varchar](80) NULL,
	[first_schl_name] [varchar](500) NULL,
	[first_schl_d_from] [varchar](80) NULL,
	[first_schl_d_to] [varchar](80) NULL,
	[scnd_schl_name] [varchar](500) NULL,
	[scnd_schl_d_from] [varchar](80) NULL,
	[scnd_schl_d_to] [varchar](80) NULL,
	[xplntn_abt_stdnt] [varchar](2000) NULL,
	[hobby_spcl_intrst] [varchar](800) NULL,
	[knwldg_source_of_da] [varchar](500) NULL,
	[verify] [varchar](50) NULL,
	[applcnt_verify] [varchar](50) NULL,
	[active_set] [varchar](50) NULL,
	[alumni_set] [varchar](50) NULL,
	[del_set] [varchar](50) NULL,
	[challan_set] [varchar](50) NULL,
	[result_set] [varchar](50) NULL,
	[date] [varchar](80) NULL,
	[month] [varchar](80) NULL,
	[year] [varchar](80) NULL,
	[time] [varchar](80) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


