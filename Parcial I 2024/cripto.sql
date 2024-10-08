USE [db_criptomonedas]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 04-10-2024 19:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Criptomonedas]    Script Date: 04-10-2024 19:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Criptomonedas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[simbolo] [varchar](10) NOT NULL,
	[valor_actual] [float] NOT NULL,
	[ultima_actualizacion] [datetime] NOT NULL,
	[categoria] [int] NOT NULL,
	[estado] [varchar](2) NOT NULL,
 CONSTRAINT [PK_Criptomonedas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([id], [nombre]) VALUES (1, N'Plataforma')
INSERT [dbo].[Categorias] ([id], [nombre]) VALUES (2, N'Moneda')
INSERT [dbo].[Categorias] ([id], [nombre]) VALUES (3, N'Token')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
SET IDENTITY_INSERT [dbo].[Criptomonedas] ON 

INSERT [dbo].[Criptomonedas] ([id], [nombre], [simbolo], [valor_actual], [ultima_actualizacion], [categoria], [estado]) VALUES (3, N'BITCOIN', N'BTC', 43600, CAST(N'2024-04-10T00:00:00.000' AS DateTime), 1, N'H')
SET IDENTITY_INSERT [dbo].[Criptomonedas] OFF
GO
ALTER TABLE [dbo].[Criptomonedas]  WITH CHECK ADD  CONSTRAINT [FK_Criptomonedas_Categorias] FOREIGN KEY([categoria])
REFERENCES [dbo].[Categorias] ([id])
GO
ALTER TABLE [dbo].[Criptomonedas] CHECK CONSTRAINT [FK_Criptomonedas_Categorias]
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_VALOR]    Script Date: 04-10-2024 19:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ACTUALIZAR_VALOR]
	@simbolo varchar(10),
	@valor float
AS
BEGIN
	
	UPDATE Criptomonedas SET valor_actual = @valor, ultima_actualizacion = GETDATE()
	WHERE simbolo = @simbolo; 
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_CRIPTOS]    Script Date: 04-10-2024 19:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_CRIPTOS] 
	@categoria int
AS
BEGIN
	SELECT T.*, T1.nombre 
	FROM Criptomonedas T, Categorias T1
	where T.categoria = T1.id
	AND T.categoria = @categoria;

END
GO
/****** Object:  StoredProcedure [dbo].[SP_INHABILITAR_CRIPTO]    Script Date: 04-10-2024 19:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INHABILITAR_CRIPTO]
	@id int
AS
BEGIN
	
	UPDATE Criptomonedas SET estado = 'NH'
	WHERE id = @id AND estado = 'H'; 
END
GO
