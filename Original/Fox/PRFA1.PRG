*:*****************************************************************************
*:
*: Procedure file: C:\NEWEMA\PRFA1.PRG
*:
*:      Documented 07/10/98 at 17:01               FoxDoc  version 2.10f
*:*****************************************************************************
*------------------------------------------------------
* Revisado para adaptaci¢n A¤o 2000
* Fecha: 09/09/98
* Modificado 04 2018
*------------------------------------------------------

DO panta WITH 'Gesti¢n de Facturas de Proveedores'
wtipod = 'FA'
wbienu = 'N'
wactiv = 'I'
wnuevo = .T.
wmater = 'S'
SELECT numero
SEEK 'NFOLC'
IF FOUND()
   zfecha = fecha
ENDIF
SEEK 'PORIV'
IF FOUND()
   wiva = porce
   xiva = porce
ENDIF
SEEK 'IVASE'
IF FOUND()
   wivase = porce
ENDIF
SEEK 'PORNI'
IF FOUND()
   wivani = porce
ENDIF
IF SEEK('MMPER')
   wminap = porce
ENDIF
** agrego jun15
*SEEK 'PORAP'
*IF FOUND()
*   wivaap = porce
*ENDIF
*SEEK 'PORIB'
*IF FOUND()
*   wriibb = porce
*ENDIF
**fin agregado **
**=f_open('ovtapr')	

SELECT movipr
SET ORDER TO 1
SET FILTER TO tipom = modo
wprove = SPACE(4)
sal    = .T.
wvalor = 1
DO WHILE .T.  
   wasien = SPACE(6)
   wactiv = 'I'  
   wmater = 'S'   
   wmoned = SPACE(5)
   xmoned = SPACE(3)
   wdimpo = '.'
   SELECT asient
   SET ORDER TO 1
   SET RELATION TO
   SELECT movipr
   DO clbox WITH 03,02,10,77
   @ 11,02,23,79 BOX '°°°°°°°°°'
   @ 05,02 SAY CHR(195)
   @ 05,03 TO 05,76
   @ 05,77 SAY CHR(180)
   @ 04,04 SAY 'Proveedor:                                       Fact.< >:               '
   @ 06,04 SAY 'Fecha Factura:            Fecha Carga:            Vencimiento:           '
   @ 07,04 SAY 'Neto:              IVA(     )%:            Exento:            Material:  '
*   @ 08,04 SAY 'Perc.IVA(     )%:           Pcia:                  IIBB(     )%:         '
   @ 08,04 SAY 'Perc.IVA(     )%:           IIBB(     )%:          Pcia:                 '
   @ 09,04 SAY 'Total:            B.de Uso <S/N>:  Activ <I/S>:   Obs:                   '
   
   DO linea24 WITH '[Esc] Salir        [] Seleccionar Proveedor'
   @ 04,15 GET wprove PICTURE '@!' VALID (f_e(15,05,15,'PROVEE',' ','wprove','PROVE','NOMBR','C',30,'1','2','V','M',.T.,2,'pb'))
   READ
   IF LASTKEY() = 27
      EXIT
   ENDIF
   DO linea24 WITH '[Esc] Salir'
  
   SELECT provee
   SEEK wprove
   IF EOF()
      DO mensa2 WITH '­ Proveedor Inexistente !'
      LOOP
   ENDIF
   IF servi = 'S'
      wiva = wivase
   ENDIF
** ago2015 **   
   wdespa = provee.despa
   IF  wdespa = 'S' 
	   @ 09,04 SAY 'Total:            B.de Uso <S/N>:  Activ <I/S>:  Des.Imp:                '
   ELSE
   	   @ 09,04 SAY 'Total:            B.de Uso <S/N>:  Activ <I/S>:   Obs:                   '
   ENDIF	  
**   
   @ 04,20 SAY nombr COLOR +W
   IF nombr = SPACE(30) .OR. cuit = SPACE(15) .OR. ningb = SPACE(15) .OR. civa = SPACE(1) .OR. DIREC = SPACE(30)
      DO mensa2 WITH '­ Faltan Datos de Proveedor !'
      LOOP
   ENDIF

   wingbr = SPACE(15)
   SELECT provee
   wnombr = nombr
   wciva  = civa
   
**agrego jun 15   
   wingbr = ningb
** fin agregado **
   
   DO CASE
   CASE wciva = 'I'
      wtipof = 'A'
      wiva = xiva
   CASE wciva = 'N'
      wtipof = 'C'
      wiva = 0
   CASE wciva = 'E' .OR. wciva = 'M'
      wtipof = 'C'
      wiva = 0
   CASE wciva = 'X'
      wtipof = ' '
      wiva = 0
   ENDCASE
   
   @ 04,59 GET wtipof PICTURE '@M A,B,C, '
   ON KEY=315 DO nsucu
   READ
   IF LASTKEY()=27
      LOOP
   ENDIF
   wsucur='0000'
   wdocum = SPACE(8)
   wkk = .F.
   DO linea24 WITH '<F1>=Ingresa Sucursal                                              Esc=Salir'
   @ 04,63 SAY wsucur COLOR N/W
** modif abr2018** para Proveed del exterior
** IF wprove >= '8001' AND wprove <= '8499'
   IF wprove >= '8001' AND wprove <= '9999'   
   	   @ 04,68 GET wdocum PICTURE '@!'	   
   ELSE	   
	   @ 04,68 GET wdocum PICTURE '99999999' VALID(!EMPTY(wdocum))      	   
   ENDIF   
**fin modif
   
   ON KEY=315 DO nsucu
   READ
   ON KEY
   DO linea24 WITH ''
   IF LASTKEY()=27
      LOOP
   ENDIF

   wdocum = ceros(wdocum,8)   

   @ 04,68 SAY wdocum COLOR N/W
   SELECT movipr
   SET ORDER TO 1
   SEEK wprove+wtipod+wsucur+wdocum
   IF .NOT. EOF()
      nuevo = .F.
      wbienu = IIF(bienu,'S','N')
      wmater = mater
      wactiv = ACTIV
      IF ok<>' '
         wkk = .T.
      ENDIF
      SCATTER MEMVAR
      IF m.miva = 0
         wiva = 0
      ELSE
         wiva = ROUND(m.miva/m.mneto*100,2)
      ENDIF
      SET COLOR TO +W
      @ 04,59 SAY tipof
      @ 06,19 SAY fecha
      @ 06,43 SAY feciv
      @ 06,67 SAY venci
      @ 07,10 SAY mneto PICTURE '@B #######.##'
      @ 07,27 SAY wiva  PICTURE '@B ##.##'
      @ 07,36 SAY miva  PICTURE '@B ######.##'
      @ 07,55 SAY mexen PICTURE '@B #######.##'
      @ 07,75 SAY wmater
** agrego jun15 **      
      IF mivap = 0
      	wivaap = 0
      ELSE
        wivaap = pivap
      ENDIF
      @ 08,13 SAY wivaap  PICTURE '@B ##.##'  
	  @ 08,22 SAY mivap  PICTURE '@B ######.##'
      IF miibb = 0
      	 wriibb = 0
      ELSE
         wriibb = pribr
      ENDIF      	  
      @ 08,37 SAY wriibb  PICTURE '@B ##.##'  
	  @ 08,45 SAY miibb   PICTURE '@B ######.##'          	            
      @ 08,60 SAY provi  COLOR i	  
      SELECT tablac
      IF ALLTRIM(wingbr) <> 'EXENTO'
         SEEK 'PV'+provi
         IF FOUND()
            @ 08,62 SAY LEFT(tablac.descr,15) COLOR i
         ELSE
            @ 08,62 SAY '               ' COLOR i
         ENDIF
      ENDIF	           	            
