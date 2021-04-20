using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class User
    {
        #region Properties
        
        public int  CiUser { set; get; }
        public string PictureUser { set; get; }
        public string DisplaynameUser { set; get; }
        public string EmailUser { set; get; }
        public string PasswordUser { set; get; }
        public string PhoneUser { set; get; }
        public string AddessUser { set; get; }
        public DateTime DateBirthUser { set; get; }
        public int Status { set; get; }

        public ICollection<Client> Clients { set; get; }
        public ICollection<Product> Products { set; get; }
        #endregion
        #region Constructor
        public User() { }
        public User(string pictureUser, string displaynameUser, string emailUser, string passwordUser,
            string phoneUser, string addressUser, DateTime dateBirth)
        {
            PictureUser = pictureUser;
            DisplaynameUser = displaynameUser;
            EmailUser = emailUser;
            PasswordUser = passwordUser;
            PhoneUser = phoneUser;
            AddessUser = addressUser;
            DateBirthUser = dateBirth;
            Status = 1;
        }
        #endregion


    }
}
