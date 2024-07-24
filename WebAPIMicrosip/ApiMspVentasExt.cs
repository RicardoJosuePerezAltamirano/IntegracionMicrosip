using System;
using System.Runtime.InteropServices;
using System.Text;

namespace WebAPIMicrosip
{
    public class ApiMspVentasExt
    {
        //  function veGetLastErrorCode: Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int veGetLastErrorCode();

        //  function veGetLastErrorMessage(ErrorMessage: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int veGetLastErrorMessage(StringBuilder ErrorMessage);

        //  procedure veSetErrorHandling(ExceptionOnError, MessageOnException: Integer); stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern void veSetErrorHandling(int ExceptionOnError, int MessageOnException);


        //  // Funciones COMUNES
        //  function SetDBVentas(DBHandle: Integer): Integer;  stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SetDBVentas(int DBHandle);

        //  procedure AbortaDoctoVentas; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern void AbortaDoctoVentas();

        // function GetDoctoVeId(var DoctoId: Integer): Integer;  stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int GetDoctoVeId(ref int DoctoId);

        //  // Checar Compatibilidad
        //  function GetVersionApiVentasAsInteger: Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int GetVersionApiVentasAsInteger();

        //  procedure GetVersionApiVentasAsString(AVersion: PChar); stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern void GetVersionApiVentasAsString(StringBuilder AVersion);

        //  function ChecaCompatibilidadVentas(HdbMetadatos: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int ChecaCompatibilidadVentas(int HdbMetadatos);

        //  // *** Funciones principales PEDIDOS ***
        //  function NuevoPedido(Fecha, Folio: PChar; ClienteId, DirConsigId, AlmacenId: Integer;
        //    FechaEntrega, TipoDscto: PChar; Descuento: Double ; OrdenCompra, Descripcion: Pchar;
        //    VendedorId, ImptoSustituidoId, ImptoSustitutoId: Integer ): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern void SetReglasPedidos(int AComprometerUnidades, int APedidosParciales,
            int APartidasParciales);

        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int NuevoPedido(string Fecha, string Folio, int ClienteId, int DirConsigId, int AlmacenId,
          string FechaEntrega, string TipoDscto, double Descuento, string OrdenCompra, string Descripcion,
          int VendedorId, int ImptoSustituidoId, int ImptoSustitutoId, int MonedaId);

        //  function RenglonPedido(ArticuloId: Integer; Unidades, PrecioUnitario,
        //    PctjeDscto: Double ; Notas: Pchar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int RenglonPedido(int ArticuloId, double Unidades,
          double PrecioUnitario, double PctjeDscto, string Notas);


        // function RenglonPedidoDesctos(ArticuloId: Integer; Unidades, PrecioUnitario,
        //  PctjeDsctoCli, PctjeDsctoVol, PctjeDsctoPromo: Double; Notas: Pchar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int RenglonPedidoDesctos(int ArticuloId, double Unidades,
          double PrecioUnitario, double PctjeDsctoCli, double PctjeDsctoVol, double PctjeDsctoPromo, string Notas);

        //  function AplicaPedido: Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int AplicaPedido();

        //  // *** Funciones principales FACTURAS ***
        //  procedure SetReglasVentas(ExistenciasNegativas, PrecioMinimo: Integer); stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern void SetReglasVentas(int ExistenciasNegativas, int PrecioMinimo);

        //  function NuevaFactura(Fecha, Folio: PChar;
        //                        ClienteId, DirConsigId, AlmacenId: Integer;
        //                        TipoDscto: Pchar; Descuento: Double;
        //                        OrdenCompra, Descripcion: PChar;
        //                        Fletes, OtrosCargos, PctjeComis : Double;
        //                        CondPagoId, VendedorId,  ImptoSustituidoId, ImptoSustitutoId: Integer;
        //                        ImporteCobro: Double; DescripcionCobro: PChar; PLHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int NuevaFactura(string Fecha, string Folio,
                                int ClienteId, int DirConsigId, int AlmacenId,
                                string TipoDscto, double Descuento,
                                string OrdenCompra, string Descripcion,
                                double Fletes, double OtrosCargos, double PctjeComis,
                                int CondPagoId, int VendedorId, int ImptoSustituidoId, int ImptoSustitutoId,
                                double ImporteCobro, string DescripcionCobro, int PLHandle);

        //  function DirClienteFactura(DirCliId: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DirClienteFactura(int DirCliId);

        // function SetFormaCobroFactura(FormaCobroId: Integer; NumCtaPago: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SetFormaCobroFactura(int FormaCobroId, string NumCtaPago);

        //  function RenglonFactura(ArticuloId: Integer; Unidades, PrecioUnitario,
        //                          PctjeDscto: Double ; Notas: Pchar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int RenglonFactura(int ArticuloId, double Unidades, double PrecioUnitario,
                                 double PctjeDscto, string Notas);

        //  function RenglonFacturaSeries(ClaveSerie: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int RenglonFacturaSeries(string ClaveSerie);

        //  function RenglonFacturaLotes(ClaveLote: PChar; Unidades: Double ): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int RenglonFacturaLotes(string ClaveLote, double Unidades);

        //  function RenglonFacturaTercero(TerceroId: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int RenglonFacturaTercero(int TerceroId);

        //  function AplicaFactura: Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int AplicaFactura();
    }

}