** fin agregado **	  

      @ 09,11 SAY (mneto + miva + mexen + mivap + miibb) PICTURE '@B #######.##'
      @ 09,37 SAY wbienu
      @ 09,51 SAY wactiv
*      
   IF  wprove >= '8000' AND wprove <= '8590'
      @ 09,61 SAY dimpo
   ELSE
      @ 09,57 SAY obser 
   ENDIF	      
*   
      SET COLOR TO
      
** Proceso Suspendido **
*	  wtotf = mneto + miva + mexen	
*	  wtot  = 0
*  	  CREATE CURSOR temp (ordve C(10),impor N(11,2))
  	  
* 	  SELECT ovtapr 
* 	  SET ORDER TO 2
* 	  wclave = wprove+wtipod+wsucur+wdocum
* 	  xclave = SPACE(18)
*      SEEK wclave
*      IF FOUND()
*	  DO WHILE !EOF()
*		IF wclave = prove+tipod+sucur+docum
*	       	xclave = wclave
*	       	wnuevo = .F.
*	       	EXIT
*	     ELSE
*	     	SELECT ovtapr
*	     	SKIP
*	     ENDIF
*	  ENDDO
*	  ENDIF	  
*      DO WHILE !EOF() .AND. wclave = xclave	 
*      	SELECT temp
*      	APPEND BLANK
*      	REPLACE ordve WITH ovtapr.ordve,impor WITH ovtapr.impov
*      	SELECT ovtapr
*      	SKIP
*      	xclave = prove+tipod+sucur+docum
*      ENDDO
*      SELECT temp
*      GO TOP             
*   DO WHILE .T.
*   	  IF wnuevo
*   	  	APPEND BLANK
*   	  ENDIF
*      DEFINE WINDOW wi FROM 10,27 TO 18,51 COLOR SCHEME 10
*
*      DO linea24 WITH 'F1=Seleccionar'+SPACE(12)+'F9=Borrar Rengl¢n'+SPACE(12)+'Esc=Salir'
*      ON KEY LABEL f1 DO consov
*      ON KEY LABEL dnarrow DO agrega_r
*      ON KEY LABEL f9 DO borra_o
	  
*      @ 22,40 SAY ' Total:                         '
*      @ 22,57 SAY wtotf COLOR W+
      
*	  BROWSE FIELDS;
*          ordve :P = '@!'                :H = '   Obra   '  :V = f_ovta(),;
*          impor :P = '@Z #######.##'     :H = '  Importe '  :V = f_tot() ;             
*		  TITLE ' ' ;
*          NODELETE ;
*          WINDOW wi	      
*      ON KEY
*      RELEASE WINDOW wi
*	  DO linea24 WITH ''

*      IF wtotf <> wtot  .AND. wnuevo             
*		 wtotm = wtotf - wtot		
*         aa = 'Confirmar'
*         = f_conf1()
*         IF aa = 'Modificar'
*            LOOP
*         ENDIF
*         IF aa = 'Salir    '
*         	sal = .F.
*            EXIT
*         ENDIF
*         EXIT
*      ELSE
*         aa = 'Confirmar'
*         = f_conf1()
*         IF aa = 'Modificar'
*            LOOP
*         ENDIF
*         IF aa = 'Salir    '
*         	sal = .F.
*            EXIT
*         ENDIF            
*         EXIT
*      ENDIF    
*      IF LASTKEY() = 27
*	     EXIT
*	  ENDIF                
*   ENDDO

*	SELECT temp
*	INDEX ON ordve TO SYS(3)	
*	GO TOP	
*	DO WHILE !EOF() .and. sal
*		IF LASTKEY()=27
*		  	EXIT
*		ENDIF
*		IF temp.impor <> 0
*			SELECT ovtapr
*			SET ORDER TO 3
*			SEEK wclave+temp.ordve
*			IF !FOUND()
*				APPEND BLANK
*				REPLACE tipod WITH wtipod,sucur WITH wsucur,docum WITH wdocum
*				REPLACE prove WITH wprove						
*			ENDIF
*			REPLACE fecha WITH m.fecha
*			REPLACE ordve WITH IIF(temp.ordve = SPACE(10),'XXXX',temp.ordve)
*			REPLACE impov WITH IIF(temp.ordve = SPACE(10),(m.mneto+m.miva+m.mexen)-temp.impor,temp.impor)
*			REPLACE impfp WITH m.mneto + m.miva + m.mexen
*		ENDIF
*		SELECT temp
*		SKIP
*		wtotf = m.mneto + m.miva + m.mexen
*		IF EOF() AND (wtot <> wtotf .OR. wnuevo) AND wtot <> 0
*            xtotm = wtotf - wtot
*			SELECT ovtapr
*			APPEND BLANK
*			REPLACE tipod WITH wtipod,sucur WITH wsucur,docum WITH wdocum
*			REPLACE prove WITH wprove,fecha WITH m.fecha
*			REPLACE ordve WITH 'XXXX'
*			REPLACE impov WITH xtotm
*			REPLACE impfp WITH m.mneto + m.miva + m.mexen				
*			EXIT
*		ENDIF
*	ENDDO   	
*************           
      SELECT cuenta
      SET ORDER TO 1
      SELECT asient
      SET ORDER TO 1
      SET RELATION TO cuent INTO cuenta ADDITIVE
      SELECT asient
      SET ORDER TO 2
      SEEK wprove + wtipod + wsucur + wdocum + 'MOVIPR'
      IF FOUND()
         wasien = asien
         
         *Situación Ormetal RNE 26/05/2008 - Detalle: asiento no visible en factura proveedores
         IF asient.asien = "210984"
         wasien = asien
         ENDIF
         ***************************************************************************************
         
         
      ELSE
         DO mensa2 WITH '­ No Se Encontr¢ Asiento !'
         LOOP
      ENDIF
      SET ORDER TO 1
      DO clbox WITH 11,02,15,77
      @ 12,03 SAY ' Asiento Nro:               * LIBRO DIARIO *              Fecha:          '
      @ 13,03 SAY ' Observaciones:                                                           '
      @ 14,52 SAY ' Moneda de Origen: '
      
      ban = .F.
      @ 12,17 SAY wasien COLOR N/W
      SELECT asient
      SEEK wasien
      IF .NOT. EOF()
         IF anula
            DO mensa2 WITH '­ Asiento Anulado !'
            LOOP
         ENDIF
         wfecha = fecha
         wgloba = globa
         wtipo  = tipo
         atipod = tipod
         asucur = sucur
         adocum = docum
         warchi = archi
         wcompr = COMPR
         wcodig = codig
         wanula = anula
         wmoned = IIF(asient.moned='EUR','EURO ',IIF(asient.moned='PES','PESOS',IIF(asient.moned='   ','PESOS','DOLAR')))      
         
         @ 12,17 SAY wasien COLOR +W
         @ 12,68 SAY wfecha COLOR +W
         IF wfecha >= cfecha
            USE data\cuenue IN 6 INDEX data\cuenue  ORDER 1  ALIAS cuenta
         ELSE
            USE data\cuenta IN 6 INDEX data\cuenta  ORDER 1  ALIAS cuenta
         ENDIF
         SELECT asient
         SET RELATION TO cuent INTO cuenta ADDITIVE
      ENDIF
      @ 13,19 SAY wgloba PICTURE '@!' COLOR +W
      @ 14,71 SAY wmoned PICTURE '@!' COLOR +W
      wacud=0
      wacuh=0
      SELECT tmp
      ZAP
      SELECT asient
      SEEK wasien
      IF .NOT. EOF()
         DO WHILE asien = wasien
            SELECT tmp
            APPEND BLANK
            REPLACE cuent WITH asient->cuent
            IF asient->tipo = 'D'
               REPLACE canti WITH asient->impor
               wacud=wacud+canti
            ELSE
               REPLACE deuda WITH asient->impor
               wacuh=wacuh+deuda
            ENDIF
            SELECT asient
            SKIP
         ENDDO
      ENDIF
      SELECT tmp
      GO TOP
      SET RELATION TO cuent INTO cuenta
      DEFINE WINDOW wi FROM 15,02 TO 22,77 COLOR SCHEME 10
      DO linea24 WITH 'Esc=Salir'
      @ 23,23 SAY ' TOTAL .........:               '
      @ 23,41 SAY wacud PICTURE '##########.##' COLOR +W
      @ 23,54 SAY wacuh PICTURE '##########.##' COLOR +W
      BROWSE FIELDS ;
         cuent  :R  :p = '999999' :H = 'Cuenta' , ;
         des = cuenta.descr :H = 'Descripci¢n', ;
         canti  :R :p = '@Z #########.##' :H = 'Debe' , ;
         deuda  :R :p = '@Z #########.##' :H = 'Haber' ;
         TITLE ' ' ;
         WINDOW wi
      ON KEY
      DO linea24 WITH ''
      RELEASE WINDOW wi
      @ 11,00,23,80 BOX '°°°°°°°°°'
      SELECT tmp
      ZAP
      SELECT asient
      SET ORDER TO 1
      SET RELATION TO
      DO mensa1 WITH 'Modifique o Presione <F9> para Borrar Factura ...'
      ACTIVATE SCREEN
      borra = .F.
      ON KEY LABEL f9 DO borra
