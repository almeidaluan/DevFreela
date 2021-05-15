using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext devFreelaDbContext;

        public ProjectRepository(DevFreelaDbContext devFreelaDbContext)
        {
            this.devFreelaDbContext = devFreelaDbContext;
        }

        public async Task<List<Project>> GetAll(){
            return await this.devFreelaDbContext.Projects.ToListAsync();
        }

        public async Task SaveAsyncProject(Project project){

            await devFreelaDbContext.Projects.AddAsync(project);
            await devFreelaDbContext.SaveChangesAsync();
        }

        public async Task<Project> GetByIdAsync(int id){
            return await devFreelaDbContext.Projects
            .Include( p => p.Client)
            .Include( p => p.Freelancer)
            .FirstOrDefaultAsync( p => p.Id == id);
        }

        public async Task StartProjectAsync(int id){
            var project = await devFreelaDbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
            project.Start();
            await devFreelaDbContext.SaveChangesAsync();
        }

        public async Task FinishProjectAsync(int id)
        {
             var project = await devFreelaDbContext.Projects.FirstOrDefaultAsync( p => p.Id == id);
            project.Finish();
            await devFreelaDbContext.SaveChangesAsync();
        }
    }
}