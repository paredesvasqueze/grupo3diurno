USE [VentaG3]
GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizarproveedor]    Script Date: 3/10/2024 11:34:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[USP_Actualizarproveedor]
    @cidProveedor INT,
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
    WHERE nidproveedor = @cidProveedor;
	select cast(@@ROWCOUNT as int)
END;
