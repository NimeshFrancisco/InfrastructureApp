using System;
using System.Collections.Generic;
using System.Data;
using Model.Entity;
namespace Data.Interfaces
{
    public interface ProductRepository
    {
        void Create(Product product);
        void Update(Product product);
        void Delete(int id);
        DataTable GetById(int id);
        DataTable GetList();
    }
}
