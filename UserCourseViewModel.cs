using Doggie.Modelsss;
using Doggie.Modelsss.BaseMode;

namespace Doggie.Dtos
{
    public class UserCourseViewModel
    {
        public List<AppUser> AppUsers { get; set; } 
        public List<Course> Courses { get; set; }   
        public int CourseId { get; set; }   
        public string AppUserId { get; set; }   
    }
}
