using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela;

namespace examen_csharp.src.ui;


public class MenuPrincipal
{
    public void MostrarBienvenida()
    {
        Console.WriteLine("===========================================");
        Console.WriteLine("      ❤︎ BIENVENID@ A CAMPUS LOVE  ❤︎        ");
        Console.WriteLine("   donde encontrarás el amor de tu vida!   ");
        Console.WriteLine("===========================================");
        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }

    public void Mostrarmenuprincipal()
    {
        Console.WriteLine("===========================================");
        Console.WriteLine("             ❤︎ MENÚ PRINCIPAL  ❤︎          ");
        Console.WriteLine("===========================================");
        Console.WriteLine("1. Crear Usuario");
        Console.WriteLine("2. Salir");
    }
    public void EjecutarMenuPrincipal()
    {
        bool validate_program = true;
        do
        {
            Console.Clear();
            Mostrarmenuprincipal();
            Console.WriteLine("Seleccione una opción: ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        var menuCrearUsuario = new MenuUsuario();
                        menuCrearUsuario.MenuCrearUsuario();
                        break;
                    case 2:
                        validate_program = false;
                        Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione otra vez.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número.");
            }
            if (validate_program)
            {
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
        } while (validate_program);
    }

}
