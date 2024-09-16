using Doggie.Modelsss;

namespace Doggie.Dtos
{
    public class HomeViewModel
    {
        public List<Course> Courses { get; set; }   
        public List<Course> Courses1 { get; set; }   
        public List<Event>  Events{ get; set; }   
        public List<Email>  Emails{ get; set; }   
        public List<blog>  Blogs{ get; set; }   
        public Course Course { get; set; }      
        public Event Event { get; set; }        
        public setting setting { get; set; }        
        public Aboutt  Aboutt { get; set; }   
    }
}
