using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Model.DTO;
using Model.Interfaces;
using Utility;

namespace Model.Entity
{
    public  class Product 
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime? AddDate { get; set; }


        public static Product MapEntityToData(IDataRecord record)
        {
            return new Product
            {
                ProductId = record.GetValueOrDefault<int>("Dealer_Code"),
                ProductName = record.GetValueOrDefault<string>("Zone"),
                AddDate = record.GetValueOrDefault<DateTime?>("Sal_District"),


            };
        }

        public static Product MapEntityToData(DataTable table)
        {
            Product item = null;
            if (table?.Rows.Count == 1)
            {
                var reader = table.CreateDataReader();
                while (reader.Read()) item = MapEntityToData(reader);
            }
            return item;
        }

        public static List<Product> MapEntityToDatas(DataTable table)
        {
            List<Product> list = null;
            if (table != null && table.Rows.Count > 0)
            {
                list = new List<Product>();
                DataTableReader reader = table.CreateDataReader();
                while (reader.Read())
                {
                    list.Add(MapEntityToData(reader));
                }
            }
            return list;
        }


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
            var result =new List<ProductDTO>();

            foreach(Product product in products)
            {
                result.Add(Product.MapToDTO(product));
            }
            return result;
        }

    }
}
