using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.API.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(string Password);
        bool Check(string hash, string password);
    }
}
