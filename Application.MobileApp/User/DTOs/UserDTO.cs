using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MobileApp.User.DTOs
{
    public class UserDTO
    {
        #region Properties
        public string DisplaynameUser { set; get; }
        public string EmailUser { set; get; }
        public string PasswordUser { set; get; }
        #endregion Properties
        #region Constructor
        public UserDTO()
        {

        }
        #endregion Constructor
    }
}
