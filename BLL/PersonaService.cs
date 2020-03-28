using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;


namespace BLL
{
    public class PersonaService
    {
        private PersonaRepository personaRepository;
        public List<Persona> personas;
        Persona persona;
        public PersonaService()
        {

            personaRepository = new PersonaRepository();
            personas= personaRepository.ConsultarPersonas();
        }
        public void CalcularPulsacion(Persona persona)
        {
            if (persona.Sexo.ToUpper().Equals("M"))
            {
                persona.Pulsacion = (210 - persona.Edad) / 10;
            }
            else if (persona.Sexo.ToUpper().Equals("F"))
            {
                persona.Pulsacion = (220 - persona.Edad) / 10;
            }
            else {
                persona.Pulsacion = 0;
            }
        }

        public void Guardar(Persona persona)
        {
            personas.Add(persona);
            personaRepository.Guardar(personas);
        }

        public void Modificar(Persona persona, Persona personaModificada)
        {
            personaRepository.Modificar(persona, personaModificada);
        }

        public void Eliminar(Persona persona) {

            personaRepository.Eliminar(persona);

        }


        public Persona BuscarPersona(string identificacion) {
            persona = new Persona();
            persona = personaRepository.BuscarPersona(identificacion);
            if (persona == null)
            {
                return null;
            }
            return persona;
        }
        
    }
}
