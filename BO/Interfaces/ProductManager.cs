using System;
using System.Collections.Generic;
using Model.DTO;

namespace BO.Interfaces
{
    public interface ProductManager
    {
        void Create(ProductDTO product);
        void Update(ProductDTO product);
        void Delete(int id);
        ProductDTO GetById(int id);
        List<ProductDTO> GetList();
    }
}
