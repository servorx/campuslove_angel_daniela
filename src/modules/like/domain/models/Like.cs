using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.usuario.domain.models;

namespace campuslove_angel_daniela.src.modules.like.domain.models;

public class Like
{
    public int Id { get; set; }
    public int IdEmisor { get; set; }
    public int IdReceptor { get; set; }
    public bool EsMatch { get; set; }
    public DateTime Fecha { get; set; }

    // Relaciones
    public Usuario Emisor { get; set; } = null!;
    public Usuario Receptor { get; set; } = null!;
    public Like()
    {

    }
    public Like(Usuario emisor, Usuario receptor, bool esMatch, DateTime fecha)
    {
        Emisor = emisor;
        Receptor = receptor;
        EsMatch = esMatch;
        Fecha = fecha;
    }
    public override string ToString()
    {
        return $"{Id} | {IdEmisor} | {IdReceptor} | {EsMatch} | {Fecha}";
    }
}
