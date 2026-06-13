using System;
using System.Collections.Generic;

namespace api.Models
{
    public class Education
    {
        public string Degree { get; set; } = string.Empty;
        public string Institution { get; set; } = string.Empty;
        public string Period { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
    }

    public class Certification
    {
        public string Name { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
    }

    public class Publication
    {
        public string Title { get; set; } = string.Empty;
        public string Journal { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
    }

    public class AboutModel
    {
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string LinkedIn { get; set; } = string.Empty;
        public string Dob { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public List<Education> Education { get; set; } = new();
        public List<Certification> Certifications { get; set; } = new();
        public List<Publication> Publications { get; set; } = new();
        public List<string> Interests { get; set; } = new();
        public List<string> Awards { get; set; } = new();
        public List<string> Languages { get; set; } = new();
    }
}
