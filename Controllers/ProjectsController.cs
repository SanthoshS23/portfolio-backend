using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using api.Data;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly PortfolioDbContext _db;

        public ProjectsController(PortfolioDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectModel>>> Get()
        {
            var row = await _db.DbData.SingleOrDefaultAsync(d => d.Key == "projects");
            if (row is null)
            {
                return NotFound();
            }
            var about = JsonSerializer.Deserialize<List<ProjectModel>>(
                row.JsonValue,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (about == null)
            {
                return BadRequest("Failed to deserialize JSON.");
            }

            return Ok(about);
        }
    }
}
