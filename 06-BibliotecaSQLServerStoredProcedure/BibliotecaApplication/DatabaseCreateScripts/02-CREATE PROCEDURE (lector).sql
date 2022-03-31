IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'lector_upd')
DROP PROCEDURE lector_upd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'lector_sel_max_id_lector')
DROP PROCEDURE lector_sel_max_id_lector
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'lector_sel_by_id')
DROP PROCEDURE lector_sel_by_id
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'lector_sel_all')
DROP PROCEDURE lector_sel_all
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'lector_ins')
DROP PROCEDURE lector_ins
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'lector_del')
DROP PROCEDURE lector_del
GO

/***
* Descripción: Modifica un registro de la tabla Lector.
***/
CREATE PROCEDURE lector_upd
	@dni int = 0,
	@apellido varchar(50),
	@id_lector int
AS
BEGIN
	UPDATE Lector 
	SET  
		dni = @dni, 
		apellido = @apellido                                       
	WHERE id_lector = @id_lector
END

GO

/***
* Descripción: Selecciona el máximo valor del campo clave primaria (primary key).
***/
CREATE PROCEDURE lector_sel_max_id_lector
AS
BEGIN
	SELECT MAX(id_lector) FROM Lector
END

GO

/***
* Descripción: Selecciona un registro de la tabla Lector por su clave primaria (primary key).
***/
CREATE PROCEDURE [lector_sel_by_id]
	@id_lector int
AS
BEGIN
	SELECT * FROM Lector WHERE id_lector = @id_lector
END

GO

/***
* Descripción: Selecciona todos los registros de la tabla Lector.
***/
CREATE PROCEDURE lector_sel_all
AS
BEGIN
	SELECT * FROM Lector ORDER BY id_lector ASC
END

GO

/***
* Descripción: Adiciona un registro en la tabla Lector.
***/
CREATE PROCEDURE lector_ins
	@dni int = 0,
	@apellido varchar(50)
AS
BEGIN
	INSERT INTO Lector 
            (dni, apellido) 
    VALUES 
            (@dni, @apellido)
END

GO

/***
* Descripción: Elimina un registro por su clave primaria (primary key)
***/
CREATE PROCEDURE lector_del
	@id_lector int
AS
BEGIN
	DELETE FROM Lector WHERE id_lector = @id_lector
END



