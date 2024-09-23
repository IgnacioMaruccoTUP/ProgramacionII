USE [FacturacionII]
GO
/****** Object:  Table [dbo].[T_Articulos]    Script Date: 23/9/2024 20:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Articulos](
	[id_articulo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[precio_unitario] [decimal](10, 2) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_T_Articulos] PRIMARY KEY CLUSTERED 
(
	[id_articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Detalles_Facturas]    Script Date: 23/9/2024 20:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Detalles_Facturas](
	[id_detalle] [int] NOT NULL,
	[id_factura] [int] NOT NULL,
	[id_articulo] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_T_Detalles_Facturas] PRIMARY KEY CLUSTERED 
(
	[id_detalle] ASC,
	[id_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Facturas]    Script Date: 23/9/2024 20:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Facturas](
	[id_factura] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[id_forma_pago] [int] NOT NULL,
	[cliente] [varchar](50) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_T_Facturas] PRIMARY KEY CLUSTERED 
(
	[id_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Formas_Pago]    Script Date: 23/9/2024 20:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Formas_Pago](
	[id_forma_pago] [int] IDENTITY(1,1) NOT NULL,
	[forma_pago] [varchar](50) NOT NULL,
 CONSTRAINT [PK_T_Formas_Pago] PRIMARY KEY CLUSTERED 
(
	[id_forma_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[T_Articulos] ON 
GO
INSERT [dbo].[T_Articulos] ([id_articulo], [nombre], [precio_unitario], [activo]) VALUES (1, N'Laptop', CAST(18700.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[T_Articulos] ([id_articulo], [nombre], [precio_unitario], [activo]) VALUES (2, N'Teclado Mecánico', CAST(100.50 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[T_Articulos] ([id_articulo], [nombre], [precio_unitario], [activo]) VALUES (3, N'Monitor 24"', CAST(250.99 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[T_Articulos] ([id_articulo], [nombre], [precio_unitario], [activo]) VALUES (4, N'Mouse Inalámbrico', CAST(45.75 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[T_Articulos] ([id_articulo], [nombre], [precio_unitario], [activo]) VALUES (5, N'Auriculares Bluetooth', CAST(89.99 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[T_Articulos] ([id_articulo], [nombre], [precio_unitario], [activo]) VALUES (6, N'Lampara LED', CAST(500.00 AS Decimal(10, 2)), 0)
GO
INSERT [dbo].[T_Articulos] ([id_articulo], [nombre], [precio_unitario], [activo]) VALUES (7, N'Fuente 850', CAST(5500.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[T_Articulos] ([id_articulo], [nombre], [precio_unitario], [activo]) VALUES (14, N'Manaos 500ml', CAST(3434.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[T_Articulos] ([id_articulo], [nombre], [precio_unitario], [activo]) VALUES (17, N'Pepitos', CAST(34.00 AS Decimal(10, 2)), 1)
GO
INSERT [dbo].[T_Articulos] ([id_articulo], [nombre], [precio_unitario], [activo]) VALUES (18, N'Pepitos', CAST(34.00 AS Decimal(10, 2)), 0)
GO
SET IDENTITY_INSERT [dbo].[T_Articulos] OFF
GO
INSERT [dbo].[T_Detalles_Facturas] ([id_detalle], [id_factura], [id_articulo], [cantidad]) VALUES (1, 1, 3, 7)
GO
INSERT [dbo].[T_Detalles_Facturas] ([id_detalle], [id_factura], [id_articulo], [cantidad]) VALUES (1, 2, 2, 10)
GO
INSERT [dbo].[T_Detalles_Facturas] ([id_detalle], [id_factura], [id_articulo], [cantidad]) VALUES (1, 3, 2, 1)
GO
INSERT [dbo].[T_Detalles_Facturas] ([id_detalle], [id_factura], [id_articulo], [cantidad]) VALUES (1, 4, 2, 2)
GO
INSERT [dbo].[T_Detalles_Facturas] ([id_detalle], [id_factura], [id_articulo], [cantidad]) VALUES (2, 1, 4, 14)
GO
INSERT [dbo].[T_Detalles_Facturas] ([id_detalle], [id_factura], [id_articulo], [cantidad]) VALUES (2, 2, 3, 20)
GO
INSERT [dbo].[T_Detalles_Facturas] ([id_detalle], [id_factura], [id_articulo], [cantidad]) VALUES (2, 3, 3, 2)
GO
INSERT [dbo].[T_Detalles_Facturas] ([id_detalle], [id_factura], [id_articulo], [cantidad]) VALUES (2, 4, 3, 3)
GO
INSERT [dbo].[T_Detalles_Facturas] ([id_detalle], [id_factura], [id_articulo], [cantidad]) VALUES (3, 4, 4, 4)
GO
SET IDENTITY_INSERT [dbo].[T_Facturas] ON 
GO
INSERT [dbo].[T_Facturas] ([id_factura], [fecha], [id_forma_pago], [cliente], [activo]) VALUES (1, CAST(N'2024-09-20T10:30:26.000' AS DateTime), 2, N'Messi', 1)
GO
INSERT [dbo].[T_Facturas] ([id_factura], [fecha], [id_forma_pago], [cliente], [activo]) VALUES (2, CAST(N'2024-09-20T10:32:57.567' AS DateTime), 2, N'Julian', 1)
GO
INSERT [dbo].[T_Facturas] ([id_factura], [fecha], [id_forma_pago], [cliente], [activo]) VALUES (3, CAST(N'2024-09-20T13:38:00.550' AS DateTime), 3, N'Spiderman', 1)
GO
INSERT [dbo].[T_Facturas] ([id_factura], [fecha], [id_forma_pago], [cliente], [activo]) VALUES (4, CAST(N'2024-09-22T19:39:12.000' AS DateTime), 2, N'Nicolasss', 1)
GO
SET IDENTITY_INSERT [dbo].[T_Facturas] OFF
GO
SET IDENTITY_INSERT [dbo].[T_Formas_Pago] ON 
GO
INSERT [dbo].[T_Formas_Pago] ([id_forma_pago], [forma_pago]) VALUES (1, N'Efectivo')
GO
INSERT [dbo].[T_Formas_Pago] ([id_forma_pago], [forma_pago]) VALUES (2, N'Tarjeta de Crédito')
GO
INSERT [dbo].[T_Formas_Pago] ([id_forma_pago], [forma_pago]) VALUES (3, N'Transferencia Bancaria')
GO
SET IDENTITY_INSERT [dbo].[T_Formas_Pago] OFF
GO
ALTER TABLE [dbo].[T_Detalles_Facturas]  WITH CHECK ADD  CONSTRAINT [FK_T_Detalles_Facturas_T_Articulos] FOREIGN KEY([id_articulo])
REFERENCES [dbo].[T_Articulos] ([id_articulo])
GO
ALTER TABLE [dbo].[T_Detalles_Facturas] CHECK CONSTRAINT [FK_T_Detalles_Facturas_T_Articulos]
GO
ALTER TABLE [dbo].[T_Detalles_Facturas]  WITH CHECK ADD  CONSTRAINT [FK_T_Detalles_Facturas_T_Facturas] FOREIGN KEY([id_factura])
REFERENCES [dbo].[T_Facturas] ([id_factura])
GO
ALTER TABLE [dbo].[T_Detalles_Facturas] CHECK CONSTRAINT [FK_T_Detalles_Facturas_T_Facturas]
GO
ALTER TABLE [dbo].[T_Facturas]  WITH CHECK ADD  CONSTRAINT [FK_T_Facturas_T_Formas_Pago] FOREIGN KEY([id_forma_pago])
REFERENCES [dbo].[T_Formas_Pago] ([id_forma_pago])
GO
ALTER TABLE [dbo].[T_Facturas] CHECK CONSTRAINT [FK_T_Facturas_T_Formas_Pago]
GO
/****** Object:  StoredProcedure [dbo].[SP_BAJA_ARTICULO]    Script Date: 23/9/2024 20:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BAJA_ARTICULO]
	@id_articulo INT
AS
BEGIN
	UPDATE T_Articulos
	SET activo = 0
	WHERE id_articulo = @id_articulo
END
GO
/****** Object:  StoredProcedure [dbo].[SP_EDITAR_ARTICULO]    Script Date: 23/9/2024 20:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EDITAR_ARTICULO]
	@id_articulo INT,
	@nombre VARCHAR(50),
	@precio_unitario DECIMAL(10,2),
	@activo BIT
AS
BEGIN
	UPDATE T_Articulos
	SET nombre = @nombre, precio_unitario = @precio_unitario, activo = @activo
	WHERE id_articulo = @id_articulo
END
GO
/****** Object:  StoredProcedure [dbo].[SP_EDITAR_FACTURA]    Script Date: 23/9/2024 20:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EDITAR_FACTURA]
	@id_factura INT,
	@fecha DATETIME,
	@cliente VARCHAR(50),
	@id_forma_pago INT,
	@activo BIT
as
begin
	update T_Facturas
	set cliente = @cliente, fecha = @fecha, id_forma_pago = @id_forma_pago, activo = @activo
	where id_factura = @id_factura

	delete from T_Detalles_Facturas
	where id_factura = @id_factura
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_DETALLES]    Script Date: 23/9/2024 20:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ELIMINAR_DETALLES]
	@id_factura INT
AS
BEGIN
	DELETE	T_Detalles_Facturas WHERE id_factura = @id_factura
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_FACTURA]    Script Date: 23/9/2024 20:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ELIMINAR_FACTURA]
	@id_factura INT
AS
BEGIN
	DELETE T_Detalles_Facturas WHERE id_factura = @id_factura
	DELETE T_Facturas WHERE id_factura = @id_factura
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_ARTICULO]    Script Date: 23/9/2024 20:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_ARTICULO]
	@nombre VARCHAR(50),
	@precio_unitario DECIMAL(10,2),
	@activo BIT
AS
BEGIN
	INSERT INTO T_Articulos(nombre, precio_unitario, activo) VALUES (@nombre, @precio_unitario, @activo)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLE]    Script Date: 23/9/2024 20:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--DETALLE
CREATE PROCEDURE [dbo].[SP_INSERTAR_DETALLE]
	@id_detalle INT,
	@id_factura INT,
	@id_articulo INT,
	@cantidad INT
AS
BEGIN
	INSERT INTO T_Detalles_Facturas(id_detalle, id_factura, id_articulo, cantidad) 
	VALUES (@id_detalle, @id_factura, @id_articulo, @cantidad);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_FACTURA]    Script Date: 23/9/2024 20:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_FACTURA]
	@cliente VARCHAR(50),
	@id_forma_pago INT,
	@activo BIT,
	@id_factura INT OUTPUT
AS
BEGIN
	INSERT INTO T_Facturas(cliente, fecha, id_forma_pago, activo) VALUES (@cliente, GETDATE(), @id_forma_pago, @activo);
	SET @id_factura = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_ARTICULO_POR_CODIGO]    Script Date: 23/9/2024 20:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RECUPERAR_ARTICULO_POR_CODIGO]
	@id_articulo INT
AS
BEGIN
	SELECT id_articulo, nombre, precio_unitario, activo
	FROM T_Articulos
	WHERE id_articulo = @id_articulo
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_ARTICULOS]    Script Date: 23/9/2024 20:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RECUPERAR_ARTICULOS]
AS
BEGIN
	SELECT id_articulo, nombre, precio_unitario, activo FROM T_Articulos
	WHERE activo = 'true'
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_FACTURA_POR_CODIGO]    Script Date: 23/9/2024 20:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RECUPERAR_FACTURA_POR_CODIGO]
	@id_factura INT
AS
BEGIN
	SELECT *
	FROM T_Facturas F 
	JOIN T_Formas_Pago FP ON F.id_forma_pago = FP.id_forma_pago
	JOIN T_Detalles_Facturas DF ON DF.id_factura = F.id_factura
	JOIN T_Articulos A ON A.id_articulo = DF.id_articulo
	WHERE F.id_factura = @id_factura
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_FACTURAS]    Script Date: 23/9/2024 20:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RECUPERAR_FACTURAS]
AS
BEGIN
	SELECT *
	FROM T_Facturas F 
	JOIN T_Formas_Pago FP ON F.id_forma_pago = FP.id_forma_pago
	JOIN T_Detalles_Facturas DF ON DF.id_factura = F.id_factura
	JOIN T_Articulos A ON A.id_articulo = DF.id_articulo
	WHERE F.activo IS NOT NULL
	ORDER BY F.id_factura
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_FACTURAS_COMPLETA]    Script Date: 23/9/2024 20:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RECUPERAR_FACTURAS_COMPLETA]
AS
BEGIN
	SELECT F.id_factura, F.fecha, F.cliente, FP.forma_pago, DF.id_detalle, DF.cantidad, A.nombre, A.precio_unitario
	FROM T_Facturas F 
	JOIN T_Formas_Pago FP ON F.id_forma_pago = FP.id_forma_pago
	JOIN T_Detalles_Facturas DF ON DF.id_factura = F.id_factura
	JOIN T_Articulos A ON A.id_articulo = DF.id_articulo
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_FACTURAS_FILTRADAS]    Script Date: 23/9/2024 20:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RECUPERAR_FACTURAS_FILTRADAS]
    @fecha DATETIME = null,
    @id_forma_pago INT = null
AS
BEGIN
    SELECT *
    FROM T_Facturas F 
    JOIN T_Formas_Pago FP ON F.id_forma_pago = FP.id_forma_pago
    JOIN T_Detalles_Facturas DF ON DF.id_factura = F.id_factura
    JOIN T_Articulos A ON A.id_articulo = DF.id_articulo
    WHERE F.activo IS NOT NULL
    AND (@fecha IS NULL OR CAST(F.fecha AS DATE) = CAST(@fecha AS DATE))
    AND (@id_forma_pago IS NULL OR F.id_forma_pago = @id_forma_pago)
    ORDER BY F.id_factura
END

GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_FORMAS_PAGO]    Script Date: 23/9/2024 20:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RECUPERAR_FORMAS_PAGO]
AS
BEGIN
	SELECT id_forma_pago, forma_pago FROM T_Formas_Pago
END
GO
