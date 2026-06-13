using System.Collections.Generic;

namespace api.Models
{
    public class SkillCategory
    {
        public string Name { get; set; } = string.Empty;
        public List<string> Skills { get; set; } = new();
    }

    public class SkillModel
    {
        public List<SkillCategory> Categories { get; set; } = new();
    }
}
