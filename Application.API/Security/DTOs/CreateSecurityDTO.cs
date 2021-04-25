using Domain.Enum;

namespace Application.API.DTOs
{
    public class CreateSecurityDTO
    {
        public string Users { set; get; }
        public string UserName { set; get; }
        public string Passwordu { set; get; }
        public RoleType? Roleu { set; get; }
    }
}
