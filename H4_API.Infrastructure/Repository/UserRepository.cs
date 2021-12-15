using H4_API.Domain.Interfaces;
using H4_API.Domain.Model;
using H4_API.Infrastructure.Interfaces;
using H4_API.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace H4_API.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<User> GetUserDetails(string username, string password)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
        }
    }
}