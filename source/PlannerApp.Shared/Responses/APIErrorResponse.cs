using System;
namespace PlannerApp.Shared.Responses
{
    public class APIErrorResponse
    {
        public string Message { get; set; }
        public string[] Errors { get; set; }
        public bool Succeeded { get; set; }
    }
}

