USE EmaSysDB;

DROP TABLE IF EXISTS FacturasProveedores;
DROP TABLE IF EXISTS Asientos;

CREATE TABLE FacturasProveedores (
    ID                      INT IDENTITY (1, 1),
    Proveedor               VARCHAR(4),
    TipoFactura             VARCHAR(1),
    Sucursal                VARCHAR(4),
    Documento               VARCHAR(8),
    FechaFactura            DATE,
    FechaCarga              DATE,
    FechaVencimiento        DATE,
    MontoNeto               DECIMAL(15, 2),
    MontoExento             DECIMAL(15, 2),
    PorcentajeIVA           DECIMAL(5, 2),
    MontoIVA                DECIMAL(15, 2),
    PorcentajePercepcionIVA DECIMAL(5, 2),
    MontoPercepcionIVA      DECIMAL(15, 2),
    PorcentajeIIBB          DECIMAL(5, 2),
    MontoIIBB               DECIMAL(15, 2),
    Material                VARCHAR(1),
    Provincia               VARCHAR(1),
    BienDeUso               BIT,
    Activo                  BIT,
    Total                   DECIMAL(15, 2),
    Observaciones           VARCHAR(50),
    
    CONSTRAINT PK_FacturasProveedores PRIMARY KEY (ID)
);

CREATE TABLE Asientos (
    ID      INT IDENTITY (1, 1),
    Asiento VARCHAR(6),
    Linea   VARCHAR(2),
    Cuenta  VARCHAR(6),
    Fecha   DATE,
    --GLOBA?
    Tipo    VARCHAR(1),
    Importe DECIMAL(15, 2),
    TipoD   VARCHAR(2), -- nombre de columna?
    TipoF   VARCHAR(1), -- nombre de columna?
    -- Sucursal?
    -- Documento?
    -- Archi
    -- Compr
    -- Codig
    -- Anula
    -- Feing
    -- Fedev
    Moneda  VARCHAR(3),
    -- Cotiz
    -- Impex
    -- User
    -- ok
    
    CONSTRAINT PK_Asientos PRIMARY KEY (ID),
    CONSTRAINT UC_Asientos_AsientoLinea UNIQUE (Asiento, Linea)
);