using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ClassLibraryNetFramework
{
    public class Class1
    {
        public void test()
        {
            //var response = ApiMspBasicaExt.DBConnect(1, "172.24.102.190/3050:C:\\Dev\\RICARDO.FDB", "SYSDBA", "masterkey");
            var response = ApiMspBasicaExt.DBConnect(1, "172.24.102.190/3050:C:\\Microsip datos\\PRUEBAS RIVAZ.FDB", "SYSDBA", "masterkey");
            Console.WriteLine($"respuesta de la conexion de BD {response}");
            //var response = ApiMspBasicaExt.DBConnect(DB, "RICARDO.FDB", "SYSDBA", "Admin1234$");
            Console.WriteLine($"respuesta de la conexion de BD {response}");
            var responseInventarios = ApiMspVentasExt.SetDBVentas(1);
            Console.WriteLine($"respuesta de la conexion a ventas de BD {responseInventarios}");
            var responsehead = ApiMspVentasExt.NuevoPedido("11/09/2024", "P11092024", 306647, 0, 237259, "11/09/2024", "I", 0, "OrdenT01", "prueba de pedido desde api",0, 0, 0, 0);
            Console.WriteLine($"respuesta de creacion de pedidos  {responsehead}");
            int documentoId = 0;
            ApiMspVentasExt.GetDoctoVeId(ref documentoId);
            Console.WriteLine($"id de la venta procesada en este momento {documentoId}");
            var responseline = ApiMspVentasExt.RenglonPedidoDesctos(12160, 1, -1, -1, -1, -1, "prueba");
            Console.WriteLine($"respuesta de creacion de renglon {responseline}");
            var responseaplicar = ApiMspVentasExt.AplicaPedido();
            Console.WriteLine($"respuesta de aplicacion de pedido {responseaplicar}");


            Console.WriteLine("NUEVA FACTURA");
            ApiMspVentasExt.NuevaFactura("11/09/2024", "F11092024", 306647, 0, 237259, "P", 0, "OrdenT01", "prueba de factura desde api", 10, 0, -1, 0, 0, 0, 0, -1, "factura de prueba", -1);
            ApiMspVentasExt.RenglonFactura(12160, 1, -1, -1, "producto de prueba");
            var responseaplicarfactura = ApiMspVentasExt.AplicaFactura();
            Console.WriteLine($"respuesta de aplicacion de factura {responseaplicarfactura}");

            ApiMspBasicaExt.DBDisconnect(-1);
        }
    }
}
