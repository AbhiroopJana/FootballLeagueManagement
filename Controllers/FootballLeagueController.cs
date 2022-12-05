using FootballLeagueManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeagueManagement.Controllers
{
    public class FootballLeagueController : Controller
    {
        private readonly FootballDBContext _context;
        public FootballLeagueController(FootballDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<FootballLeague> list = _context.FootballLeagues;
            return View(list);
        }
        public IActionResult Details(int id)
        {
            var football = _context.FootballLeagues.FirstOrDefault(m => m.MatchId== id);
            return View(football);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FootballLeague football)
        {
            if(ModelState.IsValid)
            {
                _context.FootballLeagues.Add(football);
                _context.SaveChanges();
                TempData["ResultOK"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }
            return View(football);
        }
        public IActionResult Edit(int id) 
        {
            var football =  _context.FootballLeagues.Find(id);
            
            return View(football);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, FootballLeague football)
        {
            if (ModelState.IsValid)
            {
                _context.Update(football);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(football);
        }
        public IActionResult Delete(int id) 
        {
            var football = _context.FootballLeagues.FirstOrDefault(m => m.MatchId == id);
            return View(football);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id) 
        {
            var football = _context.FootballLeagues.Find(id);
            _context.FootballLeagues.Remove(football);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
