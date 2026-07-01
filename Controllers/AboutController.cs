using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using api.Data;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AboutController : ControllerBase
    {
        private readonly PortfolioDbContext _db;

        public AboutController(PortfolioDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<AboutModel>> Get()
        {
            var row = await _db.DbData.SingleOrDefaultAsync(d => d.Key == "about");

            if (row == null)
            {
                return NotFound();
            }

            var about = JsonSerializer.Deserialize<AboutModel>(
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