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
            var response = ApiMspBasicaExt.DBConnect(1, "C:\\Program Files\\Firebird\\Firebird_3_0\\databases\\RICARDO.FDB", "SYSDBA", "Admin1234$");
            Console.WriteLine($"respuesta de la conexion de BD {response}");
            //var response = ApiMspBasicaExt.DBConnect(DB, "RICARDO.FDB", "SYSDBA", "Admin1234$");
            Console.WriteLine($"respuesta de la conexion de BD {response}");
            var responseInventarios = ApiMspVentasExt.SetDBVentas(1);
            Console.WriteLine($"respuesta de la conexion a ventas de BD {responseInventarios}");
            var responsehead = ApiMspVentasExt.NuevoPedido("23/07/2024", "B23072024", 306647, 0, 237259, "24/07/2024", "I", 0, "OrdenT01", "prueba de pedido desde api", 0, 0, 0, 0);
            Console.WriteLine($"respuesta de creacion de pedidos  {responsehead}");
            var responseline = ApiMspVentasExt.RenglonPedidoDesctos(12160, 1, -1, -1, -1, -1, "prueba");
            Console.WriteLine($"respuesta de creacion de renglon {responseline}");
            var responseaplicar = ApiMspVentasExt.AplicaPedido();
            Console.WriteLine($"respuesta de aplicacion de pedido {responseaplicar}");


            ApiMspBasicaExt.DBDisconnect(-1);
        }
    }
}
