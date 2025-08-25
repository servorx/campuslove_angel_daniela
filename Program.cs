using examen_csharp.src.shared.helpers;
using examen_csharp.src.ui;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = DbContextFactory.Create();
    }
}