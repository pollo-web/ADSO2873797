using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Autoincremental
        public int Id { get; set; }

        [Required(ErrorMessage = "El Usuario es obligatorio")]
        [StringLength(50, ErrorMessage = "El usuario no puede exceder los 50 caracteres")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoris")]
        [StringLength(50, ErrorMessage = "La contraseña no puede exeder el limite de caracteres")]
        public string Pass { get; set; }

        [Required(ErrorMessage = "La fecha de creación es obligatoria")]
        public DateTime FechaCreacion { get; set; }

        
        public byte[] HashIV { get; set; }
       
        public byte[] HashKey { get; set; }
    }

}