using Doggie.Context;
using Doggie.Extensions;
using Doggie.Modelsss;
using Microsoft.AspNetCore.Mvc;

namespace Doggie.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
  


        private readonly DoggieFriend _doggieContext;
        private readonly IWebHostEnvironment _env;
        public AboutController(DoggieFriend doggiecontext, IWebHostEnvironment env)
        {
            _doggieContext = doggiecontext;
            _env = env;
        }
        public IActionResult Index()
        { 

            Aboutt? aboutt = _doggieContext.Aboutts.FirstOrDefault();
           
            
            return View(aboutt);
        }


       

        [HttpGet]
        public IActionResult Update()
        {


            Aboutt? aboutt = _doggieContext.Aboutts.FirstOrDefault();

            

            return View(aboutt);
        }


        [HttpPost]  
        public IActionResult Update(Aboutt aboutt)
        {

            Aboutt updateAboutt = _doggieContext.Aboutts.FirstOrDefault();


            if (!ModelState.IsValid)
            {
                return View(aboutt);
            }

			updateAboutt.Title1 = aboutt.Title1;
            updateAboutt.Title2 = aboutt.Title2;    
            updateAboutt.Title3 = aboutt.Title3;
            updateAboutt.Title4 = aboutt.Title4;    
            updateAboutt.Description1= aboutt.Description1; 
            updateAboutt.Description2= aboutt.Description2; 
            updateAboutt.Description3= aboutt.Description3; 
            updateAboutt.Description4= aboutt.Description4;
            updateAboutt.CourseTitle= aboutt.CourseTitle;
            updateAboutt.StoryTitle= aboutt.StoryTitle;
            updateAboutt.AltStoryTitle= aboutt.AltStoryTitle;
            updateAboutt.CourseDescription= aboutt.CourseDescription;   
            updateAboutt.StoryDescription= aboutt.StoryDescription;   
            updateAboutt.Icon1 = aboutt.Icon1;  
            updateAboutt.Icon2 = aboutt.Icon2;  
            updateAboutt.Icon3 = aboutt.Icon3;  
            updateAboutt.Icon4 = aboutt.Icon4;  
            updateAboutt.ProjectCount= aboutt.ProjectCount; 
            updateAboutt.ClientCount= aboutt.ClientCount;   
            updateAboutt.LastCount= aboutt.LastCount;   
            updateAboutt.AnswerCount= aboutt.AnswerCount;
            updateAboutt.WhatsappCourseCount= aboutt.WhatsappCourseCount;
            updateAboutt.WhatsappGroupLink= aboutt.WhatsappGroupLink;
            updateAboutt.WhatsappGroupTitle= aboutt.WhatsappGroupTitle;
            updateAboutt.WhatsappGroupDescription= aboutt.WhatsappGroupDescription;
            if (aboutt.formFile!=null)
            {
                updateAboutt.Video = aboutt.formFile.CreateVideo(_env.WebRootPath, "assets/videos");
            }

           _doggieContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
