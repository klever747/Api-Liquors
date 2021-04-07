using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.API.DTOs
{
    public class CreateClientDTO
    {
        #region Properties
        [Required]
        public string CiUser { set; get; }
        public string PictureUser { set; get; }
        public string DisplaynameUser { set; get; }
        [Required]
        public string EmailUser { set; get; }
        [Required]
        public string PasswordUser { set; get; }
        public string PhoneUser { set; get; }
        public string AddessUser { set; get; }
        public DateTime DateBirthUser { set; get; }
        public int Status { set; get; }
        #endregion
    }
}
