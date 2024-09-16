using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doggie.Dtos
{
	public class RegisterViewModel
	{
		
		[Required]
		[EmailAddress]
		public string? Email { get; set; }
		[Required]
		public string? UserName { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string? Password { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[Compare("Password")]
		public string? ConfirmPassword { get; set; }
		[Required]
		public bool IsTerms { get; set; }
		

	}
}