**      @ 06,19 GET m.fecha VALID(f00(m.fecha) .AND. m.fecha <= DATE())
      @ 06,19 GET m.fecha Valid(F00(m.fecha) .AND. fv_con() .AND. m.fecha <= DATE())
      READ
      ON KEY
      DO linea24 WITH ''
      DO mensa1 WITH ''
      IF LASTKEY() = 27
         LOOP
      ENDIF
      IF wkk
         DO mensa2 WITH '­ Factura con Pagos Realizados !'
      ENDIF
      IF borra
         IF sino('¨ Borra Factura ?  Si/No:','Si')
            SELECT movipr
            SEEK wprove+wtipod+wsucur+wdocum
            IF .NOT. EOF()
               REPLACE docum WITH '??????'
               DELETE
               SELECT asient
               SET ORDER TO 2
               SEEK wprove+wtipod+wsucur+wdocum
               IF .NOT. EOF()
                  wasien=asien
               ENDIF
               SET ORDER TO 1
               SEEK wasien
               DO WHILE (.NOT. EOF()) .AND. wasien=asien
                  REPLACE anula WITH .T. , sucur WITH '????'
                  SKIP
               ENDDO
            ENDIF

**			SELECT ovtapr
**			SET ORDER TO 2
**			wclave = wprove+wtipod+wsucur+wdocum
**			SEEK wclave
**	        IF !EOF()
**	        	xclave = wclave
**	        ENDIF
**	        DO WHILE !EOF() .AND. wclave = xclave
**				DELETE
**				SKIP
**				xclave = prove+tipod+sucur+docum
**			ENDDO				
            
         ENDIF
*        LOOP
		 EXIT
      ENDIF
      IF !wkk .OR. m.feciv <= zfecha
         @ 07,75 GET wmater PICTURE '@M S,N'
*** agrego jun15
      @ 08,13 GET wivaap  PICTURE '@B ##.##'  
	  @ 08,22 GET mivap   PICTURE '@B ######.##'

      @ 08,37 GET wriibb  PICTURE '@B ##.##'  
	  @ 08,45 GET miibb   PICTURE '@B ######.##'          	            

   IF ALLTRIM(wingbr) <> 'EXENTO' AND miibb <> 0
      SELECT tablac
      DO linea24 WITH 'F1=Seleccionar'
      ON KEY LABEL f1 DO elige WITH 'prcia'
      @ 08,60 GET provi PICTURE '!' VALID (exis('PV'+provi,'! Provincia Inexistente !'))
      READ

      IF LASTKEY() = 27
         ON KEY
         DO linea24 WITH ''
         LOOP
      ENDIF

      @ 08,60 SAY provi COLOR i
      @ 08,62 SAY LEFT(descr,15) COLOR i
   ENDIF
   
** fin agregado         
         @ 09,37 GET wbienu PICTURE '@M N,S'
         @ 09,51 GET wactiv PICTURE '@M I,S'
*      
 	   IF  wprove >= '8000' AND wprove <= '8590'
    	  @ 09,61 GET m.dimpo PICTURE '@!'
	   ELSE
	   	  m.dimpo = wdimpo
       	  @ 09,57 GET m.obser PICTURE '@!'
	   ENDIF	      
*           
         READ
         IF LASTKEY() = 27
            LOOP
         ENDIF        
****
&& Pregunta para cargar el bien en la base de Bienes de Usos
If wbienu = 'S'
	DO abm_bien With 1
Endif
****         
         IF sino('¨ Confirma ?  Si/No:','Si')
            SELECT movipr
            REPLACE bienu WITH IIF(wbienu='S',.T.,.F.)
*      
	 	    IF  wprove >= '8000' AND wprove <= '8590'
    	        REPLACE dimpo WITH m.dimpo
		    ELSE
		    	m.dimpo = wdimpo
    	        REPLACE obser WITH m.obser,dimpo WITH m.dimpo
		    ENDIF	      		    
            REPLACE ACTIV WITH wactiv,mater WITH wmater     
            LOOP
         ENDIF
      ENDIF
   ELSE
      nuevo = .T.
      SCATTER MEMVAR BLANK
      m.fecha = DATE()
**      @ 06,19 GET m.fecha VALID(f00(m.fecha) .AND. m.fecha <= DATE())
      @ 06,19 GET m.fecha Valid(F00(m.fecha) .AND. fv_con() .AND. m.fecha <= DATE())
      READ
 
      IF LASTKEY() =27
         LOOP
      ENDIF
      m.feciv = m.fecha
   ENDIF
   
   IF !wkk
      DO WHILE .T.
         @ 06,43 GET m.feciv VALID(f00(m.feciv) .AND. m.feciv <= DATE())
         READ
         IF LASTKEY() =27
            EXIT
         ENDIF
         IF m.feciv <= zfecha
            DO mensa2 WITH '­ Fecha Corresponde a Per¡odo Cerrado !'
            LOOP
         ENDIF
         IF m.feciv <> m.fecha
            IF m.feciv < m.fecha
               DO mensa2 WITH '­ La Fecha de Carga no puede ser menor a la Fecha de la Factura !'
               LOOP
            ENDIF
            IF DAY(m.feciv) <> 1
               DO mensa2 WITH '­ El d¡a debe ser 01 !'
               LOOP
            ENDIF
            IF YEAR(m.feciv) = YEAR(m.fecha)
               IF MONTH(m.feciv) < MONTH(m.fecha)
                  DO mensa2 WITH '­ El Mes debe ser mayor al de la Fecha de la Factura !'
                  LOOP
               ENDIF
            ENDIF
         ENDIF
         EXIT
      ENDDO
      IF LASTKEY() = 27
         LOOP
      ENDIF
   ENDIF
   IF EMPTY(m.venci)
