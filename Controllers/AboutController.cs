using Microsoft.AspNetCore.Mvc;
using api.Models;
using System.Collections.Generic;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AboutController : ControllerBase
    {
        [HttpGet]
        public ActionResult<AboutModel> Get()
        {
            var about = new AboutModel
            {
                Name = "Santhosh S",
                Title = "Software Developer",
                Summary = "Software Developer with 2+ years of experience in React.js, Next.js, Angular, TypeScript, and WebSockets. Eager to solve complex challenges and build visually stunning, performant web applications.",
                Email = "santhoshpy0209@gmail.com",
                Phone = "+91 90807 06050",
                LinkedIn = "https://linkedin.com/in/santhosh-s-8700421b9",
                Dob = "23-02-2002",
                Location = "Erode, Tamil Nadu",
                Education = new List<Education>
                {
                    new Education
                    {
                        Degree = "B.E. Computer Science",
                        Institution = "Nandha College of Technology",
                        Period = "2019–2023",
                        Details = "CGPA 8.1"
                    }
                },
                Certifications = new List<Certification>
                {
                    new Certification { Name = "Core Python Programming", Issuer = "Nurture InfoTech" },
                    new Certification { Name = "Responsive Web Design", Issuer = "freeCodeCamp" }
                },
                Publications = new List<Publication>
                {
                    new Publication 
                    { 
                        Title = "One Pass Packet Steering in Software Defined Data Centers", 
                        Journal = "IJETMS", 
                        Date = "May 2023" 
                    }
                },
                Interests = new List<string> { "Football", "Browsing", "Typing" },
                Awards = new List<string> { "Zone Level Ball Badminton Runner-Up" },
                Languages = new List<string> { "English", "Tamil" }
            };

            return Ok(about);
        }
    }
}
