CREATE PROCEDURE USP_Seleccionar_categoria
AS
BEGIN
    SELECT * FROM categoria
END;
GO


CREATE PROCEDURE USP_Insert_categoria
    @cnombrecategoria VARCHAR(100)
AS
BEGIN
    INSERT INTO categoria (cnombrecategoria)
    VALUES (@cnombrecategoria)
END;
GO


CREATE PROCEDURE USP_Actualizar_Categoria
    @nidcategoria INT,
    @cnombrecategoria VARCHAR(100)
AS
BEGIN
    UPDATE categoria
    SET cnombrecategoria = @cnombrecategoria
    WHERE nidcategoria = @nidcategoria;
END;
GO



CREATE PROCEDURE USP_Eliminar_categoria
    @nidcategoria INT
AS
BEGIN
    DELETE FROM categoria
    WHERE nidcategoria = @nidcategoria;
END;
GO




alter PROCEDURE USP_Insert_categoria
    @cnombrecategoria VARCHAR(100)
AS
BEGIN
    INSERT INTO categoria (cnombrecategoria)
    VALUES (@cnombrecategoria)


	select cast(SCOPE_IDENTITY() as int)
END;
GO

alter PROCEDURE USP_Actualizar_Categoria
    @nidcategoria INT,
    @cnombrecategoria VARCHAR(100)
AS
BEGIN
    UPDATE categoria
    SET cnombrecategoria = @cnombrecategoria
    WHERE nidcategoria = @nidcategoria

	select cast(@@ROWCOUNT as int)
END;
GO

alter PROCEDURE USP_Eliminar_categoria
    @nidcategoria INT
AS
BEGIN
    DELETE FROM categoria
    WHERE nidcategoria = @nidcategoria

	select cast(@@ROWCOUNT as int)
END;
GO




alter PROCEDURE USP_Insert_DetalleVenta
    @nidventa INT,
    @nidproducto INT,
    @ncantidad INT,
    @npreciounitario DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO detalleventa (nidventa, nidproducto, ncantidad, npreciounitario)
    VALUES (@nidventa, @nidproducto, @ncantidad, @npreciounitario);


	select cast(SCOPE_IDENTITY() as int)
END;


alter PROCEDURE USP_Actualizar_DetalleVenta
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


alter PROCEDURE USP_Eliminar_DetalleVenta
    @niddetalle INT
AS
BEGIN
    DELETE FROM detalleventa
    WHERE niddetalle = @niddetalle;

	select cast(@@ROWCOUNT as int)
END;
GO

CREATE PROCEDURE USP_Seleccionar_DetalleVenta
AS
BEGIN
    SELECT * FROM detalleventa;
END;
GO










alter PROCEDURE USP_Insert_DetalleVenta
    @nidproducto INT,
    @ncantidad INT,
    @npreciounitario DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO detalleventa (nidproducto, ncantidad, npreciounitario)
    VALUES (@nidproducto, @ncantidad, @npreciounitario);
END;