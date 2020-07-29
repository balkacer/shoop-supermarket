-- Create a new database called 'shoop'
-- Connect to the 'master' database to run this snippet
USE shoop
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT name
        FROM sys.databases
        WHERE name = N'shoop'
)
CREATE DATABASE shoop
GO

-- Create a new table called 'Producto' in schema 'shoop'
-- Drop the table if it already exists
IF OBJECT_ID('Producto', 'U') IS NOT NULL
DROP TABLE Producto
GO
-- Create the table in the specified schema
CREATE TABLE Producto
(
    ProductoId INT NOT NULL PRIMARY KEY, -- primary key column
    Descripcion [NVARCHAR](50) NOT NULL,
    Stock [INTEGER] NOT NULL,
    PrecioVenta [INTEGER] NOT NULL,
    PrecioCompra [INTEGER] NOT NULL,
    Categoria [INTEGER] NOT NULL,
    Proveedor [INTEGER] NOT NULL,
    Imagen [NVARCHAR](100) NOT NULL,
    FOREIGN KEY (Categoria) REFERENCES Categoria(CategoriaId),
    FOREIGN KEY (Proveedor) REFERENCES Proveedor(ProveedorId)

    -- specify more columns here
);
GO

-- Create a new table called 'Categoria' in schema 'shoop'
-- Drop the table if it already exists
IF OBJECT_ID('Categoria', 'U') IS NOT NULL
DROP TABLE Categoria
GO
-- Create the table in the specified schema
CREATE TABLE Categoria
(
    CategoriaId INT NOT NULL PRIMARY KEY, -- primary key column
    Categoria [NVARCHAR](50) NOT NULL,
    -- specify more columns here
);
GO

-- Create a new table called 'Proveedor' in schema 'shoop'
-- Drop the table if it already exists
IF OBJECT_ID('Proveedor', 'U') IS NOT NULL
DROP TABLE Proveedor
GO
-- Create the table in the specified schema
CREATE TABLE Proveedor
(
    ProveedorId INT NOT NULL PRIMARY KEY, -- primary key column
    Proveedor [NVARCHAR](50) NOT NULL,
    Telefono [NVARCHAR](50) NOT NULL,
    Logo [BIT] NOT NULL
    -- specify more columns here
);
GO

-- Create a new table called 'Usuario' in schema 'SchemaName'
-- Drop the table if it already exists
IF OBJECT_ID('Usuario', 'U') IS NOT NULL
DROP TABLE Usuario
GO
-- Create the table in the specified schema
CREATE TABLE Usuario
(
    UsuarioId INT NOT NULL PRIMARY KEY, -- primary key column
    Nombre [NVARCHAR](50) NOT NULL,
    Apellido [NVARCHAR](50) NOT NULL,

    -- specify more columns here
);
GO