*      m.venci = m.fecha + 30
**	   m.venci = m.fecha 		&& modif 26may14
      m.venci = m.fecha + 45	   
   ENDIF
   @ 06,67 GET m.venci VALID(f00(m.venci))
   READ
   IF LASTKEY() = 27 .OR. m.venci = CTOD('  /  /  ')
      LOOP
   ENDIF
   DO WHILE m.fecha > m.venci
      DO mensa2 WITH '­ Fecha de Vencimiento Anterior a Fecha de Factura !'
      @ 06,67 GET m.venci VALID(f00(m.venci))
      READ
      LOOP
   ENDDO
   DO linea24 WITH ''
   
   IF !wkk
      @ 07,10 GET m.mneto PICTURE '#######.##'
      READ
      IF LASTKEY()=27
         LOOP
      ENDIF
      m.miva = ROUND(m.mneto * wiva / 100,2)
      @ 07,36 SAY m.miva PICTURE '@B ######.##' COLOR +W
      @ 09,11 SAY (m.mneto + m.miva + m.mexen + m.mivap + m.miibb) PICTURE '@B #######.##' COLOR +W
      
      @ 07,27 GET wiva PICTURE '##.##'
      READ
      IF LASTKEY()=27
         LOOP
      ENDIF
      m.miva = ROUND(m.mneto * wiva / 100,2)
      @ 07,36 SAY m.miva PICTURE '@B ######.##' COLOR +W
      @ 09,11 SAY (m.mneto + m.miva + m.mexen + m.mivap + m.miibb) PICTURE '@B #######.##' COLOR +W
      @ 07,36 GET m.miva PICTURE '######.##' VALID(m.miva <= m.mneto)
      READ
      IF LASTKEY()=27
         LOOP
      ENDIF
      IF m.miva = 0
         wiva = 0
      ELSE
         wiva = ROUND(m.miva/m.mneto*100,2)
      ENDIF
      @ 07,27 SAY wiva PICTURE '##.##' COLOR i
      @ 09,11 SAY (m.mneto + m.miva + m.mexen + m.mivap + m.miibb) PICTURE '@B #######.##' COLOR +W
      @ 07,55 GET m.mexen PICTURE '#######.##'
      READ      
      IF LASTKEY()=27
         LOOP
      ENDIF
      @ 07,75 GET wmater PICTURE '@M S,N'
      @ 09,11 SAY (m.mneto + m.miva + m.mexen + m.mivap + m.miibb) PICTURE '@B #######.##' COLOR +W

*** agrego jun15
      @ 08,13 GET m.pivap  PICTURE '@B ##.##'  
      READ
      IF LASTKEY()=27
         LOOP
      ENDIF
      m.mivap = ROUND(m.mneto * m.pivap / 100,2)
      
	  @ 08,22 GET m.mivap  PICTURE '@B ######.##' COLOR +W
	  READ
*	  
      IF m.mivap = 0
         m.pivap = 0
      ELSE
         m.pivap = ROUND(m.mivap/m.mneto*100,2)
      ENDIF
      @ 08,13 SAY m.pivap  PICTURE '@B ##.##'  
*	  
      @ 09,11 SAY (m.mneto + m.miva + m.mexen + m.mivap + m.miibb) PICTURE '@B #######.##' COLOR +W  

      @ 08,37 GET m.pribr  PICTURE '@B ##.##'  
      READ
      IF LASTKEY()=27
         LOOP
      ENDIF
      m.miibb = ROUND(m.mneto * m.pribr / 100,2)
            
	  @ 08,45 GET m.miibb   PICTURE '@B ######.##' COLOR +W         	               
	  READ
*	  
      IF m.miibb = 0
         m.pribr = 0
      ELSE
         m.pribr = ROUND(m.miibb/m.mneto*100,2)
      ENDIF
      @ 08,37 SAY m.pribr  PICTURE '@B ##.##'  
*	  
      @ 09,11 SAY (m.mneto + m.miva + m.mexen +m.mivap +m.miibb) PICTURE '@B #######.##' COLOR +W
   IF ALLTRIM(wingbr) <> 'EXENTO' AND m.miibb <> 0
      SELECT tablac
      set orde to 1
      go top
      DO linea24 WITH 'F1=Seleccionar'
      ON KEY LABEL f1 DO elige WITH 'prcia'
      @ 08,60 GET provi PICTURE '!' VALID (exis('PV'+provi,'! Provincia Inexistente !'))
      READ
      
      IF LASTKEY() = 27
         ON KEY
         DO linea24 WITH ''
         LOOP
      ENDIF
      @ 08,60 SAY provi COLOR i
      @ 08,62 SAY LEFT(descr,15) COLOR i
   ENDIF	  
** fin agregado        
   ENDIF
   
** agrego para modificar aunque haya pagos realizados 05/2014**
   @ 07,75 GET wmater PICTURE '@M S,N'
**      
   @ 09,37 GET wbienu PICTURE '@M N,S'
   @ 09,51 GET wactiv PICTURE '@M I,S'
*jul 2015       
   IF  wprove >= '8000' AND wprove <= '8590'
       @ 09,61 GET m.dimpo PICTURE '@!'
   ELSE
   	   m.dimpo = wdimpo
       @ 09,57 GET m.obser PICTURE '@!'
   ENDIF	      
*                 
   READ
   IF LASTKEY() = 27
      LOOP
   ENDIF  

&& Pregunta para cargar el bien en la base de Bienes de Usos
If wbienu = 'S'
	DO abm_bien With 1
Endif
****           
   IF .NOT. sino('¨ Confirma ?  Si/No:','Si')
      LOOP
   ENDIF
   IF wkk
      SELECT movipr
      REPLACE bienu WITH IIF(wbienu='S',.T.,.F.)
*jul 2015      
	  IF  wprove >= '8000' AND wprove <= '8590'
            REPLACE dimpo WITH m.dimpo
	  ELSE
	    	m.dimpo = wdimpo
            REPLACE obser WITH m.obser,dimpo WITH m.dimpo
	  ENDIF	      
      REPLACE ACTIV WITH wactiv,mater WITH wmater     
      LOOP
   ENDIF    

*** Proceso suspendido hasta nuevo aviso ***
*	  CREATE CURSOR temord (ordve C(10),impor N(11,2))
	  
*      DO linea24 WITH '[Esc] Salir'
*	  wtot  = 0
*	  wtotf = m.mneto + m.miva + m.mexen	  
*      wclave= m.prove + m.tipod + m.sucur + m.docum
*	DO WHILE .T. 
* 	  SELECT temord
*      APPEND BLANK            
*      DEFINE WINDOW wi FROM 10,27 TO 18,51 COLOR SCHEME 10
*	  DO linea24 WITH 'F1=Seleccionar'+SPACE(15)+'Esc=Salir'
*      ON KEY LABEL f1 DO consov
*      ON KEY LABEL dnarrow DO agrega_r
	  
*      @ 22,40 SAY ' Total:                         '
*      @ 22,57 SAY wtot COLOR W+
   
