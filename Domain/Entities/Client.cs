using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Client
    {
        #region Properties
       
        public int CiUser { set; get; }
        public int CiClient { set; get; }
        public string PictureClient { set; get; }
        public string DisplayNameClient { set; get; }
        public string EmailClient { set; get; }
        public string PasswordClient { set; get; }
        public string PhoneClient { set; get; }
        public string AddessClient { set; get; }
        public DateTime DateBirthClient { set; get; }
        public int Status { set; get; }
        public User User { set; get; }
        public ICollection<Order> Orders { set; get; }
        public ICollection<Sales> Sales { set; get; }
        #endregion
        #region Constructor
        public Client() { }
        public Client(int ciUser, string pictureClient, string displayName, string emailClient, 
            string passwordClient, string phoneClient, string addressClient, DateTime dateBirth)
        {
            CiUser = ciUser;
            PictureClient = pictureClient;
            DisplayNameClient = displayName;
            EmailClient = emailClient;
            PasswordClient = passwordClient;
            PhoneClient = phoneClient;
            AddessClient = addressClient;
            DateBirthClient = dateBirth;
            Status = 1;
        }
        #endregion
    }
}
