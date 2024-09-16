using Doggie.Modelsss;

namespace Doggie.Modelsss
{
	public class Category:BaseModel
	{
		public string Name { get; set; }	
		public List<Course>? Courses { get; set; }	
	}
}
