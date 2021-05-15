using System.Collections.Generic;
using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
         List<ProjectViewModel> GetAll(string query);
         ProjectDetailViewModel GetById(int id);
         int Create(NewProjectInputModel newProject);
         void Update(UpdateProjectInputModel newProject);

         void CreateComment(CreateCommentInputModel createCommentInputModel);
         void Start(int id);
         void Delete(int id);
         void Finish(int id);
    }
}