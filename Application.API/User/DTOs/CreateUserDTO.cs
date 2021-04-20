using System;
using System.ComponentModel.DataAnnotations;

namespace Application.API.DTOs
{
    public class CreateUserDTO
    {
       
        public string PictureUser { set; get; }
        public string DisplaynameUser { set; get; }
        public string EmailUser { set; get; }
        public string PasswordUser { set; get; }
        public string PhoneUser { set; get; }
        public string AddessUser { set; get; }
        public DateTime DateBirthUser { set; get; }
        public int Status { set; get; }

    }
}
