using System;
using System.Collections.Generic;

namespace Api.Deal
{
    public class Persona
    {
        public bool Agregar(IList<Models.Persona> personas) 
        {
            DataAcces.PersonaDto personaDto;

            try
            {
                personaDto = new DataAcces.PersonaDto();
                return personaDto.Agregar(personas);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Models.Persona ListPersonasDni(string nroDoc)
        {

            try
            {
                DataAcces.PersonaDto personaDto;
                personaDto = new DataAcces.PersonaDto();
                return personaDto.Listado(nroDoc);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IList<Models.Persona> ListPersonas()
        {

            try
            {
                DataAcces.PersonaDto personaDto;
                personaDto = new DataAcces.PersonaDto();
                return personaDto.ListadoGeneral();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
