using AuthDemoBlazor.Domain.Entities;
using AuthDemoBlazor.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthDemoBlazor.Application.Services
{
    internal class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<User?> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<User?> CreateAsync(User user, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            return await _unitOfWork.Users.Find(user => user.Email == email).FirstOrDefaultAsync();
        }

        public Task<User?> FindByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> FindByUserNameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User?> PasswordSignInAsync(User user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
