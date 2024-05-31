using AuthDemoBlazor.Domain.Entities;

namespace AuthDemoBlazor.Domain.Interfaces
{
    public interface IUserService
    {
        IQueryable<User> GetAll();
        Task<User?> FindByEmailAsync(string email);
        Task<User?> FindByUserNameAsync(string username);
        Task<User?> FindByIdAsync(long id);
        Task<User?> CreateAsync(User user, string password);
        Task<User?> UpdateAsync(User user);
        Task<User?> ChangePasswordAsync(User user, string currentPassword, string newPassword);
        Task<User?> PasswordSignInAsync(User user, string password);
    }
}
