using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;

namespace CapaNegocio
{
    public class NFacturasProveedores
    {
        public static String InsertarFactura(String CodigoProveedor, String TipoFactura, String Sucursal, String Documento,
            DateTime FechaFactura, DateTime FechaCarga, DateTime Vencimiento, decimal MontoNeto, decimal MontoExento,
            decimal PorcentajeIVA, decimal MontoIVA, decimal PorcentajePercepciónIVA, decimal MontoPercepcionIVA,
            decimal PorcentajeIIBB, decimal MontoIIBB, String Material, String Provincia, bool BienDeUso, bool Activo,
            decimal Total, String Observaciones)
        {
            DFacturasProveedores ObjFacturaProveedor = new DFacturasProveedores();
            ObjFacturaProveedor._CodigoProveedor = CodigoProveedor;
            ObjFacturaProveedor._TipoFactura = TipoFactura;
            ObjFacturaProveedor._Sucursal = Sucursal;
            ObjFacturaProveedor._Documento = Documento;
            ObjFacturaProveedor._FechaFactura = FechaFactura;
            ObjFacturaProveedor._FechaCarga = FechaCarga;
            ObjFacturaProveedor._Vencimiento = Vencimiento;
            ObjFacturaProveedor._MontoNeto = MontoNeto;
            ObjFacturaProveedor._MontoExento = MontoExento;
            ObjFacturaProveedor._PorcentajeIVA = PorcentajeIVA;
            ObjFacturaProveedor._MontoIVA = MontoIVA;
            ObjFacturaProveedor._PorcentajePercepcionIVA = PorcentajePercepciónIVA;
            ObjFacturaProveedor._MontoPercepcionIVA = MontoPercepcionIVA;
            ObjFacturaProveedor._PorcentajeIIBB = PorcentajeIIBB;
            ObjFacturaProveedor._MontoIIBB = MontoIIBB;
            ObjFacturaProveedor._Material = Material;
            ObjFacturaProveedor._Provincia = Provincia;
            ObjFacturaProveedor._BienDeUso = BienDeUso;
            ObjFacturaProveedor._Activo = Activo;
            ObjFacturaProveedor._Total = Total;
            ObjFacturaProveedor._Observaciones = Observaciones;

            return ObjFacturaProveedor.Insertar();
        }
    }
}