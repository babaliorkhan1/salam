using Doggie.Modelsss;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doggie.Modelsss
{
	public class Aboutt:BaseModel
	{
		public string Icon1 { get; set; } = null!;
		public string Icon2 { get; set; } = null!;
		public string Icon3 { get; set; } = null!;
		public string Icon4 { get; set; } = null!;

		public string Title1 { get; set; } = null!;
		public string Title2 { get; set; } = null!;
		public string Title3 { get; set; } = null!;
		public string Title4 { get; set; } = null!;
		public string Description1 { get; set; } = null!;
		public string Description2 { get; set; } = null!;
		public string Description3 { get; set; } = null!;
		public string Description4 { get; set; } = null!;

		public string StoryTitle { get; set; } = null!;
		public string AltStoryTitle { get; set; } = null!;
		public string StoryDescription { get; set; } = null!;						

		public string Video { get; set; } = null!;

        [Required(ErrorMessage = "Project count is required.(only number)")]
        public int ProjectCount { get; set; }
        [Required(ErrorMessage = "Project count is required.(only number)")]
        public int ClientCount { get; set; }
        [Required(ErrorMessage = "Project count is required.(only number)")]
        public int AnswerCount { get; set; }
        [Required(ErrorMessage = "Project count is required.(only number)")]
        public int LastCount { get; set; }	
		public string CourseTitle { get; set; } = null!;
		public string CourseDescription { get; set; } = null!;
		public string? WhatsappGroupTitle { get; set; } = null!;
		public string? WhatsappGroupDescription { get; set; } = null!;
		public string? WhatsappCourseCount { get; set; } = null!;
		public string? WhatsappGroupLink { get; set; } = null!; 



		[NotMapped]
		public IFormFile formFile { get; set; } = null!;

		

		
	}
}