*      BROWSE FIELDS;
*             ordve :P = '@!'                :H = '   Obra   '  :V = f_ovta(),;
*             impor :P = '@Z #######.##'     :H = '  Importe '  :V = f_tot() ;             
*		     TITLE ' ' ;
*             NODELETE ;
*             WINDOW wi
*      ON KEY
*      RELEASE WINDOW wi
*	  DO linea24 WITH ''
*      IF wtotf <> wtot  AND wtot <> 0
*		 wtotm = wtotf - wtot
*         aa = 'Confirmar'
*         = f_conf1()
*         IF aa = 'Modificar'
*            LOOP
*         ENDIF
*         IF aa = 'Salir    '
*         	sal = .F.
*            EXIT
*         ENDIF
*         EXIT
*      ELSE
*         aa = 'Confirmar'
*         = f_conf1()
*         IF aa = 'Modificar'
*            LOOP
*         ENDIF
*         IF aa = 'Salir    '
*         	sal = .F.
*            EXIT
*         ENDIF
*         EXIT
*      ENDIF    
*      IF LASTKEY() = 27
*	     EXIT
*	  ENDIF                      
*	ENDDO	
	
*	SELECT temord
*	INDEX ON ordve TO SYS(3)	
*	GO TOP	
*	DO WHILE !EOF() .and. sal
*		SELECT ordven
*		SET ORDER TO 1
*		GO TOP
*		SEEK temord.ordve
*		IF !FOUND() .AND. (temord.ordve <> SPACE(10) .OR. temord.ordve <> 'XXXX') 
*			IF LASTKEY()=27
*				EXIT
*			ENDIF
*			DO mensa2 WITH 'No Existe Orden de Venta '+temord.ordve+'...'
*			LOOP
*		ENDIF
*		IF temord.impor <> 0
*			SELECT ovtapr
*			APPEND BLANK
*			REPLACE tipod WITH wtipod,sucur WITH wsucur,docum WITH wdocum,fecha WITH m.fecha
*			REPLACE prove WITH wprove,ordve WITH IIF(temord.ordve = SPACE(10),'XXXX',temord.ordve)
*			REPLACE impov WITH IIF(temord.ordve = SPACE(10),(m.mneto+m.miva+m.mexen)-temord.impor,temord.impor)
*			REPLACE impfp WITH wtotf
*		ENDIF
*		SELECT temord
*		SKIP
*		wtotf = m.mneto + m.miva + m.mexen
*		IF EOF() AND (wtot <> wtotf AND wtot <> 0)
*            xtotm = wtotf - wtot
*			SELECT ovtapr
*			APPEND BLANK
*			REPLACE tipod WITH wtipod,sucur WITH wsucur,docum WITH wdocum
*			REPLACE prove WITH wprove,fecha WITH m.fecha
*			REPLACE ordve WITH 'XXXX'
*			REPLACE impov WITH xtotm
*			REPLACE impfp WITH m.mneto + m.miva + m.mexen				
*			EXIT
*		ENDIF		
*	ENDDO
*********   
   SELECT cuenta
   SET ORDER TO 1
   SELECT asient
   SET ORDER TO 1
   SET RELATION TO cuent INTO cuenta ADDITIVE
   DO WHILE .T.
      IF nuevo
         wasien = SPACE(6)
      ELSE
         SELECT asient
         SET ORDER TO 2
         SEEK wprove + wtipod + wsucur + wdocum + 'MOVIPR' + wtipof
         IF FOUND()
            wasien = asien
         ELSE
            DO mensa2 WITH '­ No Se Encontr¢ Asiento !'
            DO mensa2 WITH '­ Imposible Modificar Datos B sicos de la Factura !'
            SET ORDER TO 1
            EXIT
         ENDIF
         SET ORDER TO 1
      ENDIF
      DO clbox WITH 11,02,15,77
      @ 12,03 SAY ' Asiento Nro:               * LIBRO DIARIO *              Fecha:          '
      @ 13,03 SAY ' Observaciones:                                                           '
      @ 14,52 SAY ' Moneda de Origen: '

      ban = .F.
      @ 12,17 SAY wasien COLOR N/W
      SELECT asient
      SEEK wasien
      IF .NOT. EOF()
         IF anula
            DO mensa2 WITH '­ Asiento Anulado !'
            LOOP
         ENDIF
         wfecha = fecha
         wgloba = globa
         wtipo  = tipo
         atipof = tipof
         atipod = tipod
         asucur = sucur
         adocum = docum
         warchi = archi
         wcompr = COMPR
         wcodig = codig
         wanula = anula
         wmoned = IIF(asient.moned='EUR','EURO ',IIF(asient.moned='PES','PESOS',IIF(asient.moned='   ','PESOS','DOLAR')))      
         
         @ 12,17 SAY wasien COLOR N/W
         @ 12,68 SAY wfecha
         IF wfecha >= cfecha
            USE data\cuenue IN 6 INDEX data\cuenue  ORDER 1  ALIAS cuenta
         ELSE
            USE data\cuenta IN 6 INDEX data\cuenta  ORDER 1  ALIAS cuenta
         ENDIF
         SELECT asient
         SET RELATION TO cuent INTO cuenta
      ELSE
         atipof = wtipof
         atipod = wtipod
         asucur = wsucur
         adocum = wdocum
         wfecha = m.feciv
         wgloba=SPACE(50)
         wtipo=SPACE(1)
         warchi = 'MOVIPR'
         wcompr = SPACE(8)
         wcodig = wprove
         wanula = .F.
         @ 12,68 GET wfecha VALID(f00(wfecha))
         READ
         IF LASTKEY()=27
            EXIT
         ENDIF
         IF wfecha >= cfecha
            USE data\cuenue IN 6 INDEX data\cuenue  ORDER 1  ALIAS cuenta
         ELSE
            USE data\cuenta IN 6 INDEX data\cuenta  ORDER 1  ALIAS cuenta
         ENDIF
         SELECT asient
         SET RELATION TO cuent INTO cuenta
      ENDIF
      @ 13,19 GET wgloba PICTURE '@!' VALID(!EMPTY(wgloba))
      @ 14,71 GET wmoned PICTURE '@M PESOS,DOLAR,EURO '
      READ
      IF LASTKEY()=27
         LOOP
      ENDIF
      wacud=0
      wacuh=0
      SELECT tmp
      ZAP
      SELECT asient
      SEEK wasien
      IF .NOT. EOF()
         DO WHILE asien = wasien
            SELECT tmp
            APPEND BLANK
            REPLACE cuent WITH asient->cuent
            IF asient->tipo = 'D'
               REPLACE canti WITH asient->impor
               wacud=wacud+canti
            ELSE
               REPLACE deuda WITH asient->impor
               wacuh=wacuh+deuda
            ENDIF
            SELECT asient
            DELETE
            SKIP
         ENDDO
      ENDIF
      SELECT tmp
      IF EOF()
         APPEND BLANK
         REPLACE canti WITH (m.mneto + m.mexen)
         wacud=wacud+canti
         IF m.miva > 0
            APPEND BLANK
            REPLACE cuent WITH '120201'
            REPLACE canti WITH m.miva
            wacud=wacud+canti
         ENDIF
