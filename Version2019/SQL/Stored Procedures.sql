USE EmaSysDB;

DROP PROCEDURE IF EXISTS sp_ListadoFacturasProveedores;
DROP PROCEDURE IF EXISTS sp_ListadoFacturasProveedoresPorCodigo;

DROP PROCEDURE IF EXISTS sp_ListadoMovimientosProveedores;
DROP PROCEDURE IF EXISTS sp_ListadoMovimientosProveedoresPorCodigo;

DROP PROCEDURE IF EXISTS sp_FacturaProveedorPorID;

DROP PROCEDURE IF EXISTS sp_ProveedorCodigoNombre;
DROP PROCEDURE IF EXISTS sp_CondicionIVA
DROP PROCEDURE IF EXISTS sp_ObtenerProveedorId

DROP PROCEDURE IF EXISTS sp_ListaCuentasDescripcion;
DROP PROCEDURE IF EXISTS sp_InsertarMovimientoProveedor;
DROP PROCEDURE IF EXISTS sp_ActualizarMovimientoProveedor;
DROP PROCEDURE IF EXISTS sp_GetMovimientoID;

DROP PROCEDURE IF EXISTS sp_ListaProvincias;
DROP PROCEDURE IF EXISTS sp_LetraDeProvincia;
DROP PROCEDURE IF EXISTS sp_ProvinciaPorLetra;
DROP PROCEDURE IF EXISTS sp_ListaMonedas;
DROP PROCEDURE IF EXISTS sp_CodigoMoneda;
DROP PROCEDURE IF EXISTS sp_NombreMoneda;

DROP PROCEDURE IF EXISTS sp_ObtenerAsientoLibre;
DROP PROCEDURE IF EXISTS sp_InsertarLineaAsiento;
DROP PROCEDURE IF EXISTS sp_InsertarLineaIIBB;

DROP PROCEDURE IF EXISTS sp_BorrarLineasAsiento;
DROP PROCEDURE IF EXISTS sp_BorrarLineasIIBB;
DROP PROCEDURE IF EXISTS sp_EliminarFacturaProveedor;

DROP PROCEDURE IF EXISTS sp_ListaLineasAsiento;
DROP PROCEDURE IF EXISTS sp_ListaLineasIIBB;

DROP PROCEDURE IF EXISTS sp_FacturasPendientesDePago;
DROP PROCEDURE IF EXISTS sp_MontoPendiente;
DROP PROCEDURE IF EXISTS sp_ObtenerNuevoNumeroOrdenPago;
DROP PROCEDURE IF EXISTS sp_InsertarOrdenPago;
DROP PROCEDURE IF EXISTS sp_InsertarPago;
DROP PROCEDURE IF EXISTS sp_ActualizarEstadoMovimiento;

DROP PROCEDURE IF EXISTS sp_NumericCuit;
DROP PROCEDURE IF EXISTS sp_AlicuotaIIBB_ARBA;
DROP PROCEDURE IF EXISTS sp_AlicuotaIIBB_CABA;
DROP PROCEDURE IF EXISTS sp_ValidarPadronARBA;
DROP PROCEDURE IF EXISTS sp_ValidarPadronCABA;
DROP PROCEDURE IF EXISTS sp_EsExento;

GO

CREATE PROCEDURE sp_ListadoFacturasProveedores
AS
    SELECT M.ID, CONCAT(M.Proveedor, ' - ', P.ProNombr) AS Proveedor, CONCAT(M.TipoDocumento, ' ', M.Sucursal, '-', M.Documento) AS Documento, Fecha, Total, Estado FROM MovimientosProveedores M
    INNER JOIN Proveedores P ON M.Proveedor = P.ProCodigo
    WHERE M.TipoMovimiento = 'FA'
    ORDER BY ID DESC

GO

CREATE PROCEDURE sp_ListadoFacturasProveedoresPorCodigo
    @Codigo           VARCHAR(4)
