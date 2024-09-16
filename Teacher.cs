using Doggie.Modelsss;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doggie.Modelsss
{
	public class Teacher:BaseModel
	{
		public string Name { get; set; }	
		public string Image { get; set; }
		[NotMapped]
		public IFormFile FormFile { get; set; }
	}
}
