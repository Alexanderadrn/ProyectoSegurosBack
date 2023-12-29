namespace ProyectoSegurosBack.viewmodels
{
    public class PolizasVM
    {
        public int idPoliza { get; set; }

        public string? cedulaPersona { get; set; }

        public string? codSeguro { get; set; }

        public int? idPersonas { get; set; }

        public int? idSeguro { get; set; }

        public string? nombrePersonas { get; set; }
        
       
        public string? nombreSeguo { get; set; }
        public decimal? sumaAsegurada { get; set; }

        public decimal? prima { get; set; }

    }
    public class SetPolizaVM
    {
        public int idPoliza { get; set; }
        public int? idPersonas { get; set; }

        public int? idSeguro { get; set; }

    }

}
