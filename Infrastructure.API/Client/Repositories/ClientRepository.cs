using Application.API.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.API.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.API.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
