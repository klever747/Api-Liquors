using System.ComponentModel.DataAnnotations;

namespace Application.API.DTOs
{
    public class CreateUserDTO
    {

        [Required]
        public string CiUser { set; get; }
        [Required]
        public string DisplaynameUser { set; get; }
        [Required]
        public string EmailUser { set; get; }
        [Required]
        public string PasswordUser { set; get; }

    }
}
