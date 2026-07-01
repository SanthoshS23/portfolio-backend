using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using api.Data;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly PortfolioDbContext _db;

        public SkillsController(PortfolioDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<SkillModel>>> Get()
        {
            var row = await _db.DbData.SingleOrDefaultAsync(d => d.Key == "skills");
            if (row is null)
            {
                return NotFound();
            }

            var skills = JsonSerializer.Deserialize<List<SkillModel>>(
                row.JsonValue,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (skills == null)
            {
                return BadRequest("Failed to deserialize JSON.");
            }

            return Ok(skills);
        }
    }
}
