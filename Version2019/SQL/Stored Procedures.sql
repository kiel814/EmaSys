USE EmaSysDB;

DROP PROCEDURE IF EXISTS spmostrar_proveedor_codigonombre;
DROP PROCEDURE IF EXISTS sp_ListaCuentasDescripcion;
DROP PROCEDURE IF EXISTS sp_InsertarFacturaProveedor;
DROP PROCEDURE IF EXISTS sp_ListaProvincias;
DROP PROCEDURE IF EXISTS sp_ListaMonedas;
GO

CREATE PROCEDURE spmostrar_proveedor_codigonombre
AS
    SELECT ProCodigo, ProNombr FROM Proveedores
    ORDER BY ProCodigo ASC

GO

CREATE PROCEDURE sp_ListaCuentasDescripcion
AS
    SELECT Cuenta, Descripcion FROM Cuentas
    ORDER BY Cuenta ASC
    
GO

CREATE PROCEDURE sp_InsertarFacturaProveedor
    @ID                         INT OUTPUT,
    @Proveedor                  VARCHAR(4),
    @TipoFactura                VARCHAR(1),
    @Sucursal                   VARCHAR(4),
    @Documento                  VARCHAR(8),
    @Fecha                      DATE,
    @FechaCarga                 DATE,
    @Vencimiento                DATE,
    @MontoNeto                  DECIMAL(15, 2),
    @MontoExento                DECIMAL(15, 2),
    @PorcentajeIVA              DECIMAL(5, 2),
    @MontoIVA                   DECIMAL(15, 2),
    @PorcentajePercepcionIVA    DECIMAL(5, 2),
    @MontoPercepcionIVA         DECIMAL(15, 2),
    @PorcentajeIIBB             DECIMAL(5, 2),
    @MontoIIBB                  DECIMAL(15, 2),
    @Material                   VARCHAR(1),
    @Provincia                  VARCHAR(1),
    @BienDeUso                  BIT,
    @Activo                     BIT,
    @Total                      DECIMAL(15, 2),
    @Observaciones              VARCHAR(50)
AS
    INSERT INTO FacturasProveedores (Proveedor,  TipoFactura,  Sucursal,  Documento,  FechaFactura, FechaCarga,  FechaVencimiento, MontoNeto,  MontoExento,  PorcentajeIVA,  MontoIVA,  PorcentajePercepcionIVA,  MontoPercepcionIVA,  PorcentajeIIBB,  MontoIIBB,  Material,  Provincia,  BienDeUso,  Activo,  Total,  Observaciones)
    VALUES                          (@Proveedor, @TipoFactura, @Sucursal, @Documento, @Fecha      , @FechaCarga, @Vencimiento,     @MontoNeto, @MontoExento, @PorcentajeIVA, @MontoIVA, @PorcentajePercepcionIVA, @MontoPercepcionIVA, @PorcentajeIIBB, @MontoIIBB, @Material, @Provincia, @BienDeUso, @Activo, @Total, @Observaciones)

GO

CREATE PROCEDURE sp_ListaProvincias
AS
    SELECT Letra, Nombre FROM Provincias
    ORDER BY ID ASC
    
GO

CREATE PROCEDURE sp_ListaMonedas
AS
    SELECT Codigo, Nombre FROM Monedas
    ORDER BY ID ASC
    
GO