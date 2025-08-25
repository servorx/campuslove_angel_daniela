

namespace campuslove_angel_daniela.src.ui;
public class MenuUsuario
{
    public void MenuCrearUsuario()
    {
        Console.Clear();
        Console.WriteLine("===========================================");
        Console.WriteLine("             ❤︎ CREAR USUARIO ❤︎             ");
        Console.WriteLine("===========================================");
        Console.WriteLine("Ingrese su nombre:");
        string? nombre = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(nombre) || nombre.Any(char.IsDigit))
        {
            Console.WriteLine("Por favor, ingrese un nombre válido:");
            nombre = Console.ReadLine();
        }
        Console.WriteLine("Ingrese su edad:");
        string? edadInput = Console.ReadLine();
        int edad;
        while (!int.TryParse(edadInput, out edad) || edad <= 0)
        {
            Console.WriteLine("Por favor, ingrese una edad válida:");
            edadInput = Console.ReadLine();
        }
        Console.WriteLine("Ingrese su género (M/F/Otro):");
        string? genero = Console.ReadLine();
        while (genero != "M"  && genero !="m" && genero != "F" && genero !="f" && genero != "Otro")
        {
            Console.WriteLine("Por favor, ingrese un género válido (M/F/Otro):");
            genero = Console.ReadLine();
        }
        Console.WriteLine("Ingrese sus intereses:");
        string? intereses = Console.ReadLine();
        Console.WriteLine("Ingrese su carrera:");
        string? carrera = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(carrera) || carrera.Any(char.IsDigit))
        {
            Console.WriteLine("Por favor, ingrese una carrera válida:");
            carrera = Console.ReadLine();
        }
        Console.WriteLine("Ingresa tu frase de perfil:");
        string? frasePerfil = Console.ReadLine();

        Console.WriteLine("Usuario creado exitosamente!");
        Console.WriteLine($"Nombre: {nombre}");
        Console.WriteLine($"Edad: {edad}");
        Console.WriteLine($"Género: {genero}");
        Console.WriteLine($"intereses: {intereses}");
        Console.WriteLine($"Carrera: {carrera}");
        Console.WriteLine($"Frase de perfil: {frasePerfil}");
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
