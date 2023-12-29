using System;
using System.Collections.Generic;

namespace ProyectoSegurosBack.Models;

public partial class Poliza
{
    public int IdPoliza { get; set; }

    public int? IdPersonas { get; set; }

    public int? IdSeguro { get; set; }

    public virtual Persona? IdPersonasNavigation { get; set; }

    public virtual Seguro? IdSeguroNavigation { get; set; }
}
