
---Procedure: SELECT
USE ACRONI_SQL
GO
CREATE PROCEDURE usp_selUserInfo 
	@usuario VARCHAR(50)
AS
BEGIN
	SELECT senha, tipoConta, quantidade_teclados FROM tblCliente WHERE usuario=@usuario;
END
GO
CREATE PROCEDURE usp_selCadUserInfo
	@usuario VARCHAR(50),
	@email VARCHAR(50)
AS
BEGIN
	SELECT usuario, email FROM tblCliente WHERE usuario LIKE @usuario OR email LIKE @email
END
SELECT * FROM tblCliente
