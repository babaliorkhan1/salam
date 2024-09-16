using System.ComponentModel.DataAnnotations.Schema;

namespace Doggie.Modelsss
{
	public class blog:BaseModel
	{
		public string Title { get; set; }		
		public string Description { get; set; }
		public DateTime DateTime { get; set; }	
		public string Author { get; set; }	
		public string Location { get; set; }
		public string Price { get; set; }		
		public string? Image { get; set; }
		[NotMapped]
		public IFormFile? formFile { get; set; }	
	}
}
