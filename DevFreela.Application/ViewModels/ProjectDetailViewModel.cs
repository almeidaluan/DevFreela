using System;

namespace DevFreela.Application.ViewModels
{
    public class ProjectDetailViewModel
    {
        

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public decimal TotalCost { get; set;}
        public string NameClient { get; set;}
        public string NameFreelancer { get; set;}

        public ProjectDetailViewModel(int id, string title, string description, DateTime? startedAt, DateTime? finishedAt, decimal totalCost,string nameClient,string nameFreelancer)
        {
            Id = id;
            Title = title;
            Description = description;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            TotalCost = totalCost;
            NameClient = nameClient;
            NameFreelancer = nameFreelancer;
        }

    }
}