using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Sales
    {
        #region Properties
        
        public int IdSales { set; get; }
        public int CiClient { set; get; }
        public int IdOrder { set; get; }
        public double PriceSale { set; get; }
        public double PriceDelivery { set; get; }
        public string PaymentMethod { set; get; }
        public string IdPaymentSale { set; get; }
        public string Status { set; get; }

        public Client Client { set; get; }
        public Order Order { set; get; }
        #endregion
        #region Constructor
        public Sales() { }
        public Sales(int ciClient, int idOrder, double priceSale, double priceDelivery, string paymentMethod,
            string idPaymentSale, string status) 
        {
            CiClient = ciClient;
            IdOrder = idOrder;
            PriceSale = priceSale;
            PriceDelivery = priceDelivery;
            PaymentMethod = paymentMethod;
            IdPaymentSale = idPaymentSale;
            Status = status;
        }
        #endregion
    }
}
