using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.usuario.domain.models;

namespace campuslove_angel_daniela.src.modules.dislike.domain.models;

public class Dislike
{
    public int Id { get; set; }
    public int IdEmisor { get; set; }
    public int IdReceptor { get; set; }

    // Relaciones
    public Usuario Emisor { get; set; } = null!;
    public Usuario Receptor { get; set; } = null!;
    public Dislike()
    {

    }
    public Dislike(Usuario emisor, Usuario receptor)
    {
        Emisor = emisor;
        Receptor = receptor;
    }
    public override string ToString()
    {
        return $"{Id} | {IdEmisor} | {IdReceptor}";
    }
}
