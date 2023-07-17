-- Eliminar la columna `Disponibilidad` anterior
ALTER TABLE vehiculos
DROP COLUMN Disponibilidad;

-- Agregar columnas a la tabla `vehiculos`
ALTER TABLE vehiculos
ADD foto TEXT,
    placa VARCHAR(10),
    Disponibilidad BIT;

-- Modificar el tipo de datos del campo `Disponibilidad`
UPDATE vehiculos
SET Disponibilidad = CASE WHEN Disponibilidad = 1 THEN 'Disponible' ELSE 'No Disponible' END;
