using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Order
    {
        #region Properties

        public int IdOrder { set; get; }     
        public int CiClient { set; get; }
        public int IdProduct { set; get; }
        public int CantProduct { set; get; }
        public double DeliveryPrice { set; get; }
        public double PriceOrder { set; get; }
        public string AddressOrder { set; get; }
        public string StatusOrder { set; get; }

        public ICollection<Product> Products { set; get; }
        public IEnumerable<Sales> Sales { set; get; }
        public Sales Sale { set; get; }
        public Client Client { set; get; }
        #endregion
        #region Constructor

        public Order() { }
        public Order(int ciClient, int idProduct, int cantProduct, double deliveryPrice,
            double priceOrder, string addressOrder, string statusOrder) 
        {
            CiClient = ciClient;
            IdProduct = idProduct;
            CantProduct = cantProduct;
            DeliveryPrice = deliveryPrice;
            PriceOrder = priceOrder;
            AddressOrder = addressOrder;
            StatusOrder = statusOrder;
        }
        #endregion
    }
}
