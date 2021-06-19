USE [AgendClients]
GO

/****** Object:  Table [dbo].[area]    Script Date: 18/06/2021 15:15:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[area](
	[idArea] [int] IDENTITY(1,1) NOT NULL,
	[nameArea] [varchar](50) NULL,
 CONSTRAINT [PK_area_id] PRIMARY KEY CLUSTERED 
(
	[idArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[clientUser]    Script Date: 18/06/2021 15:15:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[clientUser](
	[idClient] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NULL,
	[pass] [varchar](50) NULL,
 CONSTRAINT [PK_clientUser_id] PRIMARY KEY CLUSTERED 
(
	[idClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[contacts]    Script Date: 18/06/2021 15:15:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[contacts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](50) NULL,
	[secondName] [varchar](50) NULL,
	[gen] [char](1) NULL,
	[idCountry] [int] NOT NULL,
	[city] [varchar](50) NULL,
	[cIntern] [bit] NOT NULL,
	[idOrg] [int] NOT NULL,
	[idArea] [int] NOT NULL,
	[dateAdmission] [datetime] NULL,
	[active] [bit] NOT NULL,
	[direction] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[cel] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[skype] [varchar](50) NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[country]    Script Date: 18/06/2021 15:15:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[countryName] [varchar](50) NULL,
	[abbrevation] [varchar](2) NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[org]    Script Date: 18/06/2021 15:15:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[org](
	[idOrg] [int] IDENTITY(1,1) NOT NULL,
	[nameOrg] [varchar](50) NULL,
 CONSTRAINT [PK_org_id] PRIMARY KEY CLUSTERED 
(
	[idOrg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


