USE [db_progra]
GO
/****** Object:  Table [dbo].[butacas]    Script Date: 11/14/2024 1:20:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[butacas](
	[id_butaca] [int] IDENTITY(1,1) NOT NULL,
	[id_sala] [int] NULL,
	[fila] [char](1) NULL,
	[columna] [int] NULL,
 CONSTRAINT [pk_butacas] PRIMARY KEY CLUSTERED 
(
	[id_butaca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 11/14/2024 1:20:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[fec_afiliacion] [datetime] NULL,
	[numero_doc] [int] NULL,
	[email] [varchar](50) NULL,
	[pass] [varchar](100) NULL,
	[admin] [bit] NULL,
 CONSTRAINT [pk_clientes] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[entradas]    Script Date: 11/14/2024 1:20:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[entradas](
	[id_butaca] [int] NOT NULL,
	[id_funcion] [int] NOT NULL,
	[id_reserva] [int] NULL,
 CONSTRAINT [pk_entradas] PRIMARY KEY CLUSTERED 
(
	[id_butaca] ASC,
	[id_funcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[formas_pago]    Script Date: 11/14/2024 1:20:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[formas_pago](
	[id_forma_pago] [int] IDENTITY(1,1) NOT NULL,
	[forma_pago] [varchar](50) NULL,
 CONSTRAINT [pk_formas_pago] PRIMARY KEY CLUSTERED 
(
	[id_forma_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[funciones]    Script Date: 11/14/2024 1:20:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[funciones](
	[id_funcion] [int] IDENTITY(1,1) NOT NULL,
	[id_pelicula] [int] NULL,
	[id_sala] [int] NULL,
	[horario] [datetime] NULL,
	[subtitulada] [bit] NULL,
	[precio_actual] [money] NULL,
	[fecha_alta] [datetime] NULL,
	[fecha_baja] [datetime] NULL,
 CONSTRAINT [pk_funciones] PRIMARY KEY CLUSTERED 
(
	[id_funcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[generos]    Script Date: 11/14/2024 1:20:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[generos](
	[id_genero] [int] IDENTITY(1,1) NOT NULL,
	[genero] [varchar](50) NULL,
 CONSTRAINT [pk_generos] PRIMARY KEY CLUSTERED 
(
	[id_genero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[peliculas]    Script Date: 11/14/2024 1:20:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[peliculas](
	[id_pelicula] [int] IDENTITY(1,1) NOT NULL,
	[pelicula] [varchar](100) NULL,
	[duracion] [time](7) NULL,
	[sinopsis] [varchar](200) NULL,
	[fecha_estreno] [date] NULL,
	[fecha_baja] [date] NULL,
	[id_genero] [int] NULL,
 CONSTRAINT [pk_peliculas] PRIMARY KEY CLUSTERED 
(
	[id_pelicula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reservas]    Script Date: 11/14/2024 1:20:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reservas](
	[id_reserva] [int] IDENTITY(1,1) NOT NULL,
	[id_forma_pago] [int] NULL,
	[id_cliente] [int] NULL,
	[fecha_emision] [datetime] NULL,
	[fecha_pago] [datetime] NULL,
	[estado_pago] [bit] NULL,
 CONSTRAINT [pk_reservas] PRIMARY KEY CLUSTERED 
(
	[id_reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[salas]    Script Date: 11/14/2024 1:20:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salas](
	[id_sala] [int] IDENTITY(1,1) NOT NULL,
	[activa] [bit] NULL,
 CONSTRAINT [pk_salas] PRIMARY KEY CLUSTERED 
(
	[id_sala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[butacas] ON 
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (1, 1, N'A', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (2, 1, N'B', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (3, 1, N'C', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (4, 1, N'D', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (5, 1, N'E', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (6, 1, N'F', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (7, 1, N'G', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (8, 1, N'H', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (9, 1, N'I', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (10, 1, N'J', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (11, 1, N'A', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (12, 1, N'B', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (13, 1, N'C', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (14, 1, N'D', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (15, 1, N'E', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (16, 1, N'F', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (17, 1, N'G', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (18, 1, N'H', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (19, 1, N'I', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (20, 1, N'J', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (21, 1, N'A', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (22, 1, N'B', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (23, 1, N'C', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (24, 1, N'D', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (25, 1, N'E', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (26, 1, N'F', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (27, 1, N'G', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (28, 1, N'H', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (29, 1, N'I', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (30, 1, N'J', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (31, 1, N'A', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (32, 1, N'B', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (33, 1, N'C', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (34, 1, N'D', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (35, 1, N'E', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (36, 1, N'F', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (37, 1, N'G', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (38, 1, N'H', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (39, 1, N'I', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (40, 1, N'J', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (41, 1, N'A', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (42, 1, N'B', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (43, 1, N'C', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (44, 1, N'D', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (45, 1, N'E', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (46, 1, N'F', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (47, 1, N'G', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (48, 1, N'H', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (49, 1, N'I', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (50, 1, N'J', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (51, 1, N'A', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (52, 1, N'B', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (53, 1, N'C', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (54, 1, N'D', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (55, 1, N'E', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (56, 1, N'F', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (57, 1, N'G', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (58, 1, N'H', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (59, 1, N'I', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (60, 1, N'J', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (61, 1, N'A', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (62, 1, N'B', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (63, 1, N'C', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (64, 1, N'D', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (65, 1, N'E', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (66, 1, N'F', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (67, 1, N'G', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (68, 1, N'H', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (69, 1, N'I', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (70, 1, N'J', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (71, 1, N'A', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (72, 1, N'B', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (73, 1, N'C', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (74, 1, N'D', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (75, 1, N'E', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (76, 1, N'F', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (77, 1, N'G', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (78, 1, N'H', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (79, 1, N'I', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (80, 1, N'J', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (81, 1, N'A', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (82, 1, N'B', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (83, 1, N'C', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (84, 1, N'D', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (85, 1, N'E', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (86, 1, N'F', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (87, 1, N'G', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (88, 1, N'H', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (89, 1, N'I', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (90, 1, N'J', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (91, 2, N'A', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (92, 2, N'B', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (93, 2, N'C', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (94, 2, N'D', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (95, 2, N'E', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (96, 2, N'F', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (97, 2, N'G', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (98, 2, N'H', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (99, 2, N'I', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (100, 2, N'J', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (101, 2, N'A', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (102, 2, N'B', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (103, 2, N'C', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (104, 2, N'D', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (105, 2, N'E', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (106, 2, N'F', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (107, 2, N'G', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (108, 2, N'H', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (109, 2, N'I', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (110, 2, N'J', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (111, 2, N'A', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (112, 2, N'B', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (113, 2, N'C', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (114, 2, N'D', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (115, 2, N'E', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (116, 2, N'F', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (117, 2, N'G', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (118, 2, N'H', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (119, 2, N'I', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (120, 2, N'J', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (121, 2, N'A', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (122, 2, N'B', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (123, 2, N'C', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (124, 2, N'D', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (125, 2, N'E', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (126, 2, N'F', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (127, 2, N'G', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (128, 2, N'H', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (129, 2, N'I', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (130, 2, N'J', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (131, 2, N'A', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (132, 2, N'B', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (133, 2, N'C', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (134, 2, N'D', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (135, 2, N'E', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (136, 2, N'F', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (137, 2, N'G', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (138, 2, N'H', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (139, 2, N'I', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (140, 2, N'J', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (141, 2, N'A', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (142, 2, N'B', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (143, 2, N'C', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (144, 2, N'D', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (145, 2, N'E', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (146, 2, N'F', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (147, 2, N'G', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (148, 2, N'H', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (149, 2, N'I', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (150, 2, N'J', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (151, 2, N'A', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (152, 2, N'B', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (153, 2, N'C', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (154, 2, N'D', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (155, 2, N'E', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (156, 2, N'F', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (157, 2, N'G', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (158, 2, N'H', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (159, 2, N'I', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (160, 2, N'J', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (161, 2, N'A', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (162, 2, N'B', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (163, 2, N'C', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (164, 2, N'D', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (165, 2, N'E', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (166, 2, N'F', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (167, 2, N'G', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (168, 2, N'H', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (169, 2, N'I', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (170, 2, N'J', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (171, 2, N'A', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (172, 2, N'B', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (173, 2, N'C', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (174, 2, N'D', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (175, 2, N'E', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (176, 2, N'F', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (177, 2, N'G', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (178, 2, N'H', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (179, 2, N'I', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (180, 2, N'J', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (181, 3, N'A', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (182, 3, N'B', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (183, 3, N'C', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (184, 3, N'D', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (185, 3, N'E', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (186, 3, N'F', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (187, 3, N'G', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (188, 3, N'H', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (189, 3, N'I', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (190, 3, N'J', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (191, 3, N'A', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (192, 3, N'B', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (193, 3, N'C', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (194, 3, N'D', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (195, 3, N'E', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (196, 3, N'F', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (197, 3, N'G', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (198, 3, N'H', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (199, 3, N'I', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (200, 3, N'J', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (201, 3, N'A', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (202, 3, N'B', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (203, 3, N'C', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (204, 3, N'D', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (205, 3, N'E', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (206, 3, N'F', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (207, 3, N'G', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (208, 3, N'H', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (209, 3, N'I', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (210, 3, N'J', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (211, 3, N'A', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (212, 3, N'B', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (213, 3, N'C', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (214, 3, N'D', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (215, 3, N'E', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (216, 3, N'F', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (217, 3, N'G', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (218, 3, N'H', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (219, 3, N'I', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (220, 3, N'J', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (221, 3, N'A', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (222, 3, N'B', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (223, 3, N'C', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (224, 3, N'D', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (225, 3, N'E', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (226, 3, N'F', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (227, 3, N'G', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (228, 3, N'H', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (229, 3, N'I', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (230, 3, N'J', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (231, 3, N'A', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (232, 3, N'B', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (233, 3, N'C', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (234, 3, N'D', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (235, 3, N'E', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (236, 3, N'F', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (237, 3, N'G', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (238, 3, N'H', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (239, 3, N'I', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (240, 3, N'J', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (241, 3, N'A', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (242, 3, N'B', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (243, 3, N'C', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (244, 3, N'D', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (245, 3, N'E', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (246, 3, N'F', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (247, 3, N'G', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (248, 3, N'H', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (249, 3, N'I', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (250, 3, N'J', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (251, 3, N'A', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (252, 3, N'B', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (253, 3, N'C', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (254, 3, N'D', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (255, 3, N'E', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (256, 3, N'F', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (257, 3, N'G', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (258, 3, N'H', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (259, 3, N'I', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (260, 3, N'J', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (261, 3, N'A', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (262, 3, N'B', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (263, 3, N'C', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (264, 3, N'D', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (265, 3, N'E', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (266, 3, N'F', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (267, 3, N'G', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (268, 3, N'H', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (269, 3, N'I', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (270, 3, N'J', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (271, 4, N'A', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (272, 4, N'B', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (273, 4, N'C', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (274, 4, N'D', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (275, 4, N'E', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (276, 4, N'F', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (277, 4, N'G', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (278, 4, N'H', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (279, 4, N'I', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (280, 4, N'J', 1)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (281, 4, N'A', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (282, 4, N'B', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (283, 4, N'C', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (284, 4, N'D', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (285, 4, N'E', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (286, 4, N'F', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (287, 4, N'G', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (288, 4, N'H', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (289, 4, N'I', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (290, 4, N'J', 2)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (291, 4, N'A', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (292, 4, N'B', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (293, 4, N'C', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (294, 4, N'D', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (295, 4, N'E', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (296, 4, N'F', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (297, 4, N'G', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (298, 4, N'H', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (299, 4, N'I', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (300, 4, N'J', 3)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (301, 4, N'A', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (302, 4, N'B', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (303, 4, N'C', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (304, 4, N'D', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (305, 4, N'E', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (306, 4, N'F', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (307, 4, N'G', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (308, 4, N'H', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (309, 4, N'I', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (310, 4, N'J', 4)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (311, 4, N'A', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (312, 4, N'B', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (313, 4, N'C', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (314, 4, N'D', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (315, 4, N'E', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (316, 4, N'F', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (317, 4, N'G', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (318, 4, N'H', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (319, 4, N'I', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (320, 4, N'J', 5)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (321, 4, N'A', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (322, 4, N'B', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (323, 4, N'C', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (324, 4, N'D', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (325, 4, N'E', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (326, 4, N'F', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (327, 4, N'G', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (328, 4, N'H', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (329, 4, N'I', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (330, 4, N'J', 6)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (331, 4, N'A', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (332, 4, N'B', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (333, 4, N'C', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (334, 4, N'D', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (335, 4, N'E', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (336, 4, N'F', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (337, 4, N'G', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (338, 4, N'H', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (339, 4, N'I', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (340, 4, N'J', 7)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (341, 4, N'A', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (342, 4, N'B', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (343, 4, N'C', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (344, 4, N'D', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (345, 4, N'E', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (346, 4, N'F', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (347, 4, N'G', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (348, 4, N'H', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (349, 4, N'I', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (350, 4, N'J', 8)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (351, 4, N'A', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (352, 4, N'B', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (353, 4, N'C', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (354, 4, N'D', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (355, 4, N'E', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (356, 4, N'F', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (357, 4, N'G', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (358, 4, N'H', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (359, 4, N'I', 9)
GO
INSERT [dbo].[butacas] ([id_butaca], [id_sala], [fila], [columna]) VALUES (360, 4, N'J', 9)
GO
SET IDENTITY_INSERT [dbo].[butacas] OFF
GO
SET IDENTITY_INSERT [dbo].[clientes] ON 
GO
INSERT [dbo].[clientes] ([id_cliente], [nombre], [apellido], [fec_afiliacion], [numero_doc], [email], [pass], [admin]) VALUES (1, N'Diana', N'Camacho', CAST(N'2024-07-10T10:10:00.000' AS DateTime), 23487678, N'diana.camacho@example.com', NULL, NULL)
GO
INSERT [dbo].[clientes] ([id_cliente], [nombre], [apellido], [fec_afiliacion], [numero_doc], [email], [pass], [admin]) VALUES (2, N'Juan', N'Pérez', CAST(N'2023-12-25T10:30:00.000' AS DateTime), 12345678, N'juan.perez@example.com', NULL, NULL)
GO
INSERT [dbo].[clientes] ([id_cliente], [nombre], [apellido], [fec_afiliacion], [numero_doc], [email], [pass], [admin]) VALUES (3, N'María', N'Gómez', CAST(N'2023-11-15T14:45:00.000' AS DateTime), 23456789, N'maria.gomez@example.com', NULL, NULL)
GO
INSERT [dbo].[clientes] ([id_cliente], [nombre], [apellido], [fec_afiliacion], [numero_doc], [email], [pass], [admin]) VALUES (4, N'Luis', N'Hernández', CAST(N'2023-10-05T09:00:00.000' AS DateTime), 34567890, N'luis.hernandez@example.com', NULL, NULL)
GO
INSERT [dbo].[clientes] ([id_cliente], [nombre], [apellido], [fec_afiliacion], [numero_doc], [email], [pass], [admin]) VALUES (5, N'Ana', N'Martínez', CAST(N'2023-09-20T11:20:00.000' AS DateTime), 45678901, N'ana.martinez@example.com', NULL, NULL)
GO
INSERT [dbo].[clientes] ([id_cliente], [nombre], [apellido], [fec_afiliacion], [numero_doc], [email], [pass], [admin]) VALUES (6, N'Carlos', N'López', CAST(N'2023-08-30T13:30:00.000' AS DateTime), 56789012, N'carlos.lopez@example.com', NULL, NULL)
GO
INSERT [dbo].[clientes] ([id_cliente], [nombre], [apellido], [fec_afiliacion], [numero_doc], [email], [pass], [admin]) VALUES (7, N'Sofía', N'Díaz', CAST(N'2023-07-15T12:10:00.000' AS DateTime), 67890123, N'sofia.diaz@example.com', NULL, NULL)
GO
INSERT [dbo].[clientes] ([id_cliente], [nombre], [apellido], [fec_afiliacion], [numero_doc], [email], [pass], [admin]) VALUES (8, N'Javier', N'González', CAST(N'2023-06-18T10:05:00.000' AS DateTime), 78901234, N'javier.gonzalez@example.com', NULL, NULL)
GO
INSERT [dbo].[clientes] ([id_cliente], [nombre], [apellido], [fec_afiliacion], [numero_doc], [email], [pass], [admin]) VALUES (9, N'Verónica', N'Sierra', CAST(N'2023-05-25T15:00:00.000' AS DateTime), 89012345, N'veronica.sierra@example.com', NULL, NULL)
GO
INSERT [dbo].[clientes] ([id_cliente], [nombre], [apellido], [fec_afiliacion], [numero_doc], [email], [pass], [admin]) VALUES (10, N'Marta', N'Alvarez', CAST(N'2023-04-11T14:45:00.000' AS DateTime), 90123456, N'marta.alvarez@example.com', NULL, NULL)
GO
INSERT [dbo].[clientes] ([id_cliente], [nombre], [apellido], [fec_afiliacion], [numero_doc], [email], [pass], [admin]) VALUES (11, N'Daniel', N'Bermúdez', CAST(N'2023-03-02T11:30:00.000' AS DateTime), 12398767, N'daniel.bermudez@example.com', NULL, NULL)
GO
INSERT [dbo].[clientes] ([id_cliente], [nombre], [apellido], [fec_afiliacion], [numero_doc], [email], [pass], [admin]) VALUES (12, N'Camila', N'Ramírez', CAST(N'2024-01-30T10:50:00.000' AS DateTime), 23487678, N'camila.ramirez@example.com', NULL, NULL)
GO
INSERT [dbo].[clientes] ([id_cliente], [nombre], [apellido], [fec_afiliacion], [numero_doc], [email], [pass], [admin]) VALUES (13, N'Rafael', N'García', CAST(N'2024-02-22T12:25:00.000' AS DateTime), 34576589, N'rafael.garcia@example.com', NULL, NULL)
GO
INSERT [dbo].[clientes] ([id_cliente], [nombre], [apellido], [fec_afiliacion], [numero_doc], [email], [pass], [admin]) VALUES (14, N'Lucía', N'Salinas', CAST(N'2024-03-10T11:10:00.000' AS DateTime), 45665490, N'lucia.salinas@example.com', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[clientes] OFF
GO
INSERT [dbo].[entradas] ([id_butaca], [id_funcion], [id_reserva]) VALUES (23, 10, 4)
GO
INSERT [dbo].[entradas] ([id_butaca], [id_funcion], [id_reserva]) VALUES (24, 10, 3)
GO
INSERT [dbo].[entradas] ([id_butaca], [id_funcion], [id_reserva]) VALUES (33, 10, 4)
GO
INSERT [dbo].[entradas] ([id_butaca], [id_funcion], [id_reserva]) VALUES (34, 10, 3)
GO
INSERT [dbo].[entradas] ([id_butaca], [id_funcion], [id_reserva]) VALUES (43, 10, 4)
GO
INSERT [dbo].[entradas] ([id_butaca], [id_funcion], [id_reserva]) VALUES (44, 10, 3)
GO
INSERT [dbo].[entradas] ([id_butaca], [id_funcion], [id_reserva]) VALUES (45, 10, 6)
GO
INSERT [dbo].[entradas] ([id_butaca], [id_funcion], [id_reserva]) VALUES (53, 10, 2)
GO
INSERT [dbo].[entradas] ([id_butaca], [id_funcion], [id_reserva]) VALUES (54, 10, 3)
GO
INSERT [dbo].[entradas] ([id_butaca], [id_funcion], [id_reserva]) VALUES (63, 10, 5)
GO
INSERT [dbo].[entradas] ([id_butaca], [id_funcion], [id_reserva]) VALUES (64, 10, 3)
GO
SET IDENTITY_INSERT [dbo].[formas_pago] ON 
GO
INSERT [dbo].[formas_pago] ([id_forma_pago], [forma_pago]) VALUES (1, N'Debito')
GO
INSERT [dbo].[formas_pago] ([id_forma_pago], [forma_pago]) VALUES (2, N'Efectivo')
GO
INSERT [dbo].[formas_pago] ([id_forma_pago], [forma_pago]) VALUES (3, N'Credito')
GO
SET IDENTITY_INSERT [dbo].[formas_pago] OFF
GO
SET IDENTITY_INSERT [dbo].[funciones] ON 
GO
INSERT [dbo].[funciones] ([id_funcion], [id_pelicula], [id_sala], [horario], [subtitulada], [precio_actual], [fecha_alta], [fecha_baja]) VALUES (1, 1, 1, CAST(N'2024-11-13T13:41:49.580' AS DateTime), 1, 6000.0000, CAST(N'2024-11-08T13:41:49.580' AS DateTime), NULL)
GO
INSERT [dbo].[funciones] ([id_funcion], [id_pelicula], [id_sala], [horario], [subtitulada], [precio_actual], [fecha_alta], [fecha_baja]) VALUES (2, 2, 2, CAST(N'2024-11-13T13:46:10.343' AS DateTime), 1, 7000.0000, CAST(N'2024-11-08T13:46:10.343' AS DateTime), CAST(N'2024-11-08T17:59:33.333' AS DateTime))
GO
INSERT [dbo].[funciones] ([id_funcion], [id_pelicula], [id_sala], [horario], [subtitulada], [precio_actual], [fecha_alta], [fecha_baja]) VALUES (3, 3, 3, CAST(N'2024-11-13T13:41:49.580' AS DateTime), 0, 8000.0000, CAST(N'2024-11-08T13:41:49.580' AS DateTime), CAST(N'2024-11-08T18:00:09.373' AS DateTime))
GO
INSERT [dbo].[funciones] ([id_funcion], [id_pelicula], [id_sala], [horario], [subtitulada], [precio_actual], [fecha_alta], [fecha_baja]) VALUES (4, 1, 1, CAST(N'2024-11-10T16:56:00.000' AS DateTime), 0, 2341.0000, CAST(N'2024-11-08T19:56:52.007' AS DateTime), NULL)
GO
INSERT [dbo].[funciones] ([id_funcion], [id_pelicula], [id_sala], [horario], [subtitulada], [precio_actual], [fecha_alta], [fecha_baja]) VALUES (5, 32, 3, CAST(N'2024-12-01T00:00:00.000' AS DateTime), 0, 9521.0000, CAST(N'2024-11-08T20:07:18.547' AS DateTime), CAST(N'2024-11-08T18:43:59.113' AS DateTime))
GO
INSERT [dbo].[funciones] ([id_funcion], [id_pelicula], [id_sala], [horario], [subtitulada], [precio_actual], [fecha_alta], [fecha_baja]) VALUES (6, 1, 2, CAST(N'2024-10-30T18:19:00.000' AS DateTime), 0, 123.0000, CAST(N'2024-11-08T21:19:38.130' AS DateTime), CAST(N'2024-11-08T18:43:50.313' AS DateTime))
GO
INSERT [dbo].[funciones] ([id_funcion], [id_pelicula], [id_sala], [horario], [subtitulada], [precio_actual], [fecha_alta], [fecha_baja]) VALUES (7, 21, 3, CAST(N'2024-12-03T18:27:00.000' AS DateTime), 0, 6665.0000, CAST(N'2024-11-08T21:27:31.767' AS DateTime), CAST(N'2024-11-08T18:42:53.017' AS DateTime))
GO
INSERT [dbo].[funciones] ([id_funcion], [id_pelicula], [id_sala], [horario], [subtitulada], [precio_actual], [fecha_alta], [fecha_baja]) VALUES (8, 32, 3, CAST(N'2024-11-11T19:06:00.000' AS DateTime), 1, 1236.0000, CAST(N'2024-11-08T22:06:49.077' AS DateTime), NULL)
GO
INSERT [dbo].[funciones] ([id_funcion], [id_pelicula], [id_sala], [horario], [subtitulada], [precio_actual], [fecha_alta], [fecha_baja]) VALUES (9, 21, 4, CAST(N'2024-05-08T00:31:00.000' AS DateTime), 0, 10000.0000, CAST(N'2024-11-09T03:31:40.567' AS DateTime), NULL)
GO
INSERT [dbo].[funciones] ([id_funcion], [id_pelicula], [id_sala], [horario], [subtitulada], [precio_actual], [fecha_alta], [fecha_baja]) VALUES (10, 32, 1, CAST(N'2024-11-07T00:40:00.000' AS DateTime), 1, 324234.2300, CAST(N'2024-11-09T03:41:01.407' AS DateTime), NULL)
GO
INSERT [dbo].[funciones] ([id_funcion], [id_pelicula], [id_sala], [horario], [subtitulada], [precio_actual], [fecha_alta], [fecha_baja]) VALUES (11, 1, 3, CAST(N'2024-11-17T16:12:00.000' AS DateTime), 1, 324.0000, CAST(N'2024-11-11T22:20:34.507' AS DateTime), NULL)
GO
INSERT [dbo].[funciones] ([id_funcion], [id_pelicula], [id_sala], [horario], [subtitulada], [precio_actual], [fecha_alta], [fecha_baja]) VALUES (12, 1, 1, CAST(N'2024-11-13T14:24:00.000' AS DateTime), 1, 234.0000, CAST(N'2024-11-11T22:20:50.933' AS DateTime), CAST(N'2024-11-11T19:24:38.087' AS DateTime))
GO
INSERT [dbo].[funciones] ([id_funcion], [id_pelicula], [id_sala], [horario], [subtitulada], [precio_actual], [fecha_alta], [fecha_baja]) VALUES (13, 1, 4, CAST(N'2024-11-17T16:00:00.000' AS DateTime), 1, 12345.0000, CAST(N'2024-11-11T22:53:48.313' AS DateTime), NULL)
GO
INSERT [dbo].[funciones] ([id_funcion], [id_pelicula], [id_sala], [horario], [subtitulada], [precio_actual], [fecha_alta], [fecha_baja]) VALUES (15, 1, 4, CAST(N'2024-11-17T17:55:00.000' AS DateTime), 1, 324234.0000, CAST(N'2024-11-11T23:55:43.223' AS DateTime), CAST(N'2024-11-11T20:56:14.953' AS DateTime))
GO
INSERT [dbo].[funciones] ([id_funcion], [id_pelicula], [id_sala], [horario], [subtitulada], [precio_actual], [fecha_alta], [fecha_baja]) VALUES (16, 32, 3, CAST(N'2024-12-01T23:22:00.000' AS DateTime), 1, 7777.0000, CAST(N'2024-11-12T02:22:09.683' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[funciones] OFF
GO
SET IDENTITY_INSERT [dbo].[generos] ON 
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (1, N'Acción')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (2, N'Ciencia Ficción')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (3, N'Aventura')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (4, N'Animación')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (5, N'Familiar')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (6, N'Terror')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (7, N'Suspenso')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (8, N'Comedia')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (9, N'Drama')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (10, N'Crimen')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (11, N'Fantasía')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (12, N'Thriller')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (13, N'Documental')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (14, N'Romance')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (15, N'Historia')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (16, N'Misterio')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (17, N'Acción')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (18, N'Ciencia Ficción')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (19, N'Aventura')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (20, N'Animación')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (21, N'Familiar')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (22, N'Terror')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (23, N'Suspenso')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (24, N'Comedia')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (25, N'Drama')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (26, N'Crimen')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (27, N'Fantasía')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (28, N'Thriller')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (29, N'Documental')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (30, N'Romance')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (31, N'Historia')
GO
INSERT [dbo].[generos] ([id_genero], [genero]) VALUES (32, N'Misterio')
GO
SET IDENTITY_INSERT [dbo].[generos] OFF
GO
SET IDENTITY_INSERT [dbo].[peliculas] ON 
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (1, N'Venom: El último baile', CAST(N'01:52:00' AS Time), N'Eddie y Venom están a la fuga, perseguidos y deben tomar una decisión devastadora para sus futuros.', CAST(N'2024-10-22' AS Date), CAST(N'2024-11-12' AS Date), 1)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (2, N'Robot salvaje', CAST(N'01:30:00' AS Time), N'La unidad 7134 naufraga en una isla deshabitada y debe adaptarse, convirtiéndose en padre de un pequeño ganso huérfano.', CAST(N'2024-09-12' AS Date), CAST(N'2024-10-10' AS Date), 4)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (3, N'Terrifier 3', CAST(N'01:42:00' AS Time), N'El payaso Art desata el caos en el condado de Miles mientras los habitantes duermen en Nochebuena.', CAST(N'2024-10-09' AS Date), CAST(N'2024-10-30' AS Date), 6)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (4, N'Transformers One', CAST(N'01:55:00' AS Time), N'El origen de Optimus Prime y Megatron y cómo se convirtieron en enemigos acérrimos.', CAST(N'2024-09-11' AS Date), CAST(N'2024-09-25' AS Date), 4)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (5, N'Alien: Romulus', CAST(N'01:48:00' AS Time), N'Un grupo de jóvenes colonizadores enfrenta a la forma de vida más aterradora del universo en una estación abandonada.', CAST(N'2024-08-13' AS Date), CAST(N'2024-08-27' AS Date), 2)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (6, N'La sustancia', CAST(N'01:40:00' AS Time), N'Un producto revolucionario crea un alter ego joven y perfecto.', CAST(N'2024-09-07' AS Date), CAST(N'2024-09-21' AS Date), 2)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (7, N'Deadpool y Lobezno', CAST(N'01:53:00' AS Time), N'Wade Wilson deja su vida como Deadpool, pero debe volver cuando su mundo enfrenta una amenaza existencial.', CAST(N'2024-07-24' AS Date), CAST(N'2024-08-14' AS Date), 1)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (8, N'Survivre', CAST(N'01:36:00' AS Time), N'Sobrevivientes enfrentan peligros en un mundo post-apocalíptico.', CAST(N'2024-06-19' AS Date), CAST(N'2024-07-03' AS Date), 7)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (9, N'Del revés 2', CAST(N'01:38:00' AS Time), N'Riley entra en la adolescencia y el Cuartel General de su cabeza se adapta a nuevas emociones.', CAST(N'2024-06-11' AS Date), CAST(N'2024-07-02' AS Date), 4)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (10, N'Azrael', CAST(N'01:45:00' AS Time), N'Un detective investiga asesinatos vinculados a un culto maligno.', CAST(N'2024-09-27' AS Date), CAST(N'2024-10-11' AS Date), 9)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (11, N'Joker: Folie à Deux', CAST(N'02:00:00' AS Time), N'Secuela de "Joker (2019)", mostrando la relación entre Arthur Fleck y Harley Quinn.', CAST(N'2024-10-01' AS Date), CAST(N'2024-10-15' AS Date), 9)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (12, N'Bitelchús Bitelchús', CAST(N'01:49:00' AS Time), N'Tras una tragedia, la familia Deetz regresa y su hija descubre un portal al Más Allá.', CAST(N'2024-09-04' AS Date), CAST(N'2024-09-25' AS Date), 8)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (13, N'El Cuervo', CAST(N'01:40:00' AS Time), N'Eric, asesinado junto a su prometida, revive por un cuervo místico para cobrar venganza.', CAST(N'2024-08-21' AS Date), CAST(N'2024-09-11' AS Date), 11)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (14, N'The Silent Hour', CAST(N'01:45:00' AS Time), N'Detective sordo trabaja como intérprete y se enfrenta a policías corruptos.', CAST(N'2024-10-03' AS Date), CAST(N'2024-10-17' AS Date), 10)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (15, N'Bob Esponja: Campamento del Terror', CAST(N'01:25:00' AS Time), N'Bob Esponja vive aventuras aterradoras en un campamento.', CAST(N'2024-10-10' AS Date), CAST(N'2024-11-07' AS Date), 4)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (16, N'Project Silence', CAST(N'01:55:00' AS Time), N'Sujetos de un experimento militar escapan y atacan a humanos en clima extremo.', CAST(N'2024-07-11' AS Date), CAST(N'2024-08-08' AS Date), 1)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (17, N'Hellboy: The Crooked Man', CAST(N'01:47:00' AS Time), N'Hellboy y un novato quedan atrapados en una comunidad embrujada por el Hombre Torcido.', CAST(N'2024-08-29' AS Date), CAST(N'2024-09-26' AS Date), 1)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (18, N'Invasión, insurrección', CAST(N'02:00:00' AS Time), N'Amigos de la infancia se reencuentran en la guerra como enemigos en lados opuestos.', CAST(N'2024-10-02' AS Date), CAST(N'2024-10-16' AS Date), 15)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (19, N'Rippy', CAST(N'01:20:00' AS Time), N'Terror y misterio rodean a Rippy en un entorno oscuro.', CAST(N'2024-10-25' AS Date), CAST(N'2024-11-08' AS Date), 6)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (20, N'Flow', CAST(N'01:35:00' AS Time), N'Un gato viaja en un barco tras una inundación que destruye su hogar.', CAST(N'2024-08-30' AS Date), CAST(N'2024-09-20' AS Date), 11)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (21, N'Los hombres lobo', CAST(N'01:38:00' AS Time), N'Una familia viaja en el tiempo para enfrentarse a hombres lobo y volver a casa.', CAST(N'2024-10-22' AS Date), CAST(N'2024-11-12' AS Date), 3)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (22, N'El Conde de Montecristo', CAST(N'02:15:00' AS Time), N'Adaptación de la novela de Dumas, con la búsqueda de venganza de Edmundo Dantès.', CAST(N'2024-06-28' AS Date), CAST(N'2024-07-12' AS Date), 3)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (23, N'Los Green en la gran ciudad', CAST(N'01:28:00' AS Time), N'Cricket Green y su familia van al espacio en una aventura inesperada.', CAST(N'2024-06-06' AS Date), CAST(N'2024-06-20' AS Date), 4)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (24, N'No te muevas', CAST(N'01:22:00' AS Time), N'Una mujer lucha por su vida tras ser drogada por un asesino en el bosque.', CAST(N'2024-10-24' AS Date), CAST(N'2024-11-07' AS Date), 7)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (25, N'El baño del diablo', CAST(N'01:45:00' AS Time), N'Austria, siglo XVIII. Una mujer condenada se enfrenta a malos pensamientos tras un trágico suceso.', CAST(N'2024-03-08' AS Date), CAST(N'2024-03-29' AS Date), 6)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (26, N'Problemas...', CAST(N'01:40:00' AS Time), N'Un dependiente enfrenta corrupción y conspiraciones para probar su inocencia en un asesinato que no cometió.', CAST(N'2024-10-02' AS Date), CAST(N'2024-10-23' AS Date), 1)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (27, N'Seven Cemeteries', CAST(N'01:30:00' AS Time), N'Amigos desentierran secretos oscuros tras encontrar un mapa antiguo.', CAST(N'2024-10-11' AS Date), CAST(N'2024-10-25' AS Date), 12)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (28, N'Presa', CAST(N'01:55:00' AS Time), N'Una pareja lucha por sobrevivir tras un accidente en el desierto del Kalahari ante amenazas extremistas.', CAST(N'2024-03-15' AS Date), CAST(N'2024-04-12' AS Date), 12)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (29, N'Arcadian', CAST(N'01:40:00' AS Time), N'Un padre y sus mellizos luchan por sobrevivir ante criaturas feroces en su granja remota.', CAST(N'2024-04-12' AS Date), CAST(N'2024-04-26' AS Date), 6)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (30, N'Die Alone', CAST(N'01:30:00' AS Time), N'Un hombre enfrenta sus demonios internos tras perder a su familia.', CAST(N'2024-09-27' AS Date), CAST(N'2024-10-25' AS Date), 13)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (31, N'Maníaco do Parque', CAST(N'01:25:00' AS Time), N'Un vigilante del parque, atrapado en su locura, desata una serie de asesinatos mientras trata de proteger su territorio de extraños que amenazan su mundo.', CAST(N'2024-10-12' AS Date), CAST(N'2024-10-26' AS Date), 8)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (32, N'Vaiana 2', CAST(N'01:40:00' AS Time), N'Secuela de la película de animación de 2016 "Vaiana".', CAST(N'2024-11-27' AS Date), CAST(N'2024-12-25' AS Date), 13)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (33, N'Guardiana de dragones', CAST(N'01:55:00' AS Time), N'Una niña ayuda a escapar al último dragón en una misión para recuperar su huevo robado.', CAST(N'2024-04-11' AS Date), CAST(N'2024-05-09' AS Date), 11)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (34, N'Los descendientes: Corazón rebelde', CAST(N'01:42:00' AS Time), N'Las hijas de villanos unen fuerzas para impedir un golpe de Estado en Áuradon.', CAST(N'2024-07-11' AS Date), CAST(N'2024-08-01' AS Date), 11)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (35, N'Corrupción en Bangkok: Entre el cielo y el infierno', CAST(N'01:50:00' AS Time), N'Un rescatista lucha por sobrevivir en un conflicto entre bandas en Bangkok.', CAST(N'2024-09-26' AS Date), CAST(N'2024-10-17' AS Date), 13)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (36, N'Culpa tuya', CAST(N'01:30:00' AS Time), N'Noah y Nick enfrentan nuevas relaciones y una exnovia vengativa que cambiará sus vidas.', CAST(N'2024-09-26' AS Date), CAST(N'2024-10-24' AS Date), 14)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (37, N'Barbie', CAST(N'01:54:00' AS Time), N'Barbie vive en Barbieland y decide conocer el mundo real. El CEO de Mattel intentará evitarlo y devolverla a su caja.', CAST(N'2023-07-19' AS Date), CAST(N'2023-08-16' AS Date), 8)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (38, N'El guerrero mágico: La leyenda de las ocho lunas', CAST(N'01:40:00' AS Time), N'Un príncipe lucha para liberar a su esposa del tirano galáctico con ayuda de su hermano, un rey y guerreros.', CAST(N'2023-10-11' AS Date), CAST(N'2023-11-01' AS Date), 4)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (39, N'Elemental', CAST(N'01:42:00' AS Time), N'En una ciudad de fuego, agua, tierra y aire, dos jóvenes descubren lo que tienen en común.', CAST(N'2023-06-14' AS Date), CAST(N'2023-07-12' AS Date), 4)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (40, N'The Marvels', CAST(N'01:45:00' AS Time), N'Carol Danvers se une a Kamala Khan y Monica Rambeau para salvar el universo al enfrentarse a un poderoso enemigo.', CAST(N'2023-11-08' AS Date), CAST(N'2023-11-22' AS Date), 2)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (41, N'Lassie (Una nueva aventura)', CAST(N'01:30:00' AS Time), N'Lassie investiga desapariciones de perros de pedigrí con su amiga Flo y nuevos compañeros.', CAST(N'2023-07-27' AS Date), CAST(N'2023-08-10' AS Date), 5)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (42, N'Oppenheimer', CAST(N'02:30:00' AS Time), N'Película sobre J. Robert Oppenheimer y su papel en el desarrollo de la bomba atómica, basada en el libro "American Prometheus".', CAST(N'2023-07-19' AS Date), CAST(N'2023-08-02' AS Date), 15)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (43, N'Misión: Imposible - Sentencia mortal parte uno', CAST(N'02:30:00' AS Time), N'Ethan Hunt y la IMF deben rastrear un arma mortal antes de que caiga en manos de un enemigo poderoso.', CAST(N'2023-07-08' AS Date), CAST(N'2023-07-22' AS Date), 1)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (44, N'Cualquiera menos tú', CAST(N'01:50:00' AS Time), N'Después de una primera cita, una pareja se reencuentra en una boda en Australia y finge ser una pareja.', CAST(N'2023-12-21' AS Date), CAST(N'2024-01-18' AS Date), 14)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (45, N'Gran Turismo', CAST(N'02:15:00' AS Time), N'Un adolescente gamer se convierte en piloto profesional tras ganar campeonatos de Nissan.', CAST(N'2023-08-09' AS Date), CAST(N'2023-09-06' AS Date), 3)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (46, N'Scream VI', CAST(N'01:50:00' AS Time), N'Los supervivientes de Ghostface dejan Woodsboro para comenzar un nuevo capítulo tras los últimos asesinatos.', CAST(N'2023-03-08' AS Date), CAST(N'2023-03-29' AS Date), 6)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (47, N'Five Nights at Freddy''s', CAST(N'01:40:00' AS Time), N'Un guardia de seguridad se enfrenta a terribles sucesos en Freddy Fazbear''s Pizza durante su primer turno nocturno.', CAST(N'2023-10-25' AS Date), CAST(N'2023-11-08' AS Date), 16)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (48, N'Godzilla Minus One', CAST(N'01:45:00' AS Time), N'En el Japón de la posguerra, los supervivientes deben luchar contra Godzilla y la desesperación.', CAST(N'2023-11-03' AS Date), CAST(N'2023-11-24' AS Date), 2)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (49, N'Diabolik ¿Quién eres?', CAST(N'01:30:00' AS Time), N'Diabolik y Ginko son capturados y encerrados. Él revela su pasado al inspector, mientras Eva busca a ambos.', CAST(N'2023-11-30' AS Date), CAST(N'2023-12-21' AS Date), 1)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (50, N'Transmorphers: Bestias mecánicas', CAST(N'01:40:00' AS Time), N'20 años después, una nueva raza de robots alienígenas amenaza la Tierra reconstruida.', CAST(N'2023-06-09' AS Date), CAST(N'2023-06-30' AS Date), 1)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (51, N'Kelas Bintang - Hot Moms', CAST(N'01:30:00' AS Time), N'Un grupo de madres audaces se inscribe en una clase de actuación, desatando una serie de eventos cómicos y románticos mientras desafían estereotipos y redescubren su juventud.', CAST(N'2023-02-09' AS Date), CAST(N'2023-03-02' AS Date), 14)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (52, N'Operation Black Ops', CAST(N'01:35:00' AS Time), N'Un equipo de élite es enviado a una misión encubierta que los lleva a enfrentarse a peligros inesperados, mientras luchan por cumplir su objetivo y sobrevivir en un mundo hostil.', CAST(N'2023-07-11' AS Date), CAST(N'2023-08-01' AS Date), 7)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (53, N'Culpa mía', CAST(N'01:45:00' AS Time), N'Noah se muda a una mansión de lujo, donde conoce a su hermanastro Nick. La tensión surge entre ellos.', CAST(N'2023-06-08' AS Date), CAST(N'2023-07-06' AS Date), 14)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (54, N'Las contrabandistas de Guncheon', CAST(N'01:50:00' AS Time), N'Dos mujeres se ven atrapadas en un peligroso mundo de contrabando en un pueblo de los 70.', CAST(N'2023-07-26' AS Date), CAST(N'2023-08-09' AS Date), 10)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (55, N'Héroes de Central Park', CAST(N'01:30:00' AS Time), N'Un títere de Don Quijote y un peluche emprenden una aventura en Central Park.', CAST(N'2023-09-01' AS Date), CAST(N'2023-09-29' AS Date), 4)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (56, N'Migración. Un viaje patas arriba', CAST(N'01:40:00' AS Time), N'La familia Mallard decide salir de su estanque y conocer el mundo tras historias de patos migratorios.', CAST(N'2023-12-06' AS Date), CAST(N'2024-01-03' AS Date), 5)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (57, N'Fast & Furious X', CAST(N'02:20:00' AS Time), N'Dom y su familia se enfrentan a un enemigo del pasado que amenaza todo lo que aman.', CAST(N'2023-05-17' AS Date), CAST(N'2023-06-07' AS Date), 1)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (58, N'Transformers: El despertar de las bestias', CAST(N'02:10:00' AS Time), N'Optimus Prime y los Autobots deben unirse a los Maximals para salvar el planeta de una nueva amenaza.', CAST(N'2023-06-06' AS Date), CAST(N'2023-06-27' AS Date), 2)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (59, N'John Wick 4', CAST(N'02:10:00' AS Time), N'John Wick enfrenta un nuevo rival y debe formar alianzas para ganar su libertad.', CAST(N'2023-03-22' AS Date), CAST(N'2023-04-19' AS Date), 7)
GO
INSERT [dbo].[peliculas] ([id_pelicula], [pelicula], [duracion], [sinopsis], [fecha_estreno], [fecha_baja], [id_genero]) VALUES (60, N'Spider-Man: Across the Spider-Verse', CAST(N'02:00:00' AS Time), N'Miles y Gwen deben enfrentar una nueva amenaza en el Multiverso mientras se cruzan con otros Spidermans.', CAST(N'2023-05-31' AS Date), CAST(N'2023-06-28' AS Date), 4)
GO
SET IDENTITY_INSERT [dbo].[peliculas] OFF
GO
SET IDENTITY_INSERT [dbo].[reservas] ON 
GO
INSERT [dbo].[reservas] ([id_reserva], [id_forma_pago], [id_cliente], [fecha_emision], [fecha_pago], [estado_pago]) VALUES (2, 1, 1, CAST(N'2024-11-12T08:43:31.660' AS DateTime), CAST(N'2024-11-12T11:43:31.567' AS DateTime), 1)
GO
INSERT [dbo].[reservas] ([id_reserva], [id_forma_pago], [id_cliente], [fecha_emision], [fecha_pago], [estado_pago]) VALUES (3, 2, 5, CAST(N'2024-11-12T08:46:12.180' AS DateTime), CAST(N'2024-11-12T11:46:12.167' AS DateTime), 1)
GO
INSERT [dbo].[reservas] ([id_reserva], [id_forma_pago], [id_cliente], [fecha_emision], [fecha_pago], [estado_pago]) VALUES (4, 1, 14, CAST(N'2024-11-12T09:16:53.857' AS DateTime), CAST(N'2024-11-12T12:16:53.793' AS DateTime), 1)
GO
INSERT [dbo].[reservas] ([id_reserva], [id_forma_pago], [id_cliente], [fecha_emision], [fecha_pago], [estado_pago]) VALUES (5, 2, 13, CAST(N'2024-11-12T09:17:54.123' AS DateTime), CAST(N'2024-11-12T12:17:54.100' AS DateTime), 1)
GO
INSERT [dbo].[reservas] ([id_reserva], [id_forma_pago], [id_cliente], [fecha_emision], [fecha_pago], [estado_pago]) VALUES (6, 3, 12, CAST(N'2024-11-12T09:19:25.227' AS DateTime), CAST(N'2024-11-12T12:19:25.223' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[reservas] OFF
GO
SET IDENTITY_INSERT [dbo].[salas] ON 
GO
INSERT [dbo].[salas] ([id_sala], [activa]) VALUES (1, 1)
GO
INSERT [dbo].[salas] ([id_sala], [activa]) VALUES (2, 1)
GO
INSERT [dbo].[salas] ([id_sala], [activa]) VALUES (3, 1)
GO
INSERT [dbo].[salas] ([id_sala], [activa]) VALUES (4, 1)
GO
SET IDENTITY_INSERT [dbo].[salas] OFF
GO
ALTER TABLE [dbo].[butacas]  WITH CHECK ADD  CONSTRAINT [fk_butacas_salas] FOREIGN KEY([id_sala])
REFERENCES [dbo].[salas] ([id_sala])
GO
ALTER TABLE [dbo].[butacas] CHECK CONSTRAINT [fk_butacas_salas]
GO
ALTER TABLE [dbo].[entradas]  WITH CHECK ADD  CONSTRAINT [fk_entradas_butacas] FOREIGN KEY([id_butaca])
REFERENCES [dbo].[butacas] ([id_butaca])
GO
ALTER TABLE [dbo].[entradas] CHECK CONSTRAINT [fk_entradas_butacas]
GO
ALTER TABLE [dbo].[entradas]  WITH CHECK ADD  CONSTRAINT [fk_entradas_funciones] FOREIGN KEY([id_funcion])
REFERENCES [dbo].[funciones] ([id_funcion])
GO
ALTER TABLE [dbo].[entradas] CHECK CONSTRAINT [fk_entradas_funciones]
GO
ALTER TABLE [dbo].[entradas]  WITH CHECK ADD  CONSTRAINT [fk_entradas_reservas] FOREIGN KEY([id_reserva])
REFERENCES [dbo].[reservas] ([id_reserva])
GO
ALTER TABLE [dbo].[entradas] CHECK CONSTRAINT [fk_entradas_reservas]
GO
ALTER TABLE [dbo].[funciones]  WITH CHECK ADD  CONSTRAINT [fk_funciones_peliculas] FOREIGN KEY([id_pelicula])
REFERENCES [dbo].[peliculas] ([id_pelicula])
GO
ALTER TABLE [dbo].[funciones] CHECK CONSTRAINT [fk_funciones_peliculas]
GO
ALTER TABLE [dbo].[funciones]  WITH CHECK ADD  CONSTRAINT [fk_funciones_salas] FOREIGN KEY([id_sala])
REFERENCES [dbo].[salas] ([id_sala])
GO
ALTER TABLE [dbo].[funciones] CHECK CONSTRAINT [fk_funciones_salas]
GO
ALTER TABLE [dbo].[peliculas]  WITH CHECK ADD  CONSTRAINT [fk_peliculas_genero] FOREIGN KEY([id_genero])
REFERENCES [dbo].[generos] ([id_genero])
GO
ALTER TABLE [dbo].[peliculas] CHECK CONSTRAINT [fk_peliculas_genero]
GO
ALTER TABLE [dbo].[reservas]  WITH CHECK ADD  CONSTRAINT [fk_reservas_clientes] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[clientes] ([id_cliente])
GO
ALTER TABLE [dbo].[reservas] CHECK CONSTRAINT [fk_reservas_clientes]
GO
ALTER TABLE [dbo].[reservas]  WITH CHECK ADD  CONSTRAINT [fk_reservas_formas_pago] FOREIGN KEY([id_forma_pago])
REFERENCES [dbo].[formas_pago] ([id_forma_pago])
GO
ALTER TABLE [dbo].[reservas] CHECK CONSTRAINT [fk_reservas_formas_pago]
GO
/****** Object:  StoredProcedure [dbo].[EncontrarConflicto]    Script Date: 11/14/2024 1:20:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EncontrarConflicto]
    @Horario DATETIME,      -- Horario de inicio de la función
    @IdPelicula INT,         -- ID de la película que se proyectará
    @IdSala INT,             -- ID de la sala donde se proyectará la película
    @idFuncion INT = NULL    -- ID de la función (ahora opcional)
AS
BEGIN
    DECLARE @DuracionPelicula TIME;
    DECLARE @HorarioFin DATETIME;

    SELECT @DuracionPelicula = Duracion
    FROM Peliculas
    WHERE id_pelicula = @IdPelicula;

    SET @HorarioFin = DATEADD(MINUTE, DATEDIFF(MINUTE, '00:00', @DuracionPelicula), @Horario);

    IF EXISTS (
        SELECT *
        FROM Funciones f
        JOIN Peliculas p ON f.id_pelicula = p.id_pelicula
        WHERE f.id_sala = @IdSala
        AND f.fecha_baja IS NULL
        AND (f.id_funcion <> @idFuncion OR @idFuncion IS NULL)  -- Se ajusta para permitir NULL
        AND (
            (f.Horario <= @Horario AND @Horario < DATEADD(MINUTE, DATEDIFF(MINUTE, '00:00', p.Duracion), f.Horario))
            OR
            (f.Horario < @HorarioFin AND @HorarioFin <= DATEADD(MINUTE, DATEDIFF(MINUTE, '00:00', p.Duracion), f.Horario))
            OR
            (@Horario <= f.Horario AND f.Horario < @HorarioFin)
            OR
            (@HorarioFin <= DATEADD(MINUTE, DATEDIFF(MINUTE, '00:00', p.Duracion), f.Horario) AND DATEADD(MINUTE, DATEDIFF(MINUTE, '00:00', p.Duracion), f.Horario) < @Horario)
        )
    )
    BEGIN
        SELECT 1 AS Conflicto;
    END
    ELSE
    BEGIN
        SELECT 0 AS Conflicto;
    END
END;
GO
