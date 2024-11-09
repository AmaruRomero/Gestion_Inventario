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
            int opcion;

            do
            {
                Console.WriteLine("\n--- Menú del Sistema de Inventario de Productos ---");
                Console.WriteLine("Que desea realizar?");
                Console.WriteLine("1. Ingresar productos");
                Console.WriteLine("2. Filtrar y ordenar productos");
                Console.WriteLine("3. Actualizar precio de un producto");
                Console.WriteLine("4. Eliminar un producto");
                Console.WriteLine("5. Contar y agrupar productos por precio");
                Console.WriteLine("6. Generar reporte");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        {
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
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Ingrese el precio minimo para filtrar los productos: ");
                            decimal preciominimo = decimal.Parse(Console.ReadLine());

                            var ProductosFiltrados = Inventario_de_Productos.Filtrar_Ordenar_Productos(preciominimo);

                            Console.WriteLine("Productos filtrados y ordenados por precio");
                            foreach (var producto in ProductosFiltrados)
                            {
                                producto.MostrarInfo();
                            }
                            break;
                        }
                    case 3:
                        Console.WriteLine("Ingrese el nombre del producto a actualizar:");
                        string productNombre = Console.ReadLine();
                        Console.WriteLine("Ingrese el nuevo precio:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio))
                        {
                            Inventario_de_Productos.ActualizarPrecio(productNombre, nuevoPrecio);
                            Console.WriteLine($"Precio del producto '{productNombre}' actualizado a {nuevoPrecio}.");
                        }
                        else
                        {
                            Console.WriteLine("El precio ingresado no es válido.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Ingrese el nombre del producto a eliminar:");
                        string nombre = Console.ReadLine();
                        Inventario_de_Productos.EliminarProducto(nombre);
                        break;
                    case 5:
                        {
                            Console.WriteLine("\nConteo de productos por rango de precio:");
                            Inventario_de_Productos.Contar_Agrupar_Productos_por_Precio();
                            break;
                        }
                    case 6:
                        {
                            Inventario_de_Productos.GenerarReporte();
                            break;
                        }
                    case 0:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }
            } while (opcion != 0);
        }
    }
}