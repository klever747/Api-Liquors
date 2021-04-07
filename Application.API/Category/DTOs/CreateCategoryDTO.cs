using System.ComponentModel.DataAnnotations;

namespace Application.API.DTOs
{
    public class CreateCategoryDTO
    {
        [Required]
        public int IdCategory { set; get; }
        public string NameCategory { set; get; }
        public string ImageCategory { set; get; }
    }
}
