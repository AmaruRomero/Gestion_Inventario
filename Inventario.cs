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

        public void EliminarProducto(string productName)
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

        public bool Validar_Precio_del_Producto(decimal precio)
        {
            if (precio > 0)
            {
                return true;
            }
            else if (precio < 0)
            {
                Console.WriteLine("El precio debe ser un número positivo.");
                return false;
            }
            else
            {
                Console.WriteLine("El precio ingresado no es válido. Debe ser un número.");
                return false;
            }
        }

        // Método para agregar un producto después de validar sus datos
        public bool Validar_nombre_del_producto(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre del producto no puede estar vacío o contener solo espacios.");
                return false;
            }
            return true;
        }

        // Método para generar el reporte de productos
        public void GenerarReporte()
        {
            // Cantidad de productos
            int total_de_Productos = productos.Count;

            // Precio promedio
            decimal Precio_Promedio = productos.Average(p => p.Precio);

            // Producto con el precio más bajo
            var Producto_mas_barato = productos.OrderBy(p => p.Precio).FirstOrDefault();

            // Producto con el precio más alto
            var Producto_mas_caro = productos.OrderByDescending(p => p.Precio).FirstOrDefault();

            Console.WriteLine("---- Reporte de Productos ----");
            Console.WriteLine($"Cantidad total de productos: {total_de_Productos}");
            Console.WriteLine($"Precio promedio de los productos: {Precio_Promedio}");

            if (Producto_mas_barato != null)
            {
                Console.WriteLine($"Producto con el precio más bajo: {Producto_mas_barato.Nombre} ({Producto_mas_barato.Precio})");
            }

            if (Producto_mas_caro != null)
            {
                Console.WriteLine($"Producto con el precio más alto: {Producto_mas_caro.Nombre} ({Producto_mas_caro.Precio})");
            }
        }


    }
}