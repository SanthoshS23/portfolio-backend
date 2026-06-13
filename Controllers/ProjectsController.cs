using Microsoft.AspNetCore.Mvc;
using api.Models;
using System.Collections.Generic;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ProjectModel>> Get()
        {
            var projects = new List<ProjectModel>
            {
                new ProjectModel
                {
                    Id = "corporate-employee-attrition",
                    Title = "Corporate Employee Attrition (IBM)",
                    Period = "Oct 2022 – Apr 2023",
                    Tags = new List<string> { "Data Analysis", "IBM", "HR Analytics" },
                    Description = "Analyzed employee attrition factors using IBM HR datasets to identify top churn indicators and predict turnover.",
                    Points = new List<string>
                    {
                        "Performed thorough exploratory data analysis (EDA) to map key retention statistics and correlation factors.",
                        "Engineered predictive machine learning models to forecast employee attrition with high accuracy.",
                        "Generated actionable visualizations and insight reports for HR department decision-making."
                    },
                    Status = "Completed"
                },
                new ProjectModel
                {
                    Id = "ai-portfolio-assistant",
                    Title = "AI Portfolio Assistant",
                    Period = "Future",
                    Tags = new List<string> { "Next.js", "AI", "OpenRouter" },
                    Description = "An intelligent chatbot assistant integrated directly into this portfolio using Next.js, Framer Motion, and open-source LLMs.",
                    Points = new List<string>
                    {
                        "Will support natural language query parsing about skills and work history.",
                        "Will use server-sent events for streaming token responses."
                    },
                    Status = "Coming Soon"
                },
                new ProjectModel
                {
                    Id = "realtime-analytics-dashboard",
                    Title = "Real-time Analytics Dashboard",
                    Period = "Future",
                    Tags = new List<string> { "Angular", "WebSockets", "RxJS" },
                    Description = "A high-performance live charting dashboard fed by real-time WebSocket connections.",
                    Points = new List<string>
                    {
                        "Will feature highly customizable widget dashboards.",
                        "Will optimize DOM painting using Angular's change detection strategies."
                    },
                    Status = "Coming Soon"
                }
            };

            return Ok(projects);
        }
    }
}
