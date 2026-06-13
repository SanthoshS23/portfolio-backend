using Microsoft.AspNetCore.Mvc;
using api.Models;
using System;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        [HttpPost]
        public ActionResult<ContactResponse> Post([FromBody] ContactRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Email))
            {
                return BadRequest(new ContactResponse 
                { 
                    Success = false, 
                    Message = "Invalid request. Name and Email are required." 
                });
            }

            // Log to console on server side, as requested
            Console.WriteLine("=================== CONTACT FORM SUBMISSION ===================");
            Console.WriteLine($"Date/Time: {DateTime.UtcNow} UTC");
            Console.WriteLine($"Name:      {request.Name}");
            Console.WriteLine($"Email:     {request.Email}");
            Console.WriteLine($"Subject:   {request.Subject}");
            Console.WriteLine($"Message:   {request.Message}");
            Console.WriteLine("===============================================================");

            return Ok(new ContactResponse
            {
                Success = true,
                Message = "Thanks for reaching out!"
            });
        }
    }
}
