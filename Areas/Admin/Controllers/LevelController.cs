using Doggie.Context;
using Doggie.Modelsss.BaseMode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Doggie.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LevelController : Controller
    {
        private readonly DoggieFriend _doggieContext;
        private readonly IWebHostEnvironment _env;
        public LevelController(DoggieFriend doggiecontext, IWebHostEnvironment env)
        {
            _doggieContext = doggiecontext;
            _env = env;
        }
        public IActionResult Index()
        {

            List<Level> levels = _doggieContext.Levels.Where(x=>!x.IsDeleted).ToList();
            return View(levels);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            ViewBag.Courses=_doggieContext.Courses.Where(x=>!x.IsDeleted).ToList();    
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Level even)
        {

            ViewBag.Courses = _doggieContext.Courses.Where(x=>!x.IsDeleted).ToList();
            if (!ModelState.IsValid)
            {
                return View();
            }


            await _doggieContext.Levels.AddAsync(even);
            await _doggieContext.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }







        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            Level? even = await _doggieContext.Levels.Where(x => x.Id == id).FirstOrDefaultAsync();

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

