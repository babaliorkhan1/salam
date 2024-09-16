using Doggie.Context;
using Doggie.Dtos;
using Doggie.Modelsss;
using Microsoft.AspNetCore.Mvc;

namespace Doggie.Controllers
{
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
            FaqViewModel faqViewModel=new FaqViewModel();
            faqViewModel.Aboutt=_doggieContext.Aboutts.FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return View(faqViewModel.Aboutt);
            }

            faqViewModel.emails = _doggieContext.Emails.ToList();



            return View(faqViewModel);
        }
    }
}
