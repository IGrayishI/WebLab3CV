using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class Skills
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int SkillLevel { get; set; }

        [Required]
        public int YearsOfExperience { get; set; }

        //public Skills(string title, string description, int skillLevel)
        //{
        //    Title = title;
        //    Description = description;
        //    SkillLevel = skillLevel;
        //}


    }
}


