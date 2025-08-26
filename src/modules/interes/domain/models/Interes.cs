
using campuslove_angel_daniela.src.modules.interes_usuario.domain.models;

namespace campuslove_angel_daniela.src.modules.interes.domain.models;

public class Interes
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }

    // Relaciones
    public ICollection<InteresUsuario> InteresesUsuarios { get; set; } = new List<InteresUsuario>();
    public Interes()
    {

    }
    public Interes(string nombre, string descripcion)
    {
        Nombre = nombre;
        Descripcion = descripcion;
    }
    public override string ToString()
    {
        return $"{Id} | {Nombre} | {Descripcion}";
    }
}