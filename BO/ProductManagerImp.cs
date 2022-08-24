using System;
using Model.DTO;
using BO.Interfaces;
using Model.Entity;
using System.Collections.Generic;
using Domain.Interfaces;
using Model.Mappers;

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
                var entity =new ProductDTOMapper().MapEntity();
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
               return ProductDTOMapper.MapToDTO(_productService.GetById(id));
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
               return ProductDTOMapper.MapToDTO(_productService.GetList());
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
                var entity = new ProductDTOMapper().MapEntity();
                _productService.Update(entity);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
