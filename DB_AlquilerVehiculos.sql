USE master; -- Cambia a la base de datos adecuada si es necesario
GO

IF DB_ID('alquilervehiculos') IS NOT NULL
BEGIN
    ALTER DATABASE alquilervehiculos SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE alquilervehiculos;
END
GO

CREATE DATABASE alquilervehiculos;
GO

USE alquilervehiculos;
GO

-- Table structure for table `empleados`
CREATE TABLE empleados (
  Id_Empleados INT NOT NULL IDENTITY(1,1),
  Nombres VARCHAR(50) NOT NULL,
  Apellidos VARCHAR(50) NOT NULL,
  Direccion VARCHAR(50) NOT NULL,
  Telefono VARCHAR(10) NOT NULL,
  CorreoElectronico VARCHAR(100) NOT NULL,
  FechaContrato DATE NOT NULL,
  PRIMARY KEY (Id_Empleados)
);
GO

-- Table structure for table `vehiculos`
CREATE TABLE vehiculos (
  Id_Vehiculos INT NOT NULL IDENTITY(1,1),
  Marca VARCHAR(20) NOT NULL,
  Modelo VARCHAR(25) NOT NULL,
  Anio INT NOT NULL,
  Tipo VARCHAR(25) NOT NULL,
  Disponibilidad VARCHAR(15) NOT NULL,
  PRIMARY KEY (Id_Vehiculos)
);
GO

-- Table structure for table `facturas`
CREATE TABLE facturas (
  Id_Facturas INT NOT NULL IDENTITY(1,1),
  Id_Empleados INT NOT NULL,
  Id_Vehiculos INT NOT NULL,
  NombreCliente VARCHAR(50) NOT NULL,
  CedulaCliente VARCHAR(10) NOT NULL,
  DireccionCliente VARCHAR(100) NOT NULL,
  TelefonoCliente VARCHAR(10) NOT NULL,
  FechaAlquiler DATE NOT NULL,
  FechaDevolucion DATE NOT NULL,
  PrecioAlquilerDia FLOAT NOT NULL,
  AbonoAlquiler FLOAT NOT NULL,
  TotalAlquiler FLOAT NOT NULL,
  PRIMARY KEY (Id_Facturas),
  CONSTRAINT FK_Factura_Empleados FOREIGN KEY (Id_Empleados) REFERENCES empleados (Id_Empleados) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT FK_Factura_Vehiculos FOREIGN KEY (Id_Vehiculos) REFERENCES vehiculos (Id_Vehiculos) ON DELETE CASCADE ON UPDATE CASCADE
);
GO