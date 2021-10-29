using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationASPAuth.Models
{
    public class Categorie
    {
        public int Id { get; set; }

        public string Designation { get; set; }
        public virtual ICollection<Produit> Produits { get; set; }
    }
}