using Microsoft.AspNetCore.Mvc;
using api.Models;
using System.Collections.Generic;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<SkillModel> Get()
        {
            var skills = new SkillModel
            {
                Categories = new List<SkillCategory>
                {
                    new SkillCategory
                    {
                        Name = "Frontend Technologies",
                        Skills = new List<string> { "React.js", "Next.js", "Angular", "TypeScript", "JavaScript", "Tailwind CSS", "HTML5", "CSS3" }
                    },
                    new SkillCategory
                    {
                        Name = "Backend & APIs",
                        Skills = new List<string> { "C#", "ASP.NET Core", "REST APIs", "Node.js (basic)" }
                    },
                    new SkillCategory
                    {
                        Name = "Real-time & Tooling",
                        Skills = new List<string> { "WebSockets", "Git / GitHub", "Chrome DevTools", "Agile / Scrum" }
                    }
                }
            };

            return Ok(skills);
        }
    }
}
