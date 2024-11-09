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
                string product_Nombre;
                decimal product_precio;
                bool Verificacion = false;
                bool Verificacion_precio = false;

                // Validación del nombre del producto
                do
                {
                    Console.WriteLine("Ingrese el nombre del producto:");
                    product_Nombre = Console.ReadLine();
                    Verificacion = Inventario_de_Productos.Validar_nombre_del_producto(product_Nombre);
                } while (Verificacion != true);



                do
                {
                    Console.WriteLine("Precio: ");
                    product_precio = decimal.Parse(Console.ReadLine());
                    Verificacion_precio = Inventario_de_Productos.Validar_Precio_del_Producto(product_precio);
                } while (Verificacion_precio != true);

                Producto product = new Producto(product_Nombre, product_precio);
                Inventario_de_Productos.AgregarProducto(product);
                Console.WriteLine($"Producto '{product_Nombre}' con precio {product_precio} agregado exitosamente.");
            }

            //Filtrar
            Console.Write("Ingrese el precio minimo para filtrar los productos: ");
            decimal preciominimo = decimal.Parse(Console.ReadLine());

            var ProductosFiltrados = Inventario_de_Productos.Filtrar_Ordenar_Productos(preciominimo);

            Console.WriteLine("Productos filtrados y ordenados por precio");
            foreach (var producto in ProductosFiltrados)
            {
                producto.MostrarInfo();
            }

            // Intentar actualizar el precio de un producto
            Console.WriteLine("Ingrese el nombre del producto a actualizar:");
            string productNombre = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo precio:");
            decimal nuevoPrecio = decimal.Parse(Console.ReadLine());
            Inventario_de_Productos.ActualizarPrecio(productNombre, nuevoPrecio);

            //Eliminar productos
            Console.WriteLine("Ingrese el nombre del producto a eliminar:");
            string nombre = Console.ReadLine();
            Inventario_de_Productos.EliminarProducto(productNombre);

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

            //Contar y agrupar productos
            Console.WriteLine("\nConteo de productos por rango de precio:");
            Inventario_de_Productos.Contar_Agrupar_Productos_por_Precio();


            Inventario_de_Productos.GenerarReporte();
        }


    }
}