using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Personas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Autoincremental
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "El apellido no puede exceder los 50 caracteres")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El número de identificación es obligatorio")]
        [StringLength(50, ErrorMessage = "El número de identificación no puede exceder los 50 caracteres")]
        public string NumeroIdentificacion { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [StringLength(50, ErrorMessage = "El correo no puede exceder los 50 caracteres")]
        [EmailAddress(ErrorMessage = "Debe proporcionar un correo válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El tipo de identificación es obligatorio")]
        [StringLength(50, ErrorMessage = "El tipo de identificación no puede exceder los 50 caracteres")]
        public string TipoIdentificacion { get; set; }

        [Required(ErrorMessage = "La fecha de creación es obligatoria")]
        public DateTime FechaCreacion { get; set; }
}
   
    }

