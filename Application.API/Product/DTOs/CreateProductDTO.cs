using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.API.DTOs
{
    public class CreateProductDTO
    {
        #region Properties
        [Required]
        public int ProductId { set; get; }
        [Required]
        public int ProveedorId { set; get; }
        [Required]
        public int CiUser { set; get; }
        public int StateProduct { set; get; }
        [Required]
        public int IdCategory { set; get; }
        [Required]
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