** agrego jun 15 **
         IF m.mivap > 0
            APPEND BLANK
            REPLACE cuent WITH '120228'
            REPLACE canti WITH m.mivap
            wacud=wacud+canti
         ENDIF
         IF m.miibb > 0
            APPEND BLANK
            DO CASE
            CASE provi = 'C'
            	REPLACE cuent WITH '120218'
            CASE provi = 'B'
            	REPLACE cuent WITH '120216'
            CASE provi = 'X'
            	REPLACE cuent WITH '120215'
            CASE provi = 'W'
            	REPLACE cuent WITH '120236'
            CASE provi = 'H'
            	REPLACE cuent WITH '120245'
            CASE provi = 'U'
            	REPLACE cuent WITH '120231'
            CASE provi = 'E'
            	REPLACE cuent WITH '120235'
            CASE provi = 'L'
            	REPLACE cuent WITH '120257'
            CASE provi = 'M'
            	REPLACE cuent WITH '120232'
            CASE provi = 'N'
            	REPLACE cuent WITH '120237'
            CASE provi = 'Q'
            	REPLACE cuent WITH '120242'
            CASE provi = 'R'
            	REPLACE cuent WITH '120238'
            CASE provi = 'A'
            	REPLACE cuent WITH '120248'
            CASE provi = 'J'
            	REPLACE cuent WITH '120253'
            CASE provi = 'Z'
            	REPLACE cuent WITH '120230'
            CASE provi = 'S'
            	REPLACE cuent WITH '120229'
            CASE provi = 'G'
            	REPLACE cuent WITH '120234'
            CASE provi = 'T'
            	REPLACE cuent WITH '120233'
            CASE provi = 'D'
            	REPLACE cuent WITH '120258'
            CASE provi = 'F'
            	REPLACE cuent WITH '120241'            	
            CASE provi = 'K'
            	REPLACE cuent WITH '120256'
            CASE provi = 'P'
            	REPLACE cuent WITH '120265'
            CASE provi = 'V'
            	REPLACE cuent WITH '120244'
            CASE provi = 'Y'
            	REPLACE cuent WITH '120239'
            CASE provi = '6'
            	REPLACE cuent WITH '120261'            	
        	ENDCASE            
            REPLACE canti WITH m.miibb
            wacud=wacud+canti
         ENDIF         
** fin agregado **
         APPEND BLANK
         REPLACE cuent WITH '310101'
         REPLACE deuda WITH  (m.mneto + m.miva + m.mexen + m.mivap + m.miibb)
         wacuh=wacuh+deuda
      ENDIF
      GO TOP
      SET RELATION TO cuent INTO cuenta
      DEFINE WINDOW wi FROM 15,02 TO 22,77 COLOR SCHEME 10
      DO linea24 WITH 'F1=Seleccionar'+SPACE(15)+'F9=Borrar Rengl¢n'+SPACE(15)+'Esc=Salir'
      ON KEY LABEL f1 DO consul
      ON KEY LABEL dnarrow DO agrega_r
      ON KEY LABEL f9 DO borra_r
      @ 23,23 SAY ' TOTAL .........:               '
      @ 23,41 SAY wacud PICTURE '##########.##' COLOR +W
      @ 23,54 SAY wacuh PICTURE '##########.##' COLOR +W
      BROWSE FIELDS ;
         cuent    :p = '999999' :H = 'Cuenta' :v = aaa(), ;
         des = cuenta.descr :H = 'Descripci¢n', ;
         canti  :p = '@Z #########.##' :H = 'Debe' :v = ttd(), ;
         deuda  :p = '@Z #########.##' :H = 'Haber' :v = tth() ;
         TITLE ' ' ;
         WINDOW wi
      ON KEY
      SUM FOR cuent <> SPACE(6) .AND. RIGHT(cuent,2) <> '00' canti TO wacud
      SUM FOR cuent <> SPACE(6) .AND. RIGHT(cuent,2) <> '00' deuda TO wacuh

      DO WHILE wacud <> wacuh .OR. wacud <> (m.mneto + m.miva + m.mexen + m.mivap + m.miibb)
         DO mensa2 WITH '­ Asiento Mal Confeccionado !'
         ON KEY LABEL f1 DO consul
         ON KEY LABEL dnarrow DO agrega_r
         ON KEY LABEL f9 DO borra_r
         
         BROWSE FIELDS ;
            cuent    :p = '999999' :H = 'Cuenta' :v = aaa(), ;
            des = cuenta.descr :H = 'Descripci¢n', ;
            canti  :p = '@Z #########.##' :H = 'Debe' :v = ttd(), ;
            deuda  :p = '@Z #########.##' :H = 'Haber' :v = tth() ;
            TITLE ' ' ;
            WINDOW wi
         ON KEY
         SUM FOR cuent <> SPACE(6) .AND. RIGHT(cuent,2) <> '00' canti TO wacud
         SUM FOR cuent <> SPACE(6) .AND. RIGHT(cuent,2) <> '00' deuda TO wacuh        
      ENDDO      
      DO linea24 WITH ''
      RELEASE WINDOW wi
      
      @ 21,00,23,80 BOX '°°°°°°°°°'
      SELECT tmp
      GO TOP
      wcont=0
      DO WHILE .NOT. EOF()
         IF canti <= 0 .AND. deuda <= 0
            DELETE
            SKIP
            LOOP
         ENDIF
         IF EOF('CUENTA') .OR. RIGHT(cuenta->cuent,2) = '00'
            DELETE
            SKIP
            LOOP
         ENDIF
         wcont=wcont+1
         SKIP
      ENDDO
      IF wcont = 0
         DO mensa2 WITH '­ No Hay Datos para Asiento !'
         LOOP
      ENDIF
     
      @ 11,00,23,80 BOX '°°°°°°°°°' 
      DO mensa1 WITH 'Actualizando Archivos ...'
      
      IF nuevo
         xsigue = .T.
         DO WHILE xsigue
            = f_lokea("'NASIE'")
            = f_sigue()
         ENDDO
         wasien = f_pronu("'NASIE'",6)
      ENDIF
      
      SELECT tmp
      GO TOP
      wcont = 1
      DO WHILE .NOT. EOF()
         SELECT asient
         APPEND BLANK
         REPLACE asien WITH wasien,cuent WITH tmp->cuent
         REPLACE linea WITH ceros(STR(wcont,2),2),fecha WITH wfecha
         REPLACE globa WITH wgloba,anula WITH wanula
         REPLACE tipod WITH atipod,sucur WITH asucur
         REPLACE docum WITH adocum,archi WITH warchi
         REPLACE COMPR WITH wcompr,codig WITH wcodig
         REPLACE tipof WITH atipof,moned WITH xmoned
         IF tmp->canti > 0
            REPLACE tipo WITH 'D',IMPOR WITH tmp->canti
         ELSE
            REPLACE tipo WITH 'H',IMPOR WITH tmp->deuda
         ENDIF
* agrego 07/2014 bimonetaria **
		 DO CASE
		 CASE xmoned = 'PES'
	         REPLACE asient.cotiz WITH 1
	         REPLACE asient.impex WITH asient.impor
		 CASE xmoned = 'DOL' 
			 SELECT tablac
			 SET ORDE TO 2  
   		 	 SEEK SYS(12,m.fecha)+'CZ'+'DOL'	 
			 IF !FOUND()
			      DO mensa2 WITH '­ Debe Ingresar Cotizaci¢n de Moneda a Fecha de Factura !'
			 	DO WHILE wvalor = 1
        	      ACTIVATE WINDOW mensa1
            	  ? CHR(7)
	              @ 00,05 SAY 'Ingrese Cotizaci¢n de Moneda : ' GET wvalor PICTURE '@Z 999999.99999' VALID((wvalor > 1) and !EMPTY(wvalor))
    	          READ
        	      DEACTIVATE WINDOW mensa1
        	      IF wvalor > 1
        	      	EXIT
			      ENDIF
			    ENDDO
			                   
				  SELECT asient
		          REPLACE asient.cotiz WITH wvalor
	    	      REPLACE asient.impex WITH ROUND(asient.impor * wvalor,2)

	              SELECT tablac
			      APPEND BLANK
      			  REPLACE tipod WITH 'CZ',codig WITH 'DOL',fecha WITH m.fecha,valor WITH wvalor      
			 ELSE		 
    	          REPLACE asient.cotiz WITH tablac.valor
	              REPLACE asient.impex WITH ROUND(asient.impor * tablac.valor,2)
	    	 ENDIF	
