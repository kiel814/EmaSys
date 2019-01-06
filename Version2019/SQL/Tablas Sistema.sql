USE EmaSysDB;

DROP TABLE IF EXISTS Cuentas;
DROP TABLE IF EXISTS Provincias;

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
    Letra       VARCHAR(6),
    Nombre      VARCHAR(50),
    Debe        DECIMAL(15, 2),
    Haber       DECIMAL(15, 2),
    --SAcum     MONEY,
    --SAjus     MONEY,
    --Movim     BIT,
    --Imput     VARCHAR(1),
    --Costo     VARCHAR(1),
    Moneda      VARCHAR(3),
    --ok        VARCHAR(1),
    
    CONSTRAINT PK_Provincias PRIMARY KEY (ID),
    CONSTRAINT UC_Provincias_Letra UNIQUE (Letra)
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

INSERT INTO Provincias (Letra, Nombre) VALUES ('120229', 'Anticipo IIBB Santa Fe', 0, 0, 'PES');