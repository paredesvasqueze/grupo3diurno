USE [VentaG3]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[nidcategoria] [int] IDENTITY(1,1) NOT NULL,
	[cnombrecategoria] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[nidcategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[nidcliente] [int] IDENTITY(1,1) NOT NULL,
	[cnombre] [varchar](100) NULL,
	[capellido] [varchar](100) NULL,
	[cemail] [varchar](100) NULL,
	[ctelefono] [varchar](20) NULL,
	[cdni] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[nidcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[compra]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compra](
	[nidcompra] [int] IDENTITY(1,1) NOT NULL,
	[nidproveedor] [int] NULL,
	[dfechacompra] [date] NULL,
	[ntotal] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[nidcompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detallecompra]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detallecompra](
	[niddetallecompra] [int] IDENTITY(1,1) NOT NULL,
	[nidcompra] [int] NULL,
	[nidproducto] [int] NULL,
	[ncantidad] [int] NULL,
	[npreciounitario] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[niddetallecompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalleventa]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalleventa](
	[niddetalle] [int] IDENTITY(1,1) NOT NULL,
	[nidventa] [int] NULL,
	[nidproducto] [int] NULL,
	[ncantidad] [int] NULL,
	[npreciounitario] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[niddetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[empleado]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empleado](
	[nidempleado] [int] IDENTITY(1,1) NOT NULL,
	[cnombre] [varchar](100) NULL,
	[capellido] [varchar](100) NULL,
	[cpuesto] [varchar](50) NULL,
	[nsalario] [decimal](10, 2) NULL,
	[dfechacontratacion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[nidempleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[metodopago]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[metodopago](
	[nidmetodopago] [int] IDENTITY(1,1) NOT NULL,
	[cmetodopago] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[nidmetodopago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pago]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pago](
	[nidpago] [int] IDENTITY(1,1) NOT NULL,
	[nidventa] [int] NULL,
	[dfechapago] [date] NULL,
	[nmonto] [decimal](10, 2) NULL,
	[nidmetodopago] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[nidpago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[nidproducto] [int] IDENTITY(1,1) NOT NULL,
	[cnombre] [varchar](100) NULL,
	[cdescripcion] [varchar](max) NULL,
	[npreciounitario] [decimal](10, 2) NULL,
	[nstock] [int] NULL,
	[nidcategoria] [int] NULL,
	[dfecharegistro] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[nidproducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[nidproveedor] [int] IDENTITY(1,1) NOT NULL,
	[cnombreproveedor] [varchar](100) NULL,
	[ccontacto] [varchar](100) NULL,
	[ctelefono] [varchar](20) NULL,
	[cemail] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[nidproveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usser]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usser](
	[nIdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[cUserName] [varchar](50) NULL,
	[CPassword] [varchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[venta]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venta](
	[nidventa] [int] IDENTITY(1,1) NOT NULL,
	[nidcliente] [int] NULL,
	[nidempleado] [int] NULL,
	[dfechaventa] [date] NULL,
	[ntotal] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[nidventa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[categoria] ON 

INSERT [dbo].[categoria] ([nidcategoria], [cnombrecategoria]) VALUES (2, N'Cereales')
INSERT [dbo].[categoria] ([nidcategoria], [cnombrecategoria]) VALUES (9, N'Bebidas')
INSERT [dbo].[categoria] ([nidcategoria], [cnombrecategoria]) VALUES (10, N'Lácteos')
SET IDENTITY_INSERT [dbo].[categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[cliente] ON 

INSERT [dbo].[cliente] ([nidcliente], [cnombre], [capellido], [cemail], [ctelefono], [cdni]) VALUES (2, N'Leonardo', N'lozada', N'lozadahuamanj@gmail.com', N'948759658', N'7846942')
SET IDENTITY_INSERT [dbo].[cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[compra] ON 

INSERT [dbo].[compra] ([nidcompra], [nidproveedor], [dfechacompra], [ntotal]) VALUES (3, 3, CAST(N'2024-11-21' AS Date), CAST(250.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[compra] OFF
GO
SET IDENTITY_INSERT [dbo].[detallecompra] ON 

INSERT [dbo].[detallecompra] ([niddetallecompra], [nidcompra], [nidproducto], [ncantidad], [npreciounitario]) VALUES (2, 3, 3, 10, CAST(15.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[detallecompra] OFF
GO
SET IDENTITY_INSERT [dbo].[detalleventa] ON 

INSERT [dbo].[detalleventa] ([niddetalle], [nidventa], [nidproducto], [ncantidad], [npreciounitario]) VALUES (2, 2, 3, 15, CAST(50.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[detalleventa] OFF
GO
SET IDENTITY_INSERT [dbo].[empleado] ON 

INSERT [dbo].[empleado] ([nidempleado], [cnombre], [capellido], [cpuesto], [nsalario], [dfechacontratacion]) VALUES (3, N'richard', N'terrores', N'estudiante', CAST(15.00 AS Decimal(10, 2)), CAST(N'2024-09-17' AS Date))
SET IDENTITY_INSERT [dbo].[empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[metodopago] ON 

INSERT [dbo].[metodopago] ([nidmetodopago], [cmetodopago]) VALUES (1, N'plin')
INSERT [dbo].[metodopago] ([nidmetodopago], [cmetodopago]) VALUES (1005, N'PayPal')
SET IDENTITY_INSERT [dbo].[metodopago] OFF
GO
SET IDENTITY_INSERT [dbo].[pago] ON 

INSERT [dbo].[pago] ([nidpago], [nidventa], [dfechapago], [nmonto], [nidmetodopago]) VALUES (2, 2, CAST(N'2024-11-20' AS Date), CAST(20.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[pago] ([nidpago], [nidventa], [dfechapago], [nmonto], [nidmetodopago]) VALUES (3, 2, CAST(N'2024-11-20' AS Date), CAST(15.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[pago] ([nidpago], [nidventa], [dfechapago], [nmonto], [nidmetodopago]) VALUES (4, 2, CAST(N'2024-11-20' AS Date), CAST(14.99 AS Decimal(10, 2)), 1)
INSERT [dbo].[pago] ([nidpago], [nidventa], [dfechapago], [nmonto], [nidmetodopago]) VALUES (2010, 2, CAST(N'2024-12-18' AS Date), CAST(150.00 AS Decimal(10, 2)), 1005)
SET IDENTITY_INSERT [dbo].[pago] OFF
GO
SET IDENTITY_INSERT [dbo].[producto] ON 

INSERT [dbo].[producto] ([nidproducto], [cnombre], [cdescripcion], [npreciounitario], [nstock], [nidcategoria], [dfecharegistro]) VALUES (3, N'gaseosa', N'2lt', CAST(3.99 AS Decimal(10, 2)), 50, 9, CAST(N'2024-10-17' AS Date))
SET IDENTITY_INSERT [dbo].[producto] OFF
GO
SET IDENTITY_INSERT [dbo].[proveedor] ON 

INSERT [dbo].[proveedor] ([nidproveedor], [cnombreproveedor], [ccontacto], [ctelefono], [cemail]) VALUES (3, N'Leonardo', N'Lozada', N'94975996', N'esnayder@gmail.com')
INSERT [dbo].[proveedor] ([nidproveedor], [cnombreproveedor], [ccontacto], [ctelefono], [cemail]) VALUES (11, N'marco antonio', N'lopez', N'94975996', N'marco@gmail.com')
SET IDENTITY_INSERT [dbo].[proveedor] OFF
GO
SET IDENTITY_INSERT [dbo].[Usser] ON 

INSERT [dbo].[Usser] ([nIdUsuario], [cUserName], [CPassword]) VALUES (3, N'Pedro', N'1C9B2CCB3AF0456F898A1D0B66F80721B34E0A3514BF21A44BE250EB5213492C')
INSERT [dbo].[Usser] ([nIdUsuario], [cUserName], [CPassword]) VALUES (4, N'Juan', N'834C318F53AA0954D71F8AA0FA06D7C81B7F3376353AE2E2A20282C00DF4A1E0')
INSERT [dbo].[Usser] ([nIdUsuario], [cUserName], [CPassword]) VALUES (5, N'Juan', N'834C318F53AA0954D71F8AA0FA06D7C81B7F3376353AE2E2A20282C00DF4A1E0')
INSERT [dbo].[Usser] ([nIdUsuario], [cUserName], [CPassword]) VALUES (6, N'Jhon', N'4B171B7663F82178D136B75399E0ED2E4A1519F835BE0C56E2D4E1E6BBA55161')
SET IDENTITY_INSERT [dbo].[Usser] OFF
GO
SET IDENTITY_INSERT [dbo].[venta] ON 

INSERT [dbo].[venta] ([nidventa], [nidcliente], [nidempleado], [dfechaventa], [ntotal]) VALUES (2, 2, 3, CAST(N'2024-09-20' AS Date), CAST(20.00 AS Decimal(10, 2)))
INSERT [dbo].[venta] ([nidventa], [nidcliente], [nidempleado], [dfechaventa], [ntotal]) VALUES (3, 2, 3, CAST(N'2024-09-20' AS Date), CAST(10.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[venta] OFF
GO
ALTER TABLE [dbo].[compra]  WITH CHECK ADD FOREIGN KEY([nidproveedor])
REFERENCES [dbo].[proveedor] ([nidproveedor])
GO
ALTER TABLE [dbo].[detallecompra]  WITH CHECK ADD FOREIGN KEY([nidcompra])
REFERENCES [dbo].[compra] ([nidcompra])
GO
ALTER TABLE [dbo].[detallecompra]  WITH CHECK ADD FOREIGN KEY([nidproducto])
REFERENCES [dbo].[producto] ([nidproducto])
GO
ALTER TABLE [dbo].[detalleventa]  WITH CHECK ADD FOREIGN KEY([nidproducto])
REFERENCES [dbo].[producto] ([nidproducto])
GO
ALTER TABLE [dbo].[detalleventa]  WITH CHECK ADD FOREIGN KEY([nidventa])
REFERENCES [dbo].[venta] ([nidventa])
GO
ALTER TABLE [dbo].[pago]  WITH CHECK ADD FOREIGN KEY([nidmetodopago])
REFERENCES [dbo].[metodopago] ([nidmetodopago])
GO
ALTER TABLE [dbo].[pago]  WITH CHECK ADD FOREIGN KEY([nidventa])
REFERENCES [dbo].[venta] ([nidventa])
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD FOREIGN KEY([nidcategoria])
REFERENCES [dbo].[categoria] ([nidcategoria])
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD FOREIGN KEY([nidcliente])
REFERENCES [dbo].[cliente] ([nidcliente])
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD FOREIGN KEY([nidempleado])
REFERENCES [dbo].[empleado] ([nidempleado])
GO
/****** Object:  StoredProcedure [dbo].[ActualizarCompra]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarCompra]
    @nidcompra INT,
    @nidproveedor INT,
    @dfechacompra DATE,
    @ntotal DECIMAL(10, 2)
AS
BEGIN
    UPDATE compra
    SET nidproveedor = @nidproveedor,
        dfechacompra = @dfechacompra,
        ntotal = @ntotal
    WHERE nidcompra = @nidcompra;
	select cast(@@ROWCOUNT as int)
END;

GO
/****** Object:  StoredProcedure [dbo].[ActualizarMetodopago]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActualizarMetodopago]
    @nidmetodopago INT,
    @cmetodopago VARCHAR(50)
AS
BEGIN
    UPDATE metodopago
    SET cmetodopago = @cmetodopago
    WHERE nidmetodopago = @nidmetodopago
	select cast(@@ROWCOUNT as int)
END;

GO
/****** Object:  StoredProcedure [dbo].[EliminarMetodopago]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarMetodopago]
    @nidmetodopago INT
AS
BEGIN
    DELETE FROM metodopago
    WHERE nidmetodopago = @nidmetodopago
	select cast(@@ROWCOUNT as int)
END;

GO
/****** Object:  StoredProcedure [dbo].[GetPagoById]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetPagoById]
@nidpago INT
AS
BEGIN
SELECT * FROM Pago WHERE @nidpago = nidpago
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductoById]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetProductoById]
@nIdProducto INT
AS 
BEGIN
SELECT * FROM producto WHERE @nIdProducto = nidproducto
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarCompra]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarCompra]
    @nidproveedor INT,
    @dfechacompra DATE,
    @ntotal DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO compra (nidproveedor, dfechacompra, ntotal)
    VALUES (@nidproveedor, @dfechacompra, @ntotal);
    SELECT CAST(SCOPE_IDENTITY() AS INT);
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarMetodopago]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertarMetodopago]
    @cmetodopago VARCHAR(50)
AS
BEGIN
    INSERT INTO metodopago (cmetodopago)
    VALUES (@cmetodopago)
	select cast(SCOPE_IDENTITY() as int)
END;

GO
/****** Object:  StoredProcedure [dbo].[ObtenerCompraTodos]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[ObtenerCompraTodos]
 AS
 BEGIN
 SELECT p.*,cnombreproveedor AS cnombreproveedor FROM compra p
 INNER JOIN proveedor c on p.nidproveedor = c.nidproveedor
 end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerMetodopagoTodos]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[ObtenerMetodopagoTodos]
AS
BEGIN
    SELECT * FROM metodopago AS metodo
END

GO
/****** Object:  StoredProcedure [dbo].[USE_GET_proveedor_Todos]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USE_GET_proveedor_Todos]
AS
BEGIN
    SELECT * FROM proveedor
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizar_Categoria]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Actualizar_Categoria]
    @nidcategoria INT,
    @cnombrecategoria VARCHAR(100)
AS
BEGIN
    UPDATE categoria
    SET cnombrecategoria = @cnombrecategoria
    WHERE nidcategoria = @nidcategoria;
	select cast(@@ROWCOUNT as int)
END;

GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizar_cliente]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Actualizar_cliente]
@nidcliente INT,
@cnombre VARCHAR(100),
@capellido VARCHAR(100),
@cemail VARCHAR(100),
@ctelefono VARCHAR(20),
@cdni VARCHAR(20)
AS
BEGIN
    UPDATE cliente
    SET cnombre = @cnombre,
        capellido = @capellido,
        cemail = @cemail,
        ctelefono = @ctelefono,
        cdni = @cdni
    WHERE nidcliente = @nidcliente;

	select cast(@@ROWCOUNT as int)
END;

GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizar_detallecompra]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Actualizar_detallecompra]
    @niddetallecompra INT,
    @nidcompra INT,
    @nidproducto INT,
    @ncantidad INT,
    @npreciounitario DECIMAL(10, 2)
AS
BEGIN
    UPDATE detallecompra
    SET nidcompra = @nidcompra,
        nidproducto = @nidproducto,
        ncantidad = @ncantidad,
        npreciounitario = @npreciounitario
    WHERE niddetallecompra = @niddetallecompra;
		select cast(@@ROWCOUNT as int)
END;

GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizar_DetalleVenta]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Actualizar_DetalleVenta]
    @niddetalle INT,
    @nidventa INT,
    @nidproducto INT,
    @ncantidad INT,
    @npreciounitario DECIMAL(10, 2)
AS
BEGIN
    UPDATE detalleventa
    SET nidventa = @nidventa,
        nidproducto = @nidproducto,
        ncantidad = @ncantidad,
        npreciounitario = @npreciounitario
    WHERE niddetalle = @niddetalle;

	select cast(@@ROWCOUNT as int)
END;

GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizar_Empleado]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Actualizar_Empleado]
    @nidempleado INT,
    @cnombre VARCHAR(100),
    @capellido VARCHAR(100),
    @cpuesto VARCHAR(50),
    @nsalario DECIMAL(10, 2),
    @dfechacontratacion DATE
AS
BEGIN
    UPDATE empleado
    SET cnombre = @cnombre,
        capellido = @capellido,
        cpuesto = @cpuesto,
        nsalario = @nsalario,
        dfechacontratacion = @dfechacontratacion
    WHERE nidempleado = @nidempleado;
		select cast(@@ROWCOUNT as int)
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizar_Pago]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Actualizar_Pago]
    @nidpago INT,
    @nidventa INT,
    @dfechapago DATE,
    @nmonto DECIMAL(10, 2),
    @nidmetodopago INT
AS
BEGIN
    UPDATE Pago
    SET nidventa = @nidventa,
        dfechapago = @dfechapago,
        nmonto = @nmonto,
        nidmetodopago = @nidmetodopago
    WHERE nidpago = @nidpago;
		select cast(@@ROWCOUNT as int)
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizar_producto]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento para actualizar un producto
CREATE PROCEDURE [dbo].[USP_Actualizar_producto]
    @nidproducto INT,
    @cnombre VARCHAR(100),
    @cdescripcion VARCHAR(MAX),
    @npreciounitario DECIMAL(10, 2),
    @nstock INT,
    @nidcategoria INT,
	@dfecharegistro DATETIME
AS
BEGIN
    UPDATE producto
    SET cnombre = @cnombre,
        cdescripcion = @cdescripcion,
        npreciounitario = @npreciounitario,
        nstock = @nstock,
        nidcategoria = @nidcategoria,
		dfecharegistro = @dfecharegistro
    WHERE nidproducto = @nidproducto;
		select cast(@@ROWCOUNT as int)
END;

GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizarproveedor]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Actualizarproveedor]
    @nidProveedor INT,
    @cnombreProveedor VARCHAR(100),
    @ccontacto VARCHAR(100),
    @ctelefono VARCHAR(20),
    @cemail VARCHAR(100)
AS
BEGIN
    UPDATE proveedor
    SET cnombreproveedor = @cnombreProveedor,
        ccontacto = @ccontacto,
        ctelefono = @ctelefono,
        cemail = @cemail
    WHERE nidproveedor = @nidProveedor;
	select cast(@@ROWCOUNT as int)
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_ActualizarVenta]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_ActualizarVenta]
    @nidventa INT,
    @nidcliente INT,
    @nidempleado INT,
    @dfechaventa DATE,
    @ntotal DECIMAL(10, 2)
AS
BEGIN
    UPDATE venta
    SET nidcliente = @nidcliente,
        nidempleado = @nidempleado,
        dfechaventa = @dfechaventa,
        ntotal = @ntotal
    WHERE nidventa = @nidventa;
	select cast(@@ROWCOUNT as int)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_categoria]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Eliminar_categoria]
    @nidcategoria INT
AS
BEGIN
    DELETE FROM categoria
    WHERE nidcategoria = @nidcategoria;

	select cast(@@ROWCOUNT as int)
END;

GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_cliente]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Eliminar_cliente]
    @nidcliente INT
AS
BEGIN
    DELETE FROM cliente
    WHERE nidcliente = @nidcliente;
		select cast(@@ROWCOUNT as int)
END;

GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_Compra]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---
CREATE PROCEDURE [dbo].[USP_Eliminar_Compra]
    @nidcompra INT
AS
BEGIN
    DELETE FROM compra WHERE nidcompra = @nidcompra;
	select cast(@@ROWCOUNT as int)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_detallecompra]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Eliminar_detallecompra]
    @niddetallecompra INT
AS
BEGIN
    DELETE FROM detallecompra
    WHERE niddetallecompra = @niddetallecompra;
		select cast(@@ROWCOUNT as int)
END;

GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_DetalleVenta]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Eliminar_DetalleVenta]
    @niddetalle INT
AS
BEGIN
    DELETE FROM detalleventa
    WHERE niddetalle = @niddetalle;

	select cast(@@ROWCOUNT as int)
END;

GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_Empleado]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Eliminar_Empleado]
    @nidempleado INT
AS
BEGIN
    DELETE FROM empleado
    WHERE nidempleado = @nidempleado;
		select cast(@@ROWCOUNT as int)
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_producto]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento para eliminar un producto
CREATE PROCEDURE [dbo].[USP_Eliminar_producto]
    @nidproducto INT
AS
BEGIN
    DELETE FROM producto
    WHERE nidproducto = @nidproducto;
		select cast(@@ROWCOUNT as int)
END;

GO
/****** Object:  StoredProcedure [dbo].[USP_EliminarPago]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_EliminarPago]
    @nidpago INT
AS
BEGIN
    DELETE FROM Pago
    WHERE nidpago = @nidpago;
	select cast(@@ROWCOUNT as int)
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminarproveedor]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Eliminarproveedor]
    @nidProveedor INT
AS
BEGIN
    DELETE FROM proveedor
    WHERE nidproveedor = @nidProveedor;
		select cast(@@ROWCOUNT as int)
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_EliminarVenta]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_EliminarVenta]
    @nidVenta INT
AS
BEGIN
    DELETE FROM venta
    WHERE nidVenta = @nidVenta;
		select cast(@@ROWCOUNT as int)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_cliente_Todos]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GET_cliente_Todos]
as
begin
select * from cliente
end

GO
/****** Object:  StoredProcedure [dbo].[USP_GET_detallecompra_Todos]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GET_detallecompra_Todos]
AS
BEGIN
    SELECT p.*, CONCAT (dfechacompra, ' ' ,cnombreproveedor) AS cdetallecompra, r.cnombre as cnombreproducto
	FROM detallecompra p
	INNER JOIN compra v on p.nidcompra = v.nidcompra
	INNER JOIN proveedor c on c.nidproveedor = v.nidproveedor
	INNER JOIN producto r on r.nidproducto = p.nidproducto
END

GO
/****** Object:  StoredProcedure [dbo].[USP_GET_Empleado_Todos]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GET_Empleado_Todos]
AS
BEGIN
    SELECT * FROM empleado;
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_Pago_Todos]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GET_Pago_Todos]
AS
BEGIN
    SELECT p.*, CONCAT (dfechaventa, ' ' ,cnombre, capellido) AS cventa, m.cmetodopago FROM pago p
	INNER JOIN venta v on p.nidventa = v.nidventa
	INNER JOIN cliente c on c.nidcliente = v.nidcliente
	INNER JOIN metodopago m on p.nidmetodopago = m.nidmetodopago
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_producto_Todos]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GET_producto_Todos]
AS
BEGIN
    SELECT p.*, cnombrecategoria AS categoria from producto p
	INNER JOIN categoria c on p.nidcategoria = c.nidcategoria
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_venta_todos]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GET_venta_todos]
AS
BEGIN
    SELECT v.*, e.cnombre AS cnombrecliente, c.cnombre AS empleado FROM venta v
    INNER JOIN empleado c ON v.nidempleado = c.nidempleado
    INNER JOIN cliente e ON v.nidcliente = e.nidcliente
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_Insert_categoria]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_Insert_categoria]
    @cnombrecategoria VARCHAR(100)
AS
BEGIN
    INSERT INTO categoria (cnombrecategoria)
    VALUES (@cnombrecategoria)
	select cast(SCOPE_IDENTITY() as int)
END;

GO
/****** Object:  StoredProcedure [dbo].[USP_Insert_cliente]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_Insert_cliente]
@cnombre VARCHAR(100),
@capellido VARCHAR(100),
@cemail VARCHAR(100),
@ctelefono VARCHAR(20),
@cdni VARCHAR(20)
AS
BEGIN
INSERT INTO cliente 
([cnombre], [capellido], [cemail], [ctelefono], [cdni])
VALUES 
(@cnombre, @capellido, @cemail, @ctelefono, @cdni)

select cast(SCOPE_IDENTITY() as int)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Insert_detallecompra]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Insert_detallecompra]
    @nidcompra INT,
    @nidproducto INT,
    @ncantidad INT,
    @npreciounitario DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO detallecompra (nidcompra, nidproducto, ncantidad, npreciounitario)
    VALUES (@nidcompra, @nidproducto, @ncantidad, @npreciounitario);
	select cast(SCOPE_IDENTITY() as int)
END;

GO
/****** Object:  StoredProcedure [dbo].[USP_Insert_DetalleVenta]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_Insert_DetalleVenta]
    @nidventa INT,
    @nidproducto INT,
    @ncantidad INT,
    @npreciounitario DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO detalleventa (nidventa,nidproducto, ncantidad, npreciounitario)
    VALUES (@nidventa,@nidproducto, @ncantidad, @npreciounitario);

	select cast(SCOPE_IDENTITY() as int)
END;

GO
/****** Object:  StoredProcedure [dbo].[USP_Insert_Empleado]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Insert_Empleado]
    @cnombre VARCHAR(100),
    @capellido VARCHAR(100),
    @cpuesto VARCHAR(50),
    @nsalario DECIMAL(10, 2),
    @dfechacontratacion DATE
AS
BEGIN
    INSERT INTO empleado (cnombre, capellido, cpuesto, nsalario, dfechacontratacion)
    VALUES (@cnombre, @capellido, @cpuesto, @nsalario, @dfechacontratacion);
		select cast(SCOPE_IDENTITY() as int)
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_Pago]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_INSERT_Pago]
    @nidventa INT,
    @dfechapago DATETIME,
    @nmonto DECIMAL(10, 2),
    @nidmetodopago INT
AS
BEGIN
    INSERT INTO pago (nidventa, dfechapago, nmonto, nidmetodopago)
    VALUES (@nidventa, @dfechapago, @nmonto, @nidmetodopago);
    
	select cast(SCOPE_IDENTITY() as int)
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_Insert_producto]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento para insertar un producto
CREATE PROCEDURE [dbo].[USP_Insert_producto]
    @cnombre VARCHAR(100),
    @cdescripcion VARCHAR(MAX),
    @npreciounitario DECIMAL(10, 2),
    @nstock INT,
    @nidcategoria INT,
    @dfecharegistro DATE
AS
BEGIN
    INSERT INTO producto 
    (cnombre, cdescripcion, npreciounitario, nstock, nidcategoria, dfecharegistro)
    VALUES 
    (@cnombre, @cdescripcion, @npreciounitario, @nstock, @nidcategoria, @dfecharegistro);
		select cast(SCOPE_IDENTITY() as int)
END;

GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_proveedor]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_INSERT_proveedor]
    @cnombreProveedor VARCHAR(100),
    @ccontacto VARCHAR(100),
    @ctelefono VARCHAR(20),
    @cemail VARCHAR(100)
AS
BEGIN
    INSERT INTO proveedor (cnombreproveedor, ccontacto, ctelefono, cemail)
    VALUES (@cnombreProveedor, @ccontacto, @ctelefono, @cemail);
	select cast(SCOPE_IDENTITY() as int)
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_Venta]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_INSERT_Venta]
    @nidcliente INT,
    @nidempleado INT,
    @dfechaventa DATE,
    @ntotal DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO venta (nidcliente, nidempleado, dfechaventa, ntotal)
    VALUES (@nidcliente, @nidempleado, @dfechaventa, @ntotal);
	select cast(SCOPE_IDENTITY() as int)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Seleccionar_categoria]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Seleccionar_categoria]
AS
BEGIN
    SELECT * FROM categoria
END;

GO
/****** Object:  StoredProcedure [dbo].[USP_Seleccionar_DetalleVenta]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Seleccionar_DetalleVenta]
AS
BEGIN
    SELECT dv.*, CONCAT(v.dfechaventa, ' ', c.cnombre, ' ', c.capellido) AS cdetalle, p.cnombre
    FROM detalleventa dv
    INNER JOIN venta v ON dv.nidventa = v.nidventa
    INNER JOIN cliente c ON v.nidcliente = c.nidcliente
    INNER JOIN producto p ON dv.nidproducto = p.nidproducto;
END;
GO
/****** Object:  StoredProcedure [dbo].[ValidarUsuario]    Script Date: 19/12/2024 08:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ValidarUsuario]
@cUserName VARCHAR(50),
@CPassword VARCHAR(256)
AS
BEGIN
IF exists(SELECT * FROM Usser WHERE cUserName=@cUserName 
and CPassword = @CPassword
)
	BEGIN
	SELECT cast(1 as bit)
	END
ELSE
	BEGIN
	SELECT cast(0 as bit)
	END
END
GO
