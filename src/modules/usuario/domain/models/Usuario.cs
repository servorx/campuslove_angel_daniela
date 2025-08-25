

using campuslove_angel_daniela.src.modules.dislike.domain.models;
using campuslove_angel_daniela.src.modules.interes_usuario.domain.models;
using campuslove_angel_daniela.src.modules.like.domain.models;


namespace campuslove_angel_daniela.src.modules.usuario.domain.models;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public string Contrasenia { get; set; } = null!;
    public int Edad { get; set; }
    public string? Carrera { get; set; }
    public string? Frase { get; set; }
    public string Orientacion { get; set; } = null!;
    public string Busqueda { get; set; } = null!;
    // relaciones foraneas 
    public ICollection<InteresUsuario> InteresesUsuarios { get; set; } = new List<InteresUsuario>();
    public ICollection<Like> LikesEnviados { get; set; } = new List<Like>();
    public ICollection<Like> LikesRecibidos { get; set; } = new List<Like>();
    public ICollection<Dislike> DislikesEnviados { get; set; } = new List<Dislike>();
    public ICollection<Dislike> DislikesRecibidos { get; set; } = new List<Dislike>();
    // define el constructor
    public Usuario() { }
    public Usuario(string nombre, string apellido, string correo, string contrasenia, int edad, string? carrera, string? frase, string orientacion, string busqueda)
    {
        Nombre = nombre;
        Apellido = apellido;
        Correo = correo;
        Contrasenia = contrasenia;
        Edad = edad;
        Carrera = carrera;
        Frase = frase;
        Orientacion = orientacion;
        Busqueda = busqueda;
    }
    public override string ToString()
    {
        return $"{Id} | {Nombre} | {Apellido} | {Correo} | {Contrasenia} | {Edad} | {Orientacion} | {Busqueda}";
    }
}
