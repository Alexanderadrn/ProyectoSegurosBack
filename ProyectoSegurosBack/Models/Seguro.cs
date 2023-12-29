using System;
using System.Collections.Generic;

namespace ProyectoSegurosBack.Models;

public partial class Seguro
{
    public int IdSeguro { get; set; }

    public string? NombreSeguo { get; set; }

    public string? CodigoSeguro { get; set; }

    public decimal? SumaAsegurada { get; set; }

    public decimal? Prima { get; set; }

    public virtual ICollection<Poliza> Polizas { get; set; } = new List<Poliza>();
}
