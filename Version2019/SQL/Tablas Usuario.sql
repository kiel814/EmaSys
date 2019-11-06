USE EmaSysDB;

DROP TABLE IF EXISTS MovimientosProveedores;
DROP TABLE IF EXISTS IIBB;
DROP TABLE IF EXISTS Asientos;
DROP TABLE IF EXISTS Pagos;
DROP TABLE IF EXISTS OrdenesPago;
DROP TABLE IF EXISTS Pagos;

CREATE TABLE MovimientosProveedores (
    ID                      INT IDENTITY (1, 1),
    TipoMovimiento          VARCHAR(2),
    Proveedor               VARCHAR(4),
    TipoDocumento           VARCHAR(1),
    Sucursal                VARCHAR(5),
    Documento               VARCHAR(8),
    Fecha                   DATE,
    FechaCarga              DATE,
    Vencimiento             DATE,
    MontoNeto               DECIMAL(15, 2),
    MontoExento             DECIMAL(15, 2),
    PorcentajeIVA           DECIMAL(5, 4),
    MontoIVA                DECIMAL(15, 2),
    PorcentajePercepIVA     DECIMAL(5, 4),
    MontoPercepIVA          DECIMAL(15, 2),
    Material                BIT,
    Provincia               VARCHAR(1),
    Actividad               VARCHAR(1),
    Total                   DECIMAL(15, 2),
    Despacho                VARCHAR(50),
    Observaciones           VARCHAR(50),
    TipoFacturaOrig         VARCHAR(1),
    SucursalOrig            VARCHAR(5),
    DocumentoOrig           VARCHAR(8),
    Asiento                 VARCHAR(6),
    Estado                  VARCHAR(7),
    
    CONSTRAINT PK_MovimientosProveedores PRIMARY KEY (ID),
    CONSTRAINT UC_MovimientosProveedores_Documento UNIQUE (TipoMovimiento, Proveedor, TipoDocumento, Sucursal, Documento)
);

CREATE TABLE IIBB (
    ID                      INT IDENTITY (1, 1),
    Movimiento              INT,
    Linea                   INT,
    Provincia               VARCHAR(1),
    Porcentaje              DECIMAL(5, 4),
    Monto                   DECIMAL(15, 2),
    
    CONSTRAINT PK_IIBB PRIMARY KEY (ID),
    CONSTRAINT UC_IIBB_MovimientoLinea UNIQUE (Movimiento, Linea)
);

CREATE TABLE Asientos (
    ID              INT IDENTITY (1, 1),
    Asiento         VARCHAR(6),
    Linea           VARCHAR(2),
    Cuenta          VARCHAR(6),
    Fecha           DATE,
    Observaciones   VARCHAR(50),
    Tipo            VARCHAR(1),
    Importe         DECIMAL(15, 2),
    TipoMovimiento  VARCHAR(2),
    TipoDocumento   VARCHAR(1),
    Moneda          VARCHAR(3),
    EmpleadoID      INTEGER,
    Estado          VARCHAR(7),
    -- Sucursal?
    -- Documento?
    -- Archi
    -- Compr
    -- Codig
    -- Anula
    -- Feing
    -- Fedev
    -- Cotiz
    -- Impex
    
    CONSTRAINT PK_Asientos PRIMARY KEY (ID),
    CONSTRAINT UC_Asientos_AsientoLinea UNIQUE (Asiento, Linea)
);

CREATE TABLE OrdenesPago (
    ID                      INT IDENTITY (1, 1),
    Fecha                   DATE,
    PorcentajeIIBB          DECIMAL(5, 4),
    MontoIIBB               DECIMAL(15, 2),
    PorcentajeGanancias     DECIMAL(5, 4),
    MontoGanancias          DECIMAL(15, 2),
    Estado                  VARCHAR(7),
    
    CONSTRAINT PK_OrdenesPago PRIMARY KEY (ID)
);

CREATE TABLE Pagos (
    ID                      INT IDENTITY (1, 1),
    Orden                   INT,
    Movimiento              INT,
    Pago                    DECIMAL(15, 2),
    
    CONSTRAINT PK_Pagos PRIMARY KEY (ID)
);