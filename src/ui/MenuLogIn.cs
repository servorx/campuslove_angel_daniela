
using campuslove_angel_daniela.src.modules.interes_usuario.application.services;
using campuslove_angel_daniela.src.modules.like.application.services;
using campuslove_angel_daniela.src.modules.usuario.application.services;
using campuslove_angel_daniela.src.modules.usuario.domain.models;
using examen_csharp.src.ui;

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

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("❌ El correo y la contraseña no pueden estar vacíos.");
            return;
        }

        var usuario = await AutenticarUsuarioAsync(email, password);

        if (usuario != null)
        {
            Console.WriteLine($"¡Inicio de sesión exitoso! Bienvenid@ {usuario.Nombre}.");
            var menuFunciones = new MenuFunciones(_usuarioService, _likeService);
            await menuFunciones.MenuPrincipalUsuario(usuario.Id);
        }
        else
        {
            Console.WriteLine("❌ Credenciales inválidas. Por favor, inténtalo de nuevo.");
        }

        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
    }
    private async Task<Usuario?> AutenticarUsuarioAsync(string email, string password) => await _usuarioService.GetUsuarioPorCredencialesAsync(email, password);

}