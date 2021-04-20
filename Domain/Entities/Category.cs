using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category
    {
        #region Properties

        public int IdCategory { set; get; }

        public string NameCategory { set; get; }
        public string ImageCategory { set; get; }

        public IEnumerable<Product> Products { set; get; }
        #endregion
        #region Constructor
        public Category() { }
        public Category(string nameCategory, string imageCategory)
        {
            NameCategory = nameCategory;
            ImageCategory = imageCategory;
        }
        #endregion

    }
}
