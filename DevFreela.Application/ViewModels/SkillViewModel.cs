namespace DevFreela.Application.ViewModels
{
    public class SkillViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }

         public SkillViewModel(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}