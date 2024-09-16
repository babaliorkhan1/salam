using Doggie.Modelsss.BaseMode;

namespace Doggie.Modelsss
{
	public class CourseAppUser:BaseModel
	{
		public Course Course { get; set; }	
		public AppUser AppUser { get; set; }	
		public int CourseId { get; set; }	
		public string AppUserId { get; set; }
	}
}
