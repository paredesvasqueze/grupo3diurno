ALTER PROCEDURE USP_Actualizarproveedor
    @cnombreProveedor VARCHAR(100),
    @ccontacto VARCHAR(100),
    @ctelefono VARCHAR(20),
    @cemail VARCHAR(100)
AS
BEGIN
    INSERT INTO proveedor (cnombreproveedor, ccontacto, ctelefono, cemail)
    VALUES (@cnombreProveedor, @ccontacto, @ctelefono, @cemail);
	select cast(@@ROWCOUNT as int)
END;
GO
