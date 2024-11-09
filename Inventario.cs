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

        public void DeleteProduct(string productName)
        {
            // Buscar el producto por su nombre
            Producto producto_a_Eliminar = productos.Find(p => p.Nombre.Equals(productName, StringComparison.OrdinalIgnoreCase));

            if (producto_a_Eliminar != null)
            {
                // Si el producto existe
                productos.Remove(producto_a_Eliminar);
                Console.WriteLine($"El producto '{producto_a_Eliminar.Nombre}' ha sido eliminado.");
            }
            else
            {
                // Si no se encuentra el producto
                Console.WriteLine("Producto no existente.");
            }
        }


        public void Contar_Agrupar_Productos_por_Precio()
        {
            var Rangos_de_Precio = new List<(decimal Minimo, decimal Maximo)>
        {
            (0, 100),
            (101, 200),
            (201, 300),
            (301, 400),
            (401, 500),
            (501, 700),
            (701, 1000),
            (1001, 2000),
            (2001, 5000),
            (5001, 10000)
        };

            foreach (var rango in Rangos_de_Precio)
            {
                var contar = productos.Count(p => p.Precio >= rango.Minimo && p.Precio <= rango.Maximo);
                Console.WriteLine($"Productos en el rango de {rango.Minimo} a {rango.Maximo}: {contar}");
            }
        }

    }
}