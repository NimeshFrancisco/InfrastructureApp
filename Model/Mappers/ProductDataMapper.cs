using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Utility;

namespace Model.Mappers
{
    public  class ProductDataMapper: Product
    {
        ProductDataMapper() { }
        public static Product MapEntityToData(IDataRecord record)
        {
            return new Product
            {
                ProductId = record.GetValueOrDefault<int>("Id"),
                ProductName = record.GetValueOrDefault<string>("ProductName"),
                AddDate = record.GetValueOrDefault<DateTime?>("AddDate"),


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
    }
}
