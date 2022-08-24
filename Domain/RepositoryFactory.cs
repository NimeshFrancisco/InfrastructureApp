using System;
using System.Data.SqlClient;
using Data.Interfaces;
using Data.Repositories;

namespace Domain
{
    public static class RepositoryFactory
    {
        public static ProductRepository Product(SqlConnection openedSqlCon)
        {
            return new ProductRepositoryImp(openedSqlCon);
        }
    }
}
