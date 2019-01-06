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

INSERT INTO Provincias (Letra, Nombre) VALUES ('C', 'Capital Federal');
INSERT INTO Provincias (Letra, Nombre) VALUES ('B', 'Buenos Aires');
INSERT INTO Provincias (Letra, Nombre) VALUES ('X', 'Cordoba');
INSERT INTO Provincias (Letra, Nombre) VALUES ('W', 'Corrientes');
INSERT INTO Provincias (Letra, Nombre) VALUES ('H', 'Chaco');
INSERT INTO Provincias (Letra, Nombre) VALUES ('U', 'Chubut');
INSERT INTO Provincias (Letra, Nombre) VALUES ('E', 'Entre Rios');
INSERT INTO Provincias (Letra, Nombre) VALUES ('L', 'La Pampa');
INSERT INTO Provincias (Letra, Nombre) VALUES ('M', 'Mendoza');
INSERT INTO Provincias (Letra, Nombre) VALUES ('N', 'Misiones');
INSERT INTO Provincias (Letra, Nombre) VALUES ('Q', 'Neuquen');
INSERT INTO Provincias (Letra, Nombre) VALUES ('R', 'Rio Negro');
INSERT INTO Provincias (Letra, Nombre) VALUES ('A', 'Salta');
INSERT INTO Provincias (Letra, Nombre) VALUES ('J', 'San Juan');
INSERT INTO Provincias (Letra, Nombre) VALUES ('Z', 'Santa Cruz');
INSERT INTO Provincias (Letra, Nombre) VALUES ('S', 'Santa Fe');
INSERT INTO Provincias (Letra, Nombre) VALUES ('G', 'Santiago del Estero');
INSERT INTO Provincias (Letra, Nombre) VALUES ('T', 'Tucuman');
INSERT INTO Provincias (Letra, Nombre) VALUES ('D', 'San Luis');
INSERT INTO Provincias (Letra, Nombre) VALUES ('F', 'La Rioja');
INSERT INTO Provincias (Letra, Nombre) VALUES ('K', 'Catamarca');
INSERT INTO Provincias (Letra, Nombre) VALUES ('P', 'Formosa');
INSERT INTO Provincias (Letra, Nombre) VALUES ('V', 'Tierra del Fuego');
INSERT INTO Provincias (Letra, Nombre) VALUES ('Y', 'Jujuy');
INSERT INTO Provincias (Letra, Nombre) VALUES ('6', 'Internacional');

INSERT INTO Monedas (Codigo, Nombre) VALUES ('ARS', 'Pesos');
INSERT INTO Monedas (Codigo, Nombre) VALUES ('USD', 'Dolares');
INSERT INTO Monedas (Codigo, Nombre) VALUES ('EUR', 'Euros');