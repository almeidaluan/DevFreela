using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly DevFreelaDbContext devFreelaDbContext;
        public UserRepository(DevFreelaDbContext devFreelaDbContext)
        {
            this.devFreelaDbContext = devFreelaDbContext;
        }

        public async Task CreateUser(User user){
            await devFreelaDbContext.Users.AddAsync(user);
            await devFreelaDbContext.SaveChangesAsync();
        }
        
    }
}