** oct 2014 **
		 CASE xmoned = 'EUR'
			 SELECT tablac
			 SET ORDE TO 2  
   		 	 SEEK SYS(12,m.fecha)+'CZ'+'EUR'	 
			 IF !FOUND()
			      DO mensa2 WITH '­ Debe Ingresar Cotizaci¢n de Moneda a Fecha de Factura !'
			 	DO WHILE wvalor = 1
        	      ACTIVATE WINDOW mensa1
            	  ? CHR(7)
	              @ 00,05 SAY 'Ingrese Cotizaci¢n de Moneda : ' GET wvalor PICTURE '@Z 999999.99999' VALID((wvalor > 1) and !EMPTY(wvalor))
    	          READ
        	      DEACTIVATE WINDOW mensa1
        	      IF wvalor > 1
        	      	EXIT
			      ENDIF
			    ENDDO
			                   
				  SELECT asient
		          REPLACE asient.cotiz WITH wvalor
	    	      REPLACE asient.impex WITH ROUND(asient.impor * wvalor,2)

	              SELECT tablac
			      APPEND BLANK
      			  REPLACE tipod WITH 'CZ',codig WITH 'EUR',fecha WITH m.fecha,valor WITH wvalor      
			 ELSE		 
    	          REPLACE asient.cotiz WITH tablac.valor
	              REPLACE asient.impex WITH ROUND(asient.impor * tablac.valor,2)
	    	 ENDIF		    	 	 
		 ENDCASE
* fin agregado **         
         SELECT tmp
         SKIP
         wcont = wcont + 1
      ENDDO
      SELECT movipr
      SEEK wprove+wtipod+wsucur+wdocum
      IF EOF()
         APPEND BLANK
         m.tipof = wtipof
         m.prove = wprove
         m.tipod = wtipod
         m.sucur = wsucur
         m.docum = wdocum
         m.tipom = .T.
      ENDIF
      m.mater = wmater
      m.bienu = IIF(wbienu='S',.T.,.F.)
      m.activ = wactiv
      m.civa  = wciva
      m.ramo  = provee.ramo
      m.servi = provee.servi
      m.agper = provee.agper
      m.cotiz = asient.cotiz
      m.moned = asient.moned
*
      IF (wiva >= 10.45 .AND. wiva <= 15.55) or ;
      	(wiva >= 9.45 .AND. wiva <= 14.55)
     		m.banco = 'S'
      ENDIF				 
               
* jul 2015 * 
*   IF wprove >= '8000' AND wprove <= '8500' AND m.dimpo = SPACE(16) AND m.sucur = wprove
*	   m.ok = .T.   	 
*   ENDIF  
*    
      GATHER MEMVAR
      DO mensa1 WITH ''
      IF nuevo
         = f_actnu("'NASIE'")
         = f_menpr('Se gener¢ Asiento N§ '+wasien)
      ENDIF
      EXIT
   ENDDO
ENDDO

USE data\cuenta IN 6 INDEX data\cuenta  ORDER 1  ALIAS cuenta

SELECT asient
SET ORDER TO 1
SET RELATION TO

SELECT movipr
SET ORDER TO 1
SET FILTER TO
**=f_close('ovtapr')
RETURN


PROCEDURE nsucu
ON KEY
wsucur=SPACE(4)
@ 04,63 GET wsucur PICTURE '9999'
READ
wsucur= ceros(wsucur,4)
@ 04,63 SAY wsucur COLOR N/W
ON KEY=315 DO nsucu
RETURN


PROCEDURE consul
ON KEY
SET BORDER TO 'Í','Í','³','³','Õ','¸','Ô','¾'
SELECT cuenta
wcuent = SPACE(6)
DEFINE POPUP elige FROM 08,07 TO 22,72 COLOR SCHEME 4 MARGIN ;
   PROMPT FIELD (cuent + '  ' + descr)
ON SELECTION POPUP elige DEACTIVATE POPUP elige
ACTIVATE POPUP elige
IF .NOT. EMPTY(PROMPT())
   wcuent = cuent
   xmoned = moned
** agrega fal 07/14 **   suspender hasta consultar con Szerman **
** si va a crear la cta en dolares para registrar la FA **
	IF wmoned <> cuenta.moned
*       wmoned = IIF(cuenta.moned='EUR','EURO ',IIF(cuenta.moned='PES','PESOS',IIF(cuenta.moned='   ','PESOS','DOLAR')))      
*   	   DO mensa2 WITH '­ La Moneda Origen para esa Cuenta es '+wmoned+' !'
	       ymoned = IIF(cuenta.moned='EUR','EURO ',IIF(cuenta.moned='PES','PESOS',IIF(cuenta.moned='   ','PESOS','DOLAR')))      
   		   DO mensa2 WITH '­ La Moneda Origen para esa Cuenta es '+ymoned+' !'   	   
*   	   xmoned = cuenta.moned 
*       wmoned = IIF(xmoned='EUR','EURO ',IIF(xmoned='PES','PESOS',IIF(xmoned='   ','PESOS','DOLAR')))        
       @ 14,71 SAY wmoned PICTURE '@!' COLOR +W   	      	   
* borrar linea siguiente si la moneda se toma de la cuenta *       
       xmoned = LEFT(wmoned,3)
	ELSE
       wmoned = IIF(cuenta.moned='EUR','EURO ',IIF(cuenta.moned='PES','PESOS',IIF(cuenta.moned='   ','PESOS','DOLAR')))      
       xmoned = cuenta.moned       
	ENDIF   
**	
ENDIF
RELEASE POPUP elige
SET ORDER TO 1
SET BORDER TO SINGLE
KEYBOARD CHR(13)
SELECT tmp
IF wcuent <> SPACE(6) .AND. RIGHT(wcuent,2) <> '00'
   REPLACE cuent WITH wcuent
ENDIF
IF RIGHT(wcuent,2)='00'
   DO mensa2 WITH '­ Cuenta No Imputable !'
   REPLACE cuent WITH SPACE(6)
*** agrega FAL 07/14 ***
ELSE
** agrega fal 07/14 **   suspnder hasta consultar con Szerman **
** si va a crear la cta en dolares para registrar la FA **
	IF wmoned <> cuenta.moned
*       wmoned = IIF(cuenta.moned='EUR','EURO ',IIF(cuenta.moned='PES','PESOS',IIF(cuenta.moned='   ','PESOS','DOLAR')))      
*	  	   DO mensa2 WITH '­ Moneda Origen para esa Cuenta es '+wmoned+' !'
       	   ymoned = IIF(cuenta.moned='EUR','EURO ',IIF(cuenta.moned='PES','PESOS',IIF(cuenta.moned='   ','PESOS','DOLAR')))      
	  	   DO mensa2 WITH '­ Moneda Origen para esa Cuenta es '+ymoned+' !'	  	   
