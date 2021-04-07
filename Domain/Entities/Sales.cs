using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Sales
    {
        #region Properties
        public int IdSales { set; get; }
        public int IdOrder { set; get; }
        public double PriceSale { set; get; }
        public double PriceDelivery { set; get; }
        public string PaymentMethod { set; get; }
        public string IdPaymentSale { set; get; }
        public string Status { set; get; }
        #endregion
    }
}
