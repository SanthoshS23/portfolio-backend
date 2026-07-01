using System.Collections.Generic;

namespace api.Models
{
    public class SkillModel
    {
        public string Name { get; set; } = string.Empty;
        public List<string> Skills { get; set; } = new();
    }
}
