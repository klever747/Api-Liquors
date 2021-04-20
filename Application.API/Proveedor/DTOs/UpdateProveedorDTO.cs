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
        public int ProveedorId { set; get; }
        public string NameProveedor { set; get; }
        public string ContactProveedor { set; get; }
        public string PhoneProveedor { set; get; }
        public string AddressProveedor { set; get; }
        public int status { set; get; }
    }
}
