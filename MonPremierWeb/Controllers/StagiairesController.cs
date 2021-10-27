using MonPremierWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonPremierWeb.Controllers
{
    public class StagiairesController : Controller
    {
        // GET: Stagiaires
        public ActionResult Index()
        {
            Stagiaire a = new Stagiaire();
            a.Id = 10; a.Nom = "Snow"; a.Prenom = "John";
            return View(a);
        }

        [HttpGet]
        public ActionResult Saisie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Saisie(Abonne abonne)
        {

            ViewBag.Prenom = abonne.Prenom;
            //ViewData["Nom"] = abonne.Nom; 
            return View("Success");
        }

        public ActionResult FormulaireBootstrap(Abonne abonne)
        {
            return View();
        }

        [HttpGet]
        public ActionResult SaisieHelper()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaisieHelper(Abonne abonne)
        {
            return View("Success");
        }
    }
}