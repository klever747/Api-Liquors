﻿using System.ComponentModel.DataAnnotations;

namespace Application.API.DTOs
{
    public class UpdateSaleDTO
    {
        [Required]
        public int IdOrder { set; get; }
        public double DeliveryPrice { set; get; }
        public double PriceOrder { set; get; }
        public string AddressOrder { set; get; }
        public string StatusOrder { set; get; }
    }
}