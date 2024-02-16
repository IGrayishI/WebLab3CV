using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class Skills
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Skill level is required.")]
        public int SkillLevel { get; set; }

        [Required(ErrorMessage = "Years of experience is required.")]
        public int YearsOfExperience { get; set; }

        //public Skills(string title, string description, int skillLevel)
        //{
        //    Title = title;
        //    Description = description;
        //    SkillLevel = skillLevel;
        //}


    }
}


