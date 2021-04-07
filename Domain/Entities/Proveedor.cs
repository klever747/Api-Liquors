namespace Domain.Entities
{
    public class Proveedor
    {
        #region Properties
        public int ProveedorId { set; get; }
        public string CiUser { set; get; }
        public string NameProveedor { set; get; }
        public string ContactProveedor { set; get; }
        public string PhoneProveedor { set; get; }
        public string AddressProveedor { set; get; }
        public int status { set; get; }
        #endregion
    }
}
