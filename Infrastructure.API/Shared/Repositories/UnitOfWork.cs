using Application.API.Interfaces.Repositories;

using System.Threading.Tasks;

namespace Infrastructure.API.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties
        public IUserRepository UserRepository { get; set; }
        public ISalesRepository SalesRepository { get; set; }
        public IProveedorRepository ProveedorRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IClientRepository ClientRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public ISecurityRepository SecurityRepository { get; set; }
        
        #endregion
        #region Constructors
        public UnitOfWork(IUserRepository userRepository,
            ISalesRepository salesRepository, IProveedorRepository proveedorRepository,
            IProductRepository productRepository, IOrderRepository orderRepository,
            IClientRepository clientRepository,ICategoryRepository categoryRepository, 
            ISecurityRepository securityRepository)
        {
            UserRepository = userRepository;
            SalesRepository = salesRepository;
            ProveedorRepository = proveedorRepository;
            ProductRepository = productRepository;
            OrderRepository = orderRepository;
            ClientRepository = clientRepository;
            CategoryRepository = categoryRepository;
            SecurityRepository = securityRepository;

        }
        #endregion

    }
}
