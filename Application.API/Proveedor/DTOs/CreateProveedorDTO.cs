using System.ComponentModel.DataAnnotations;

namespace Application.API.DTOs
{
    public class CreateProveedorDTO
    {
        [Required]
        public int ProveedorId { set; get; }
        [Required]
        public string CiUser { set; get; }
        [Required]
        public string NameProveedor { set; get; }
        [Required]
        public string ContactProveedor { set; get; }
        public string PhoneProveedor { set; get; }
        public string AddressProveedor { set; get; }
        public int status { set; get; }
    }
}
