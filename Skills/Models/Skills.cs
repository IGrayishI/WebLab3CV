namespace ClassLibrary.Models
{
    public class Skills
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public int SkillLevel { get; set; }

        //public Skills(string title, string description, int skillLevel)
        //{
        //    Title = title;
        //    Description = description;
        //    SkillLevel = skillLevel;
        //}


    }
}


