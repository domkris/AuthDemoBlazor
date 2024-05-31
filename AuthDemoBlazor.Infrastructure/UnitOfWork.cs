using AuthDemoBlazor.Domain.Interfaces;
using AuthDemoBlazor.Infrastructure.Repositories;

namespace AuthDemoBlazor.Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AuthDemoBlazorDbContext _dbContext;
        public UnitOfWork(AuthDemoBlazorDbContext dbContext)
        {
            _dbContext = dbContext;
            Users = new UserRepository(_dbContext);
        }

        public IUserRepository Users { get; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
