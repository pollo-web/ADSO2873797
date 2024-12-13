using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solonacional.Models
{
    public class Personas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Identficador { get; set; }
        [Required(ErrorMessage ="Por favor introduzca su nombre")]
        [StringLength(25,ErrorMessage ="Exedio el limite de caracteres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Por favor introduzca su apellido")]
        [StringLength(25, ErrorMessage = "Exedio el limite de caracteres")]
        public string Ápellidos {  get; set; }

        [Required(ErrorMessage = "Por favor introduzca su ID")]
        public int NumeroIdentificacion { get; set; }

        [Required(ErrorMessage = "Por favor introduzca su correo")]
        [EmailAddress(ErrorMessage ="Correo no valido")]
        [StringLength(50, ErrorMessage = "Exedio el limite de caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor introduzca su tipo de identificacion")]
        [StringLength(20, ErrorMessage = "Exedio el limite de caracter")]
        public string TipoIdentificacion { get; set; }

        [Required(ErrorMessage = "Por favor introduzca la fecha de creacion.")]
        public DateTime Fechacreacion { get; set; }
    }
}