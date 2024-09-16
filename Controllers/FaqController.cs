using Doggie.Context;
using Doggie.Dtos;
using Doggie.Modelsss;
using Doggie.Modelsss.BaseMode;
using Doggie.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Doggie.Controllers
{
    public class FaqController : Controller
    {
        private readonly DoggieFriend _context;
        private readonly IMailService _mailService;

        public FaqController(DoggieFriend context, IMailService mailService)
        {
            _context = context;
            _mailService = mailService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            FaqViewModel viewModel=new FaqViewModel();
            viewModel.Faq = _context.Faqs.FirstOrDefault();
            viewModel.Aboutt = _context.Aboutts.FirstOrDefault();




            return View(viewModel);

            

        }
	
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task SendMessage(Email email)
        {
            //await _mailService.Send("orxanbabali210@gmail.com", email.Name,  email.Messsage, email.Subject,email.Pasword);



            _context.Emails.Add(email); 
            _context.SaveChanges();

        }


		[HttpGet]
		public List<Event>  getall()
		{
			List<Event> list = _context.Events.ToList();


            return list;



		}
        [HttpGet]
        public List<Course> getall1()
        {
            List<Course> list = _context.Courses.ToList();


            return list;



        }


       

    }
}