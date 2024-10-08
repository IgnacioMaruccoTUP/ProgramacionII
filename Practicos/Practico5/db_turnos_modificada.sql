USE [db_turnos]
GO
/****** Object:  Table [dbo].[T_DETALLES_TURNO]    Script Date: 8/10/2024 10:17:18 ******/
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
/****** Object:  Table [dbo].[T_SERVICIOS]    Script Date: 8/10/2024 10:17:18 ******/
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
/****** Object:  Table [dbo].[T_TURNOS]    Script Date: 8/10/2024 10:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TURNOS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[cliente] [varchar](100) NULL,
	[fecha_baja] [datetime] NULL,
	[motivo_baja] [varchar](100) NULL,
 CONSTRAINT [PK_T_TURNOS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[T_DETALLES_TURNO] ([id_turno], [id_servicio], [observaciones]) VALUES (1, 1, N'observacion - 1')
GO
INSERT [dbo].[T_DETALLES_TURNO] ([id_turno], [id_servicio], [observaciones]) VALUES (1, 2, N'observacion - 2')
GO
INSERT [dbo].[T_DETALLES_TURNO] ([id_turno], [id_servicio], [observaciones]) VALUES (2, 1, N'una obs')
GO
INSERT [dbo].[T_DETALLES_TURNO] ([id_turno], [id_servicio], [observaciones]) VALUES (2, 2, N'otra observacion')
GO
INSERT [dbo].[T_DETALLES_TURNO] ([id_turno], [id_servicio], [observaciones]) VALUES (3, 5, N'otra observacion')
GO
INSERT [dbo].[T_DETALLES_TURNO] ([id_turno], [id_servicio], [observaciones]) VALUES (3, 6, N'una obs')
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
SET IDENTITY_INSERT [dbo].[T_TURNOS] ON 
GO
INSERT [dbo].[T_TURNOS] ([id], [fecha], [cliente], [fecha_baja], [motivo_baja]) VALUES (1, CAST(N'2023-11-07T22:45:45.913' AS DateTime), N'Messi-Lionel', NULL, NULL)
GO
INSERT [dbo].[T_TURNOS] ([id], [fecha], [cliente], [fecha_baja], [motivo_baja]) VALUES (2, CAST(N'2024-10-07T22:53:31.837' AS DateTime), N'Castolo', NULL, NULL)
GO
INSERT [dbo].[T_TURNOS] ([id], [fecha], [cliente], [fecha_baja], [motivo_baja]) VALUES (3, CAST(N'2024-11-07T22:53:31.837' AS DateTime), N'Maximo Cozzetti', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[T_TURNOS] OFF
GO
ALTER TABLE [dbo].[T_DETALLES_TURNO]  WITH CHECK ADD  CONSTRAINT [FK_T_DETALLES_TURNO_T_SERVICIOS] FOREIGN KEY([id_servicio])
REFERENCES [dbo].[T_SERVICIOS] ([id])
GO
ALTER TABLE [dbo].[T_DETALLES_TURNO] CHECK CONSTRAINT [FK_T_DETALLES_TURNO_T_SERVICIOS]
GO
ALTER TABLE [dbo].[T_DETALLES_TURNO]  WITH CHECK ADD  CONSTRAINT [FK_T_DETALLES_TURNO_T_TURNOS] FOREIGN KEY([id_turno])
REFERENCES [dbo].[T_TURNOS] ([id])
GO
ALTER TABLE [dbo].[T_DETALLES_TURNO] CHECK CONSTRAINT [FK_T_DETALLES_TURNO_T_TURNOS]
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_SERVICIOS]    Script Date: 8/10/2024 10:17:18 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_CONTAR_TURNOS]    Script Date: 8/10/2024 10:17:18 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLES]    Script Date: 8/10/2024 10:17:18 ******/
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
