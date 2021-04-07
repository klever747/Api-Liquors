using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.API.DTOs
{
    public class UpdateProveedorDTO
    {
       
        [Required]
        public string NameProveedor { set; get; }
        [Required]
        public string ContactProveedor { set; get; }
        [Required]
        public string PhoneProveedor { set; get; }
        [Required]
        public string AddressProveedor { set; get; }
        public int status { set; get; }
    }
}
