using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela;
using campuslove_angel_daniela.src.modules.interes_usuario.application.services;
using campuslove_angel_daniela.src.modules.usuario.application.services;

namespace campuslove_angel_daniela.src.ui;


public class MenuPrincipal
{
    private readonly UsuarioService _usuarioService;
    private readonly InteresUsuarioService _interesUsuarioService;

    public MenuPrincipal(UsuarioService usuarioService, InteresUsuarioService interesUsuarioService)
    {
        _usuarioService = usuarioService;
        _interesUsuarioService = interesUsuarioService;
    }
    public void MostrarBienvenida()
    {
        Console.Clear();
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
        Console.WriteLine("2. Log In usuario");
        Console.WriteLine("3. Salir");
    }
    public async Task EjecutarMenuPrincipal()
    {
        bool validate_program = true;
        do
        {
            Console.Clear();
            Mostrarmenuprincipal();
            Console.Write("Seleccione una opción: ");
            string? input = Console.ReadLine();
            // esto se hace para verificar que lo ingresado sea un número, si no lo es, muestra error y vuelve a pedir el dato
            if (int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        var menuCrearUsuario = new MenuUsuario(_usuarioService, _interesUsuarioService);
                        await menuCrearUsuario.MenuCrearUsuario();
                        break;
                    case 2:
                        var menuLogInUsuario = new MenuLogIn(_usuarioService);
                        menuLogInUsuario.MenuLogInUsuario();
                        break;
                    case 3:
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
