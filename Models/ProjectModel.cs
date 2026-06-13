using System.Collections.Generic;

namespace api.Models
{
    public class ProjectModel
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Period { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new();
        public string Description { get; set; } = string.Empty;
        public List<string> Points { get; set; } = new();
        public string Status { get; set; } = string.Empty; // e.g. "Completed", "Coming Soon"
    }
}
