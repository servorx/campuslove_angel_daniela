using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.interes.domain.models;
using campuslove_angel_daniela.src.modules.usuario.domain.models;

namespace campuslove_angel_daniela.src.modules.interes_usuario.domain.models;

public class InteresUsuario
{
    public int IdUsuario { get; set; }
    public int IdIntereses { get; set; }

    // Relaciones
    public Usuario Usuario { get; set; } = null!;
    public Interes Interes { get; set; } = null!;
    public InteresUsuario()
    {

    }
    public InteresUsuario(Usuario usuario, Interes intereses)
    {
        Usuario = usuario;
        Interes = intereses;
    }
    public override string ToString()
    {
        return $"{IdUsuario} | {IdIntereses}";
    }
}
