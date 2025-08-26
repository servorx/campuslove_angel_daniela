
using campuslove_angel_daniela.src.modules.usuario.application.services;
using campuslove_angel_daniela.src.modules.usuario.domain.models;

namespace campuslove_angel_daniela.src.ui;

public class MenuLogIn
{
    private readonly UsuarioService _usuarioService;
    public MenuLogIn(UsuarioService usuarioService) =>_usuarioService = usuarioService;
    public void MenuLogInUsuario()
    {
        Console.Clear();
        Console.WriteLine("===========================================");
        Console.WriteLine("             ❤︎ LOG IN USUARIO  ❤︎          ");
        Console.WriteLine("===========================================");
        Console.Write("Ingrese su correo electrónico: ");
        string? email = Console.ReadLine();
        Console.Write("Ingrese su contraseña: ");
        string? password = Console.ReadLine();

        bool isAuthenticated = AutenticarUsuario(email, password);

        if (isAuthenticated)
        {
            Console.WriteLine("¡Inicio de sesión exitoso! Bienvenid@.");
        }
        else
        {
            Console.WriteLine("Credenciales inválidas. Por favor, inténtalo de nuevo.");
        }

        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
    }
    private bool AutenticarUsuario(string email, string password)
    {
        return _usuarioService.VerificarLoginAsync(email, password).Result;
    }
}