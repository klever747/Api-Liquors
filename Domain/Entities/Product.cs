namespace Domain.Entities
{
    public class Product
    {
        #region Properties
        public int ProductId { set; get; }
        public int ProveedorId { set; get; }
        public int CiUser { set; get; }
        public int StateProduct { set; get; }
        public int IdCategory { set; get; }
        public string NameProduct { set; get; }
        public string ImageProduct { set; get; }
        public double PriceProduct { set; get; }
        public int StockProduct { set; get; }
        public int DeliveryTime { set; get; }
        public string DetailProduct { set; get; }
        public int SalesProduct { set; get; }
        #endregion


    }
}
