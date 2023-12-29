using ProyectoSegurosBack.viewmodels;
using System.Globalization;

namespace ProyectoSegurosBack.services
{
    public interface ISeguros
    {
        public List<SegurosVM> ObtenerSeguros();
        public bool setSeguros(SegurosVM seguros);
        public bool putSeguros(SegurosVM seguros);
        public bool deleteSeguro(int id);
        public bool SetPoliza(SetPolizaVM setPolizas);
        public List<PolizasVM> ObtenerPolizas();
        public List<PolizasVM> ObtenerSegurosByCedula(string cedula);
        public List<PolizasVM> ObtenerSegurosByCod(string codigo);
        public List<PolizasVM> GetAllPolizas(string codigo, string cedula);
        public List<PolizasVM> ObtenerSegurosById(int id);
    }
}
