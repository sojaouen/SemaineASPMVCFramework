using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonPremierWeb.Models
{
    public class Abonne
    {
        // Creation de vues qui utilisent un modele
        public int Id { get; set; }
        [Required(ErrorMessage = "Ce champs nom est obligatoire")]
        [Display(Name ="Nom")]
        public string Nom { get; set; }
        [MinLength(5)]
        public string Prenom  { get; set; }

        public string Email { get; set; }

        // Creer un Controller qui continet une Action Index qui affiche un abonne 
    }
}