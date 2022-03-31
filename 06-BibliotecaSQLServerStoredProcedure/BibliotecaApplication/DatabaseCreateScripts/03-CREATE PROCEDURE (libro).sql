IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'libro_upd')
DROP PROCEDURE libro_upd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'libro_sel_max_id_libro')
DROP PROCEDURE libro_sel_max_id_libro
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'libro_sel_lectores_sin_libros')
DROP PROCEDURE libro_sel_lectores_sin_libros
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'libro_sel_en_prestamo_agrupado')
DROP PROCEDURE libro_sel_en_prestamo_agrupado
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'libro_sel_en_prestamo')
DROP PROCEDURE libro_sel_en_prestamo
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'libro_sel_by_isbn')
DROP PROCEDURE libro_sel_by_isbn
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'libro_sel_by_id')
DROP PROCEDURE libro_sel_by_id
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'libro_sel_all')
DROP PROCEDURE libro_sel_all
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'libro_ins')
DROP PROCEDURE libro_ins
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'libro_del')
DROP PROCEDURE libro_del
GO

CREATE PROCEDURE libro_upd
	@codigo_identificacion_unico varchar(10),
	@titulo varchar(max),
	@isbn varchar(max),
	@id_lector int,
	@id_libro int
AS
	UPDATE Libro 
    SET  
        codigo_identificacion_unico = @codigo_identificacion_unico,
        titulo = @titulo, 
        isbn = @isbn,
        id_lector = @id_lector                        
    WHERE id_libro = @id_libro
	
GO

CREATE PROCEDURE [libro_sel_max_id_libro]
AS
	SELECT MAX(id_libro) FROM Libro

GO

CREATE PROCEDURE [libro_sel_lectores_sin_libros]
AS
SELECT *                                             
FROM Lector
WHERE 
    Lector.id_lector NOT IN  
            (
                SELECT id_lector FROM Libro 
                WHERE id_lector IS NOT null                          
            )                                          
ORDER BY Lector.apellido ASC

GO

CREATE PROCEDURE [dbo].[libro_sel_en_prestamo_agrupado]
AS
	SELECT 
		Lector.id_lector,
		Lector.apellido,
		Lector.dni,
		Count(Libro.id_libro) as [Cantidad de libros en prestamo]
    FROM Libro 
    RIGHT JOIN Lector ON Lector.id_lector = Libro.id_lector
    GROUP BY 
            Lector.id_lector,
            Lector.apellido,
            Lector.dni
    ORDER BY Lector.apellido ASC
	
GO

CREATE PROCEDURE [libro_sel_en_prestamo]
AS
	SELECT 
		Libro.id_libro,
		Libro.codigo_identificacion_unico,
		Libro.titulo,
		Libro.isbn,
		Lector.apellido
	FROM Libro 
	INNER JOIN Lector ON Lector.id_lector = Libro.id_lector
	ORDER BY id_libro ASC
	
GO

CREATE PROCEDURE [libro_sel_by_isbn]
	@isbn varchar(max)
AS
	SELECT * FROM Libro WHERE isbn = @isbn
	
GO

CREATE PROCEDURE [libro_sel_by_id]
	@id_libro int
AS
	SELECT * FROM Libro WHERE id_libro = @id_libro
	
GO

CREATE PROCEDURE [libro_sel_all]
AS
	SELECT * FROM Libro ORDER BY id_libro ASC
	
GO

CREATE PROCEDURE [libro_ins]
	@codigo_identificacion_unico varchar(10),
	@titulo varchar(max),
	@isbn varchar(max),
	@id_lector int
AS
	INSERT INTO Libro 
            (codigo_identificacion_unico, titulo, isbn, id_lector) 
    VALUES 
            (@codigo_identificacion_unico, @titulo, @isbn, @id_lector)
			
GO

CREATE PROCEDURE [libro_del]
	@id_libro int
AS
	DELETE FROM Libro WHERE id_libro = @id_libro