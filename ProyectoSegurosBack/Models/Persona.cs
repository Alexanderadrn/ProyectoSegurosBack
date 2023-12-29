using System;
using System.Collections.Generic;

namespace ProyectoSegurosBack.Models;

public partial class Persona
{
    public int IdPersonas { get; set; }

    public string? NombrePersonas { get; set; }

    public string? CedulaPersonas { get; set; }

    public string? TelefonoPersonas { get; set; }

    public int? EdadPersonas { get; set; }

    public virtual ICollection<Poliza> Polizas { get; set; } = new List<Poliza>();
}
