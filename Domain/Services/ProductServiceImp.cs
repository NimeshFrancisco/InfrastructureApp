using System;
using Model.Entity;
using Data.Interfaces;
using System.Data;
using System.Transactions;
using System.Data.SqlClient;
using System.Collections.Generic;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
//using System.Configuration;

namespace Domain.Services
{
    public class ProductServiceImp: ProductService
    {
        private  ProductRepository _productrepository = null;
        //private string _configuration = ConfigurationManager.AppSettings["DevConnection"].ToString();
        private readonly IConfiguration _configuration;
        private string _connectionString;
        public ProductServiceImp(ProductRepository productRepository, IConfiguration Configuration)
        {
            _productrepository = productRepository;
            _configuration = Configuration;
            _connectionString = _configuration.GetConnectionString("DevConnection");

        }

        public void Create(Product product)
        {
            SqlConnection connection = DBConnectionStringManager.GetConnection(_connectionString);

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    connection.Open();

                    _productrepository = RepositoryFactory.Product(connection);
                    _productrepository.Create(product);

                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                // log
            }
            catch (ApplicationException ex)
            {
                // log
            }
            catch (Exception ex)
            {
                // log
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void Delete(int id)
        {
            SqlConnection connection = DBConnectionStringManager.GetConnection(_connectionString);

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    connection.Open();

                    _productrepository =RepositoryFactory.Product(connection);
                    _productrepository.Delete(id);
                    
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                // log
            }
            catch (ApplicationException ex)
            {
                // log
            }
            catch (Exception ex)
            {
                // log
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public Product GetById(int id)
        {
            Product product = null;

            SqlConnection connection = DBConnectionStringManager.GetConnection(_connectionString);

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    connection.Open();

                    _productrepository = RepositoryFactory.Product(connection);
                    DataTable table = _productrepository.GetById(id);
                    product =  Product.MapEntityToData(table);

                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                // log
            }
            catch (ApplicationException ex)
            {
                // log
            }
            catch (Exception ex)
            {
                // log
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return product;
        }

        public List<Product> GetList()
        {
            var products = new List<Product>();

            SqlConnection connection = DBConnectionStringManager.GetConnection(_connectionString);

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    connection.Open();

                    _productrepository = RepositoryFactory.Product(connection);
                    DataTable table = _productrepository.GetList();
                    products = Product.MapEntityToDatas(table);

                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                // log
            }
            catch (ApplicationException ex)
            {
                // log
            }
            catch (Exception ex)
            {
                // log
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return products;
        }

       

        public void Update(Product product)
        {
            SqlConnection connection = DBConnectionStringManager.GetConnection(_connectionString);

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    connection.Open();

                    _productrepository = RepositoryFactory.Product(connection);
                    _productrepository.Update(product);

                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                // log
            }
            catch (ApplicationException ex)
            {
                // log
            }
            catch (Exception ex)
            {
                // log
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
