namespace Doggie.Modelsss
{
    public class EventCategory : BaseModel
    {
        public string Name { get; set; }
        public List<Event>? Events { get; set; }
    }
}
