using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== REGISTRO DE PRODUCTO ===\n");

        string nombre;
        do
        {
            Console.Write("Nombre del producto: ");
            nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede quedar vacío.\n");
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

        Console.WriteLine();
        Console.WriteLine("REGISTRO VÁLIDO");
        Console.WriteLine($"Producto: {nombre} | Precio: ${precio} | Cantidad: {cantidad}");

        Console.WriteLine("\nPresione una tecla para salir...");
        Console.ReadKey();
    }
}