AS
    SELECT M.ID, CONCAT(M.Proveedor, ' - ', P.ProNombr) AS Proveedor, CONCAT(M.TipoDocumento, ' ', M.Sucursal, '-', M.Documento) AS Documento, Fecha, Total, Estado FROM MovimientosProveedores M
    INNER JOIN Proveedores P ON M.Proveedor = P.ProCodigo
    WHERE M.Proveedor = @Codigo
    AND M.TipoMovimiento = 'FA'
    ORDER BY ID DESC

GO

CREATE PROCEDURE sp_ListadoMovimientosProveedores
    @TipoMov VARCHAR(2)
AS
    SELECT M.ID, CONCAT(M.Proveedor, ' - ', P.ProNombr) AS Proveedor, CONCAT(M.TipoDocumento, ' ', M.Sucursal, '-', M.Documento) AS Documento, Fecha, Total, CONCAT(M.TipoFacturaOrig, ' ', M.SucursalOrig, '-', M.DocumentoOrig) AS Factura, Estado FROM MovimientosProveedores M
    INNER JOIN Proveedores P ON M.Proveedor = P.ProCodigo
    WHERE M.TipoMovimiento = @TipoMov
    ORDER BY ID DESC

GO

CREATE PROCEDURE sp_ListadoMovimientosProveedoresPorCodigo
    @TipoMov          VARCHAR(2),
    @Codigo           VARCHAR(4)
AS
    SELECT M.ID, CONCAT(M.Proveedor, ' - ', P.ProNombr) AS Proveedor, CONCAT(M.TipoDocumento, ' ', M.Sucursal, '-', M.Documento) AS Documento, Fecha, Total, CONCAT(M.TipoFacturaOrig, ' ', M.SucursalOrig, '-', M.DocumentoOrig) AS Factura, Estado FROM MovimientosProveedores M
    INNER JOIN Proveedores P ON M.Proveedor = P.ProCodigo
    WHERE M.Proveedor = @Codigo
    AND M.TipoMovimiento = @TipoMov
    ORDER BY ID DESC

GO

CREATE PROCEDURE sp_FacturaProveedorPorID
    @ID INT
AS
    SELECT * FROM MovimientosProveedores
    WHERE ID = @ID

GO

CREATE PROCEDURE sp_ProveedorCodigoNombre
AS
    SELECT ProCodigo, ProNombr FROM Proveedores
    ORDER BY ProCodigo ASC

GO

CREATE PROCEDURE sp_CondicionIVA
    @CondicionIVA     VARCHAR(1) OUTPUT,
    @Codigo           VARCHAR(4)
AS
    SET @CondicionIVA = (SELECT ProCIva FROM Proveedores WHERE ProCodigo = @Codigo)
    
GO

CREATE PROCEDURE sp_ObtenerProveedorId
    @ID         INT OUTPUT,
    @Codigo     VARCHAR(4)
AS
    SET @ID = (SELECT ProveedorID FROM Proveedores WHERE ProCodigo = @Codigo)
    
GO

CREATE PROCEDURE sp_ListaCuentasDescripcion
AS
    SELECT Cuenta, Descripcion FROM Cuentas
    ORDER BY Cuenta ASC
    
GO

CREATE PROCEDURE sp_InsertarMovimientoProveedor
    @TipoMovimiento             VARCHAR(2),
    @Proveedor                  VARCHAR(4),
    @TipoDocumento              VARCHAR(1),
    @Sucursal                   VARCHAR(5),
    @Documento                  VARCHAR(8),
    @Fecha                      DATE,
    @FechaCarga                 DATE,
    @Vencimiento                DATE,
    @MontoNeto                  DECIMAL(15, 2),
    @MontoExento                DECIMAL(15, 2),
    @PorcentajeIVA              DECIMAL(5, 4),
    @MontoIVA                   DECIMAL(15, 2),
    @PorcentajePercepIVA        DECIMAL(5, 4),
    @MontoPercepIVA             DECIMAL(15, 2),
    @Material                   BIT,
    @Provincia                  VARCHAR(1),
    @Actividad                  VARCHAR(1),
    @Total                      DECIMAL(15, 2),
    @Despacho                   VARCHAR(50),
    @Observaciones              VARCHAR(50),
    @TipoFacturaOrig            VARCHAR(1),
    @SucursalOrig               VARCHAR(5),
    @DocumentoOrig              VARCHAR(8),
    @Asiento                    VARCHAR(6),
    @Estado                     VARCHAR(7)
