/*************************************************************************************************************
Script Name              : dbMercatorESC
Description              : Script para generar la base de datos del proyecto
Version	                 : 1.0
Modification History	 : IS	-	Date		-	Description
                           ----		----------		----------------------------------------------------------
						   BJPH		15/06/2016		Se creo el script para la base de datos de Mercator con usuario de servidor y bd
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
							AND  TABLE_NAME = ''))
					BEGIN
						SELECT 'Table already exists' AS 'Msg'
					END
					ELSE
						BEGIN
							CREATE TABLE 
							(

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