using Doggie.Context;
using Doggie.Modelsss;
using Doggie.Modelsss.BaseMode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Doggie.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AltLevelController : Controller
    {

        private readonly DoggieFriend _doggieContext;
        private readonly IWebHostEnvironment _env;
        public AltLevelController(DoggieFriend doggiecontext, IWebHostEnvironment env)
        {
            _doggieContext = doggiecontext;
            _env = env;
        }
        public IActionResult Index()
        {

            List<AltLevel> levels = _doggieContext.AltLevels.Where(x=>!x.IsDeleted).ToList() ;

            return View(levels);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            ViewBag.courses = _doggieContext.Courses.Where(x => !x.IsDeleted).Include(c => c.Levels.Where(c=>!c.IsDeleted)).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AltLevel even)
        {

            ViewBag.courses = _doggieContext.Courses.Where(x => !x.IsDeleted).Include(c => c.Levels.Where(c => !c.IsDeleted)).ToList();

            if (!ModelState.IsValid)
            {
                return View();
            }


            await _doggieContext.AltLevels.AddAsync(even);
            await _doggieContext.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }





        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            AltLevel? even = await _doggieContext.AltLevels.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (even == null)
            {
                return View();
            }
            even.IsDeleted = true;
            await _doggieContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}