AS
    INSERT INTO MovimientosProveedores ( TipoMovimiento,  Proveedor,  TipoDocumento,  Sucursal,  Documento,  Fecha,  FechaCarga,  Vencimiento,  MontoNeto,  MontoExento,  PorcentajeIVA,  MontoIVA,  PorcentajePercepIVA,  MontoPercepIVA,  Material,  Provincia,  Actividad,  Total,  Despacho,  Observaciones,  TipoFacturaOrig,  SucursalOrig,  DocumentoOrig,  Asiento,  Estado)
    VALUES                             (@TipoMovimiento, @Proveedor, @TipoDocumento, @Sucursal, @Documento, @Fecha, @FechaCarga, @Vencimiento, @MontoNeto, @MontoExento, @PorcentajeIVA, @MontoIVA, @PorcentajePercepIVA, @MontoPercepIVA, @Material, @Provincia, @Actividad, @Total, @Despacho, @Observaciones, @TipoFacturaOrig, @SucursalOrig, @DocumentoOrig, @Asiento, @Estado)

GO

CREATE PROCEDURE sp_ActualizarMovimientoProveedor
    @ID                         INT,
    @TipoMovimiento             VARCHAR(2),
    @Proveedor                  VARCHAR(4),
    @TipoDocumento              VARCHAR(1),
    @Sucursal                   VARCHAR(5),
    @Documento                  VARCHAR(8),
    @Fecha                      DATE,
    @FechaCarga                 DATE,
    @Vencimiento                DATE,
    @MontoNeto                  DECIMAL(15, 2),
    @MontoExento                DECIMAL(15, 2),
    @PorcentajeIVA              DECIMAL(5, 4),
    @MontoIVA                   DECIMAL(15, 2),
    @PorcentajePercepIVA        DECIMAL(5, 4),
    @MontoPercepIVA             DECIMAL(15, 2),
    @Material                   BIT,
    @Provincia                  VARCHAR(1),
    @Actividad                  VARCHAR(1),
    @Total                      DECIMAL(15, 2),
    @Despacho                   VARCHAR(50),
    @Observaciones              VARCHAR(50),
    @TipoFacturaOrig            VARCHAR(1),
    @SucursalOrig               VARCHAR(5),
    @DocumentoOrig              VARCHAR(8)
AS
    UPDATE MovimientosProveedores SET
        TipoMovimiento = @TipoMovimiento,
        Proveedor = @Proveedor,
        TipoDocumento = @TipoDocumento, Sucursal = @Sucursal, Documento = @Documento,
        Fecha = @Fecha, FechaCarga = @FechaCarga, Vencimiento = @Vencimiento,
        MontoNeto = @MontoNeto, MontoExento = @MontoExento,
        PorcentajeIVA = @PorcentajeIVA, MontoIVA = @MontoIVA,
        PorcentajePercepIVA = @PorcentajePercepIVA, MontoPercepIVA = @MontoPercepIVA,
        Material = @Material, Provincia = @Provincia, Actividad = @Actividad,
        Total = @Total,
        Despacho = @Despacho, Observaciones = @Observaciones,
        TipoFacturaOrig = @TipoFacturaOrig, SucursalOrig = @SucursalOrig, DocumentoOrig = @DocumentoOrig
    WHERE ID = @ID

GO

CREATE PROCEDURE sp_GetMovimientoID
    @ID                         INT OUTPUT,
    @TipoMovimiento             VARCHAR(2),
    @Proveedor                  VARCHAR(4),
    @TipoDocumento              VARCHAR(1),
    @Sucursal                   VARCHAR(5),
    @Documento                  VARCHAR(8)
AS
    SELECT @ID = ID FROM MovimientosProveedores
        WHERE TipoMovimiento = @TipoMovimiento
            AND Proveedor = @Proveedor
            AND TipoDocumento = @TipoDocumento
            AND Sucursal = @Sucursal
            AND Documento = @Documento
    IF @ID IS NULL
        SET @ID = -1
        
GO

