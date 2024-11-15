using Microsoft.AspNetCore.Mvc;
using PLF_11112024_Rautner.Data;
using PLF_11112024_Rautner.Models;

namespace PLF_11112024_Rautner.Controllers
{
    public class GeschenkController : Controller
    {
        //Instance of Context
        public readonly ApplicationDbContext _context;

        //Konstruktor
        public GeschenkController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Index Function (um die Seite zu zeigen)
        public IActionResult Index()
        {
            //Seite anzeigen
            return View();
        }

        //Submit Function (wenn der Speichern Knopf auf der Seite gedrückt wurde)
        public IActionResult SubmitForm(GeschenkModel geschenk)
        {
            //Erstellername hinzufügen
            geschenk.CreatorName = User.Identity.Name;

            //Geschenk in Datenbank einfügen
            _context.GeschenkModels.Add(geschenk);

            //Datenbank speichern
            _context.SaveChanges();

            //Wieder auf Seite zurück
            return RedirectToAction(nameof(Index));
        }
    }
}
