USE [VentaG3]
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_proveedor_Todos]    Script Date: 3/10/2024 11:41:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[USE_GET_proveedor_Todos]
AS
BEGIN
    SELECT * FROM proveedor
END;
