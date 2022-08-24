using System;
using System.Collections.Generic;
using Model.DTO;
using Model.Entity;

namespace Domain.Interfaces
{
    public interface ProductService
    {
        void Create(Product product);
        void Update(Product product);
        void Delete(int id);
        Product GetById(int id);
        List<Product> GetList();
    }
}