using AuthDemoBlazor.Domain.Entities;
using AuthDemoBlazor.Domain.Interfaces;
using AuthDemoBlazor.Infrastructure.Repositories.Base;

namespace AuthDemoBlazor.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User, long>, IUserRepository
    {
        public UserRepository(AuthDemoBlazorDbContext dbContext) : base(dbContext)
        {

        }
    }
}
