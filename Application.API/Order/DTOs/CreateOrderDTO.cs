using System.ComponentModel.DataAnnotations;

namespace Application.API.DTOs
{
    public class CreateOrderDTO
    {
        [Required]
        public int IdOrder { set; get; }
        [Required]
        public string CiUser { set; get; }
        [Required]
        public int Idroduct { set; get; }
        public double DeliveryPrice { set; get; }
        public double PriceOrder { set; get; }
        public string AddressOrder { set; get; }
        public string StatusOrder { set; get; }
    }
}
