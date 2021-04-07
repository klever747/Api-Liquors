namespace Application.API.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IClientRepository ClientRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        IProveedorRepository ProveedorRepository { get; }
        ISalesRepository SalesRepository { get; }
       
     }
}
