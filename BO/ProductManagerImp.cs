using System;
using Model.DTO;
using BO.Interfaces;
using Model.Entity;
using System.Collections.Generic;
using Domain.Interfaces;

namespace BO
{
    public class ProductManagerImp: ProductManager
    {
        public readonly ProductService _productService = null;
        public ProductManagerImp(ProductService productService)
        {
            _productService = productService;
        }

        public void Create(ProductDTO product)
        {
            try
            {
                var entity = product.MapEntity();
                _productService.Create(entity);
            }
            catch (Exception ex)
            {

            }
            
        }

        public void Delete(int id)
        {
            try {

                _productService.Delete(id);
            }
            catch (Exception ex)
            {

            }
        }

        public ProductDTO GetById(int id)
        {
            try
            {
               return _productService.GetById(id).MapToDTO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductDTO> GetList()
        {
            try
            {
               return Product.MapToDTO(_productService.GetList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(ProductDTO product)
        {
            try
            {
                var entity = product.MapEntity();
                _productService.Update(entity);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
