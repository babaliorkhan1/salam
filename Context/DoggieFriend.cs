using Doggie.Modelsss;
using Doggie.Modelsss.BaseMode;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Doggie.Context
{
	public class DoggieFriend: IdentityDbContext<AppUser>
	{

		public  DoggieFriend(DbContextOptions<DoggieFriend> options) : base(options)
		{

		}
		public DbSet<Event> Events { get; set; }
		public DbSet<Aboutt> Aboutts { get; set; }	
		public DbSet<Faq> Faqs { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<EventCategory> ECategories { get; set; }
		public DbSet<AltLevel> AltLevels { get; set; }
		public DbSet<Level>  Levels { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Email> Emails { get; set; }
		public DbSet<setting> settings { get; set; }
		public DbSet<CourseAppUser> appUsers { get; set; }
		public DbSet<registeremail> Registeremails { get; set; } 
		public DbSet<blog> Blogs { get; set; }		


	}
}
