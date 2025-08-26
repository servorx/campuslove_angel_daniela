
using campuslove_angel_daniela.src.modules.interes.infrastructure.repositories;
using campuslove_angel_daniela.src.modules.interes_usuario.application.services;
using campuslove_angel_daniela.src.modules.interes_usuario.infrastructure.repositories;
using campuslove_angel_daniela.src.modules.like.application.services;
using campuslove_angel_daniela.src.modules.like.infrastructure.repositories;
using campuslove_angel_daniela.src.modules.usuario.application.services;
using campuslove_angel_daniela.src.modules.usuario.infrastructure.repositories;
using campuslove_angel_daniela.src.shared.helpers;
using campuslove_angel_daniela.src.ui;
using examen_csharp.src.modules.configuracion.application.services;
using examen_csharp.src.modules.configuracion.infrastructure.repositories;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = DbContextFactory.Create();
        // Instanciar repositorios
        var usuarioRepository = new UsuarioRepository(context);
        var interesRepository = new InteresRepository(context);
        var interesUsuarioRepository = new InteresUsuarioRepository(context);
        var likeRepository = new LikeRepository(context);
        var configuracionRepository = new ConfiguracionRepository(context);
        // pasamos los repositorios al servicio
        var usuarioService = new UsuarioService(usuarioRepository, interesRepository, interesUsuarioRepository);
        var interesUsuarioService = new InteresUsuarioService(interesUsuarioRepository);
        var likeService = new LikeService(likeRepository);
        var configuracionService = new ConfiguracionService(configuracionRepository);

        var menu = new MenuPrincipal(usuarioService, interesUsuarioService, likeService, configuracionService);

        menu.MostrarBienvenida();
        menu.EjecutarMenuPrincipal().GetAwaiter().GetResult();
    }
}