using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.API.DTOs
{
    public class UpdateCategoryDTO
    {
        [Required]
        public int IdCategory { set; get; }
        public string NameCategory { set; get; }
        public string ImageCategory { set; get; }
    }
}
