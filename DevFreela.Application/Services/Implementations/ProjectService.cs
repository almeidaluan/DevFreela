using System.Collections.Generic;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectService(DevFreelaDbContext dbContext){
            _dbContext = dbContext;
        }
        public int Create(NewProjectInputModel newProject)
        {

            var project = new Project(newProject.Title, newProject.Description, newProject.IdClient, newProject.IdFreelancer, newProject.TotalCost);
            
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel createCommentInputModel)
        {
            var comment = new ProjectComment(createCommentInputModel.Content, createCommentInputModel.IdProject, createCommentInputModel.IdUser);

            _dbContext.ProjectComments.Add(comment);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault( p => p.Id == id);
            
            project.Cancel();
            _dbContext.SaveChanges();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault( p => p.Id == id);
            project.Finish();
            _dbContext.SaveChanges();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;

            var projectsViewModel = projects.Select( p => new ProjectViewModel(p.Title, p.CreatedAt)).ToList();

            return projectsViewModel;
        }

        public ProjectDetailViewModel GetById(int id)
        {
            var project = _dbContext.Projects
            .Include( p => p.Client)
            .Include( p => p.Freelancer)
            .FirstOrDefault( p => p.Id == id);

            if(project == null) return null;

            var projectsDetailViewModel = new ProjectDetailViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.StartedAt,
                project.FinishedAt,
                project.TotalCost,
                project.Client.FullName,
                project.Freelancer.FullName
            );
            
            return projectsDetailViewModel;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
            project.Start();
            _dbContext.SaveChanges();
        }

        public void Update(UpdateProjectInputModel updateProjectInput)
        {
            var project = _dbContext.Projects.FirstOrDefault(p => p.Id == updateProjectInput.Id);
            project.Update(updateProjectInput.Title, updateProjectInput.Description, updateProjectInput.TotalCost);
            _dbContext.SaveChanges();
        }
    }
}