using Microsoft.AspNetCore.Mvc;
using PLF_11112024_Rautner.Data;
using PLF_11112024_Rautner.Models;
using System.Diagnostics;

namespace PLF_11112024_Rautner.Controllers
{
    public class HomeController : Controller
    {
        //Instances (Logger & Context)
        private readonly ILogger<HomeController> _logger;
        public readonly ApplicationDbContext _context;

        //Konstruktor
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        //Seite Anzeigen
        public IActionResult Index()
        {
            //Seite mir Listen aller Geschenkideen als Model anzeigen
            return View(_context.GeschenkModels.ToList());
        }

        //Geschenkidee auf Erledigt setzen
        public IActionResult DoneGeschenk(int Id)
        {
            //Geschenkidee aus Datenbank filtern/suchen
            GeschenkModel? geschenk = _context.GeschenkModels.Find(Id);

            //Überprüfen ob Geschenkidee existiert
            if(geschenk != null)
            {
                //Geschenkidee auf Erledigt setzen
                geschenk.Erledigt = true;

                //Geschenkidee in Datenbank aktualisieren
                _context.GeschenkModels.Update(geschenk);

                //Datenbank speichern
                _context.SaveChanges();
            }

            //Wieder auf Siete zurück
            return RedirectToAction(nameof(Index));
        }

        //Geschenkidee löschen
        public IActionResult DeleteGeschenk(int Id)
        {
            //Geschenkidee aus Datenbank filtern/suchen
            GeschenkModel? geschenk = _context.GeschenkModels.Find(Id);

            //Überprüfen ob Geschenkidee existiert
            if(geschenk != null)
            {
                //Geschenkidee aus Datenbank löschen
                _context.GeschenkModels.Remove(geschenk);

                //Datenbank speichern
                _context.SaveChanges();
            }

            //Wieder auf Seite zurück
            return RedirectToAction(nameof(Index));
        }

        //Alle Geschenkideen löschen (nur god@heaven Benutzer)
        public IActionResult DeleteAll()
        {
            //Über alle Geschenkideen in Datenbank loopen
            foreach (GeschenkModel geschenk in _context.GeschenkModels.ToList())
            {
                //Geschenkidee aus Datenbank löschen
                _context.GeschenkModels.Remove(geschenk);
            }

            //Datenbank speichern
            _context.SaveChanges();

            //Wieder auf Seite zurück
            return RedirectToAction(nameof(Index));
        }

        //Error Seite anzeigen
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}