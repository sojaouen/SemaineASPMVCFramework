using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationASPAuth.Models;
using System.IO;
using System.Configuration;

namespace WebApplicationASPAuth.Controllers
{
    [Authorize] // La Page est soumise a une authentification
    public class ProduitsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Produits
        [AllowAnonymous] // Permet l'acces a des utilisateurs non authentifies
        public async Task<ActionResult> Index()
        {
            var produits = db.Produits.Include(p => p.Categorie);
            return View(await produits.ToListAsync());
        }
        // ADMIN a le droit : Details, Delete
        // SAISIE a le droit : Create, Details

        // GET: Produits/Details/5
        [Authorize(Roles ="ADMIN,SAISIE")] // user et user2
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = await db.Produits.FindAsync(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // GET: Produits/Create
        [Authorize(Roles ="SAISIE")] // user2
        public ActionResult Create()
        {
            ViewBag.CategorieID = new SelectList(db.Categories, "Id", "Designation");
            return View();
        }

        // POST: Produits/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Libelle,Photo,CategorieID")] Produit produit, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                // Verifie que le fichier est valide
                // Copiel'image dans le dossier images
                // On met le path dans produit.Photo (string a mettre en base)
                if (Photo != null && Photo.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Photo.FileName);
                    string dossierImg = ConfigurationManager.AppSettings["dossierImages"];

                    var path = Path.Combine(Server.MapPath(dossierImg), fileName);
                    Photo.SaveAs(path);

                    produit.Photo = fileName;
                }
                db.Produits.Add(produit);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategorieID = new SelectList(db.Categories, "Id", "Designation", produit.CategorieID);
            return View(produit);
        }

        // GET: Produits/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = await db.Produits.FindAsync(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategorieID = new SelectList(db.Categories, "Id", "Designation", produit.CategorieID);
            return View(produit);
        }

        // POST: Produits/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Libelle,Photo,CategorieID")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produit).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategorieID = new SelectList(db.Categories, "Id", "Designation", produit.CategorieID);
            return View(produit);
        }

        // GET: Produits/Delete/5
        [Authorize(Roles ="ADMIN")] //user
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produit = await db.Produits.FindAsync(id);
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // POST: Produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Produit produit = await db.Produits.FindAsync(id);
            db.Produits.Remove(produit);
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
    }
}