*   	   xmoned = cuenta.moned 
*       wmoned = IIF(xmoned='EUR','EURO ',IIF(xmoned='PES','PESOS',IIF(xmoned='   ','PESOS','DOLAR')))        
       @ 14,71 SAY wmoned PICTURE '@!' COLOR +W   	   
           xmoned = LEFT(wmoned,3)
	ELSE
       wmoned = IIF(cuenta.moned='EUR','EURO ',IIF(cuenta.moned='PES','PESOS',IIF(cuenta.moned='   ','PESOS','DOLAR')))      
       xmoned = cuenta.moned
	ENDIF
***      
ENDIF
DO linea24 WITH 'F1=Seleccionar       F9=Borrar Rengl¢n       Esc=Salir'
ON KEY LABEL f1 DO consul
ON KEY LABEL dnarrow DO agrega_r
ON KEY LABEL f9 DO borra_r
RETRY


PROCEDURE agrega_r
ON KEY LABEL dnarrow
SKIP
IF EOF()
   APPEND BLANK
ENDIF
ON KEY LABEL dnarrow DO agrega_r
RETRY

PROCEDURE borra_r
REGI = RECNO()
IF DELETED()
   RECALL
   wacud = wacud + canti
   wacuh = wacuh + deuda
ELSE
   DELETE
   wacud = wacud - canti
   wacuh = wacuh - deuda
ENDIF
@ 23,41 SAY wacud PICTURE '##########.##' COLOR +W
@ 23,54 SAY wacuh PICTURE '##########.##' COLOR +W
RETRY

FUNCTION ttd
REGI = RECNO()
REPLACE deuda WITH 0
SUM ALL canti TO wacud
SUM ALL deuda TO wacuh
@ 23,41 SAY wacud PICTURE '##########.##' COLOR +W
@ 23,54 SAY wacuh PICTURE '##########.##' COLOR +W
GO REGI
RETURN .T.

FUNCTION tth
REGI = RECNO()
REPLACE canti WITH 0
SUM ALL canti TO wacud
SUM ALL deuda TO wacuh
@ 23,41 SAY wacud PICTURE '##########.##' COLOR +W
@ 23,54 SAY wacuh PICTURE '##########.##' COLOR +W
GO REGI
RETURN .T.

FUNCTION aaa
nnn = ceros(cuent,6)
REPLACE cuent  WITH nnn
IF EOF('CUENTA')
   DO mensa2 WITH '­ Cuenta Inexistente !'
   REPLACE cuent WITH SPACE(6)
** agrega fal 07/14 bimonetaria**
ELSE
** agrega fal 07/14 **   suspnder hasta consultar con Szerman **
** si va a crear la cta en dolares para registrar la FA **
	IF wmoned <> cuenta.moned
*    	   wmoned = IIF(cuenta.moned='EUR','EURO ',IIF(cuenta.moned='PES','PESOS',IIF(cuenta.moned='   ','PESOS','DOLAR')))      
*   	   DO mensa2 WITH '­ La Moneda Origen para esa Cuenta es '+wmoned+' !'
    	   ymoned = IIF(cuenta.moned='EUR','EURO ',IIF(cuenta.moned='PES','PESOS',IIF(cuenta.moned='   ','PESOS','DOLAR')))      
	       DO mensa2 WITH '­ La Moneda Origen para esa Cuenta es '+ymoned+' !'
*   	   xmoned = cuenta.moned 
*       wmoned = IIF(xmoned='EUR','EURO ',IIF(xmoned='PES','PESOS',IIF(xmoned='   ','PESOS','DOLAR')))        
       @ 14,71 SAY wmoned PICTURE '@!' COLOR +W  	   
       xmoned = LEFT(wmoned,3)
	ELSE
       wmoned = IIF(cuenta.moned='EUR','EURO ',IIF(cuenta.moned='PES','PESOS',IIF(cuenta.moned='   ','PESOS','DOLAR')))      
       xmoned = cuenta.moned
	ENDIF
***   
ENDIF
IF RIGHT(nnn,2)='00'
   DO mensa2 WITH '­ Cuenta No Imputable !'
   REPLACE cuent WITH SPACE(6)
ENDIF
RETURN .T.

FUNCTION fv_con
*return .t.
IF wciva = 'M' .AND. provee.feins >= m.fecha
   wciva = provee.aciva 
ENDIF
RETURN .T.   

*--------------------
FUNCTION f_tot
*--------------------
reg = RECNO()
wtot = 0
SUM impor FOR impor <> 0 TO wtot
@ 22,08 SAY SPACE(33)+'TOTAL:'+SPACE(25)
@ 22,49 SAY wtot PICTURE '9999999.99' COLOR +W
GO reg
RETURN .T.

*--------------------
FUNCTION f_actik
*--------------------
DO linea24 WITH '[Esc] Salir'
ON KEY LABEL dnarrow DO agrega_r
RETURN .T.

*--------------------
FUNCTION f_ovta
*--------------------
IF LASTKEY() = 28 .OR. LASTKEY() = 5
    RETURN .T.
ENDIF
SELECT ordven
SET ORDER TO 1
GO TOP
IF nuevo
	SEEK temord.ordve
	wtemp = temord.ordve
ELSE
	SEEK temp.ordve
	wtemp = temp.ordve
ENDIF
IF !FOUND() .AND. (wtemp <> SPACE(10) .OR. wtemp <> 'XXXX')
	IF LASTKEY()=27
		EXIT
	ENDIF
	DO mensa2 WITH 'No Existe Orden de Venta  '+wtemp	
	RETURN .F.
ENDIF
RETURN .T.

*---------------
PROCEDURE consov
*---------------
ON KEY
SET BORDER TO 'Í','Í','³','³','Õ','¸','Ô','¾'
SELECT ordven
wordve = SPACE(10)
DEFINE POPUP elige FROM 15,17 TO 21,59 COLOR SCHEME 4 MARGIN ;
   PROMPT FIELD (ordve + '  ' + descr)
ON SELECTION POPUP elige DEACTIVATE POPUP elige
ACTIVATE POPUP elige
IF .NOT. EMPTY(PROMPT())
   wordve = ordve
ENDIF
RELEASE POPUP elige
SET ORDER TO 1
SET BORDER TO SINGLE
KEYBOARD CHR(13)
IF nuevo 
	SELECT temord
	IF wordve <> SPACE(10) 	
	   REPLACE ordve WITH wordve	   
	ENDIF
ELSE
	SELECT temp
	REPLACE ordve WITH wordve
ENDIF
DO linea24 WITH 'F1=Seleccionar       Esc=Salir'
ON KEY LABEL f1 DO consov
ON KEY LABEL dnarrow DO agrega_r
RETRY

*-----------------
PROCEDURE borra_o
*-----------------
REGI = RECNO()
IF DELETED()
   RECALL
   wtotf = impor + wtotf
ELSE
   DELETE
   wtotf = wtotf - impor
   SELECT ovtapr
   SET ORDER TO 3
   IF nuevo
   	   SELECT temord
       DELETE
	   SELECT ovtapr
	   RETURN .T.
   ELSE   
	   SEEK wclave+temp.ordve
   ENDIF
   IF FOUND()
   		DELETE
   ENDIF
ENDIF
@ 22,40 SAY ' Total:                         '
@ 22,57 SAY wtotf COLOR W+
RETRY

*: EOF: PRFA1.PRG