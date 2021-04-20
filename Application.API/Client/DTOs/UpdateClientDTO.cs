using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.API.DTOs
{
    public class UpdateClientDTO
    {
        #region Properties
        [Required]
        public int CiClient { set; get; }
        public string PictureClient { set; get; }
        public string DisplaynameClient { set; get; }
        public string EmailClient { set; get; }
        public string PasswordClient { set; get; }
        public string PhoneClient { set; get; }
        public string AddessClient { set; get; }
        public DateTime DateBirthClient { set; get; }
        public int Status { set; get; }
        #endregion
    }
}
