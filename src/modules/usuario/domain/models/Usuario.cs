using examen_csharp.src.modules.entidad.domain.models;

namespace examen_csharp.src.modules.usuario.domain.models;

public class Usuario
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Genero { get; set; }
    public string? Carrera { get; set; }
    public string? Intereses { get; set; }
    public string? Frase { get; set; }
    // relaciones foraneas con likes
    // define el constructor
    public Usuario(
        string nombre,
        string apellido,
        string genero,
        string carrera,
        string intereses,
        string frase
    )
    {
        Nombre = nombre;
        Apellido = apellido;
        Genero = genero;
        Carrera = carrera;
        Intereses = intereses;
        Frase = frase;
    }
    // define el constructor vacio
    public Usuario() { }
    public override string ToString()
    {
        return $"{Id} | {Nombre} | {Apellido} | {Genero} | {Carrera} | {Intereses} | {Frase }";
    }
}
