/*************************************************************************************************************
Script Name              : dbMercatorESC
Description              : Script para generar la base de datos del proyecto
Version	                 : 1.0
Modification History	 : IS	-	Date		-	Description
                           ----		----------		----------------------------------------------------------
						   BJPH		29/06/2016		Se agregaron las tablas y añadio FK en el script.
**************************************************************************************************************/

USE master
GO

DECLARE @Errormessage VARCHAR(MAX)

IF NOT EXISTS(SELECT sid, name FROM MASTER..SYSLOGINS WHERE name ='MercatorAppEsc')
	BEGIN
		EXEC sp_addlogin 'MercatorAppEsc','ut335m3rcator'
	END
ELSE
	BEGIN
	  SET @Errormessage = 'Username already exist in database'
	  SELECT @Errormessage AS 'Msg'
	END
GO

--CREATE DATABASE
IF EXISTS(SELECT * FROM dbo.SYSDATABASES WHERE name = 'dbMercatorESC_UAT')
BEGIN
	ALTER DATABASE [dbMercatorESC_UAT] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	USE master
	DROP DATABASE dbMercatorESC_UAT
	CREATE DATABASE dbMercatorESC_UAT
END
ELSE
	BEGIN
		CREATE DATABASE dbMercatorESC_UAT
	END
GO

--USE DATABASE
USE dbMercatorESC_UAT
GO

--DECLARE VARIABLES
DECLARE @Errormessage VARCHAR(MAX)

--VIEW USERNAMES FOR DATABASE ACTUALLY

IF NOT EXISTS(SELECT uid, name sid FROM SYSUSERS WHERE name = 'MercatorAppESC' AND islogin = 1)
BEGIN

--CREATE LOGIN
CREATE USER MercatorAppESC FOR LOGIN MercatorAppESC

--ADD ROLES TO USER
EXEC sp_addrolemember 'db_owner', 'MercatorAppESC'
EXEC sp_addrolemember 'db_accessadmin','MercatorAppESC'

END

ELSE
	BEGIN
		SET @Errormessage = 'Username already exist in server'
		SELECT @Errormessage AS 'Msg'
END

BEGIN TRY
	BEGIN TRAN
		IF EXISTS(SELECT * FROM dbo.SYSDATABASES WHERE name = 'dbMercatorESC_UAT' )
		BEGIN		
			IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
						WHERE TABLE_SCHEMA = 'dbo' 
						AND  TABLE_NAME = 'Producto'))
				BEGIN
					SELECT 'Table Producto already exists' AS 'Msg'
				END
				ELSE
					BEGIN
						CREATE TABLE Producto
						(
							PKProducto INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
							Cod_Barras VARCHAR(MAX) NOT NULL,
							Nombre NVARCHAR(20) NOT NULL, 
							Precio FLOAT NOT NULL,
							Cantidad INT NOT NULL,
							Fabricante NVARCHAR(20) NOT NULL 
						);
					END

			IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
						WHERE TABLE_SCHEMA = 'dbo' 
						AND  TABLE_NAME = 'Proveedor'))
				BEGIN
					SELECT 'Table Proveedor already exists' AS 'Msg'
				END
				ELSE
					BEGIN
						 CREATE TABLE Proveedor
				(
				PKNum_proveedor INT NOT NULL IDENTITY(1,1) PRIMARY  KEY,
				Nom_provedor NVARCHAR(30) NOT NULL,
				FKNum_proveedor INT NOT NULL REFERENCES Producto (PKProducto)
				)
					END
						

				IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
						WHERE TABLE_SCHEMA = 'dbo' 
						AND  TABLE_NAME = 'Venta'))
				BEGIN
					SELECT 'Table Venta already exists' AS 'Msg'
				END
				ELSE
					BEGIN
						 CREATE TABLE Venta
				(
				 PKNum_venta INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
				 Fecha DATETIME NOT NULL,
				 Total DECIMAL(11,2) NOT NULL,
				 
				)
					END	
				
				IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
						WHERE TABLE_SCHEMA = 'dbo' 
						AND  TABLE_NAME = 'DetalleVenta'))
				BEGIN
					SELECT 'Table DetalleVenta already exists' AS 'Msg'
				END
				ELSE
					BEGIN
						CREATE TABLE DetalleVenta
						(
							PKId_detalle INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
							FKNum_venta INT NOT NULL REFERENCES Venta (PKNum_venta),
				            FKProducto INT NOT NULL REFERENCES Producto (PKProducto),
							Cantidad INT NOT NULL,
							Precio MONEY NOT NULL,
							Subtotal DECIMAL (11,2) NOT NULL 
						);
					END

				IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
						WHERE TABLE_SCHEMA = 'dbo' 
						AND  TABLE_NAME = 'Compra'))
				BEGIN
					SELECT 'Table Compra already exists' AS 'Msg'
				END
				ELSE
					BEGIN
						CREATE TABLE Compra
						(
							 PKNum_compra INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
							 FKNum_proveedor INT NOT NULL REFERENCES Proveedor (PKNum_proveedor),
							 Empleado VARCHAR(40)  NOT NULL,
							 Fecha_rec DATETIME NOT NULL
						);
					END
				
				IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES 
						WHERE TABLE_SCHEMA = 'dbo' 
						AND  TABLE_NAME = 'DetalleCompra'))
				BEGIN
					SELECT 'Table DetalleCompra already exists' AS 'Msg'
				END
				ELSE
					BEGIN
						CREATE TABLE DetalleCompra
						(	
							PKId_detallecompra INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
							FKNum_compra INT NOT NULL REFERENCES Compra (PKNum_compra),
							FKProducto1 INT NOT NULL REFERENCES Producto (PKProducto),
							Cantidad INT NOT NULL,
							Monto MONEY NOT NULL
						);
					END
				
				COMMIT
			END
		ELSE
			BEGIN
					
				ROLLBACK
					
				SET @Errormessage = 'Database not exist'
				RAISERROR(@Errormessage,16,1);
			END
END TRY
BEGIN CATCH
	
	SELECT  @Errormessage = 'Error: ' + CAST(ERROR_NUMBER() AS NVARCHAR) + ' -> ' + ERROR_MESSAGE() + '. Error Line: *' + CAST(ERROR_LINE() AS VARCHAR(50)) + '*.'; 
	
	--SELECT  @Errormessage AS Msg;
	
	RAISERROR(@Errormessage,16,1);
	
	IF(@@TRANCOUNT > 0)
		ROLLBACK
		
END CATCH