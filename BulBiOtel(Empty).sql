USE [BulBiOtel]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 7.09.2021 20:25:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[AdminId] [tinyint] IDENTITY(1,1) NOT NULL,
	[AdminUserName] [nvarchar](50) NULL,
	[AdminPassword] [nvarchar](50) NULL,
	[Permission] [nvarchar](50) NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 7.09.2021 20:25:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogRecords]    Script Date: 7.09.2021 20:25:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogRecords](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[LogAdminUserName] [nvarchar](50) NULL,
	[ProcessingDateTime] [datetime2](7) NULL,
	[OperationType] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_LogRecords] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Otels]    Script Date: 7.09.2021 20:25:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Otels](
	[OtelsId] [int] IDENTITY(1,1) NOT NULL,
	[OtelName] [nvarchar](60) NULL,
	[OtelLocation] [nvarchar](60) NULL,
	[OtelPrice] [money] NULL,
	[OtelDescription] [nvarchar](200) NULL,
	[OtelStars] [tinyint] NOT NULL,
	[OtelRating] [float] NULL,
	[OtelCountry] [int] NULL,
	[OtelPicture] [varchar](200) NULL,
 CONSTRAINT [PK_Otels] PRIMARY KEY CLUSTERED 
(
	[OtelsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OtelUsers]    Script Date: 7.09.2021 20:25:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OtelUsers](
	[OtelUserId] [int] IDENTITY(1,1) NOT NULL,
	[OtelUserName] [nvarchar](50) NULL,
	[OtelName] [nvarchar](50) NULL,
	[OtelPassword] [nvarchar](50) NULL,
	[OtelMail] [nvarchar](100) NULL,
	[OtelStatus] [int] NULL,
	[OtelId] [int] NULL,
	[Permission] [nvarchar](50) NULL,
 CONSTRAINT [PK_OtelUsers] PRIMARY KEY CLUSTERED 
(
	[OtelUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OtelUsers] ADD  CONSTRAINT [DF_OtelUsers_OtelPermission]  DEFAULT ((0)) FOR [OtelStatus]
GO
ALTER TABLE [dbo].[OtelUsers] ADD  CONSTRAINT [DF_OtelUsers_UserPermission]  DEFAULT (N'allow') FOR [Permission]
GO
ALTER TABLE [dbo].[Otels]  WITH CHECK ADD  CONSTRAINT [FK_Otels_Countries] FOREIGN KEY([OtelCountry])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[Otels] CHECK CONSTRAINT [FK_Otels_Countries]
GO
