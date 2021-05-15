using System;

namespace DevFreela.Application.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set;}
        public string Title { get; set;}
        public DateTime CreatedAt { get; set;}

        public ProjectViewModel(string Title,DateTime CreatedAt){
            this.Title = Title;
            this.CreatedAt = CreatedAt;
        }
        public ProjectViewModel(int Id,string Title, DateTime CreatedAt)
        {
            this.Id = Id;
            this.Title = Title;
            this.CreatedAt = CreatedAt;
        }
    }
}