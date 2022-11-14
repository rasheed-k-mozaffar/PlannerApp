using System;
namespace PlannerApp.Shared.Responses
{
	public class APIResponse
	{
		public string Message { get; set; }
		public bool Succeeded { get; set; }
	}

	public class APIResponse<T> : APIResponse
	{
		public T Value { get; set; }
	}

}

