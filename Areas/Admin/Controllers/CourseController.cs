using Doggie.Context;
using Doggie.Extensions;
using Doggie.Modelsss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Doggie.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CourseController : Controller
	{
		private readonly DoggieFriend _doggieContext;
		private readonly IWebHostEnvironment _env;
		public CourseController(DoggieFriend doggiecontext, IWebHostEnvironment env)
		{
			_doggieContext = doggiecontext;
			_env = env;
		}

		public IActionResult Index()
		{
			List<Course> courses = _doggieContext.Courses.Where(x=>!x.IsDeleted).Include(x => x.Category).ToList();
			return View(courses);
		}

		[HttpGet]
		public IActionResult Create()
		{

			ViewBag.Categorys = _doggieContext.Categories.Where(x=>!x.IsDeleted).ToList();
			return View();
		}

		[HttpPost]
		public IActionResult Create(Course course)
		{
            ViewBag.Categorys = _doggieContext.Categories.Where(x=>!x.IsDeleted).ToList();

            if (!ModelState.IsValid)
			{
				return View();
			}

			course.Image = course.formFile.CreateImage(_env.WebRootPath, "assets/images/courses");
			course.CreatedTime=DateTime.Now;
			_doggieContext.Courses.Add(course);
			_doggieContext.SaveChanges();


			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			Course even = await _doggieContext.Courses.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();
            ViewBag.Categorys = _doggieContext.Categories.Where(x => !x.IsDeleted).ToList();


            if (even == null)
			{
				return View(even);
			}


			return View(even);
		}




		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(int id, Course even)
		{
			Course? updateEven = await _doggieContext.Courses.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();
            ViewBag.Categorys = _doggieContext.Categories.Where(x => !x.IsDeleted).ToList();

            if (even.formFile != null)
			{
				updateEven.Image = even.formFile.CreateImage(_env.WebRootPath, "assets/images/course");
			}


			updateEven.Title = even.Title;
			updateEven.Description = even.Description;
			updateEven.Description1 = even.Description1;
			updateEven.Language = even.Language;
			updateEven.LanguageText = even.LanguageText;
			updateEven.Lecture = even.Lecture;
			updateEven.LectureCount = even.LectureCount;
			updateEven.StudentCount = even.StudentCount;
			updateEven.QuizzeCount = even.QuizzeCount;
			updateEven.Quizzes = even.Quizzes;
			updateEven.SkillLevel = even.SkillLevel;
			updateEven.SkillLevelText = even.SkillLevelText;
			updateEven.Levels = even.Levels;
			updateEven.CategoryId = even.CategoryId;
			updateEven.Duration = even.Duration;
			updateEven.DurationTime = even.DurationTime;
			updateEven.Name = even.Name;
			updateEven.StudentsText = even.StudentsText;
			updateEven.Price = even.Price;
			updateEven.Link=even.Link;
			updateEven.TopPrice= even.TopPrice;
			updateEven.outCome1= even.outCome1;	
			updateEven.outCome2= even.outCome2;	
			updateEven.outCome3= even.outCome3;	
			updateEven.outCome4= even.outCome4;	
			updateEven.outCome5= even.outCome5;	
			updateEven.TeacherName= even.TeacherName;	

			


			await _doggieContext.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}



















		[HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
           Course? even = await _doggieContext.Courses.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();

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
