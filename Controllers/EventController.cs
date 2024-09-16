using Doggie.Context;
using Doggie.Dtos;
using Doggie.Extensions;
using Doggie.Modelsss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Doggie.Controllers
{
	public class EventController : Controller
	{ private readonly DoggieFriend _context;
		public EventController(DoggieFriend context)
		{
			_context= context;
		}
		public IActionResult Index()
		{
			EventViiewModel eventViiewModel = new EventViiewModel();
			eventViiewModel.Events  = _context.Events.Where(x => !x.IsDeleted).ToList();
			eventViiewModel.EventCategories  = _context.ECategories.Where(x => !x.IsDeleted).ToList();
			eventViiewModel.count = _context.Events.Count() * 1000;

			

			return View(eventViiewModel);
		}








		public IActionResult Detail(int id)
		{

			EventViiewModel eventViiewModel = new EventViiewModel();
			eventViiewModel.Event = _context.Events.Where(x => x.Id == id).FirstOrDefault();
			eventViiewModel.Events = _context.Events.Where(x => !x.IsDeleted).Take(3).ToList() ;


			return View(eventViiewModel);
		}

		public async Task<List<Event>> events(int id)
		{
			List<Event> events = _context.Events.Where(x => !x.IsDeleted && x.EventCategoryId == id).ToList();


			return events;
		}



	}
}
