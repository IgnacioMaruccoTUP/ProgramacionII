USE [db_turnos]
GO
/****** Object:  Table [dbo].[T_DETALLES_TURNO]    Script Date: 29/9/2024 13:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_DETALLES_TURNO](
	[id_turno] [int] NOT NULL,
	[id_servicio] [int] NOT NULL,
	[observaciones] [varchar](200) NULL,
 CONSTRAINT [PK_T_DETALLES_TURNO] PRIMARY KEY CLUSTERED 
(
	[id_turno] ASC,
	[id_servicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_SERVICIOS]    Script Date: 29/9/2024 13:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_SERVICIOS](
	[id] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[costo] [int] NOT NULL,
	[enPromocion] [varchar](1) NOT NULL,
	[fecha_cancelacion] [datetime] NULL,
	[motivo_cancelacion] [varchar](100) NULL,
 CONSTRAINT [PK_T_SERVICIOS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_TURNOS]    Script Date: 29/9/2024 13:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TURNOS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [varchar](10) NULL,
	[hora] [varchar](5) NULL,
	[cliente] [varchar](100) NULL,
 CONSTRAINT [PK_T_TURNOS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion], [fecha_cancelacion], [motivo_cancelacion]) VALUES (0, N'Extension', 23000, N'S', NULL, NULL)
GO
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion], [fecha_cancelacion], [motivo_cancelacion]) VALUES (1, N'Lavado de cabello', 500, N'N', NULL, NULL)
GO
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion], [fecha_cancelacion], [motivo_cancelacion]) VALUES (2, N'Corte', 2000, N'S', NULL, NULL)
GO
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion], [fecha_cancelacion], [motivo_cancelacion]) VALUES (3, N'Tintura', 3500, N'N', NULL, NULL)
GO
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion], [fecha_cancelacion], [motivo_cancelacion]) VALUES (4, N'Alisado', 12000, N'N', NULL, NULL)
GO
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion], [fecha_cancelacion], [motivo_cancelacion]) VALUES (5, N'Nutrición', 12500, N'S', NULL, NULL)
GO
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion], [fecha_cancelacion], [motivo_cancelacion]) VALUES (6, N'Tratamiento de Keratina', 20000, N'N', NULL, NULL)
GO
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion], [fecha_cancelacion], [motivo_cancelacion]) VALUES (7, N'Manicura y Pedicura', 23000, N'S', CAST(N'2024-09-29T13:24:57.267' AS DateTime), N'Porque si')
GO
INSERT [dbo].[T_SERVICIOS] ([id], [nombre], [costo], [enPromocion], [fecha_cancelacion], [motivo_cancelacion]) VALUES (8, N'Coloracion', 20000, N'S', NULL, NULL)
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_SERVICIOS]    Script Date: 29/9/2024 13:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_SERVICIOS]
AS
BEGIN
SELECT * from T_SERVICIOS ORDER BY 2;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONTAR_TURNOS]    Script Date: 29/9/2024 13:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONTAR_TURNOS]
 @fecha VARCHAR(10),
 @hora VARCHAR(8),
 @ctd_turnos INT OUTPUT
AS
BEGIN
 SET NOCOUNT ON;
 SELECT @ctd_turnos = COUNT(*)
 FROM T_TURNOS
 WHERE fecha = @fecha AND hora = @hora;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLES]    Script Date: 29/9/2024 13:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_DETALLES]
@id_turno int,
@id_servicio int,
@observaciones varchar(200)
AS
BEGIN
INSERT INTO T_DETALLES_TURNO(id_turno,id_servicio, observaciones)
 VALUES (@id_turno,@id_servicio, @observaciones);

END
GO
