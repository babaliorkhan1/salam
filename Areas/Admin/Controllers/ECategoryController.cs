using Doggie.Context;
using Doggie.Extensions;
using Doggie.Modelsss;
using Doggie.Modelsss.BaseMode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Doggie.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ECategoryController : Controller
    {
        private readonly DoggieFriend _doggieContext;
        private readonly IWebHostEnvironment _env;
        public ECategoryController(DoggieFriend doggiecontext, IWebHostEnvironment env)
        {
            _doggieContext = doggiecontext;
            _env = env;
        }
        public IActionResult Index()
        {

            List<EventCategory> eventCategories = _doggieContext.ECategories.Where(x => !x.IsDeleted).ToList();
            return View(eventCategories);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventCategory even)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            await _doggieContext.ECategories.AddAsync(even);
            await _doggieContext.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            EventCategory eventCategory = await _doggieContext.ECategories.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();



            if (eventCategory == null)
            {
                return View(eventCategory);
            }


            return View(eventCategory);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, EventCategory even)
        {
            EventCategory eventCategory = await _doggieContext.ECategories.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();




            eventCategory.Name =even.Name;
           


            await _doggieContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


		[HttpGet]
		public async Task<IActionResult> Remove(int id)
		{
			EventCategory? even = await _doggieContext.ECategories.Where(x => x.Id == id).FirstOrDefaultAsync();

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
