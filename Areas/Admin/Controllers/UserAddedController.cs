using Doggie.Context;
using Doggie.Dtos;
using Doggie.Modelsss;
using Doggie.Modelsss.BaseMode;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Doggie.Areas.Admin.Controllers
{
    [Area("Admin")]
	public class UserAddedController : Controller
	{
		private readonly DoggieFriend _doggieContext;
		private readonly IWebHostEnvironment _env;
		public UserAddedController(DoggieFriend doggiecontext, IWebHostEnvironment env)
		{
			_doggieContext = doggiecontext;
			_env = env;
		}


        public IActionResult Index()
        {
            UserCourseViewModel userCourseViewModel=new UserCourseViewModel();  
            userCourseViewModel.AppUsers=_doggieContext.Users.Include(x=>x.courses.Where(x=>!x.IsDeleted)).ThenInclude(x=>x.Course).ToList(); 
            userCourseViewModel.Courses=_doggieContext.Courses.Where(x=>!x.IsDeleted).ToList(); 

            return View(userCourseViewModel);
        }



        [HttpGet]
        public IActionResult Create()
        {

            UserCourseViewModel userCourseViewModel=new UserCourseViewModel();
            userCourseViewModel.Courses = _doggieContext.Courses.Where(x => !x.IsDeleted).ToList();
            userCourseViewModel.AppUsers= _doggieContext.Users.ToList();
            return View(userCourseViewModel);
        }
        [HttpPost]
        public IActionResult Create(UserCourseViewModel userCourseViewModel)
        {
            Course course = _doggieContext.Courses.FirstOrDefault(x => x.Id ==userCourseViewModel.CourseId &&!x.IsDeleted);

            CourseAppUser courseAppUser = new CourseAppUser();

            AppUser appUser = _doggieContext.Users.FirstOrDefault(x => x.Id == userCourseViewModel.AppUserId);
            courseAppUser.AppUserId = appUser.Id;
            courseAppUser.CourseId = course.Id;
            _doggieContext.appUsers.Add(courseAppUser);

            _doggieContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }





        [HttpGet]
        public IActionResult Users()

        {

            List<AppUser> users = _doggieContext.Users.Where(x => x.courses.Count > 0).ToList();



            return View(users);
        }


    }
}
