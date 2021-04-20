using System.Collections.Generic;

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
        public string DetailProduct { set; get; }
        public int SalesProduct { set; get; }

        public ICollection<Proveedor> Proveedores { set; get; }
        public ICollection<Order> Orders { set; get; }
        public Category Category { set; get; }
        public User User { set; get; }
        #endregion
        #region Constructor
        public Product() { }
        public Product(int proveedorId, int ciUser, int idCategory, string nameProduct,
            string imageProduct, double priceProduct, int stockProduct, string detailProduct, int salesProduct) 
        {
            ProveedorId = proveedorId;
            CiUser = ciUser;
            StateProduct = 1;
            IdCategory = idCategory;
            NameProduct = nameProduct;
            ImageProduct = imageProduct;
            PriceProduct = priceProduct;
            StockProduct = stockProduct;
            DetailProduct = detailProduct;
            SalesProduct = salesProduct;
        }
        #endregion

    }
}