CREATE PROCEDURE sp_ListaProvincias
AS
    SELECT Letra, Nombre, CuentaIIBB FROM Provincias
    ORDER BY ID ASC
    
GO

CREATE PROCEDURE sp_LetraDeProvincia
    @Letra VARCHAR(1) OUTPUT,
    @Nombre VARCHAR(25)
AS
    SELECT @Letra = Letra FROM Provincias WHERE Nombre = @Nombre
    
GO

CREATE PROCEDURE sp_ProvinciaPorLetra
    @Provincia VARCHAR(25) OUTPUT,
    @Letra VARCHAR(1)
AS
    SELECT @Provincia = Nombre FROM Provincias WHERE Letra = @Letra
    
GO

CREATE PROCEDURE sp_ListaMonedas
AS
    SELECT Nombre FROM Monedas
    ORDER BY ID ASC
    
GO

CREATE PROCEDURE sp_CodigoMoneda
    @Codigo VARCHAR(3) OUTPUT,
    @Nombre VARCHAR(25)
AS
    SELECT @Codigo = Codigo FROM Monedas WHERE Nombre = @Nombre
    
GO

CREATE PROCEDURE sp_NombreMoneda
    @Nombre VARCHAR(25) OUTPUT,
    @Codigo VARCHAR(3)
AS
    SELECT @Nombre = Nombre FROM Monedas WHERE Codigo = @Codigo
    
GO

CREATE PROCEDURE sp_ObtenerAsientoLibre
    @Numero VARCHAR(6) OUTPUT
AS
	DECLARE @Ultimo VARCHAR(6)
    SELECT @Ultimo = MAX(Asiento) FROM Asientos
	IF @Ultimo IS NULL
		BEGIN
			SET @Numero = '000001'
		END
	ELSE
		BEGIN
			-- Convierto el último a INT, le sumo 1 y lo vuelvo a VARCHAR.
			-- Para padear con ceros, le agrego 5 ceros adelante y me quedo con los últimos 6 caracteres.
			SET @Numero = RIGHT('00000' + CAST(CAST(@Ultimo AS INT) + 1 AS VARCHAR), 6)
		END
    SELECT @Numero Asiento
GO

CREATE PROCEDURE sp_InsertarLineaAsiento
    @Asiento        VARCHAR(6),
    @Linea          VARCHAR(2),
    @Cuenta         VARCHAR(6),
    @Fecha          DATE,
    @Tipo           VARCHAR(1),
    @Importe        DECIMAL(15, 2),
    @TipoMovimiento VARCHAR(2),
    @TipoDocumento  VARCHAR(1),
    @Moneda         VARCHAR(3),
    @Observaciones  VARCHAR(50),
    @EmpleadoID     INTEGER,
    @Estado         VARCHAR(7)
AS
    INSERT INTO Asientos ( Asiento,  Linea,  Cuenta,  Fecha,  Tipo,  Importe,  TipoMovimiento,  TipoDocumento,  Moneda,  Observaciones,  EmpleadoID,  Estado)
	VALUES               (@Asiento, @Linea, @Cuenta, @Fecha, @Tipo, @Importe, @TipoMovimiento, @TipoDocumento, @Moneda, @Observaciones, @EmpleadoID, @Estado)

GO

CREATE PROCEDURE sp_InsertarLineaIIBB
    @DocType        VARCHAR(2),
    @DocId          INT,
    @Linea          INT,
    @Provincia      VARCHAR(1),
    @Porcentaje     DECIMAL(5, 4),
    @Monto          DECIMAL(15, 2)
AS
    INSERT INTO IIBB ( DocType,  DocId,  Linea,  Provincia,  Porcentaje,  Monto)
	VALUES           (@DocType, @DocId, @Linea, @Provincia, @Porcentaje, @Monto)

GO

CREATE PROCEDURE sp_BorrarLineasAsiento
    @Asiento VARCHAR(6)
AS
    DELETE FROM Asientos WHERE Asiento = @Asiento

GO

CREATE PROCEDURE sp_BorrarLineasIIBB
    @DocType        VARCHAR(2),
    @DocId          INT
AS
    DELETE FROM IIBB WHERE DocType = @DocType AND DocId = @DocId

