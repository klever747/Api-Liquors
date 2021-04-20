using System.Collections.Generic;

namespace Domain.Entities
{
    public class Proveedor
    {
        #region Properties

        public int ProveedorId { set; get; }
        public string NameProveedor { set; get; }
        public string ContactProveedor { set; get; }
        public string PhoneProveedor { set; get; }
        public string AddressProveedor { set; get; }
        public int Status { set; get; }
        public ICollection<Product> Products { set; get; }
        #endregion

        #region Constructor
        public Proveedor() { }
        public Proveedor(string nameProveedor, string contactProveedor, string phoneProveedor, string addresProveedor) 
        {
            NameProveedor = nameProveedor;
            ContactProveedor = contactProveedor;
            PhoneProveedor = phoneProveedor;
            AddressProveedor = addresProveedor;
            Status = 1;
        }
        #endregion
    }
}
