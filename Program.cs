using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== REGISTRO DE PRODUCTO ===\n");

        bool esValido = true;
        string motivoRechazo = "";

        Console.Write("Nombre del producto: ");
        string nombre = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nombre))
        {
            esValido = false;
            motivoRechazo += "- El nombre no puede quedar vacío.\n";
        }

        Console.Write("Precio del producto: ");
        string entradaPrecio = Console.ReadLine();
        decimal precio = 0;
        if (!decimal.TryParse(entradaPrecio, out precio))
        {
            esValido = false;
            motivoRechazo += "- El precio tiene un formato inválido.\n";
        }
        else if (precio < 0)
        {
            esValido = false;
            motivoRechazo += "- El precio no puede ser negativo.\n";
        }

        Console.Write("Cantidad de unidades: ");
        string entradaCantidad = Console.ReadLine();
        int cantidad = 0;
        if (!int.TryParse(entradaCantidad, out cantidad))
        {
            esValido = false;
            motivoRechazo += "- La cantidad tiene un formato inválido.\n";
        }
        else if (cantidad > 1000)
        {
            esValido = false;
            motivoRechazo += "- La cantidad no puede superar 1000 unidades.\n";
        }
        else if (cantidad < 0)
        {
            esValido = false;
            motivoRechazo += "- La cantidad no puede ser negativa.\n";
        }

        Console.WriteLine();
        if (esValido)
        {
            Console.WriteLine("REGISTRO VÁLIDO");
            Console.WriteLine($"Producto: {nombre} | Precio: ${precio} | Cantidad: {cantidad}");
        }
        else
        {
            Console.WriteLine("REGISTRO RECHAZADO. Motivo(s):");
            Console.Write(motivoRechazo);
        }

        Console.WriteLine("\nPresione una tecla para salir...");
        Console.ReadKey();
    }
}