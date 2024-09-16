using Doggie.Context;
using Doggie.Dtos;
using Doggie.Modelsss;
using Doggie.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Doggie.Controllers
{
	public class HomeController : Controller
	{
        private readonly DoggieFriend _context;
        private readonly  IMailService _mailService;
        

        public HomeController(DoggieFriend context,IMailService mailService)
        {
            _context = context;
            _mailService = mailService;
        }

        public async Task <IActionResult> Index()
		{

            
            

            HomeViewModel homeViewModel=new HomeViewModel();


            homeViewModel.Courses = _context.Courses.Include(x=>x.Category).Where(x=>!x.IsDeleted).ToList();
            homeViewModel.Courses1 = _context.Courses.Include(x=>x.Category).Where(x=>!x.IsDeleted).ToList();
            homeViewModel.Events = _context.Events.Where(x=>!x.IsDeleted).ToList();
            homeViewModel.Emails = _context.Emails.Where(x=>!x.IsDeleted).ToList();
            homeViewModel.setting = _context.settings.FirstOrDefault();
            homeViewModel.Aboutt = _context.Aboutts.FirstOrDefault();
            homeViewModel.Blogs = _context.Blogs.Where(x=>!x.IsDeleted).ToList(); 
			

			return View(homeViewModel);

		}

        [HttpPost]
        public async Task<IActionResult> SendMessage(string email)
        {


            registeremail registeremail = new registeremail();
            registeremail.Name = email;
           await _context.Registeremails.AddAsync(registeremail);
            await _context.SaveChangesAsync();

            return Ok();

        }










    }
}