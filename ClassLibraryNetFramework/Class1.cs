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
            // revisar lugar de expedicion , lugar fiscal - lugar de facturacion
            // documentos incluidos en la factura , hay que relacionarlo
            Console.WriteLine($"respuesta de la conexion de BD {response}");
            var responseInventarios = ApiMspVentasExt.SetDBVentas(1);
            Console.WriteLine($"respuesta de la conexion a ventas de BD {responseInventarios}");
            var responsehead = ApiMspVentasExt.NuevoPedido("12/09/2024", "P130912", 306647, 0, 237259, "12/09/2024", "I", 0, "OrdenT01", "prueba de pedido desde api",0, 0, 0, 0);
            Console.WriteLine($"respuesta de creacion de pedidos  {responsehead}");
            int documentoId = 0;
            var aux = documentoId;
            var getid1=ApiMspVentasExt.GetDoctoVeId(ref documentoId);
            Console.WriteLine($"obtuvo el id {getid1}");
            Console.WriteLine($"id de la venta procesada en este momento {documentoId}");
            var responseline = ApiMspVentasExt.RenglonPedidoDesctos(12160, 1, -1, -1, -1, -1, "prueba");
            Console.WriteLine($"respuesta de creacion de renglon {responseline}");
            var responseaplicar = ApiMspVentasExt.AplicaPedido();
            Console.WriteLine($"respuesta de aplicacion de pedido {responseaplicar}");


            Console.WriteLine("NUEVA FACTURA");
            ApiMspVentasExt.NuevaFactura("12/09/2024", "F130912", 306647, 0, 237259, "P", 0, "OrdenT01", "prueba de factura desde api", 10, 0, -1, 0, 0, 0, 0, -1, "factura de prueba", -1);

            int documentoId2 = 0;
           
            
            var getid2 = ApiMspVentasExt.GetDoctoVeId(ref documentoId2);
            Console.WriteLine($"documento factura {documentoId2}");
            Console.WriteLine($"obtuvo el id {getid2}");

            ApiMspVentasExt.RenglonFactura(12160, 1, -1, -1, "producto de prueba");

            

            var responseaplicarfactura = ApiMspVentasExt.AplicaFactura();
            Console.WriteLine($"respuesta de aplicacion de factura {responseaplicarfactura}");


            //var resplink=ApiMspBasicaExt.DtstLink(documentoId2,documentoId);.
            var idtransaccion = ApiMspBasicaExt.NewTrn(1, 2);
            var dataset = ApiMspBasicaExt.NewDtst(idtransaccion);

            var auxopen = ApiMspBasicaExt.DtstOpen(dataset);
            Console.WriteLine($"response open {auxopen}");


            Console.WriteLine($"dataset id {dataset}");
            

          

            // Asigna los valores de los parámetros a la consulta
            ApiMspBasicaExt.DtstSetFieldAsInteger(dataset, "documentoId", documentoId);
            ApiMspBasicaExt.DtstSetFieldAsInteger(dataset, "documentoId2", documentoId2);

            

            var query = $"INSERT INTO DOCTOS_VE_LIGAS ( DOCTO_VE_FTE_ID, DOCTO_VE_DEST_ID) VALUES ({documentoId}, {documentoId2})";

            // Ahora ejecuta la consulta con la API, pasando los parámetros por separado
            var responsequery = ApiMspBasicaExt.DtstInsQry(dataset, query);

            //var responsequery =ApiMspBasicaExt.DtstInsQry(dataset, $"INSERT INTO DOCTOS_VE_LIGAS (DOCTO_VE_FTE_ID,DOCTO_VE_DEST_ID) VALUES (:{documentoId}, :{documentoId2})");
            Console.WriteLine($"response query {responsequery}");
            ApiMspBasicaExt.DtstInsert(dataset);
            var responsepost=ApiMspBasicaExt.DtstPost(dataset);
            ApiMspBasicaExt.TrnCommit(idtransaccion);

            ApiMspBasicaExt.DtstClose(dataset);
            Console.WriteLine($"respuesta post {responsepost}");



            //Console.WriteLine($"repsuesta del link {resplink}");
            ApiMspBasicaExt.DBDisconnect(-1);
        }
    }
}
