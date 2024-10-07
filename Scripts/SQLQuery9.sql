USE [VentaG3]
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminarproveedor]    Script Date: 3/10/2024 11:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[USP_Eliminarproveedor]
    @nidProveedor INT
AS
BEGIN
    DELETE FROM proveedor
    WHERE nidproveedor = @nidProveedor;
END;
