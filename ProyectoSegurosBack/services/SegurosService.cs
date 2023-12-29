using Microsoft.Identity.Client;
using ProyectoSegurosBack.Models;
using ProyectoSegurosBack.viewmodels;
using System.Diagnostics.Eventing.Reader;

namespace ProyectoSegurosBack.services
{
    public class SegurosService : ISeguros
    {

        private SegurosContext _context;
        public SegurosService(SegurosContext context)
        {
            this._context = context;
        }
        #region Seguros
        public List<SegurosVM> ObtenerSeguros()
        {
            List<SegurosVM> listaSeguros = new List<SegurosVM>();
            var seguros = _context.Seguros.ToList();
            foreach (var item in seguros)
            {
                SegurosVM seguro = new SegurosVM
                {
                    idSeguro = item.IdSeguro,
                    nombreSeguo = item.NombreSeguo,
                    codigoSeguro = item.CodigoSeguro,
                    sumaAsegurada = item.SumaAsegurada,
                    prima = item.Prima

                };
                listaSeguros.Add(seguro);
            }
            return listaSeguros;
        }
        public bool setSeguros(SegurosVM seguros)
        {
            bool registrado = false;
            try
            {
                Seguro seguroBD = new Seguro();
                seguroBD.IdSeguro = seguros.idSeguro;
                seguroBD.NombreSeguo = seguros.nombreSeguo;
                seguroBD.CodigoSeguro = seguros.codigoSeguro;
                seguroBD.SumaAsegurada = seguros.sumaAsegurada;
                seguroBD.Prima = seguros.prima;

                _context.Seguros.Add(seguroBD);
                _context.SaveChanges();
                registrado = true;
            }
            catch (Exception)
            {
                registrado = false;
            }
            return registrado;
        }
        public bool putSeguros(SegurosVM seguros)
        {
            bool registrado = false;
            try
            {
                var putSeguros = _context.Seguros.Where(x => x.IdSeguro == seguros.idSeguro).FirstOrDefault();
                putSeguros.NombreSeguo = seguros.nombreSeguo;
                putSeguros.CodigoSeguro = seguros.codigoSeguro;
                putSeguros.SumaAsegurada = seguros.sumaAsegurada;
                putSeguros.Prima = seguros.prima;
                _context.SaveChanges();
                registrado = true;
            }
            catch (Exception)
            {
                registrado = false;
            }
            return registrado;
        }
        public bool deleteSeguro(int id)
        {
            bool registrado = false;
            var deleteSeguro = _context.Seguros.Where(X => X.IdSeguro == id).FirstOrDefault();
            try
            {
                _context.Seguros.Remove(deleteSeguro);
                _context.SaveChanges();
                registrado = true;
            }
            catch
            {
                registrado = false;
            }
            return registrado;
        }
        #endregion

