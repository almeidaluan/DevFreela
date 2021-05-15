using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
         
    }
}