GO

CREATE PROCEDURE sp_EliminarFacturaProveedor
    @ID INTEGER
AS
    UPDATE MovimientosProveedores SET Estado = 'Anulada' WHERE ID = @ID
    DECLARE @Asiento VARCHAR(6)
    SELECT @Asiento = Asiento FROM MovimientosProveedores WHERE ID = @ID
    UPDATE Asientos SET Estado = 'Anulada' WHERE Asiento = @Asiento

GO

CREATE PROCEDURE sp_ListaLineasAsiento
    @Asiento VARCHAR(6)
AS
    SELECT * FROM Asientos WHERE Asiento = @Asiento
    ORDER BY Linea ASC

GO

CREATE PROCEDURE sp_ListaLineasIIBB
    @DocType        VARCHAR(2),
    @DocId          INT
AS
    SELECT * FROM IIBB WHERE DocType = @DocType AND DocId = @DocId
    ORDER BY Linea ASC

GO

CREATE PROCEDURE sp_FacturasPendientesDePago
    @Proveedor                  VARCHAR(4),
    @FechaIni                   DATE,
    @FechaFin                   DATE
AS
    SELECT
        ID,
        TipoMovimiento AS Tipo,
        CONCAT(TipoDocumento, ' ', Sucursal, '-', Documento) AS Documento,
        CONCAT(TipoFacturaOrig, ' ', SucursalOrig, '-', DocumentoOrig) AS Contradocumento,
        Fecha AS Fecha,
        Vencimiento AS Vencimiento,
        Total AS Total,
        MontoNeto AS NetoOriginal,
        Estado AS Estado
    FROM MovimientosProveedores
    WHERE Proveedor = @Proveedor
    AND TipoMovimiento IN ('FA', 'DB')
    AND Vencimiento >= @FechaIni
    AND Vencimiento <= @FechaFin
    AND Estado NOT IN ('T', 'Anulada')
    ORDER BY Vencimiento ASC
GO

CREATE PROCEDURE sp_MontoPendiente
    @ID         INT,
    @Pendiente  DECIMAL(15,2) OUTPUT
AS
    DECLARE @Proveedor      VARCHAR(4)
    DECLARE @TipoFactura  VARCHAR(1)
    DECLARE @Sucursal       VARCHAR(5)
    DECLARE @Documento      VARCHAR(8)
    DECLARE @MontoOriginal DECIMAL(15, 2)
    SELECT 
        @Proveedor = Proveedor,
        @TipoFactura = TipoDocumento,
        @Sucursal = Sucursal,
        @Documento = Documento,
        @MontoOriginal = Total
        FROM MovimientosProveedores WHERE ID = @ID
    
    DECLARE @MontoCredito DECIMAL(15, 2)
    SELECT @MontoCredito = SUM(Total) FROM MovimientosProveedores
        WHERE Proveedor = @Proveedor
        AND TipoFacturaOrig = @TipoFactura
        AND SucursalOrig = @Sucursal
        AND DocumentoOrig = @Documento
        AND TipoMovimiento = 'CR'
    
	IF @MontoCredito IS NULL
    BEGIN
        SET @MontoCredito = 0
    END
    
    DECLARE @MontoPagos DECIMAL(15, 2)
    SELECT @MontoPagos = SUM(Pago) FROM Pagos
        WHERE Movimiento = @ID
    
	IF @MontoPagos IS NULL
    BEGIN
        SET @MontoPagos = 0
    END
    
    SELECT (@MontoOriginal - @MontoCredito - @MontoPagos) MontoPendiente
GO

CREATE PROCEDURE sp_ObtenerNuevoNumeroOrdenPago
    @Numero INT OUTPUT
AS
	DECLARE @Ultimo INT
    SELECT @Ultimo = MAX(ID) FROM OrdenesPago
	IF @Ultimo IS NULL
		BEGIN
			SET @Numero = 1
		END
	ELSE
		BEGIN
			SET @Numero = @Ultimo + 1
		END
    SELECT @Numero
GO

