--Eliminar manualmente las claves foraneas en la tabla factura
-- y despues borrar manualmente el campo TotalAlquiler y ejecutar el script

use alquilervehiculos;

-- Añadimos una nueva columna calculada TotalAlquiler
ALTER TABLE facturas
ADD TotalAlquiler AS 
    (DATEDIFF(day, FechaAlquiler, FechaDevolucion) + 1) * PrecioAlquilerDia - AbonoAlquiler;
GO

-- Agregamos nuevamente las restricciones FOREIGN KEY
ALTER TABLE facturas
ADD CONSTRAINT FK_Factura_Empleados FOREIGN KEY (Id_Empleados) REFERENCES empleados (Id_Empleados) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_Factura_Vehiculos FOREIGN KEY (Id_Vehiculos) REFERENCES vehiculos (Id_Vehiculos) ON DELETE CASCADE ON UPDATE CASCADE;
GO