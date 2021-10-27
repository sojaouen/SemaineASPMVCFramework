using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonPremierWeb.Controllers
{
    public class TestController : Controller
    {
        // Nom contient le suffixe + hérite de la classe Controller

        // Une méthode qui retourne une Vue

        public ActionResult MaVue()
        {
            return View();

            // Suppose que nous avons :
            // 1 -  Un dossier Test dans Views
            // 2 - Dans ce dossier on a un fichier MaVue.cshtml
        }

        // Une action qui retourne un string

        public string Action2()
        {
            return "Salut !!! - Depuis ma page web";
        }

        // Une action qui retourne un string avec du HTML

        public string Action3()
        {
            return "<html> <title> tester une action avec un peu d'HTML </title>" +
                "<body>" +
                "<h1> titre de niveau 1</h1>" +
                "<p> un paragraphe en <b> gras </b> de <i> l'italique </i> et du <u> souligne </u>" +
                "du <b style='color:red;'> gras et rouge </b>" +
                " suite du paragraphe <span style='color:blue;'> en bleu...</span>" +
                "</p> </body>" +
                "</html>";
        }

        // Retourner du JSON

        public JsonResult GetJson()
        {
            var data = new { nom = "Snow", prenom = "John" };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}