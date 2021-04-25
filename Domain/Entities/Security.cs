using Domain.Enum;

namespace Domain.Entities
{
    public class Security:BaseEntity
    {
        public string Users { set; get; }
        public string UserName { set; get; }
        public string Passwordu { set; get;  }
        public RoleType Roleu { set; get; }

        public Security() { }
        public Security(string users, string userName, string passwordU, RoleType roleU)
        {
            Users = users;
            UserName = userName;
            Passwordu = passwordU;
            Roleu = roleU;
           
        }
    }
}
