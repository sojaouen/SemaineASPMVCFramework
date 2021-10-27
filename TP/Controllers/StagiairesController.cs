using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TP;
using TP.Models;

namespace TP.Controllers
{
    public class StagiairesController : Controller
    {
        private StagiairesDBContext db = new StagiairesDBContext();

        static List<Stagiaire> listeStagiaires;

        public StagiairesController()
        {
            if (listeStagiaires == null) ;
            listeStagiaires = new List<Stagiaire>();
        }

        // GET: Stagiaires
        public async Task<ActionResult> Index()
        {
            return View(await db.Stagiaires.ToListAsync());
        }

        // GET: Stagiaires/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stagiaire stagiaire = await db.Stagiaires.FindAsync(id);
            if (stagiaire == null)
            {
                return HttpNotFound();
            }
            return View(stagiaire);
        }

        // Liste stagiaires GridMVC
        public ActionResult ListeGrid()
        {
            return View(db.Stagiaires.ToList());
        }

        // GET: Stagiaires/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stagiaires/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nom,Prenom,DateNaissance,Email")] Stagiaire stagiaire)
        {
            if (ModelState.IsValid)
            {
                db.Stagiaires.Add(stagiaire);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(stagiaire);
        }

        // GET: Stagiaires/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stagiaire stagiaire = await db.Stagiaires.FindAsync(id);
            if (stagiaire == null)
            {
                return HttpNotFound();
            }
            return View(stagiaire);
        }

        // POST: Stagiaires/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nom,Prenom,DateNaissance,Email")] Stagiaire stagiaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stagiaire).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(stagiaire);
        }

        // GET: Stagiaires/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stagiaire stagiaire = await db.Stagiaires.FindAsync(id);
            if (stagiaire == null)
            {
                return HttpNotFound();
            }
            return View(stagiaire);
        }

        // POST: Stagiaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Stagiaire stagiaire = await db.Stagiaires.FindAsync(id);
            db.Stagiaires.Remove(stagiaire);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // Action pour la modification d'un stagiaire

        public ActionResult Modif(int id)
        {
            Stagiaire stagiaireAModifierOrigin = listeStagiaires.FirstOrDefault(x => x.Id == id);

            return View(stagiaireAModifierOrigin);
        }

        [HttpPost]

        public ActionResult Modif(Stagiaire stagiaire)
        {
            if (ModelState.IsValid)
            {
                // modif +suppression + ajout

                Stagiaire stagiaireAModifier = listeStagiaires.FirstOrDefault(x => x.Id == stagiaire.Id);

                // Automapper()
                stagiaireAModifier.Nom = stagiaire.Nom;
                stagiaireAModifier.Prenom = stagiaire.Prenom;
                stagiaireAModifier.DateNaissance = stagiaire.DateNaissance;
                stagiaireAModifier.Email = stagiaire.Email;

                return RedirectToAction("ListeGrid");

            }
            return View(stagiaire);
        }

            

    }
}
