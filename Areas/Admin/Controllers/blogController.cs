using Doggie.Context;
using Doggie.Extensions;
using Doggie.Modelsss;
using Doggie.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Doggie.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class blogController : Controller
	{
		private readonly DoggieFriend _doggieContext;
		private readonly IWebHostEnvironment _env;
		private readonly IMailService _mailService;
		public blogController(DoggieFriend doggiecontext, IWebHostEnvironment env, IMailService mailService)
		{
			_doggieContext = doggiecontext;
			_env = env;
			_mailService = mailService;
		}
		public IActionResult Index()
		{

			List<blog> blogs = _doggieContext.Blogs.Where(x => !x.IsDeleted).ToList();
			return View(blogs);
		}


		[HttpGet]
		public async Task<IActionResult> Create()
		{

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(blog blog)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}


		blog.Image = blog.formFile.CreateImage(_env.WebRootPath, "assets/images/banner");

			await _doggieContext.Blogs.AddAsync(blog);
			await _doggieContext.SaveChangesAsync();

			List<registeremail> registeremails=_doggieContext.Registeremails.ToList();

			foreach (var item in registeremails)
			{

                await _mailService.Send("babaliorkhan@gmail.com", item.Name, $"Hello {item.Name},How are you", "New Blog", "zhnq whzx fbne laho");



            }
            return RedirectToAction(nameof(Index));
		}






		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{

			blog blog = await _doggieContext.Blogs.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();


			if (blog == null)
			{
				return View(blog);
			}


			return View(blog);
		}




		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(int id,blog blog)
		{

			blog blog1 = await _doggieContext.Blogs.Where(x => x.Id == id).FirstOrDefaultAsync();

			if (blog.formFile != null)
			{
				blog1.Image = blog.formFile.CreateImage(_env.WebRootPath, "assets/images/banner");
			}




			blog1.Title = blog.Title;
			blog1.Description = blog.Description;	
			blog1.Author=blog.Author;	
			blog1.Location = blog.Location;	
			blog1.Price=blog.Price;	
			blog1.DateTime= blog.DateTime;	 
			

			await _doggieContext.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}









		[HttpGet]
		public async Task<IActionResult> Remove(int id)
		{
			blog blog = await _doggieContext.Blogs.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();

			if (blog == null)
			{
				return View();
			}
			blog.IsDeleted = true;
			await _doggieContext.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

	}
}
