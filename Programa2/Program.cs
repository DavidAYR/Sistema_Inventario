using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int registrosValidos = 0;
        int registrosRechazados = 0;
        decimal valorTotalInventario = 0;

        List<string> productosValidos = new List<string>();

        bool continuarPrograma = true;

        while (continuarPrograma)
        {
            Console.WriteLine("\n=== SISTEMA DE INVENTARIO ===");
            Console.WriteLine("1. Agregar registro");
            Console.WriteLine("2. Listar registros");
            Console.WriteLine("3. Ver estadísticas del inventario");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    bool cargandoProductos = true;
                    while (cargandoProductos)
                    {
                        Console.WriteLine("\n--- Ingreso de nuevo producto ---");
                        string nombre;
                        do
                        {
                            Console.Write("Nombre del producto: ");
                            nombre = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(nombre))
                            {
                                Console.WriteLine("El nombre no puede estar vacío.\n");
                            }
                        }
                        while (string.IsNullOrWhiteSpace(nombre));

                        decimal precio;
                        do
                        {
                            Console.Write("Precio del producto: ");
                            string entradaPrecio = Console.ReadLine();

                            if (decimal.TryParse(entradaPrecio, out precio) && precio >= 0)
                            {
                                break;
                            }

                            Console.WriteLine("El precio debe ser un número válido y no negativo.\n");
                        }
                        while (true);

                        int cantidad;
                        do
                        {
                            Console.Write("Cantidad de unidades: ");
                            string entradaCantidad = Console.ReadLine();

                            if (int.TryParse(entradaCantidad, out cantidad) && cantidad >= 0 && cantidad <= 1000)
                            {
                                break;
                            }

                            Console.WriteLine("La cantidad debe ser un número entero entre 0 y 1000.\n");
                        }
                        while (true);

                        registrosValidos++;
                        valorTotalInventario += precio * cantidad;
                        productosValidos.Add($"{nombre} (Precio: ${precio} | Cantidad: {cantidad})");
                        Console.WriteLine("Registro guardado exitosamente.");

                        Console.Write("\n¿Desea agregar otro producto ahora mismo? (s/n): ");
                        string respuesta = (Console.ReadLine() ?? "").Trim().ToLower();
                        if (respuesta != "s")
                        {
                            cargandoProductos = false;
                        }
                    }
                    break;

                case "2":
                    Console.WriteLine("\n--- Lista de registros válidos ---");
                    if (productosValidos.Count == 0)
                    {
                        Console.WriteLine("No hay productos válidos registrados.");
                    }
                    else
                    {
                        for (int i = 0; i < productosValidos.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {productosValidos[i]}");
                        }
                    }
                    break;

                case "3":
                    Console.WriteLine("\n--- Estadísticas actuales ---");
                    Console.WriteLine($"Registros válidos: {registrosValidos}");
                    Console.WriteLine($"Registros rechazados: {registrosRechazados}");
                    Console.WriteLine($"Valor total del inventario: ${valorTotalInventario}");
                    break;

                case "4":
                    Console.WriteLine("Saliendo del sistema...");
                    continuarPrograma = false;
                    break;

                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }
        }
    }
}