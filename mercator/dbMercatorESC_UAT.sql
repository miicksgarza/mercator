/*************************************************************************************************************
Script Name              : dbMercatorESC
Description              : Script para generar la base de datos del proyecto
Version	                 : 1.0
Modification History	 : IS	-	Date		-	Description
                           ----		----------		----------------------------------------------------------
						   BJPH		26/07/2016		Se cambio la base de datos.
**************************************************************************************************************/

Use Master
Go
If(db_id('dbMercatorESC')Is Not Null)
DROP DATABASE dbMercatorESC
CREATE DATABASE dbMercatorESC
GO

USE dbMercatorESC
GO

CREATE TABLE Categoria
(IdCategoria INT IDENTITY PRIMARY KEY,
Descripcion VARCHAR(50) NOT NULL
)
GO

CREATE TABLE Producto
(IdProducto INT IDENTITY PRIMARY KEY,
IdCategoria INT NOT NULL REFERENCES Categoria,
Nombre VARCHAR(50) NOT NULL,
Marca VARCHAR(80),
Stock INT NOT NULL,
PrecioCompra DECIMAL(6,2) NOT NULL,
PrecioVenta DECIMAL(6,2) NOT NULL,
FechaVencimiento DATE,
Foto IMAGE NULL
)
GO

 CREATE TABLE Proveedor
(IdProveedor INT IDENTITY PRIMARY  KEY,
NombreProv NVARCHAR(30) NOT NULL,
Direccion VARCHAR(80) NOT NULL,
Telefono BIGINT NOT NULL
)


CREATE TABLE Empleado
(IdEmpleado INT IDENTITY PRIMARY KEY,
Dni CHAR(8) NOT NULL,
Apellido VARCHAR(30) NOT NULL,
Nombre VARCHAR(30) NOT NULL,
Sexo CHAR(1) NOT NULL,
FechaNac DATE NOT NULL,
Direccion VARCHAR(80) NOT NULL,
EstadoCivil CHAR(1) NOT NULL
)
Go

CREATE TABLE Compra
(IdCompra INT IDENTITY PRIMARY KEY,
FKIdEmpleado INT NOT NULL REFERENCES Empleado,
TipoDocumento VARCHAR(7) CHECK(TipoDocumento In('Factura')),
Serie CHAR(5) NOT NULL,
NroDocumento CHAR(7) NOT NULL,
FechaVenta  DATE NOT NULL,
Total  MONEY NOT NULL
)
GO

CREATE TABLE DetalleCompra
(IdDetalleCompra INT IDENTITY PRIMARY KEY,
FKIdProducto INT NOT NULL REFERENCES Producto,
IdCompra INT NOT NULL REFERENCES Compra,
Cantidad INT NOT NULL,
PrecioUnitario DECIMAL(6,2) NOT NULL,
IVA MONEY NOT NULL,
SubTotal MONEY NOT NULL
)
GO

CREATE TABLE Venta
(IdVenta INT IDENTITY PRIMARY KEY,
FechaVenta DATE NOT NULL,
Serie INT NOT NULL,
Nro_Doc INT NOT NULL,
Total MONEY NOT NULL
)
GO

CREATE TABLE DetalleVenta
(
IdDetalleVenta INT IDENTITY PRIMARY KEY,
FKIdProducto2 INT NOT NULL REFERENCES Producto,
FKIdVenta INT NOT NULL REFERENCES Venta,
Cantidad INT NOT NULL,
PrecioUnitario Decimal (6,2)NOT NULL,
IVA Money NOT NULL,
SubTotal money NOT NULL,)

CREATE TABLE Datos
(IdDatos INT IDENTITY PRIMARY KEY,
Nombre VARCHAR (80) NOT NULL,
Localidad VARCHAR (100)NOT NULL,
Telefono BIGINT NOT NULL,
Horario TIME NOT NULL,
) 

CREATE TABLE Usuario
(IdUsuario INT IDENTITY PRIMARY KEY,
FKIdEmpleado1 INT NOT NULL REFERENCES Empleado,
Usuario VARCHAR(20) NOT NULL,
Contraseña VARCHAR(12) NOT NULL
)
Go


Create Proc [Serie Documento]
@Serie char(5) out
as begin
Set @Serie='00001'
end
go

Create Procedure [Numero Correlativo]
@TipoDocumento Varchar(7),
@NroCorrelativo Char(7)Out
As Begin
	Declare @Cant Int
	If(@TipoDocumento='Factura')
	Begin
	Select @Cant=Count(*)+1 From Compra where TipoDocumento='Factura'
		If @Cant<10
			Set @NroCorrelativo='000000'+Ltrim(Str(@Cant))
		Else
			If @Cant<100
				Set @NroCorrelativo='00000'+Ltrim(Str(@Cant))
			Else
				If @Cant<1000
					Set @NroCorrelativo='0000'+Ltrim(Str(@Cant))
				Else
					If(@Cant<10000)
						Set @NroCorrelativo='000'+LTRIM(STR(@Cant))
					Else
						If(@Cant<100000)
							Set @NroCorrelativo='00'+LTRIM(STR(@Cant))
						Else
							If(@Cant<1000000)
								Set @NroCorrelativo='0'+LTRIM(str(@Cant))
							Else
								If(@Cant<10000000)
									Set @NroCorrelativo=LTRIM(str(@Cant))
									
	End

	End

	GO





Create Proc IniciarSesion
@Usuario Varchar(20),
@Contraseña Varchar(12),
@Mensaje Varchar(50) Out
As Begin
	Declare @Empleado Varchar(50)
	If(Not Exists(Select Usuario From Usuario Where Usuario=@Usuario))
		Set @Mensaje='El Nombre de Usuario no Existe.'
		Else Begin
			If(Not Exists(Select Contraseña From Usuario Where Contraseña=@Contraseña))
				Set @Mensaje='Su Contraseña es Incorrecta.'
				Else Begin
					Set @Empleado=(Select E.Nombre+', '+E.Apellido From Empleado E Inner Join Usuario U 
								   On E.IdEmpleado=U.FKIdEmpleado1 Where U.Usuario=@Usuario)
					    Begin
					Select Usuario,Contraseña From Usuario Where Usuario=@Usuario And Contraseña=@Contraseña
							Set @Mensaje='Bienvenido Sr(a): '+@Empleado+'.'
						End
				  End
		   End
   End
Go