using System;

namespace DevFreela.Core.Entities
{
    public class ProjectComment : BaseEntity
    {
        public ProjectComment(string content, int idProject, int idUSer)
        {
            Content = content;
            IdProject = idProject;
            IdUSer = idUSer;
        }

        public string Content { get; private set; }
        public Project project { get; set;}
        public int IdProject { get; private set; }
        public User user { get; set;}
        public int IdUSer { get; private set; }
        public DateTime CreatedAt { get; private set; }

    }
}