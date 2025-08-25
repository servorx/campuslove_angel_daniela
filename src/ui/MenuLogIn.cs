
namespace campuslove_angel_daniela.src.ui;

public class MenuLogIn
{
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

    private bool AutenticarUsuario(string? email, string? password)
    {
        throw new NotImplementedException();
    }
}