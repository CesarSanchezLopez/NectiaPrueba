USE [NectiaDB]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 14/10/2024 6:22:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Descripcion] [varchar](100) NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 14/10/2024 6:22:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 14/10/2024 6:22:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](500) NULL,
	[Marca] [varchar](500) NULL,
	[Valor] [decimal](18, 2) NULL,
	[Descripcion] [varchar](1500) NULL,
	[Imagen] [image] NULL,
	[CategoriaId] [int] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 14/10/2024 6:22:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User] [varchar](500) NOT NULL,
	[Password] [varchar](500) NOT NULL,
	[PrimerNombre] [varchar](500) NULL,
	[SegundoNombre] [varchar](500) NULL,
	[Telefono] [varchar](500) NULL,
	[PerfilId] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculo]    Script Date: 14/10/2024 6:22:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Descripcion] [varchar](500) NULL,
	[Chasis] [varchar](50) NULL,
	[Kilometraje] [int] NULL,
	[Color] [varchar](50) NULL,
	[Valor] [decimal](18, 2) NULL,
	[Tipo] [varchar](50) NULL,
	[Modelo] [varchar](4) NULL,
	[Marca] [varchar](15) NULL,
	[Placa] [varchar](8) NULL,
	[Version] [varchar](15) NULL,
 CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([Id], [Nombre], [Descripcion]) VALUES (1, N'Bicicletas', N'Bicicletas')
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Perfil] ON 

INSERT [dbo].[Perfil] ([Id], [Nombre]) VALUES (1, N'Admin')
INSERT [dbo].[Perfil] ([Id], [Nombre]) VALUES (2, N'Developer')
SET IDENTITY_INSERT [dbo].[Perfil] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [User], [Password], [PrimerNombre], [SegundoNombre], [Telefono], [PerfilId]) VALUES (1, N'Cesar', N'Admin123', N'Cesar', N'Adolfo', N'123456789', NULL)
INSERT [dbo].[Usuario] ([Id], [User], [Password], [PrimerNombre], [SegundoNombre], [Telefono], [PerfilId]) VALUES (6, N'admin', N'admin', N'Adminstrador', N'Adminstrador', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehiculo] ON 

INSERT [dbo].[Vehiculo] ([Id], [Nombre], [Descripcion], [Chasis], [Kilometraje], [Color], [Valor], [Tipo], [Modelo], [Marca], [Placa], [Version]) VALUES (1, N'Hilux', N'Casmioneta ', N'Normal', 20000, N'Rojo', CAST(15000000.00 AS Decimal(18, 2)), N'Camineta particular', N'2005', N'Toyota', N'123-abc', N'')
SET IDENTITY_INSERT [dbo].[Vehiculo] OFF
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Perfil] FOREIGN KEY([PerfilId])
REFERENCES [dbo].[Perfil] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Perfil]
GO
