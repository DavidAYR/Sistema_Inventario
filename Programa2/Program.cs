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
                        bool esValido = true;
                        string motivoRechazo = "";

                        Console.Write("Nombre del producto: ");
                        string nombre = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(nombre))
                        {
                            esValido = false;
                            motivoRechazo += "[El nombre no puede estar vacío] ";
                        }

                        Console.Write("Precio del producto: ");
                        string entradaPrecio = Console.ReadLine();
                        decimal precio = 0;
                        if (!decimal.TryParse(entradaPrecio, out precio))
                        {
                            esValido = false;
                            motivoRechazo += "[Formato de precio inválido] ";
                        }
                        else if (precio < 0)
                        {
                            esValido = false;
                            motivoRechazo += "[El precio no puede ser negativo] ";
                        }

                        Console.Write("Cantidad de unidades: ");
                        string entradaCantidad = Console.ReadLine();
                        int cantidad = 0;
                        if (!int.TryParse(entradaCantidad, out cantidad))
                        {
                            esValido = false;
                            motivoRechazo += "[Formato de cantidad inválido] ";
                        }
                        else if (cantidad > 1000)
                        {
                            esValido = false;
                            motivoRechazo += "[La cantidad no puede superar 1000 unidades] ";
                        }
                        else if (cantidad < 0)
                        {
                            esValido = false;
                            motivoRechazo += "[La cantidad no puede ser negativa] ";
                        }

                        if (esValido)
                        {
                            registrosValidos++;
                            valorTotalInventario += precio * cantidad;
                            productosValidos.Add($"{nombre} (Precio: ${precio} | Cantidad: {cantidad})");
                            Console.WriteLine("Registro guardado exitosamente.");
                        }
                        else
                        {
                            registrosRechazados++;
                            Console.WriteLine($"Registro RECHAZADO. Motivo: {motivoRechazo}");
                        }

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