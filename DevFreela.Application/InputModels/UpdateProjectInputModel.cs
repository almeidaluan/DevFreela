namespace DevFreela.Application.InputModels
{
    public class UpdateProjectInputModel
    {
        

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TotalCost { get; set; }
        
        public UpdateProjectInputModel(int id, string title, string description, int totalCost)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }
    }
}