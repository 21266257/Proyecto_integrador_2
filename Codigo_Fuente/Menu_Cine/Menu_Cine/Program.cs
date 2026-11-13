using System;

class Program
{
    static void Main()
    {
        // Definir dimensiones de la sala
        int filas = 5;
        int columnas = 6;
        bool[,] sala = new bool[filas, columnas];

        // Inicializar todos los asientos como disponibles
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                sala[i, j] = true;
            }
        }

        int opcion = 0;
        do
        {
            Console.Clear();
            // Diseño único y claro utilizando caracteres de bordes dobles
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║                  --- CINE CyTI ---                   ║");
            Console.WriteLine("║          SISTEMA DE ADMINISTRACIÓN DE SALAS          ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("║    [ 1 ] Mostrar mapa de asientos                    ║");
            Console.WriteLine("║    [ 2 ] Reservar asiento                            ║");
            Console.WriteLine("║    [ 3 ] Liberar asiento                             ║");
            Console.WriteLine("║    [ 4 ] Consultar disponibilidad                    ║");
            Console.WriteLine("║    [ 5 ] Mostrar estadísticas de ocupación           ║");
            Console.WriteLine("║    [ 6 ] Salir del sistema                           ║");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.Write(" >> Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

            switch (opcion)
            {
                case 1:
                    MostrarAsientos(sala, filas, columnas);
                    break;
                case 2:
                    Console.WriteLine("\n[Módulo de reserva - En desarrollo");
                    break;
                case 3:
                    Console.WriteLine("\n[Módulo de liberación - En desarrollo");
                    break;
                case 4:
                    Console.WriteLine("\n[Módulo de consulta - En desarrollo");
                    break;
                case 5:
                    Console.WriteLine("\n[Módulo de estadísticas - En desarrollo");
                    break;
                case 6:
                    Console.WriteLine("\nCerrando el sistema... ¡Hasta pronto!");
                    break;
                default:
                    Console.WriteLine("\n[!] Opción no válida. Intente con un número del 1 al 6.");
                    break;
            }

            if (opcion != 6)
            {
                Console.WriteLine("\nPresione cualquier tecla para volver al menú");
                Console.ReadKey();
            }

        } while (opcion != 6);
    }
    static void MostrarAsientos(bool[,] sala, int filas, int columnas)
    {
        Console.WriteLine("\n ╔════════════════════════════════════════════════╗");
        Console.WriteLine(" ║               MAPA DE LA SALA                  ║");
        Console.WriteLine(" ╚════════════════════════════════════════════════╝\n");

        // Encabezado de columnas
        Console.Write("       ");
        for (int j = 0; j < columnas; j++) Console.Write($" C{j + 1}   ");
        Console.WriteLine("\n");

        // Filas con los asientos
        for (int i = 0; i < filas; i++)
        {
            Console.Write($"  F{i + 1}   ");
            for (int j = 0; j < columnas; j++)
            {
                // [L] = Libre, [O] = Ocupado
                string estado = sala[i, j] ? "[ L ]" : "[ O ]";
                Console.Write(estado + "  ");
            }
            Console.WriteLine("\n");
        }

        Console.WriteLine(" --------------------------------------------------");
        Console.WriteLine("  Simbología:  [ L ] Disponible    [ O ] Ocupado");
        Console.WriteLine(" --------------------------------------------------");
    }
}