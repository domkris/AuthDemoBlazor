namespace AuthDemoBlazor.Domain.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository Users { get; }
        Task<int> SaveAsync();
    }
}
