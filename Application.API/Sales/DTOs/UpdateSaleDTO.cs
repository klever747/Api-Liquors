using System.ComponentModel.DataAnnotations;

namespace Application.API.DTOs
{
    public class UpdateSaleDTO
    {

        public int IdSales { set; get; }
        public int IdOrder { set; get; }
        public double PriceSale { set; get; }
        public double PriceDelivery { set; get; }
        public string PaymentMethod { set; get; }
        public string IdPaymentSale { set; get; }
        public string Status { set; get; }
    }
}
