USE [BulBiOtel]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 7.09.2021 20:38:39 ******/
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
/****** Object:  Table [dbo].[Countries]    Script Date: 7.09.2021 20:38:39 ******/
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
/****** Object:  Table [dbo].[LogRecords]    Script Date: 7.09.2021 20:38:39 ******/
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
/****** Object:  Table [dbo].[Otels]    Script Date: 7.09.2021 20:38:39 ******/
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
/****** Object:  Table [dbo].[OtelUsers]    Script Date: 7.09.2021 20:38:39 ******/
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
SET IDENTITY_INSERT [dbo].[Admins] ON 

INSERT [dbo].[Admins] ([AdminId], [AdminUserName], [AdminPassword], [Permission]) VALUES (1, N'emir', N'123', N'Admin')
INSERT [dbo].[Admins] ([AdminId], [AdminUserName], [AdminPassword], [Permission]) VALUES (2, N'yasin', N'123', N'Admin')
SET IDENTITY_INSERT [dbo].[Admins] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (1, N'Adana')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (2, N'Adıyaman')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (3, N'Afyon')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (4, N'Ağrı')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (5, N'Amasya')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (6, N'Ankara')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (7, N'Antalya')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (8, N'Artvin')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (9, N'Aydın')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (10, N'Balıkesir')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (11, N'Bilecik')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (12, N'Bingöl')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (13, N'Bitlis')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (14, N'Bolu')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (15, N'Burdur')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (16, N'Bursa')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (17, N'Çanakkale')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (18, N'Çankırı')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (19, N'Çorum')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (20, N'Denizli')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (21, N'Diyarbakır')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (22, N'Edirne')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (23, N'Elazığ')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (24, N'Erzincan')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (25, N'Erzurum')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (26, N'Eskişehir')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (27, N'Gaziantep')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (28, N'Giresun')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (29, N'Gümüşhane')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (30, N'Hakkari')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (31, N'Hatay')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (32, N'Isparta')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (33, N'Mersin')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (34, N'İstanbul')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (35, N'İzmir')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (36, N'Kars')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (37, N'Kastamonu')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (38, N'Kayseri')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (39, N'Kırklareli')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (40, N'Kırşehir')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (41, N'Kocaeli')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (42, N'Konya')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (43, N'Kütahya')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (44, N'Malatya')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (45, N'Manisa')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (46, N'K.Maraş')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (47, N'Mardin')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (48, N'Muğla')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (49, N'Muş')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (50, N'Nevşehir')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (51, N'Niğde')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (52, N'Ordu')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (53, N'Rize')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (54, N'Sakarya')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (55, N'Samsun')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (56, N'Siirt')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (57, N'Sinop')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (58, N'Sivas')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (59, N'Tekirdağ')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (60, N'Tokat')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (61, N'Trabzon')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (62, N'Tunceli')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (63, N'Şanlıurfa')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (64, N'Uşak')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (65, N'Van')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (66, N'Yozgat')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (67, N'Zonguldak')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (68, N'Aksaray')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (69, N'Bayburt')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (70, N'Karaman')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (71, N'Kırıkkale')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (72, N'Batman')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (73, N'Şırnak')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (74, N'Bartın')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (75, N'Ardahan')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (76, N'Iğdır')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (77, N'Yalova')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (78, N'Karabük')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (79, N'Kilis')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (80, N'Osmaniye')
INSERT [dbo].[Countries] ([CountryId], [CountryName]) VALUES (81, N'Düzce')
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[LogRecords] ON 

INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (40, N'emir', CAST(N'2021-09-01T13:19:00.7790409' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (41, N'emir', CAST(N'2021-09-01T13:19:10.8527465' AS DateTime2), N'Şehir Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (42, N'emir', CAST(N'2021-09-01T13:19:19.5939293' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (43, N'emir', CAST(N'2021-09-01T13:19:36.3346723' AS DateTime2), N'Şehir Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (44, N'emir', CAST(N'2021-09-01T13:19:39.7817582' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (45, N'emir', CAST(N'2021-09-01T13:20:05.7123736' AS DateTime2), N'Otel Düzenleme İşlemi Yapıldı', N'Crystal Admiral Resort Suites Spa')
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (46, N'emir', CAST(N'2021-09-01T13:20:05.7396500' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (47, N'emir', CAST(N'2021-09-01T13:20:14.5457631' AS DateTime2), N'Log Kayıtları Listelendi', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (48, N'emir', CAST(N'2021-09-01T13:20:51.9181499' AS DateTime2), N'Log Kayıtları Listelendi', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (49, N'emir', CAST(N'2021-09-01T13:21:21.5834160' AS DateTime2), N'Log Kayıtları Listelendi', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (50, N'emir', CAST(N'2021-09-01T13:23:06.1885105' AS DateTime2), N'Log Kayıtları Listelendi', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (51, N'emir', CAST(N'2021-09-01T13:23:21.6455881' AS DateTime2), N'Log Kayıtları Listelendi', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (52, N'emir', CAST(N'2021-09-01T13:23:30.1925284' AS DateTime2), N'Log Kayıtları Listelendi', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (53, N'emir', CAST(N'2021-09-01T13:23:39.2667724' AS DateTime2), N'Log Kayıtları Listelendi', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (54, N'emir', CAST(N'2021-09-01T13:23:47.9399922' AS DateTime2), N'Çıkış Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (55, N'emir', CAST(N'2021-09-01T13:23:52.1978835' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (56, N'emir', CAST(N'2021-09-01T13:23:53.1435736' AS DateTime2), N'Log Kayıtları Listelendi', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (57, N'emir', CAST(N'2021-09-01T13:24:56.2129819' AS DateTime2), N'Otel Kayıt Eklendi', N'deneme')
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (58, N'emir', CAST(N'2021-09-01T13:24:58.8659780' AS DateTime2), N'Log Kayıtları Listelendi', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (59, N'emir', CAST(N'2021-09-01T13:25:13.6968645' AS DateTime2), N'Log Kayıtları Listelendi', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (60, N'emir', CAST(N'2021-09-01T13:25:19.7983725' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (61, N'emir', CAST(N'2021-09-01T13:25:26.1918033' AS DateTime2), N'Otel Silme İşlemi Yapıldı.', N'deneme')
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (62, N'emir', CAST(N'2021-09-01T13:25:26.2228063' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (63, N'emir', CAST(N'2021-09-01T13:25:27.5452952' AS DateTime2), N'Log Kayıtları Listelendi', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (64, N'deneme', CAST(N'2021-09-01T20:23:29.5157145' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (65, N'emir', CAST(N'2021-09-01T20:24:06.5794969' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (66, N'emir', CAST(N'2021-09-01T20:24:56.4872415' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (67, N'emir', CAST(N'2021-09-01T20:42:09.5598575' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (68, N'emir', CAST(N'2021-09-01T20:43:46.4989686' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (69, N'emir1', CAST(N'2021-09-01T20:46:34.0664754' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (70, N'emir', CAST(N'2021-09-01T20:48:02.8783456' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (71, N'emir', CAST(N'2021-09-01T20:48:37.0167363' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (72, N'emir', CAST(N'2021-09-01T20:49:16.7878304' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (73, N'emir', CAST(N'2021-09-01T21:00:55.6396871' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (74, N'emir', CAST(N'2021-09-01T21:05:44.3541453' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (75, N'emir', CAST(N'2021-09-01T21:09:17.9482965' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (76, N'emir1', CAST(N'2021-09-01T22:56:15.9153870' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (77, N'deneme', CAST(N'2021-09-01T23:16:15.3730331' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (78, N'emir', CAST(N'2021-09-01T23:16:21.9896924' AS DateTime2), N'Çıkış Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (79, N'emir', CAST(N'2021-09-04T14:08:47.0241811' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (80, N'emir', CAST(N'2021-09-04T14:12:53.8323378' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (81, N'emir', CAST(N'2021-09-04T14:15:49.8433719' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (82, N'emir', CAST(N'2021-09-04T14:16:56.4566271' AS DateTime2), N'Şehir Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (83, N'emir', CAST(N'2021-09-04T14:16:58.1797694' AS DateTime2), N'Log Kayıtları Listelendi', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (84, N'emir', CAST(N'2021-09-04T14:17:14.8373710' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (85, N'emir', CAST(N'2021-09-04T14:17:16.9590987' AS DateTime2), N'Log Kayıtları Listelendi', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (86, N'emir', CAST(N'2021-09-04T14:29:36.6091878' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (87, N'emir', CAST(N'2021-09-04T14:33:43.8555633' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (88, N'emir', CAST(N'2021-09-04T14:40:36.0706377' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (89, N'emir', CAST(N'2021-09-04T14:40:40.1660910' AS DateTime2), N'Log Kayıtları Listelendi', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (90, N'emir', CAST(N'2021-09-04T14:45:28.9372169' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (91, N'emir', CAST(N'2021-09-04T14:45:48.3039897' AS DateTime2), N'emir1 kullanıcısının durmu Reddedildi.', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (92, N'emir', CAST(N'2021-09-04T14:46:18.7909484' AS DateTime2), N'Log Kayıtları Listelendi', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (93, N'emir', CAST(N'2021-09-04T14:53:21.5963812' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (94, N'emir', CAST(N'2021-09-04T14:53:25.5686972' AS DateTime2), N'emir1 adlı otel kullanıcısının durmu Onaylandı.', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (95, N'emir', CAST(N'2021-09-04T14:54:11.4044271' AS DateTime2), N'emir1 adlı otel kullanıcısının durmu Reddedildi.', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (96, N'emir', CAST(N'2021-09-04T14:54:21.5654368' AS DateTime2), N'emir1 adlı otel kullanıcısının durmu Onaylandı.', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (97, N'emir', CAST(N'2021-09-04T14:55:34.9115607' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (98, N'emir', CAST(N'2021-09-04T14:56:39.1907897' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (99, N'emir', CAST(N'2021-09-04T14:59:05.4157071' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (100, N'emir', CAST(N'2021-09-04T14:59:53.5207590' AS DateTime2), N'deneme adlı otel kullanıcısının durmu Onaylandı.', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (101, N'emir', CAST(N'2021-09-04T14:59:55.0704995' AS DateTime2), N'deneme adlı otel kullanıcısının durmu Reddedildi.', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (102, N'emir', CAST(N'2021-09-04T15:21:57.7562861' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (103, N'emir', CAST(N'2021-09-04T15:22:00.9128774' AS DateTime2), N'xxaiden3 adlı otel kullanıcısının durmu Onaylandı.', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (104, N'emir', CAST(N'2021-09-04T15:36:19.4821702' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (105, N'emir', CAST(N'2021-09-04T15:37:18.2914236' AS DateTime2), N'Otel Düzenleme İşlemi Yapıldı', N'Süleyman')
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (106, N'emir', CAST(N'2021-09-04T15:37:18.3344254' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (107, N'emir', CAST(N'2021-09-04T15:38:34.4016544' AS DateTime2), N'Otel Düzenleme İşlemi Yapıldı', N'Süleyman')
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (108, N'emir', CAST(N'2021-09-04T15:38:34.4279972' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (109, N'emir', CAST(N'2021-09-04T15:40:06.3226818' AS DateTime2), N'Otel Düzenleme İşlemi Yapıldı', N'Süleyman')
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (110, N'emir', CAST(N'2021-09-04T15:40:06.3512010' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (111, N'xxaiden3', CAST(N'2021-09-04T15:42:01.7155913' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (112, N'yasin', CAST(N'2021-09-04T15:42:03.2444743' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (113, N'yasin', CAST(N'2021-09-04T15:42:08.7335754' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (114, N'emir', CAST(N'2021-09-04T15:44:00.2521143' AS DateTime2), N'Otel Düzenleme İşlemi Yapıldı', N'Süleyman')
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (115, N'emir', CAST(N'2021-09-04T15:44:00.3115166' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (116, N'yasin', CAST(N'2021-09-04T15:46:14.0153834' AS DateTime2), N'Otel Silme İşlemi Yapıldı.', N'Süleyman')
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (117, N'yasin', CAST(N'2021-09-04T15:46:14.8115190' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (118, N'yasin', CAST(N'2021-09-04T15:46:19.3414972' AS DateTime2), N'Otel Silme İşlemi Yapıldı.', N'Emir Gürbüz')
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (119, N'yasin', CAST(N'2021-09-04T15:46:20.1410632' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (120, N'emir', CAST(N'2021-09-04T15:57:58.5048398' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (121, N'emir', CAST(N'2021-09-04T15:58:00.9628024' AS DateTime2), N'Çıkış Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (122, N'emir', CAST(N'2021-09-04T23:37:16.0321369' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (123, N'emir', CAST(N'2021-09-04T23:37:21.0541882' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (124, N'emir', CAST(N'2021-09-04T23:39:30.5180994' AS DateTime2), N'Otel Düzenleme İşlemi Yapıldı', N'DoubleTree by Hilton Hotel Izmir Airport')
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (125, N'emir', CAST(N'2021-09-04T23:39:30.5484873' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (126, N'emir', CAST(N'2021-09-04T23:39:36.4789932' AS DateTime2), N'Otel Düzenleme İşlemi Yapıldı', N'DoubleTree by Hilton Hotel Izmir Airport')
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (127, N'emir', CAST(N'2021-09-04T23:39:36.5159954' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (128, N'emir', CAST(N'2021-09-04T23:39:42.8121314' AS DateTime2), N'Otel Düzenleme İşlemi Yapıldı', N'DoubleTree by Hilton Hotel Izmir Airport')
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (129, N'emir', CAST(N'2021-09-04T23:39:42.8451334' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (130, N'emir', CAST(N'2021-09-04T23:42:05.1444990' AS DateTime2), N'Otel Düzenleme İşlemi Yapıldı', N'DoubleTree by Hilton Hotel Izmir Airport')
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (131, N'emir', CAST(N'2021-09-04T23:42:05.1740568' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (132, N'emir', CAST(N'2021-09-04T23:42:50.2327007' AS DateTime2), N'Giriş Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (133, N'emir', CAST(N'2021-09-04T23:42:52.1846766' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (134, N'emir', CAST(N'2021-09-04T23:42:57.0945358' AS DateTime2), N'Otel Düzenleme İşlemi Yapıldı', N'DoubleTree by Hilton Hotel Izmir Airport')
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (135, N'emir', CAST(N'2021-09-04T23:42:57.1305375' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (136, N'emir', CAST(N'2021-09-04T23:43:05.2395043' AS DateTime2), N'Otel Düzenleme İşlemi Yapıldı', N'DoubleTree by Hilton Hotel Izmir Airport')
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (137, N'emir', CAST(N'2021-09-04T23:43:05.2685018' AS DateTime2), N'Otel Listeleme İşlemi Yapıldı', NULL)
INSERT [dbo].[LogRecords] ([LogId], [LogAdminUserName], [ProcessingDateTime], [OperationType], [Description]) VALUES (138, N'emir', CAST(N'2021-09-04T23:43:09.7346057' AS DateTime2), N'Çıkış Yapıldı', NULL)
GO
SET IDENTITY_INSERT [dbo].[LogRecords] OFF
GO
SET IDENTITY_INSERT [dbo].[Otels] ON 

INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (1, N'Crystal Admiral Resort Suites Spa', N'Antalya - Side | Kızılot', 700.0000, N'Aquapark - Denize Sıfır - Mini Club - Alakart Restoran - Spa ve Sağlık', 5, 4.9, 7, N'../wwwroot/otelPicture/1.jpg')
INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (2, N'Limak Atlantis Hotel', N'Antalya - Belek | İleribaşı', 900.0000, N'Aquapark - Denize Sıfır - Mini Club - Alakart Restoran - Spa ve Sağlık', 5, 4.8, 7, N'../wwwroot/otelPicture/2.jpg')
INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (4, N'My Home Anatolia Hotel', N'Ankara', 130.0000, N'Normalden %20 daha az', 4, 4.3, 6, N'../wwwroot/otelPicture/4.jpg')
INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (6, N'OTTO CITY Premium Suites', N'Ankara', 223.0000, N'Ücretsiz Kablosuz Bağlantı', 4, 7.9, 6, N'../wwwroot/otelPicture/5.jpg')
INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (15, N'Samsun Palas Hotel & SPA', N'Atatürk Mah, 649. Sk. no : 6/ 1', 206.0000, N'%38 indirim | Ücretsiz Kahvaltı | SPA | Havuz', 4, 4.3, 55, N'../wwwroot/otelPicture/3f91b3d1-ba46-4124-a6f1-884ed5f0be6a.jpg')
INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (16, N'Narven Termal Kasaba', N'Demirciler Köyü Mevki, 165/5 Merkez', 536.0000, N'SPA | HAVUZ ', 5, 4.3, 14, N'../wwwroot/otelPicture/9b99de59-5507-4b2e-b456-76e681a032cc.jpg')
INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (17, N'Hotel Kale 17', N'Kemalpaşa Mah. Matbaa Sk. No:7 D:2/B', 416.0000, N'Harika Oda Hizmeti | En Beğenilenlerden | Mükemmel Konum', 5, 4.8, 17, N'../wwwroot/otelPicture/74d87d48-6df6-41dc-99bd-c44eaa4c9c6c.jpg')
INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (18, N'Dedeman İstanbul Otel', N'Gayrettepe, Yıldız Posta Cd. No:50', 421.0000, N'Havuz | Spa | Mükemmel Servis', 5, 4, 34, N'../wwwroot/otelPicture/7a99997c-314a-4d81-848e-751e1ab09280.jpg')
INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (19, N'Divan İstanbul', N'Harbiye Mh, Asker Ocağı Cd. No:1', 1008.0000, N'Harika Egzersiz Tesisleri | Spa | En Beğenilenlerden', 5, 4.5, 34, N'../wwwroot/otelPicture/5451ce33-3814-4ca4-a929-9e07b67a968d.jpg')
INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (20, N'Movenpick Malatya Hotel', N'İnönü, İnönü Cd. No 174', 539.0000, N'Havuz | Spa | En Beğenilenlerden | Evcil Hayvan Kabul Ediliyor ', 5, 4.5, 44, N'../wwwroot/otelPicture/a5ebfb92-8361-4f67-84a3-1dfedea024d7.jpg')
INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (21, N'Ramada Plaza Malatya Altin Kayisi', N'Özalper, İstasyon Cd. No:24, 44090', 440.0000, N'Havuz | Spa | Bar ', 5, 4.2, 44, N'../wwwroot/otelPicture/bd707bea-ad4a-45c7-9bd4-3ebee7a4a414.jpg')
INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (22, N'Bedesten Hotel', N'Kum, 74300 Amasra/Bartın', 180.0000, N'Harika Fırsat Normalden %35 Daha Az', 3, 3.8, 74, N'../wwwroot/otelPicture/553c17d1-e922-4562-baa7-01ba137528d3.jpg')
INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (23, N'Anemon Aydın Otel', N'Ilıcabaşı, 323. Sk. No:12', 415.0000, N'Havuz | En Beğenilenlerden | Bar | Ücretsiz Kahvaltı | Spor Salonu', 4, 4.6, 9, N'../wwwroot/otelPicture/549d218a-fa7e-47da-9973-609b506f4947.jpg')
INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (24, N'Lara Family Club Hotel', N'Kemerağzı, Yaşar Sobutay Bulvarı No:331', 796.0000, N'Mükemmel Akşam Yemeği | Mükemmel Servis | Mükemmel Kahvaltı | Spa', 4, 4.4, 7, N'../wwwroot/otelPicture/4f654d74-6333-40de-a171-94dd970bda1d.jpg')
INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (25, N'Titanic Beach Lara Resort', N'Güzeloba, Lara Turizm Yolu', 2400.0000, N'En Beğenilenlerden | Spa | Havuz | Mükemmel Konum', 5, 4.6, 7, N'../wwwroot/otelPicture/a0b38fc5-b57d-48ec-a825-cd4271c556ba.jpg')
INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (26, N'Fimar Life Thermal Resort Hotel', N'terziköy kaplıca mevkii', 650.0000, N'Şık Odalar | Spa | Kapalı Havuz ', 5, 4.3, 5, N'../wwwroot/otelPicture/c43f6d56-3064-4897-a17f-4a0c112410b2.jpg')
INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (27, N'TASİGO Eskişehir', N'Dede Mahallesi, Haktanır Sokak No:1', 567.0000, N'Termal Havuz | Spa | Şehir Manzarası', 5, 4.6, 26, N'../wwwroot/otelPicture/14d05d1e-23d2-4bf5-9a24-e6e7ba6177db.jpg')
INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (28, N'Double Tree By Hilton', N'İsmet Kaptan, 1373. Sk. No:5', 535.0000, N'Zarif Odalar | Gösterişli Restoran | Teras Bar | Havuz', 4, 4, 35, N'../wwwroot/otelPicture/be748dd0-d775-42d5-b3db-211e71e32e6e.jpg')
INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (29, N'DoubleTree by Hilton Hotel Izmir Airport', N'Fatih, Ege Cd. 4a, 35410', 443.0000, N'Harika Bar | Havuz | Lüks Ortam | Ücretsiz Otopark', 4, 4.3, 35, N'../wwwroot/otelPicture/ce535018-cda3-49f8-9641-5a49b08d9764.jpg')
INSERT [dbo].[Otels] ([OtelsId], [OtelName], [OtelLocation], [OtelPrice], [OtelDescription], [OtelStars], [OtelRating], [OtelCountry], [OtelPicture]) VALUES (39, N'deneme', N'denemeJ', 200.0000, N'DenemeJ', 4, 4, 76, N'../wwwroot/otelPicture/default.jpg')
SET IDENTITY_INSERT [dbo].[Otels] OFF
GO
SET IDENTITY_INSERT [dbo].[OtelUsers] ON 

INSERT [dbo].[OtelUsers] ([OtelUserId], [OtelUserName], [OtelName], [OtelPassword], [OtelMail], [OtelStatus], [OtelId], [Permission]) VALUES (2, N'emir1', NULL, N'123', N'emir.gurbuz06@hotmail.com', 3, 39, N'User')
INSERT [dbo].[OtelUsers] ([OtelUserId], [OtelUserName], [OtelName], [OtelPassword], [OtelMail], [OtelStatus], [OtelId], [Permission]) VALUES (3, N'deneme', N'Ankara Yenimahalle', N'123', N'deneme@hotmail.com', 1, 0, N'User')
INSERT [dbo].[OtelUsers] ([OtelUserId], [OtelUserName], [OtelName], [OtelPassword], [OtelMail], [OtelStatus], [OtelId], [Permission]) VALUES (5, N'ad', N'd', N'123', N'ds', 0, 0, N'User')
INSERT [dbo].[OtelUsers] ([OtelUserId], [OtelUserName], [OtelName], [OtelPassword], [OtelMail], [OtelStatus], [OtelId], [Permission]) VALUES (6, N'a', N'a', N'123', N'a', 0, 0, NULL)
INSERT [dbo].[OtelUsers] ([OtelUserId], [OtelUserName], [OtelName], [OtelPassword], [OtelMail], [OtelStatus], [OtelId], [Permission]) VALUES (7, N'xxaiden3', N'asd', N'dsa', N'asd', 3, 0, N'User')
SET IDENTITY_INSERT [dbo].[OtelUsers] OFF
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
