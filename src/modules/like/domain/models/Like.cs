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

    // Relaciones
    public Usuario Emisor { get; set; } = null!;
    public Usuario Receptor { get; set; } = null!;
    public Like()
    {

    }
    public Like(Usuario emisor, Usuario receptor, bool esMatch)
    {
        Emisor = emisor;
        Receptor = receptor;
        EsMatch = esMatch;
    }
    public override string ToString()
    {
        return $"{Id} | {IdEmisor} | {IdReceptor} | {EsMatch}";
    }
}
