using Doggie.Modelsss;

namespace Doggie.Dtos
{
    public class EventViiewModel
    {
        public List<Event> Events { get; set; } 
        public Event Event { get; set; }    
        public List<EventCategory>  EventCategories { get; set; }
        public int count { get; set; }
    }
}
