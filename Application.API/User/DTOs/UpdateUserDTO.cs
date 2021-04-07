using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.API.DTOs
{
    public class UpdateUserDTO
    {
        [Required]
        public string PictureUser { set; get; }
        [Required]
        public string DisplaynameUser { set; get; }
        [Required]
        public string EmailUser { set; get; }
        [Required]
        public string PasswordUser { set; get; }
        [Required]
        public string PhoneUser { set; get; }
        [Required]
        public string AddessUser { set; get; }
        [Required]
        public DateTime DateBirthUser { set; get; }
        [Required]
        public int Status { set; get; }
    }
}
