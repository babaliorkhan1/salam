using Doggie.Modelsss;
using Doggie.Modelsss.BaseMode;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doggie.Modelsss
{
	public class Course:BaseModel
	{
		public string Name { get; set; }	
		public Category? Category { get; set; }	
        public int CategoryId { get; set; } 
		public int Price { get; set; }	
		public int TopPrice { get; set; }	

		public string? Image { get; set; }
		public string Title { get; set; }	
		public string Description { get; set; }
		public string Lecture { get; set; }
		public string LectureCount { get; set; }
        public string Quizzes { get; set; }
        public string QuizzeCount { get; set; }
        public string Duration { get; set; }
        public string DurationTime { get; set; }
        public string SkillLevelText { get; set; }
        public string SkillLevel { get; set; }
        public string LanguageText { get; set; }
        public string Language { get; set; }
        public string StudentsText { get; set; }
        public string StudentCount { get; set; }
        public string Description1 { get; set; }
        public string Link { get; set; } 
        public string outCome1 { get; set; } 
        public string outCome2 { get; set; } 
        public string outCome3 { get; set; } 
        public string outCome4 { get; set; } 
        public string outCome5 { get; set; } 
        public string TeacherName { get; set; } 
        
        public List<Level>? Levels { get; set; } 
        public List<CourseAppUser>? Userss{ get; set; } 
        
       
      

        [NotMapped]
		public IFormFile? formFile { get; set; }	
	}
}
