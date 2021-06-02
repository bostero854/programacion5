using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Persona
    {
        [Required]
        [StringLength(13, MinimumLength = 8, ErrorMessage = "Ingrese como mínimo 8 caracteres.")]
        public string Dni { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ingrese como mínimo 3 caracteres.")]
        public string Nombre{ get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ingrese como mínimo 3 caracteres.")]
        public string Apellido{ get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Ingrese como mínimo 3 caracteres.")]
        public string Curso { get; set; }

        [Required]
        public Int32 Año { get; set; }
    }
}
