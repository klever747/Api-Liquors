using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.API.DTOs
{
    public class UpdateProductDTO
    {
        #region Properties
        [Required]
        public int StateProduct { set; get; }
        [Required]
        public string NameProduct { set; get; }
        public string ImageProduct { set; get; }
        [Required]
        public double PriceProduct { set; get; }
        [Required]
        public int StockProduct { set; get; }
        public int DeliveryTime { set; get; }
        [Required]
        public string DetailProduct { set; get; }
        [Required]
        public int SalesProduct { set; get; }
        #endregion
    }
}
