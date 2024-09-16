using Doggie.Context;
using Doggie.Modelsss;
using Doggie.Services;
using Microsoft.AspNetCore.Mvc;

namespace Doggie.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FaqController : Controller
    {

        private readonly DoggieFriend _doggieContext;
        private readonly IWebHostEnvironment _env;
        public FaqController(DoggieFriend doggiecontext, IWebHostEnvironment env)
        {
            _doggieContext = doggiecontext;
            _env = env;
        }
        public IActionResult Index()
        {

          Faq faq=_doggieContext.Faqs.FirstOrDefault();

            

            return View(faq);
        }


        [HttpGet]
        public IActionResult Update()
        {

            Faq UpdateFaq = _doggieContext.Faqs.FirstOrDefault();
            return View(UpdateFaq);  
        }



        [HttpPost]
        public IActionResult Update(Faq faq)
        {

            Faq UpdateFaq = _doggieContext.Faqs.FirstOrDefault();

            UpdateFaq.Title=faq.Title;
           UpdateFaq.Title1= faq.Title1;    
            UpdateFaq.Description=faq.Description;  
            UpdateFaq.Description1=faq.Description1;        
            UpdateFaq.Answer1=faq.Answer1;
            UpdateFaq.Answer2 =faq.Answer2;
            UpdateFaq.Answer3=faq.Answer3;
            UpdateFaq.Answer4 =faq.Answer4;
            UpdateFaq.Answer5=faq.Answer5;
            UpdateFaq.Question1 = faq.Question1;
            UpdateFaq.Question2 = faq.Question2;
            UpdateFaq.Question3 = faq.Question3;
            UpdateFaq.Question4 = faq.Question4;
            UpdateFaq.Question5 = faq.Question5;

            _doggieContext.SaveChanges();
            






            return RedirectToAction("Index");   
        }



      
       


        

    }
}
