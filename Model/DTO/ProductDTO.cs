using System;
using Model.Entity;

namespace Model.DTO
{
    public class ProductDTO
    {

        public int ProductId { get; set; }
        public string  ProductName { get; set; }
        public DateTime? AddDate { get; set; }

        public Product MapEntity()
        {
            var result = new Product()
            {
                ProductId = this.ProductId,
                ProductName = this.ProductName,
                AddDate = this.AddDate
            };
            return result;
        }

    }
}
