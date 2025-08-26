
using campuslove_angel_daniela.src.modules.interes_usuario.application.services;
using campuslove_angel_daniela.src.modules.interes_usuario.domain.models;
using campuslove_angel_daniela.src.modules.usuario.application.interfaces;
using campuslove_angel_daniela.src.modules.usuario.application.services;
using campuslove_angel_daniela.src.modules.usuario.domain.models;
using examen_csharp.src.shared.utils;

namespace campuslove_angel_daniela.src.ui;
public class MenuUsuario
{
    // funcioalidades de los servicios de usuario e intereses
    // crear usuario
    private readonly UsuarioService _usuarioService;
    private readonly InteresUsuarioService _interesUsuarioService;
    public MenuUsuario(UsuarioService usuarioService, InteresUsuarioService interesService)
    {
        _usuarioService = usuarioService;
        _interesUsuarioService = interesService;
    }
    public async Task MenuCrearUsuario()
    {
        Console.Clear();
        Console.WriteLine("===========================================");
        Console.WriteLine("             ❤︎ CREAR USUARIO ❤︎             ");
        Console.WriteLine("===========================================");

        Console.Write("Ingrese su nombre: ");
        string? nombre = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(nombre) || nombre.Any(char.IsDigit))
        {
            Console.Write("Por favor, ingrese un nombre válido: ");
            nombre = Console.ReadLine();
        }

        Console.Write("Ingrese su apellido: ");
        string? apellido = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(apellido) || apellido.Any(char.IsDigit))
        {
            Console.Write("Por favor, ingrese un apellido válido: ");
            apellido = Console.ReadLine();
        }

        Console.Write("Ingrese su edad: ");
        string? edadInput = Console.ReadLine();
        int edad;
        while (!int.TryParse(edadInput, out edad) || edad <= 0)
        {
            if (edad <= 15)
            {
                Console.Write("Estas muy pequeño, ¿no?");
                Console.Write("Ingrese su edad: ");
                edadInput = Console.ReadLine();
            }
            Console.Write("Por favor, ingrese una edad válida: ");
            edadInput = Console.ReadLine();
        }

        Console.Write("Ingrese su género (M/F/Otro): ");
        string? genero = Console.ReadLine();
        while (genero != "M" && genero != "m" && genero != "F" && genero != "f" && genero != "Otro".ToLower().ToString().Trim())
        {
            Console.Write("Por favor, ingrese un género válido (M/F/Otro): ");
            genero = Console.ReadLine();
        }

        Console.Write("Ingrese su carrera profesional: ");
        string? carrera = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(carrera) || carrera.Any(char.IsDigit))
        {
            Console.Write("Por favor, ingrese una carrera válida: ");
            carrera = Console.ReadLine();
        }

        Console.Write("Ingresa tu frase de perfil: ");
        string? frase_perfil = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(frase_perfil) || frase_perfil.Any(char.IsDigit))
        {
            Console.Write("Por favor, ingrese una frase de perfil válida: ");
            frase_perfil = Console.ReadLine();
        }

        Console.Write("Ingresa tu orientacion (Heterosexual/Homosexual/Bisexual): ");
        string? orientacion = Console.ReadLine()?.ToLower().ToString().Trim();
        while (orientacion != "heterosexual".ToString().Trim().ToLower() && orientacion != "homosexual".ToString().Trim().ToLower() && orientacion != "bisexual".ToString().Trim().ToLower())
        {
            Console.Write("Por favor, ingrese una orientacion sexual valida (Heterosexual/Homosexual/Bisexual): ");
            orientacion = Console.ReadLine();
        }
        Console.Write("Ingresa aquello que buscar en esta aplicación (Relacion, amistad, etc.): ");
        string? busqueda = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(busqueda) || busqueda.Any(char.IsDigit))
        {
            Console.Write("Por favor, ingrese una busqueda válida: ");
            busqueda = Console.ReadLine();
        }

        Console.Write("Ingresa tu correo: ");
        string? correo = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(correo) || !correo.Contains("@"))
        {
            Console.Write("Por favor, ingrese un correo válido: ");
            correo = Console.ReadLine();
        }

        Console.Write("Ingresa tu contraseña: ");
        string? contrasenia = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(contrasenia))
        {
            Console.Write("Por favor, ingrese una contraseña válida: ");
            contrasenia = Console.ReadLine();
        }

        // Pedir intereses al usuario (ej: separados por coma)
        Console.Write("Ingrese sus intereses separados por coma: ");
        string? interesesInput = Console.ReadLine();
        var interesesList = interesesInput?.Split(",")
            .Select(i => i.Trim())
            .ToList();

        Console.Clear();
        Console.WriteLine("seguro que quieres crear el usuario con los siguietnes datos?");
        Console.WriteLine($"Nombre: {nombre}");
        Console.WriteLine($"Apellido: {apellido}");
        Console.WriteLine($"Correo: {correo}");
        Console.WriteLine($"Contraseña: {contrasenia}");
        Console.WriteLine($"Edad: {edad}");
        Console.WriteLine($"Genero: {genero}");
        Console.WriteLine($"Carrera: {carrera}");
        Console.WriteLine($"Frase: {frase_perfil}");
        Console.WriteLine($"Orientacion: {orientacion}");
        Console.WriteLine($"Busqueda: {busqueda}");
        Console.WriteLine($"Intereses: {string.Join(", ", interesesList)}");
        Console.WriteLine();
        Console.Write("¿Deseas crear el usuario? (S/N): ");
        string? input = Console.ReadLine();
        while (input != "s" && input != "S" && input != "n" && input != "N")
        {
            Console.WriteLine("Por favor, ingrese S o N: ");
            input = Console.ReadLine();
        }
        var usuario = new Usuario(
            nombre,
            apellido,
            correo,
            contrasenia,
            edad,
            genero,
            carrera,
            frase_perfil,
            orientacion,
            busqueda);
        // hashear la contraseña antes de guardarla
        usuario.Contrasenia = PasswordHasher.HashPassword(contrasenia);
        // aqui toca colocar los servicios de crear intereses y crear usuario a la vez
        await _usuarioService.CrearUsuarioConInteresesAsync(usuario, interesesList);
        Console.WriteLine("Usuario creado con éxito.");
        var result = _usuarioService.CrearUsuarioAsync(usuario);
        Console.WriteLine("Usuario creado con éxito.");
        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
