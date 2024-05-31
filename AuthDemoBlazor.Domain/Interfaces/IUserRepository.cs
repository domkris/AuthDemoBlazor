using AuthDemoBlazor.Domain.Entities;

namespace AuthDemoBlazor.Domain.Interfaces
{
    public interface IUserRepository: IBaseRepository<User, long>
    {
       
    }
}
