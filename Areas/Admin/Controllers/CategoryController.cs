using Doggie.Context;
using Doggie.Modelsss;
using Doggie.Modelsss.BaseMode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Doggie.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly DoggieFriend _doggieContext;
        private readonly IWebHostEnvironment _env;
        public CategoryController(DoggieFriend doggiecontext, IWebHostEnvironment env)
        {
            _doggieContext = doggiecontext;
            _env = env;
        }
        public IActionResult Index()
        {

            List<Category>  categories = _doggieContext.Categories.Where(x=>!x.IsDeleted).ToList();
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category even)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }


            await _doggieContext.Categories.AddAsync(even);
            await _doggieContext.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }




        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            Category? even = await _doggieContext.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();

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
