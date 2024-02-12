using WebApiSistemaGestion.database;
using WebApiSistemaGestion.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSistemaGestion.service
{
    internal class ProductoVendidoService
    {
        public static List<ProductoVendido> ObtenerTodosLosProductoVendido()
        {
            using (CoderContext contexto = new CoderContext())
            {
                List<ProductoVendido> productoVendido = contexto.ProductoVendido.ToList();
                return productoVendido;
            }
        }
    }
}
