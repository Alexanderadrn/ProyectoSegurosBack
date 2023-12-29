using ProyectoSegurosBack.Models;
using ProyectoSegurosBack.viewmodels;
using System.Reflection.Metadata.Ecma335;

namespace ProyectoSegurosBack.services
{
    public class PersonasService : IPersonas
    {
        private SegurosContext _context;
        public PersonasService(SegurosContext context)
        {
            this._context = context;
        }
        /*public bool CedulaValida (string cedula)
        {
            return cedula.Length == 10;
        } */
        public List<PersonasVM> ObtenerPersonas()
        {
            List<PersonasVM> listaPersonas = new List<PersonasVM>();
            var personas = _context.Personas.ToList();
            foreach (var item in personas)
            {
                PersonasVM persona = new PersonasVM
                {
                    idPersonas = item.IdPersonas,
                    nombrePersonas = item.NombrePersonas,
                    cedulaPersonas = item.CedulaPersonas,
                    telefonoPersonas = item.TelefonoPersonas,
                    edadPersonas = item.EdadPersonas,
                };
                listaPersonas.Add(persona); 
            }
            return listaPersonas;
        }

        public bool setPersonas(PersonasVM personas)
        {
            bool registrado = false;
            try
            {
                Persona personaBD = new Persona();
                personaBD.IdPersonas = personas.idPersonas;
                personaBD.NombrePersonas = personas.nombrePersonas;
                personaBD.CedulaPersonas = personas.cedulaPersonas;
                personaBD.TelefonoPersonas = personas.telefonoPersonas;
                personaBD.EdadPersonas = personas.edadPersonas;
                
                _context.Personas.Add(personaBD);
                _context.SaveChanges();
                registrado = true;
            }
            catch (Exception)
            {
                registrado=false;
            }
            return registrado;
        }
        public bool putPersonas (PersonasVM personas)
        {
            bool registrado= false;
            try
            {
                var putPersonas = _context.Personas.Where(x => x.IdPersonas == personas.idPersonas).FirstOrDefault();
                putPersonas.NombrePersonas = personas.nombrePersonas;
                putPersonas.CedulaPersonas = personas.cedulaPersonas;
                putPersonas.EdadPersonas = personas.edadPersonas;
                putPersonas.TelefonoPersonas = personas.telefonoPersonas;
                _context.SaveChanges();
                registrado =true;
            }
            catch(Exception)
            {
                registrado=false;
            }
            return registrado;
        }
        public bool deletePersonas(int idPersonas)
        {
            bool registrado = false;
            var deletePersonas = _context.Personas.Where(X => X.IdPersonas == idPersonas).FirstOrDefault();
            try
            {
                _context.Personas.Remove(deletePersonas);
                _context.SaveChanges();
                registrado = true;
            }
            catch
            {
                registrado = false;
            }
            return registrado;
        }
        
        

        

    }
}
