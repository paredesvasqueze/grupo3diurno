USE [VentaG3]
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_proveedor]    Script Date: 3/10/2024 11:33:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[USP_INSERT_proveedor]
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
