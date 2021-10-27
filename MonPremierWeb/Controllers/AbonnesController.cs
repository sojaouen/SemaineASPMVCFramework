using MonPremierWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonPremierWeb.Controllers
{
    public class AbonnesController : Controller
    {
        static List<Abonne> listeAbonnes;

        public AbonnesController()
        {
            if (listeAbonnes == null)
                listeAbonnes = new List<Abonne>();
        }
        // GET: Abonnes
        public ActionResult Index()
        {
            Abonne a = new Abonne();
            a.Id = 10; a.Nom = "Snow"; a.Prenom = "John";
            return View(a); // ici on a un dossier Abonnes et ce dossier contient un fichier index.html
        }
        public ActionResult Liste()
        {
            return View(GetListe());
        }

        public List<Abonne> GetListe()
        {
            Random x = new Random();

            for (int i = 0; i < 100; i++)
            {
                Abonne abn = new Abonne();
                int j = x.Next(1, 1000);
                abn.Id = j;
                abn.Nom = "Nom" + j;
                abn.Prenom = "Prenom" + j;
                listeAbonnes.Add(abn);
            }

            return listeAbonnes;
        }

        public ActionResult Liste2()
        {
            return View(GetListe());
        }

        [HttpGet]
        // liste abonnes GridMVC
        public ActionResult Liste3()
        {
            return View(GetListe());
        }
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


        [HttpGet]
        public ActionResult SaisieHelper2()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SaisieHelper2(Abonne abonne)
        {
            if (!ModelState.IsValid)
            {
                return View(abonne);
            }

            return View("Success");
        }

        // Action pour la modification d'uin abonne
        [HttpGet]
        public ActionResult Modif(int id)
        {
            Abonne abonneAModifierOrigin = listeAbonnes.FirstOrDefault(x => x.Id == id);

            // tester s'il existe

            return View(abonneAModifierOrigin);
        }

        [HttpPost]

        public JsonResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Abonne abonneASupprimer = listeAbonnes.FirstOrDefault(x => x.Id == id);
                // if trouve

                listeAbonnes.Remove(abonneASupprimer);
                return Json(new { resultat = "OK" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { resultat = "NOK" }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]

        public ActionResult Modif(Abonne abonne)
        {
            if (ModelState.IsValid)
            {
                // modif = suppression + ajout

                Abonne abonneAModifier = listeAbonnes.FirstOrDefault(x => x.Id == abonne.Id);

                // Automapper()
                abonneAModifier.Nom = abonne.Nom;
                abonneAModifier.Prenom = abonne.Prenom;
                abonneAModifier.Email = abonne.Email;

                return RedirectToAction("Liste3");
            }
            return View(abonne);
        }
    }
}