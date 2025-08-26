
using campuslove_angel_daniela.src.modules.interes.infrastructure.repositories;
using campuslove_angel_daniela.src.modules.interes_usuario.application.services;
using campuslove_angel_daniela.src.modules.interes_usuario.infrastructure.repositories;
using campuslove_angel_daniela.src.modules.usuario.application.services;
using campuslove_angel_daniela.src.modules.usuario.infrastructure.repositories;
using campuslove_angel_daniela.src.shared.helpers;
using campuslove_angel_daniela.src.ui;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = DbContextFactory.Create();
        // 2. Instanciar repositorios
        var usuarioRepository = new UsuarioRepository(context);
        var interesRepository = new InteresRepository(context);
        var interesUsuarioRepository = new InteresUsuarioRepository(context);

        // pasamos los 3 repositorios al servicio
        var usuarioService = new UsuarioService(usuarioRepository, interesRepository, interesUsuarioRepository);

        var interesUsuarioService = new InteresUsuarioService(interesUsuarioRepository);

        var menu = new MenuPrincipal(usuarioService, interesUsuarioService);

        menu.EjecutarMenuPrincipal().GetAwaiter().GetResult();
    }
}