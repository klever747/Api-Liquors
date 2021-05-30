
namespace Application.MobileApp.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
}
