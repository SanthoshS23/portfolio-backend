using Microsoft.AspNetCore.Mvc;
using api.Models;
using System.Collections.Generic;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperienceController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ExperienceModel>> Get()
        {
            var experiences = new List<ExperienceModel>
            {
                new ExperienceModel
                {
                    Company = "Syncfusion",
                    Role = "Software Developer III",
                    Period = "Feb 2024 – Present",
                    Location = "Chennai, Tamil Nadu",
                    Projects = new List<ExperienceProject>
                    {
                        new ExperienceProject
                        {
                            Name = "BoldAI Agent",
                            Points = new List<string>
                            {
                                "Developed scalable UI components using Next.js and Tailwind CSS with lazy loading optimizations.",
                                "Built and integrated REST APIs to handle complex AI chat flows and agent versioning.",
                                "Designed and delivered an embeddable JS widget allowing external platforms to integrate the AI agent.",
                                "Leveraged Chrome DevTools extensively for runtime profiling, memory leak detection, and CPU usage optimization.",
                                "Worked in a fast-paced Agile/Scrum environment with daily standups and sprint planning."
                            }
                        },
                        new ExperienceProject
                        {
                            Name = "BoldChat",
                            Points = new List<string>
                            {
                                "Engineered high-performance real-time messaging features using Angular, TypeScript, and WebSockets.",
                                "Implemented robust REST API integrations for history loading, user status syncing, and file sharing.",
                                "Optimized UI/UX rendering pipelines, significantly reducing message-delivery lag and rendering times."
                            }
                        }
                    }
                }
            };

            return Ok(experiences);
        }
    }
}