        #region Relacion
        public bool SetPoliza(SetPolizaVM setPolizas)
        {
            bool registrado = false;
            if (setPolizas.idPersonas != 0 && setPolizas.idSeguro != 0)
            {
                try
                {
                    Poliza polizaBD = new Poliza();
                    polizaBD.IdPersonas = setPolizas.idPersonas;
                    polizaBD.IdSeguro = setPolizas.idSeguro;
                    _context.Polizas.Add(polizaBD);
                    _context.SaveChanges();
                    registrado = true;
                }
                catch (Exception)
                {
                    registrado = false;
                }

            }
            else
            {
                Console.WriteLine("No existe el numero de cedula o codgido seguro");
                registrado = false;
            }
            return registrado;
        }
        public List<PolizasVM> ObtenerPolizas()
        {
            List<PolizasVM> lista = new List<PolizasVM>();
            var relacion = (from polizas in _context.Polizas
                            join personas in _context.Personas
                            on polizas.IdPersonas equals personas.IdPersonas
                            join seguros in _context.Seguros
                            on polizas.IdSeguro equals seguros.IdSeguro
                            where polizas.IdPoliza != 0
                            select new
                            {
                                polizas.IdPersonas,
                                polizas.IdPoliza,
                                polizas.IdSeguro,
                                personas.NombrePersonas,
                                personas.CedulaPersonas,
                                seguros.NombreSeguo,
                                seguros.CodigoSeguro,
                                seguros.SumaAsegurada,
                                seguros.Prima

                            }
                         ).ToList();
            foreach (var item in relacion)
            {
                PolizasVM registro = new PolizasVM
                {
                    idPoliza = item.IdPoliza,
                    idPersonas = item.IdPersonas,
                    idSeguro = item.IdSeguro,
                    nombrePersonas = item.NombrePersonas,
                    cedulaPersona = item.CedulaPersonas,
                    nombreSeguo = item.NombreSeguo,
                    codSeguro = item.CodigoSeguro,
                    prima = item.Prima,
                    sumaAsegurada = item.SumaAsegurada

                };
                lista.Add(registro);

            }
            return lista;
        }
        public List<PolizasVM> ObtenerPolizasfiltros(string cedula, string codigo)
        {
            List<PolizasVM> lista = new List<PolizasVM>();
            var relacion = (from polizas in _context.Polizas
                            join personas in _context.Personas
                            on polizas.IdPersonas equals personas.IdPersonas
                            join seguros in _context.Seguros
                            on polizas.IdSeguro equals seguros.IdSeguro
                            where personas.CedulaPersonas == cedula && seguros.CodigoSeguro == codigo
                            select new
                            {
                                polizas.IdPersonas,
                                polizas.IdPoliza,
                                polizas.IdSeguro,
                                personas.NombrePersonas,
                                personas.CedulaPersonas,
                                seguros.NombreSeguo,
                                seguros.CodigoSeguro,
                                seguros.SumaAsegurada,
                                seguros.Prima

                            }
                         ).ToList();
            foreach (var item in relacion)
            {
                PolizasVM registro = new PolizasVM
                {
                    idPoliza = item.IdPoliza,
                    idPersonas = item.IdPersonas,
                    idSeguro = item.IdSeguro,
                    nombrePersonas = item.NombrePersonas,
                    cedulaPersona = item.CedulaPersonas,
                    nombreSeguo = item.NombreSeguo,
                    codSeguro = item.CodigoSeguro,
                    prima = item.Prima,
                    sumaAsegurada = item.SumaAsegurada

                };
                lista.Add(registro);

            }
            return lista;
        }
        public List<PolizasVM> ObtenerSegurosByCedula(string cedula)
        {
            List<PolizasVM> lista = new List<PolizasVM>();
            var relacion = (from polizas in _context.Polizas
                            join personas in _context.Personas
                            on polizas.IdPersonas equals personas.IdPersonas
                            join seguros in _context.Seguros
                            on polizas.IdSeguro equals seguros.IdSeguro
                            where personas.CedulaPersonas == cedula
                            select new
                            {
                                polizas.IdPersonas,
                                polizas.IdPoliza,
                                polizas.IdSeguro,
                                personas.NombrePersonas,
                                personas.CedulaPersonas,
                                seguros.NombreSeguo,
                                seguros.CodigoSeguro,
                                seguros.SumaAsegurada,
                                seguros.Prima

                            }
                         ).ToList();
            foreach (var item in relacion)
            {
                PolizasVM registro = new PolizasVM
                {
                    idPoliza = item.IdPoliza,
                    idPersonas = item.IdPersonas,
                    idSeguro = item.IdSeguro,
                    nombrePersonas = item.NombrePersonas,
                    cedulaPersona = item.CedulaPersonas,
                    nombreSeguo = item.NombreSeguo,
                    codSeguro = item.CodigoSeguro,
                    prima = item.Prima,
                    sumaAsegurada = item.SumaAsegurada

                };
                lista.Add(registro);

            }
            return lista;

        }
        public List<PolizasVM> ObtenerSegurosByCod(string codigo)
        {
            List<PolizasVM> lista = new List<PolizasVM>();
            var relacion = (from polizas in _context.Polizas
                            join personas in _context.Personas
                            on polizas.IdPersonas equals personas.IdPersonas
                            join seguros in _context.Seguros
                            on polizas.IdSeguro equals seguros.IdSeguro
                            where seguros.CodigoSeguro == codigo
                            select new
                            {
                                polizas.IdPersonas,
                                polizas.IdPoliza,
                                polizas.IdSeguro,
                                personas.NombrePersonas,
                                personas.CedulaPersonas,
                                seguros.NombreSeguo,
                                seguros.CodigoSeguro,
                                seguros.SumaAsegurada,
                                seguros.Prima

                            }
                         ).ToList();
            foreach (var item in relacion)
            {
                PolizasVM registro = new PolizasVM
                {
                    idPoliza = item.IdPoliza,
                    idPersonas = item.IdPersonas,
                    idSeguro = item.IdSeguro,
                    nombrePersonas = item.NombrePersonas,
                    cedulaPersona = item.CedulaPersonas,
                    nombreSeguo = item.NombreSeguo,
                    codSeguro = item.CodigoSeguro,
                    prima = item.Prima,
                    sumaAsegurada = item.SumaAsegurada

                };
                lista.Add(registro);

            }
            return lista;

        }
        public List<PolizasVM> GetAllPolizas(string codigo, string cedula)
        {
            if (!string.IsNullOrEmpty(cedula) && !string.IsNullOrEmpty(codigo))
            {
                return ObtenerPolizasfiltros(cedula, codigo);

            }
            else if (!string.IsNullOrEmpty(cedula))
            {
                return ObtenerSegurosByCedula(cedula);

            }
            else if (!string.IsNullOrEmpty(codigo))
            {
                return ObtenerSegurosByCod(codigo);
            }
            else
            {
                return ObtenerPolizas();
            }
        }
        public List<PolizasVM> ObtenerSegurosById(int id)
        {
            List<PolizasVM> lista = new List<PolizasVM>();
            var relacion = (from polizas in _context.Polizas
                            join personas in _context.Personas
                            on polizas.IdPersonas equals personas.IdPersonas
                            join seguros in _context.Seguros
                            on polizas.IdSeguro equals seguros.IdSeguro
                            where personas.IdPersonas == id
                            select new
                            {
                                polizas.IdPersonas,
                                polizas.IdPoliza,
                                polizas.IdSeguro,
                                personas.NombrePersonas,
                                personas.CedulaPersonas,
                                seguros.NombreSeguo,
                                seguros.CodigoSeguro,
                                seguros.SumaAsegurada,
                                seguros.Prima

                            }
                         ).ToList();
            foreach (var item in relacion)
            {
                PolizasVM registro = new PolizasVM
                {
                    idPoliza = item.IdPoliza,
                    idPersonas = item.IdPersonas,
                    idSeguro = item.IdSeguro,
                    nombrePersonas = item.NombrePersonas,
                    cedulaPersona = item.CedulaPersonas,
                    nombreSeguo = item.NombreSeguo,
                    codSeguro = item.CodigoSeguro,
                    prima = item.Prima,
                    sumaAsegurada = item.SumaAsegurada

                };
                lista.Add(registro);

            }
            return lista;

        }
    }

    #endregion

}

