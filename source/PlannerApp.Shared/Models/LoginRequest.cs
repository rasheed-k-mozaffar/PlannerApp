using System;
using System.ComponentModel.DataAnnotations;
namespace PlannerApp.Shared.Models
{
	public class LoginRequest
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[StringLength(20 , MinimumLength = 6)]
		public string Password { get; set; }
	}
}

