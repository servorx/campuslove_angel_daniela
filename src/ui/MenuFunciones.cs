using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.like.application.services;
using campuslove_angel_daniela.src.modules.usuario.application.services;

namespace examen_csharp.src.ui;
public class MenuFunciones
{
    private readonly UsuarioService _usuarioService;
    private readonly LikeService _likeService;
    public MenuFunciones(UsuarioService usuarioService, LikeService likeService)
    {
        _usuarioService = usuarioService;
        _likeService = likeService;
    }
    public async Task MenuPrincipalUsuario(int usuarioId)
    {
        string? inputMenu;
        do
        {
            MostrarMenuPrincipal();
            inputMenu = Console.ReadLine();

            if (int.TryParse(inputMenu, out int opcion))
                await EjecutarOpcionAsync(opcion, usuarioId);

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        } while (inputMenu != "6");
    }

    // Menú impreso
    private void MostrarMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("===========================================");
        Console.WriteLine("             ❤︎ MENÚ PRINCIPAL  ❤︎          ");
        Console.WriteLine("===========================================");
        Console.WriteLine("1. Ver todas las personas");
        Console.WriteLine("2. Dar like o dislike");
        Console.WriteLine("3. Ver coincidencias");
        Console.WriteLine("4. Listar todas las coincidencias de un usuario");
        Console.WriteLine("5. Mostrar el usuario con mas likes recibidos");
        Console.WriteLine("6. Salir");
        Console.Write("Seleccione una opción: ");
    }

    // Manejo de opciones
    private async Task EjecutarOpcionAsync(int opcion, int usuarioId)
    {
        switch (opcion)
        {
            case 1:
                VerTodasLasPersonas();
                break;

            case 2:
                VerTodasLasPersonas();
                int personaId = LeerNumero("Ingrese el ID de la persona a la que quiere reaccionar: ");
                DarLikeODislike(usuarioId, personaId);
                break;

            case 3:
                await ListarMisCoincidenciasAsync(usuarioId);
                break;

            case 4:
                int otroUsuarioId = LeerNumero("Ingrese el ID de la persona a la que quiere ver las coincidencias: ");
                await ListarMisCoincidenciasAsync(otroUsuarioId);
                break;

            case 5:
                MostrarUsuarioMasLikes();
                break;

            case 6:
                Console.WriteLine("👋 Cerrando sesión...");
                break;

            default:
                Console.WriteLine("❌ Opción inválida. Por favor, seleccione otra vez.");
                break;
        }
    }

    // Utilidad para leer números de consola
    private int LeerNumero(string mensaje)
    {
        int numero = 0;
        Console.Write(mensaje);
        while (!int.TryParse(Console.ReadLine(), out numero))
        {
            Console.Write("❌ Entrada inválida. Intenta de nuevo: ");
        }
        return numero;
    }

    // Listar personas
    private void VerTodasLasPersonas()
    {
        var usuarios = _usuarioService.ListarUsuariosAsync().Result;
        Console.WriteLine("\n❤︎ Lista de personas registradas:");
        foreach (var u in usuarios)
        {
            Console.WriteLine($"[{u.Id}] {u.Nombre} {u.Apellido} - {u.Edad} años");
        }
    }

    // Dar Like o Dislike
    private async Task DarLikeODislike(int usuarioId, int personaId)
    {
        Console.Write("¿Desea dar Like (L) o Dislike (D)? ");
        string? reaccion = Console.ReadLine()?.ToUpper();

        if (reaccion == "L")
        {
            await _likeService.CrearLikeAsync(usuarioId, personaId);
            Console.WriteLine("💖 Has dado like!");
        }
        else if (reaccion == "D")
        {
            await _likeService.CrearLikeAsync(usuarioId, personaId);
            Console.WriteLine("💔 Has dado dislike.");
        }
        else
        {
            Console.WriteLine("❌ Respuesta inválida.");
        }
    }

    // Coincidencias
    private async Task ListarMisCoincidenciasAsync(int usuarioId)
    {
        var misMatches = await _likeService.GetMatchesAsync(usuarioId);

        Console.WriteLine("\n❤︎ Coincidencias del usuario:");
        foreach (var m in misMatches)
        {
            Console.WriteLine($"{m.Receptor.Nombre} {m.Receptor.Apellido} ({m.Receptor.Correo})");
        }
        if (misMatches == null || misMatches.Count() == 0)
        {
            Console.WriteLine("❌ No hay coincidencias para este usuario.");
        }
    }

    // Usuario con más likes
    private async Task MostrarUsuarioMasLikes()
    {
        var topUser = await _likeService.GetUsuarioConMasLikesAsync();

        if (topUser != null)
        {
            Console.WriteLine($"\n🏆 El usuario con más likes es: {topUser.Nombre} {topUser.Apellido}");
        }
        else
        {
            Console.WriteLine("❌ Aún no hay likes registrados.");
        }
    }
}