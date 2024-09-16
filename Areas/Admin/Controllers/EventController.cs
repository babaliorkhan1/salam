using Doggie.Context;
using Doggie.Extensions;
using Doggie.Modelsss;
using Doggie.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Doggie.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class EventController : Controller
	{
		private readonly DoggieFriend _doggieContext;
		private readonly IWebHostEnvironment _env;
        private readonly IMailService _mailService;
        public EventController(DoggieFriend doggiecontext, IWebHostEnvironment env,IMailService mailService)
		{
			_doggieContext = doggiecontext;
			_env = env;
			_mailService = mailService;	
		}
		public IActionResult Index()
		{

			List<Event> events = _doggieContext.Events.Where(x => !x.IsDeleted).ToList();
			return View(events);
		}


		[HttpGet]
		public async Task<IActionResult> Create()
		{
			ViewBag.EventCategorys=_doggieContext.ECategories.Where(x=>!x.IsDeleted).ToList();

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Event even)
		{


            ViewBag.EventCategorys = _doggieContext.ECategories.Where(x => !x.IsDeleted).ToList();

            if (!ModelState.IsValid)
			{
				return View();
			}


            even.Image = even.FormFile.CreateImage(_env.WebRootPath, "assets/images/event");
            even.Image2 = even.FormFile2.CreateImage(_env.WebRootPath, "assets/images/event");

			await _doggieContext.Events.AddAsync(even);
			await _doggieContext.SaveChangesAsync();


			

			return RedirectToAction(nameof(Index));
		}






		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
            ViewBag.EventCategorys = _doggieContext.ECategories.Where(x => !x.IsDeleted).ToList();

            Event even = await _doggieContext.Events.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();


			if (even == null)
			{
				return View(even);
			}


			return View(even);
		}




		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(int id, Event even)
		{
            ViewBag.EventCategorys = _doggieContext.ECategories.Where(x => !x.IsDeleted).ToList();

            Event? updateEven = await _doggieContext.Events.Where(x => x.Id == id).FirstOrDefaultAsync();

			if (even.FormFile != null)
			{
				updateEven.Image = even.FormFile.CreateImage(_env.WebRootPath, "assets/images/event");
			}

            if (even.FormFile2 != null)
            {
                updateEven.Image2 = even.FormFile2.CreateImage(_env.WebRootPath, "assets/images/event");
            }


            updateEven.Title = even.Title;
			updateEven.Description = even.Description;
			updateEven.Price = even.Price;
			updateEven.Location = even.Location;
			updateEven.MapLink = even.MapLink;
			updateEven.DetailDescription = even.DetailDescription;
			updateEven.DetailTitle = even.DetailTitle;
			updateEven.StartTime = even.StartTime;
			updateEven.StartStopTime = even.StartStopTime;
			updateEven.PhoneNumber = even.PhoneNumber;
			updateEven.EventCategoryId= even.EventCategoryId;
			updateEven.Link=even.Link;
			updateEven.VideoTitle=even.VideoTitle;	
			updateEven.VideoDescription=even.VideoDescription;	


			await _doggieContext.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}









		[HttpGet]
		public async Task<IActionResult> Remove(int id)
		{
			Event? even = await _doggieContext.Events.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();

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
