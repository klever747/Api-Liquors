using System.ComponentModel.DataAnnotations;

namespace Application.API.DTOs
{
    public class CreateProveedorDTO
    {
        [Required]
        public int ProveedorId { set; get; }
        public string NameProveedor { set; get; }
        public string ContactProveedor { set; get; }
        public string PhoneProveedor { set; get; }
        public string AddressProveedor { set; get; }
    }
}
