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


