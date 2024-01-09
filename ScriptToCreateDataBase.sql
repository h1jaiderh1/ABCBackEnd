CREATE DATABASE ABC
GO
USE ABC
GO
-- Crear la tabla Producto
CREATE TABLE Producto (
    idProducto INT PRIMARY KEY identity(1,1),
    nombre NVARCHAR(255),
    valorUnitario DECIMAL(10, 2),
    fechaCreacion DATETIME default getdate(),
    fechaActualizacion DATETIME,
    isActive BIT default 1,
    cantidad INT
);
GO
-- Crear la tabla Cliente
CREATE TABLE Cliente (
    idCliente INT PRIMARY KEY identity(1,1),
    tipo NVARCHAR(50),
    numeroDocumento NVARCHAR(20),
    correo NVARCHAR(255),
    telefono NVARCHAR(20),0
    direccion NVARCHAR(255),
    departamento NVARCHAR(100),
    ciudad NVARCHAR(100),
    barrio NVARCHAR(100),
    fechaCreacion DATETIME default getdate(),
    fechaActualizacion DATETIME,
    isActive BIT
);
GO
-- Crear la tabla Pedido
CREATE TABLE Pedido (
    idPedido INT PRIMARY KEY identity(1,1),
    fechaCreacion DATETIME default getdate(),
    fechaActualizacion DATETIME,
    fechaCierre DATETIME,
    fechaFacturacion DATETIME,
    idCliente INT FOREIGN KEY REFERENCES Cliente(idCliente), -- Relación con la tabla Cliente
    isActive BIT,
	total DECIMAL(10,2)
);
GO
-- Crear la tabla PedidoProducto
CREATE TABLE PedidoProducto (
    idPedidoProducto INT PRIMARY KEY identity(1,1),
    idPedido INT FOREIGN KEY REFERENCES Pedido(idPedido), -- Relación con la tabla Pedido
    idProducto INT FOREIGN KEY REFERENCES Producto(idProducto), -- Relación con la tabla Producto
	cantidad int,
	precioUnitario decimal(10,2),
    precioTotal DECIMAL(10, 2)
);
GO
-- Crear la tabla Usuario
CREATE TABLE Usuario (
    idUsuario INT PRIMARY KEY identity(1,1),
    nombres NVARCHAR(100),
    apellidos NVARCHAR(100),
    identificacionCiudadania NVARCHAR(20),
    usuario NVARCHAR(50),
    contrasena NVARCHAR(50),
    fechaCreacion DATETIME default getdate(),
    isActive BIT default 1
);
drop table Usuario
INSERT INTO Usuario (nombres,apellidos,identificacionCiudadania,usuario,contrasena) values
('Jaider Santiago', 'Villa', '1001','JaiderV','123')
select * from Usuario

INSERT INTO Producto(nombre,valorUnitario,fechaActualizacion, cantidad)values
('Martillo',10000,getdate(),2)
 