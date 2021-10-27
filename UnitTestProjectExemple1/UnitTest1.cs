using ConsoleAppATester.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplicationASPAuth.Controllers;
using WebApplicationASPAuth.Models;

namespace UnitTestProjectExemple1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // AAA
            int i = 1 + 3;
            // On s'attend a ce que la valeur de i soit 4

            Assert.AreEqual(4, i, "Erreur");
        }

        [TestMethod]
        public void TestProjetConsoleCalculAddition()
        {
            // Arrangement
            // - importer les projets (si le projet a tester fait reference a d'autres projets)
            // - importer les packages NuGet utilises dans l'autre projet
            // - Par exemple si l'autre projet utilise le MVC
            // - Si l'autre projet utilise EntityFramework ...
            Calcul c = new Calcul();
            // Act
            int i = c.Addition(10, 5);
            // Assert
            Assert.AreEqual(15, i);
        }
        [TestMethod]

        public void TestLibCalcul()
        {
            ClassLibraryATester.Calcul calcul = new ClassLibraryATester.Calcul();
            int i = calcul.Soustraction(4, 10);
            Assert.AreEqual(6, i);
        }

        [TestMethod]

        public async Task TestAppASPAuthCategorieEditAsync()
        {
            // Test formel sur cette methode
            // Etapes : 1 - Ajouter un ref au projet 
            CategoriesController categoriesController = new CategoriesController();

            // retourner l'affichage (Model + ...
          ViewResult viewResult = await categoriesController.Edit(2) as ViewResult;
            Categorie categorie = viewResult.Model as Categorie;

            Assert.AreEqual(2, categorie.Id, "Vous n'editez pas la bonne categorie");

        }
    }
}
