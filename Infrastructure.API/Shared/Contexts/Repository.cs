using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.API.Contexts
{
    public class ApplicationDbContext: DbContext
    {
        #region Properties
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion
        #region Constructor
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        #endregion
        #region Methods
        //Migration to development environment
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    if (!options.IsConfigured)
        //    {
        //        options.UseSqlServer(@"Server = DESKTOP-RMUFT67\SQLEXPRESS; Database = AtenasLiquorsDB; Trusted_Connection = True; ");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