CREATE PROCEDURE sp_InsertarOrdenPago
    @ID                     INT,
    @Proveedor              INT,
    @Fecha                  DATE,
    @MontoIIBB              DECIMAL(15, 2),
    @PorcentajeGanancias    DECIMAL(5, 4),
    @MontoGanancias         DECIMAL(15, 2),
    @Estado                 VARCHAR(7)
AS
    SET IDENTITY_INSERT OrdenesPago ON
    INSERT INTO OrdenesPago ( ID,  Proveedor,  Fecha,  MontoIIBB,  PorcentajeGanancias,  MontoGanancias,  Estado)
	VALUES                  (@ID, @Proveedor, @Fecha, @MontoIIBB, @PorcentajeGanancias, @MontoGanancias, @Estado)
    SET IDENTITY_INSERT OrdenesPago OFF
GO

CREATE PROCEDURE sp_InsertarPago
    @Orden          INT,
    @Movimiento     INT,
    @Pago           DECIMAL(15, 2)
AS
    INSERT INTO Pagos ( Orden,  Movimiento,  Pago)
	VALUES            (@Orden, @Movimiento, @Pago)
GO

CREATE PROCEDURE sp_ActualizarEstadoMovimiento
    @Movimiento     INT,
    @Estado         VARCHAR(7)
AS
    UPDATE MovimientosProveedores SET Estado = @Estado WHERE ID = @Movimiento
GO

CREATE PROCEDURE sp_NumericCuit
    @Codigo VARCHAR(4),
    @CUIT NUMERIC(11,0) OUTPUT
AS
    DECLARE @StrCUIT AS VARCHAR(13)
    SET @CUIT = 0
    
    SELECT @StrCUIT = ProCuit FROM Proveedores WHERE ProCodigo = @Codigo
	IF @StrCUIT IS NOT NULL
    BEGIN
        SET @StrCUIT = REPLACE(@StrCUIT, '-', '')
        SET @CUIT = CAST(@StrCUIT AS NUMERIC(11, 0))
    END
GO

CREATE PROCEDURE sp_AlicuotaIIBB_ARBA
    @Codigo VARCHAR(4),
    @Alicuota DECIMAL(4, 2) OUTPUT
AS
    DECLARE @CUIT NUMERIC(11,0)
    EXEC sp_NumericCuit @Codigo, @CUIT OUTPUT
    
    SELECT @Alicuota = Alic FROM PadronbR WHERE Cuitpr = @CUIT --AND Regim = 'R'
GO

CREATE PROCEDURE sp_AlicuotaIIBB_CABA
    @Codigo VARCHAR(4),
    @Alicuota DECIMAL(4, 2) OUTPUT
AS
    DECLARE @CUIT NUMERIC(11,0)
    EXEC sp_NumericCuit @Codigo, @CUIT OUTPUT
    
    SELECT @Alicuota = Aliret FROM PadronC WHERE Cuitpr = @CUIT
GO

CREATE PROCEDURE sp_ValidarPadronARBA
    @Codigo VARCHAR(4),
    @Resultado VARCHAR(255) OUTPUT
AS
    DECLARE @CUIT VARCHAR(13)
    DECLARE @FechaIni DATE
    DECLARE @FechaFin DATE
    DECLARE @FechaActual DATE
    
    DECLARE @NumAux NUMERIC(8, 0)
    DECLARE @StrAux VARCHAR(8)
    
    SELECT @CUIT = ProCuit FROM Proveedores WHERE ProCodigo = @Codigo
    SET @CUIT = REPLACE(@CUIT, '-', '')
    
    IF @CUIT IS NULL
    BEGIN
        SET @Resultado = 'No se encuentra el proveedor en el sistema.'
    END
	ELSE
    BEGIN
        SELECT @FechaActual = GETDATE()
        
        SELECT @NumAux = Fecdde FROM PadronbP WHERE Cuitpr = CAST(@CUIT AS NUMERIC(11,0)) AND Regim = 'M'
		IF @NumAux IS NULL
		BEGIN
			SET @Resultado = 'No se encuentra el proveedor en el padrón.'
		END
		ELSE
		BEGIN
			SET @StrAux = RIGHT('00000000' + CAST(@NumAux AS VARCHAR), 8)
			SET @FechaIni = CAST(SUBSTRING(@StrAux, 5, 4) + '-' + SUBSTRING(@StrAux, 3, 2) + '-' + SUBSTRING(@StrAux, 1, 2) AS DATE)
			
			SELECT @NumAux = Fechta FROM PadronbP WHERE Cuitpr = CAST(@CUIT AS NUMERIC(11,0)) AND Regim = 'M'
			SET @StrAux = RIGHT('00000000' + CAST(@NumAux AS VARCHAR), 8)
			SET @FechaFin = CAST(SUBSTRING(@StrAux, 5, 4) + '-' + SUBSTRING(@StrAux, 3, 2) + '-' + SUBSTRING(@StrAux, 1, 2) AS DATE)

			IF @FechaActual >= @FechaIni AND @FechaActual <= @FechaFin
			BEGIN
				SET @Resultado = ''
			END
			ELSE
			BEGIN
				SET @Resultado = 'Fuera del rango de fechas del padrón (' + CAST(@FechaIni AS VARCHAR) + ' ' + CAST(@FechaFin AS VARCHAR) + ').'
			END
		END
    END
