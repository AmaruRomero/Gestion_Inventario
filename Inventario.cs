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

        public void ActualizarPrecio(string productNombre, decimal NuevoPrecio)
        {
            // Buscar el producto por su nombre
            Producto product = productos.Find(p => p.Nombre.Equals(productNombre, StringComparison.OrdinalIgnoreCase));

            if (product != null)
            {
                // Si el producto existe, actualizamos el precio
                product.Precio = NuevoPrecio;
                Console.WriteLine($"El precio de '{product.Nombre}' ha sido actualizado a {product.Precio}");
            }
            else
            {
                 // Si no se encuentra el producto, mostramos un mensaje
                 Console.WriteLine("Producto no existente.");
            }
            
        }



    }
}