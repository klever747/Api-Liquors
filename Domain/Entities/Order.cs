using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Order
    {
        #region Properties
        public int IdOrder { set; get; }
        public string CiUser { set; get; }
        public int Idroduct { set; get; }
        public double DeliveryPrice { set; get; }
        public double PriceOrder { set; get; }
        public string AddressOrder { set; get; }
        public string StatusOrder { set; get; }
        #endregion
    }
}
