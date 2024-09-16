using Doggie.Modelsss;
using System.ComponentModel.DataAnnotations;

namespace Doggie.Modelsss
{
    public class Email:BaseModel
    {
        public string? Name { get; set; }    
        public string? Messsage { get; set; }    
        public string? Position{ get; set; }
		[DataType(DataType.Password)]
		public string? Pasword{ get; set; }    
    }
}
