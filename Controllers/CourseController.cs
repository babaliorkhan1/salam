using Doggie.Context;
using Doggie.Dtos;
using Doggie.Modelsss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace Doggie.Controllers
{
	public class CourseController : Controller
	{

        private readonly DoggieFriend _context;
        public CourseController(DoggieFriend context)
        {
            _context = context;
        }
        public IActionResult Index()
		{
			CourseViewMode courseViewMode=new CourseViewMode();


			

                courseViewMode.Courses = _context.Courses.Where(x => !x.IsDeleted).OrderBy(x => x.CreatedTime).Include(y => y.Category).ToList();

            courseViewMode.Categories = _context.Categories.Where(x => !x.IsDeleted).ToList();
          
            courseViewMode.Aboutt = _context.Aboutts.FirstOrDefault();

			return View(courseViewMode);
		}


        public IActionResult Index1(int? id)
        {
            CourseViewMode courseViewMode = new CourseViewMode();


			courseViewMode.Categories = _context.Categories.Where(x => !x.IsDeleted).ToList();

			if (id != null)
            {

                courseViewMode.Courses = _context.Courses.Where(x=>x.CategoryId == id && !x.IsDeleted).OrderBy(x => x.CreatedTime).Include(y => y.Category).ToList();

            }

			courseViewMode.Courses1 = _context.Courses.Where(x => !x.IsDeleted).OrderBy(x => x.CreatedTime).Include(y => y.Category).ToList();



			courseViewMode.Aboutt = _context.Aboutts.FirstOrDefault();

            return View(courseViewMode);
        }
        public IActionResult Detail(int id)
		{


			Course? even = _context.Courses.Include(x=>x.Userss).ThenInclude(x=>x.AppUser).Include(x=>x.Category).Include(v=>v.Levels.Where(v=>!v.IsDeleted)).ThenInclude(m=>m.AltLevels.Where(m=>!m.IsDeleted)).Where(x => x.Id == id).FirstOrDefault();
            if (even==null)
            {
                return RedirectToAction("notfound", "contact");
            }
            ViewBag.url = "https://web.telegram.org/k/#@orkhanebot";

			return View(even);
		}


      



    }
}
