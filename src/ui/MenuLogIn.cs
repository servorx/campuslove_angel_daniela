
using campuslove_angel_daniela.src.modules.interes_usuario.application.services;
using campuslove_angel_daniela.src.modules.like.application.services;
using campuslove_angel_daniela.src.modules.usuario.application.services;
using campuslove_angel_daniela.src.modules.usuario.domain.models;

namespace campuslove_angel_daniela.src.ui;

public class MenuLogIn
{
    private readonly UsuarioService _usuarioService;
    private readonly InteresUsuarioService _interesUsuarioService;
    private readonly LikeService _likeService;
    public MenuLogIn(UsuarioService usuarioService, InteresUsuarioService interesUsuarioService,  LikeService likeService)
    {
        _usuarioService = usuarioService;
        _interesUsuarioService = interesUsuarioService;
        _likeService = likeService;
    }
    public async Task MenuLogInUsuario()
    {
        Console.Clear();
        Console.WriteLine("===========================================");
        Console.WriteLine("             ❤︎ LOG IN USUARIO  ❤︎          ");
        Console.WriteLine("===========================================");
        Console.Write("Ingrese su correo electrónico: ");
        string? email = Console.ReadLine();
        Console.Write("Ingrese su contraseña: ");
        string? password = Console.ReadLine();

        var usuario = await AutenticarUsuarioAsync(email, password); // 👈 await

        if (usuario != null)
        {
            Console.WriteLine($"¡Inicio de sesión exitoso! Bienvenid@ {usuario.Nombre}.");
            MenuPrincipalUsuario(usuario.Id);
        }
        else
        {
            Console.WriteLine("❌ Credenciales inválidas. Por favor, inténtalo de nuevo.");
        }

        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private async Task<Usuario?> AutenticarUsuarioAsync(string email, string password) => await _usuarioService.GetUsuarioPorCredencialesAsync(email, password);
    public async Task MenuPrincipalUsuario(int usuarioId)
    {
        string? input_menu = "";
        while (input_menu != "6")
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
            input_menu = Console.ReadLine();

            if (int.TryParse(input_menu, out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        VerTodasLasPersonas();
                        break;
                    case 2:
                        VerTodasLasPersonas();
                        Console.Write("Ingrese el ID de la persona a la que quiere reaccionar: ");
                        var id_usuario = int.Parse(Console.ReadLine());
                        DarLikeODislike(id_usuario);
                        break;
                    case 3:
                        // Aquí puedes implementar ver coincidencias directas del usuario
                        await ListarMisCoincidenciasAsync(usuarioId);
                        break;
                    case 4:
                        Console.Write("Ingrese el ID de la persona a la que quiere ver las coincidencias: ");
                        var id_usuario1 = int.Parse(Console.ReadLine());
                        await ListarMisCoincidenciasAsync(id_usuario1);
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

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
    private void VerTodasLasPersonas()
    {
        var usuarios = _usuarioService.ListarUsuariosAsync().Result;
        Console.WriteLine("\n❤︎ Lista de personas registradas:");
        foreach (var u in usuarios)
        {
            Console.WriteLine($"[{u.Id}] {u.Nombre} {u.Apellido} - {u.Edad} años");
        }
    }
    private void DarLikeODislike(int usuarioId)
    {
        Console.Write("\nIngrese el ID de la persona a la que quiere reaccionar: ");
        if (int.TryParse(Console.ReadLine(), out int personaId))
        {
            Console.Write("¿Desea dar Like (L) o Dislike (D)? ");
            string? reaccion = Console.ReadLine()?.ToUpper();

            if (reaccion == "L")
            {
                _likeService.CrearLikeAsync(usuarioId, personaId);
                Console.WriteLine("💖 Has dado like!");
            }
            else if (reaccion == "D")
            {
                _likeService.CrearLikeAsync(usuarioId, personaId);
                Console.WriteLine("💔 Has dado dislike.");
            }
            else
            {
                Console.WriteLine("❌ Respuesta inválida.");
            }
        }
    }
    // private void VerCoincidencias(int usuarioId)
    // {
    //     var matches = _likeService.GetLikesDeUsuarioAsync(usuarioId);
    //     Console.WriteLine("\n❤︎ Tus coincidencias:");
    //     foreach (var m in matches)
    //     {
    //         Console.WriteLine($"{m.Nombre} {m.Apellido}, {m.Edad} años");
    //     }
    // }
    private async Task ListarMisCoincidenciasAsync(int usuarioId)
    {
        var misMatches = await _likeService.GetMatchesAsync(usuarioId);

        Console.WriteLine("\n❤︎ Coincidencias del usuario:");
        foreach (var m in misMatches)
        {
            Console.WriteLine($"{m.Receptor.Nombre} {m.Receptor.Apellido} ({m.Receptor.Correo})");
        }
    }
    private void MostrarUsuarioMasLikes()
    {
        var topUser = _likeService.GetUsuarioConMasLikesAsync();
        if (topUser != null)
        {
            Console.WriteLine($"\n🏆 El usuario con más likes es: {topUser.Result.Receptor.Nombre} {topUser.Result.Emisor.Apellido}");
        }
        else
        {
            Console.WriteLine("❌ Aún no hay likes registrados.");
        }
    }
}