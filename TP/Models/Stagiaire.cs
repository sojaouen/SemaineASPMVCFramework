using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TP.Models
{
    public class Stagiaire
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ce champs nom est obligatoire")]
        [Display(Name = "Nom")]
        [MinLength(3)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Ce champs prenom est obligatoire")]
        [Display(Name = "Prenom")]
        [MinLength(3)]
        public string Prenom { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd.MM.yyyy}")]
        public DateTime DateNaissance { get; set; }
        public string Email { get; set; }
    }
}