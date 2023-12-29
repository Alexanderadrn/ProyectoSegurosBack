using ProyectoSegurosBack.viewmodels;

namespace ProyectoSegurosBack.services
{
    public interface IPersonas
    {
        public List<PersonasVM> ObtenerPersonas();
        public bool setPersonas(PersonasVM personas);
        public bool putPersonas(PersonasVM personas);
        public bool deletePersonas(int idPersonas);
    }
}
