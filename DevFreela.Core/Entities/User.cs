using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active= true;
            CreatedAt = DateTime.Now;
            Skills = new List<UserSkill>();
            OwnedProjects = new List<Project>();
            FreelancerProjects = new List<Project>();
        }

        public string FullName { get; private set;}
        public string Email { get; private set;}
        public DateTime BirthDate { get; set;}
        public DateTime CreatedAt { get; set;}
        public bool Active { get; set;}
        public List<UserSkill> Skills { get; set;}
        public List<Project> OwnedProjects { get; private set;}
        public List<Project> FreelancerProjects { get; private set;}
        public List<ProjectComment> Comments { get; private set;}

    }
}