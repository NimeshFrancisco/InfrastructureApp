using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Data.Interfaces;
using Model.Entity;

namespace Data.Repositories
{
    public class ProductRepositoryImp : ProductRepository
    {
        

        private readonly SqlConnection _openedSqlConnection;
        public ProductRepositoryImp(SqlConnection openedSqlCon)
        {
            _openedSqlConnection = openedSqlCon;
        }

        public void Create(Product product)
        {
            using (SqlCommand cmd = new SqlCommand("Create_Product", _openedSqlConnection))
            {
                cmd.CommandTimeout = 300; // secs
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductName", (object)product.ProductName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@AddDate", (object)product.AddDate ?? DBNull.Value);

            }
        }

        public void Delete(int id)
        {
            
            using (SqlCommand cmd = new SqlCommand("Delete_Product", _openedSqlConnection))
            {
                cmd.CommandTimeout = 300; // secs
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", (object)id ?? DBNull.Value);
                 
            }
           
        }

        public DataTable GetById(int id)
        {
            DataTable table = null;
            using (SqlCommand cmd = new SqlCommand("Sreach_Product", _openedSqlConnection))
            {
                cmd.CommandTimeout = 300; // secs
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", (object)id ?? DBNull.Value);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    table = new DataTable();
                    da.Fill(table);
                }
            }
            return table;
        }

        public DataTable GetList()
        {
            DataTable table = null;
            using (SqlCommand cmd = new SqlCommand("Sreach_Product", _openedSqlConnection))
            {
                cmd.CommandTimeout = 300; // secs
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", (object)0?? DBNull.Value);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    table = new DataTable();
                    da.Fill(table);
                }
            }
            return table;
        }

        public void Update(Product product)
        {
            using (SqlCommand cmd = new SqlCommand("Update_Product", _openedSqlConnection))
            {
                cmd.CommandTimeout = 300; // secs
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", (object)product.ProductId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ProductName", (object)product.ProductName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@AddDate", (object)product.AddDate ?? DBNull.Value);

            }
        }
    }
}
