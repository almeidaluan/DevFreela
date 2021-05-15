using System.Collections.Generic;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll();
        Task SaveAsyncProject(Project project);
        Task<Project> GetByIdAsync(int id);
        Task StartProjectAsync(int id);
        Task FinishProjectAsync(int id);
        
    }
}