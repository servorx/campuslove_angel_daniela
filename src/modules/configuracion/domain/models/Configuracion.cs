using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examen_csharp.src.modules.configuracion.domain.models;

public class Configuracion
{
    public int Id { get; set; }
    public string Clave { get; set; } = null!;
    public int Valor { get; set; }
    public Configuracion()
    {

    }
    public Configuracion(string clave, int valor)
    {
        Clave = clave;
        Valor = valor;
    }
    public override string ToString()
    {
        return $"{Id} | {Clave} | {Valor}";
    }
}
