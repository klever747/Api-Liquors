using System.ComponentModel.DataAnnotations;

namespace Application.API.DTOs
{
    public class CreateOrderDTO
    {
        public int IdOrder { set; get; }
        public int CiClient { set; get; }
        public int Idroduct { set; get; }
        public double DeliveryPrice { set; get; }
        public int CantOrder { set; get; }
        public double PriceOrder { set; get; }
        public string AddressOrder { set; get; }
        public string StatusOrder { set; get; }
    }
}
