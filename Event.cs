using Doggie.Modelsss;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Doggie.Modelsss
{
	public class Event : BaseModel
	{
		[Required]
		public string Title { get; set; } = null!;
        [Required(ErrorMessage = "Only number is required")]
        public int Price { get; set; }	
		public string? Image { get; set; }
		public string? Image2 { get; set; }
		[Required]
		public string StartStopTime { get; set; } = null!;
		[Required]
		public string Location { get; set; } = null!;
		[Required]
		[StringLength(110, ErrorMessage = "The field can only contain up to 10 characters.")]
		public string Description { get; set; } = null!;
		[Required]
		public string DetailTitle { get; set; } = null!;
		public string VideoTitle { get; set; } = null!;
		[Required]
		public string DetailDescription { get; set; } = null!;
		public string VideoDescription { get; set; } = null!;
		[Required]
		public string PhoneNumber { get; set; } = null!;
		[Required]
		public string MapLink { get; set; } = null!;
		[Required]
		public string Link { get; set; } = null!;
		[Required]
		public DateTime StartTime { get; set; }
		public EventCategory? EventCategory { get; set; }= null!;
		public int? EventCategoryId { get; set; }
		[NotMapped]
		public IFormFile? FormFile { get; set; }=null!;
		[NotMapped]
		public IFormFile? FormFile2 { get; set; }=null!;
	}


}
