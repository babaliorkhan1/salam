using Doggie.Context;
using Doggie.Extensions;
using Doggie.Modelsss;
using Microsoft.AspNetCore.Mvc;

namespace Doggie.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingController : Controller
    {
        private readonly DoggieFriend _doggieContext;
        private readonly IWebHostEnvironment _env;
        public SettingController(DoggieFriend doggiecontext, IWebHostEnvironment env)
        {
            _doggieContext = doggiecontext;
            _env = env;
        }
        
        public IActionResult Index()
        {
            setting list = _doggieContext.settings.FirstOrDefault();

            return View(list);
        }
        [HttpGet]
        public IActionResult Update()
        {
            setting setting = _doggieContext.settings.FirstOrDefault();
            return View(setting);
        }


        [HttpPost]
        public IActionResult Update(setting setting)
        {
            setting setting1 = _doggieContext.settings.FirstOrDefault();


            setting1.Title=setting.Title;
            setting1.Title2 = setting.Title2;
            setting1.Description=setting.Description;
            setting1.CourseTitle=setting.CourseTitle;   
            setting1.CourseDescription=setting.CourseDescription;
            setting1.CommentTitle=setting.CommentTitle; 
            setting1.EventTitle=setting.EventTitle; 
            setting1.EventDescription=setting.EventDescription; 
            setting1.CommentDescription=setting.CommentDescription;
            setting1.FacebookLink=setting.FacebookLink; 
            setting1.LinkendLink=setting.LinkendLink;   
            setting1.GoogleLink=setting.GoogleLink;

            if (setting.formFile!=null)
            {
                setting1.Image1 = setting.formFile.CreateImage(_env.WebRootPath, "assets/images/blog/default");
               
            }

            if (setting.formFile2 != null)
            {
                setting1.Image2 = setting.formFile2.CreateImage(_env.WebRootPath, "assets/images/blog/default");
            }

            _doggieContext.SaveChanges(); 
            return RedirectToAction("index", "setting");
        }




    }
}
