using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationASPAuth.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Photo { get; set; }
        public int CategorieID { get; set; }

        public virtual Categorie Categorie { get; set; }
    }
}