using System;
namespace PlannerApp.Shared.Models
{
	public class LoginResult
	{
		public string Token { get; set; }
		public DateTime ExpieryDate { get; set; }
	}
}

