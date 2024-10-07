CREATE PROCEDURE USE_GET_proveedor_Todos
    @nombreProveedor VARCHAR(100),
    @contacto VARCHAR(100),
    @telefono VARCHAR(20),
    @email VARCHAR(100)
AS
BEGIN
    SELECT * FROM proveedor
END;
GO

