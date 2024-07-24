using ClassLibraryNetFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIMicrosip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("crearpedido")]
        public async Task<IActionResult> Get()
        {
            var DB = 1;//ApiMspBasicaExt.NewDB();
            var response = ApiMspBasicaExt.DBConnect(DB, "RICARDO.FDB", "SYSDBA", "Admin1234$");
            Console.WriteLine($"respuesta de la conexion de BD {response}");
            var responseInventarios = ApiMspVentasExt.SetDBVentas(DB);
            Console.WriteLine($"respuesta de la conexion a ventas de BD {responseInventarios}");
            var responsehead = ApiMspVentasExt.NuevoPedido("23/07/2024", "B23072024", 306647, 0, 237259, "24/07/2024", "I", 0, "OrdenT01", "prueba de pedido desde api", 0, 0, 0, 0);
            Console.WriteLine($"respuesta de creacion de pedidos  {responsehead}");
            var responseline = ApiMspVentasExt.RenglonPedidoDesctos(12160, 1, -1, -1, -1, -1, "prueba");
            Console.WriteLine($"respuesta de creacion de renglon {responseline}");
            var responseaplicar = ApiMspVentasExt.AplicaPedido();
            Console.WriteLine($"respuesta de aplicacion de pedido {responseaplicar}");


            ApiMspBasicaExt.DBDisconnect(-1);
            return Ok();

        }
        [HttpGet("crearpedido2")]
        public async Task<IActionResult> Get2()
        {
           Class1 class1= new Class1();
            class1.test();
            return Ok();

        }

    }
}
