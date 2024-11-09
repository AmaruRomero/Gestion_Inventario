using System;
using System.Linq;
using Menu_inventario;

namespace Menu_inventario
{
    class Program
    {
        public static void Main(string[] args)
        {
            Inventario Inventario_de_Productos = new Inventario();
            Console.WriteLine("Bienvenidos al sistema de inventario de productos");
            Console.WriteLine("Cuantos productos desea ingresar?: ");
            int cant = int.Parse(Console.ReadLine());

            for (int i = 0; i < cant; i++)
            {
                Console.WriteLine($"\nProducto {i + 1}");
                Console.WriteLine("Nombre: ");
                string? nombre = Console.ReadLine();

                Console.WriteLine("Precio: ");
                decimal precio = decimal.Parse(Console.ReadLine());

                Producto product = new Producto(nombre, precio);
                Inventario_de_Productos.AgregarProducto(product);
            }

            Console.Write("Ingrese el precio minimo para filtrar los productos: ");
            decimal preciominimo = decimal.Parse(Console.ReadLine());

            var ProductosFiltrados = Inventario_de_Productos.Filtrar_Ordenar_Productos(preciominimo);

            Console.WriteLine("Productos filtrados y ordenados por precio");
            foreach (var producto in ProductosFiltrados)
            {
                Console.WriteLine(producto);
            }

            // Intentar actualizar el precio de un producto
            Console.WriteLine("Ingrese el nombre del producto a actualizar:");
            string productNombre = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo precio:");
            /*decimal.TryParse(Console.ReadLine(), out decimal newPrice  se lee directamente la entrada del usuario y
            se intenta convertir a un decimal en un solo paso. Si la conversión tiene éxito, se ejecuta el bloque de
            código donde se actualiza el precio. Si falla, el programa muestra el mensaje de error.*/
            if (decimal.TryParse(Console.ReadLine(), out decimal newPrecio))
            {
                Inventario_de_Productos.ActualizarPrecio(productNombre, newPrecio);
            }
            else
            {
                Console.WriteLine("El precio ingresado no es válido.");
            }
        }

    }
    }
}