using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_inventario
{
    public class Inventario
    {
        private List<Producto> productos;

        public Inventario()
        {
            productos = new List<Producto>();
        }

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public IEnumerable<Producto> Filtrar_Ordenar_Productos(decimal preciominimo)
        {
            return productos
            .Where(p => p.Precio > preciominimo)
            .OrderBy(p => p.Precio);
        }

    }
}