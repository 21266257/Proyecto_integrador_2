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
                    ReservarAsiento(sala, filas, columnas);
                    break;
                case 3:
                    LiberarAsiento(sala, filas, columnas);
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

    static void ReservarAsiento(bool[,] sala, int filas, int columnas)
    {
        Console.Clear();
        MostrarAsientos(sala, filas, columnas);

        Console.WriteLine($"\n ╔════════════════════════════════════════════════╗");
        Console.WriteLine($" ║               RESERVAR UN ASIENTO              ║");
        Console.WriteLine($" ╚════════════════════════════════════════════════╝\n");

        int f = 0, c = 0;

        Console.Write($" >> Ingrese número de fila (1 a {filas}): ");
        if (!int.TryParse(Console.ReadLine(), out f)) f = 0;

        Console.Write($" >> Ingrese número de columna (1 a {columnas}): ");
        if (!int.TryParse(Console.ReadLine(), out c)) c = 0;

        f--;
        c--;

        Console.WriteLine("\n --------------------------------------------------");
        if (f >= 0 && f < filas && c >= 0 && c < columnas)
        {
            if (sala[f, c])
            {
                sala[f, c] = false;
                Console.WriteLine(" ¡Asiento reservado con éxito!");
            }
            else
            {
                Console.WriteLine(" Error: El asiento ya se encuentra ocupado.");
            }
        }
        else
        {
            Console.WriteLine(" Error: Coordenadas fuera de rango o entrada inválida.");
        }
        Console.WriteLine(" --------------------------------------------------");
    }
    static void LiberarAsiento(bool[,] sala, int filas, int columnas)
    {
        Console.Clear();
        MostrarAsientos(sala, filas, columnas);

        Console.WriteLine($"\n ╔════════════════════════════════════════════════╗");
        Console.WriteLine($" ║               LIBERAR UN ASIENTO               ║");
        Console.WriteLine($" ╚════════════════════════════════════════════════╝\n");

        int f = 0, c = 0;

        Console.Write($" >> Ingrese número de fila (1 a {filas}): ");
        if (!int.TryParse(Console.ReadLine(), out f)) f = 0;

        Console.Write($" >> Ingrese número de columna (1 a {columnas}): ");
        if (!int.TryParse(Console.ReadLine(), out c)) c = 0;

        f--;
        c--;

        Console.WriteLine("\n --------------------------------------------------");
        if (f >= 0 && f < filas && c >= 0 && c < columnas)
        {
            if (!sala[f, c])
            {
                sala[f, c] = true;
                Console.WriteLine(" [✔] ¡Asiento liberado con éxito!");
            }
            else
            {
                Console.WriteLine(" [!] Aviso: El asiento ya estaba libre.");
            }
        }
        else
        {
            Console.WriteLine(" [X] Error: Coordenadas fuera de rango o entrada inválida.");
        }
        Console.WriteLine(" --------------------------------------------------");
    }
}