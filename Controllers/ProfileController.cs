using Microsoft.AspNetCore.Mvc;

namespace Doggie.Controllers
{
	public class ProfileController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
