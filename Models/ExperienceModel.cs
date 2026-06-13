using System.Collections.Generic;

namespace api.Models
{
    public class ExperienceProject
    {
        public string Name { get; set; } = string.Empty;
        public List<string> Points { get; set; } = new();
    }

    public class ExperienceModel
    {
        public string Company { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Period { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public List<ExperienceProject> Projects { get; set; } = new();
    }
}
