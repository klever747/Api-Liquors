using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Shared.DTOs
{
    public class CreateUserDTO
    {
        #region Properties
        public string DisplaynameUser { set; get; }
        public string EmailUser { set; get; }
        public string PasswordUser { set; get; }
        #endregion Properties
        #region Constructor
        public CreateUserDTO()
        {
        }

        public CreateUserDTO(string displaynameUser, string emailUser, string passwordUser)
        {
            DisplaynameUser = displaynameUser;
            EmailUser = emailUser;
            PasswordUser = passwordUser;
        }
        #endregion Constructor
    }
}
