using Model.DTO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Mappers
{
    public class ProductDTOMapper : ProductDTO
    {
        //DTO Mapping
        public ProductDTO MapToDTO()
        {
            var result = new ProductDTO()
            {
                ProductId = this.ProductId,
                ProductName = this.ProductName,
                AddDate = this.AddDate
            };
            return result;
        }
        public static ProductDTO MapToDTO(Product product)
        {
            var result = new ProductDTO()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                AddDate = product.AddDate
            };
            return result;
        }
        public static List<ProductDTO> MapToDTO(List<Product> products)
        {
            var result = new List<ProductDTO>();

            foreach (Product product in products)
            {
                result.Add(MapToDTO(product));
            }
            return result;
        }

        //Entity mapping
        public  Product MapEntity()
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