GO

CREATE PROCEDURE sp_ValidarPadronCABA
    @Codigo VARCHAR(4),
    @Resultado VARCHAR(255) OUTPUT
AS
    DECLARE @CUIT VARCHAR(13)
    DECLARE @FechaIni DATE
    DECLARE @FechaFin DATE
    DECLARE @FechaActual DATE
    
    DECLARE @NumAux NUMERIC(8, 0)
    DECLARE @StrAux VARCHAR(8)
    
    
    
    SELECT @CUIT = ProCuit FROM Proveedores WHERE ProCodigo = @Codigo
    SET @CUIT = REPLACE(@CUIT, '-', '')
    
    IF @CUIT IS NULL
    BEGIN
        SET @Resultado = 'No se encuentra el proveedor en el sistema.'
    END
	ELSE
    BEGIN
        SELECT @FechaActual = GETDATE()
        
        SELECT @NumAux = Fecdde FROM PadronC WHERE Cuitpr = CAST(@CUIT AS NUMERIC(11,0))
		IF @NumAux IS NULL
		BEGIN
			SET @Resultado = 'No se encuentra el proveedor en el padrón.'
		END
		ELSE
		BEGIN
			SET @StrAux = RIGHT('00000000' + CAST(@NumAux AS VARCHAR), 8)
			SET @FechaIni = CAST(SUBSTRING(@StrAux, 5, 4) + '-' + SUBSTRING(@StrAux, 3, 2) + '-' + SUBSTRING(@StrAux, 1, 2) AS DATE)
			
			SELECT @NumAux = Fechta FROM PadronC WHERE Cuitpr = CAST(@CUIT AS NUMERIC(11,0))
			SET @StrAux = RIGHT('00000000' + CAST(@NumAux AS VARCHAR), 8)
			SET @FechaFin = CAST(SUBSTRING(@StrAux, 5, 4) + '-' + SUBSTRING(@StrAux, 3, 2) + '-' + SUBSTRING(@StrAux, 1, 2) AS DATE)

			IF @FechaActual >= @FechaIni AND @FechaActual <= @FechaFin
			BEGIN
				SET @Resultado = ''
			END
			ELSE
			BEGIN
				SET @Resultado = 'Fuera del rango de fechas del padrón (' + CAST(@FechaIni AS VARCHAR) + ' ' + CAST(@FechaFin AS VARCHAR) + ').'
			END
		END
    END
GO

CREATE PROCEDURE sp_EsExento
    @Codigo VARCHAR(4),
    @Exento BIT OUTPUT
AS
	DECLARE @ID INT
	DECLARE @IngBr VARCHAR(1)
    
    SET @Exento = 'FALSE'
    SELECT @ID = ProveedorID FROM Proveedores WHERE ProCodigo = @Codigo
	IF @ID IS NOT NULL
    BEGIN
        SELECT @IngBr = ProIngbr FROM Proveedores WHERE ProCodigo = @Codigo
        IF @IngBr = 'E'
        BEGIN
            SET @Exento = 'TRUE'
        END
    END
GO