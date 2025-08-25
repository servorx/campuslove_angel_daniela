using campuslove_angel_daniela.src.shared.helpers;
using campuslove_angel_daniela.src.ui;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = DbContextFactory.Create();
        var menu = new MenuPrincipal();
        menu.MostrarBienvenida();
        menu.Mostrarmenuprincipal();
        menu.EjecutarMenuPrincipal();
    }
}