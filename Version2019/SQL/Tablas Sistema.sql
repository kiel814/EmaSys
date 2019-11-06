USE EmaSysDB;

DROP TABLE IF EXISTS Cuentas;
DROP TABLE IF EXISTS Provincias;
DROP TABLE IF EXISTS Monedas;

CREATE TABLE Cuentas (
    ID          INT IDENTITY (1, 1),
    Cuenta      VARCHAR(6),
    Descripcion VARCHAR(50),
    Debe        DECIMAL(15, 2),
    Haber       DECIMAL(15, 2),
    --SAcum     MONEY,
    --SAjus     MONEY,
    --Movim     BIT,
    --Imput     VARCHAR(1),
    --Costo     VARCHAR(1),
    Moneda      VARCHAR(3),
    --ok        VARCHAR(1),
    
    CONSTRAINT PK_Cuentas PRIMARY KEY (ID),
    CONSTRAINT UC_Cuentas_Cuenta UNIQUE (Cuenta)
);

CREATE TABLE Provincias (
    ID          INT IDENTITY (1, 1),
    Letra       VARCHAR(1),
    Nombre      VARCHAR(25),
    CuentaIIBB  VARCHAR(6),
    
    CONSTRAINT PK_Provincias PRIMARY KEY (ID),
    CONSTRAINT UC_Provincias_Letra UNIQUE (Letra)
);

CREATE TABLE Monedas (
    ID          INT IDENTITY (1, 1),
    Codigo      VARCHAR(3),
    Nombre      VARCHAR(25),
    
    CONSTRAINT PK_Monedas PRIMARY KEY (ID),
    CONSTRAINT UC_Monedas_Codigo UNIQUE (Codigo)
);

INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('100000', 'Activo Corriente', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('110000', 'Disponibilidades', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('110101', 'Caja', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('110102', 'Fondo Fijo', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('110106', 'Transferencias y Depositos Bancarios', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('110120', 'Cobranzas a Depositar', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('110121', 'Valores Pendientes de Acreditacion', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('110200', 'Bancos', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('110201', 'Banco Rio Cuenta Central', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('110202', 'Banco Rio Sucursal Florida', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('120000', 'Creditos', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('120100', 'Creditos', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('120110', 'Cuenta Corriente Gobierno', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('120111', 'Cuenta Corriente Gobierno en Mora', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('120112', 'Cuenta Corriente Gobierno Gestion Judicial', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('120113', 'Cuenta Corriente Gobierno Aduana', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('120130', 'Cuenta Corriente Particulares', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('120131', 'Cuenta Corriente CICSA Alquiler', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('120132', 'Cuenta Corriente Particulares Gestion Judicial', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('120201', 'Credito Fiscal IVA Compras', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('120228', 'Anticipo IVA Percepciones Proveedores', 0, 0, 'PES');
INSERT INTO Cuentas (Cuenta, Descripcion, Debe, Haber, Moneda) VALUES ('120229', 'Anticipo IIBB Santa Fe', 0, 0, 'PES');

INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('C', 'Capital Federal', '120218');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('B', 'Buenos Aires', '120216');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('X', 'Cordoba', '120215');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('W', 'Corrientes', '120236');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('H', 'Chaco', '120245');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('U', 'Chubut', '120231');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('E', 'Entre Rios', '120235');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('L', 'La Pampa', '120257');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('M', 'Mendoza', '120232');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('N', 'Misiones', '120237');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('Q', 'Neuquen', '120242');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('R', 'Rio Negro', '120238');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('A', 'Salta', '120248');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('J', 'San Juan', '120253');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('Z', 'Santa Cruz', '120230');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('S', 'Santa Fe', '120229');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('G', 'Santiago del Estero', '120234');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('T', 'Tucuman', '120233');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('D', 'San Luis', '120258');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('F', 'La Rioja', '120241');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('K', 'Catamarca', '120256');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('P', 'Formosa', '120265');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('V', 'Tierra del Fuego', '120244');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('Y', 'Jujuy', '120239');
INSERT INTO Provincias (Letra, Nombre, CuentaIIBB) VALUES ('6', 'Internacional', '120261');

INSERT INTO Monedas (Codigo, Nombre) VALUES ('ARS', 'Peso Argentino');
INSERT INTO Monedas (Codigo, Nombre) VALUES ('USD', 'Dólar Estadounidense');
INSERT INTO Monedas (Codigo, Nombre) VALUES ('EUR', 'Euro');