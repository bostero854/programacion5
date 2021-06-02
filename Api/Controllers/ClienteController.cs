using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {


        [HttpPost()]
        public IActionResult Post(IList<Models.Persona> personas)
        {
            Deal.Persona persona;
            try
            {
                persona = new Deal.Persona();

                if (persona.Agregar(personas))
                {
                    return Ok();
                }
                else 
                {
                    return BadRequest("Error al agregar los datos");
                }

               
            }
            catch (Exception)
            {

                throw;
            }
    
        }

        [HttpGet("dni/{dni}")]
        public IActionResult Get(string dni)
        {
            Deal.Persona persona;
            Models.Persona Persona;
            try
            {
                persona = new Deal.Persona();
                Persona = persona.ListPersonasDni(dni);
                if (Persona != null)
                {
                    return Ok(Persona);
                }
                else 
                {
                    return BadRequest("Sin registros");
                }
              
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet()]
        public IActionResult Get()
        {
            Deal.Persona persona;
            IList<Models.Persona> ilistPersona;
            try
            {
                persona = new Deal.Persona();
                ilistPersona = persona.ListPersonas();
                if (ilistPersona != null)
                {
                    return Ok(ilistPersona);
                }
                else
                {
                    return BadRequest("Sin registros");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
