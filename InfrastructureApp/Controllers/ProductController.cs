using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BO.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InfrastructureApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductManager _productManager;
        public ProductController(ProductManager productManager)
        {
            _productManager = productManager;
        }
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        // GET: api/values
        [HttpGet]
        //[ValidateAntiForgeryToken]
        //[AllowAnonymous]
        //[Route("get-all", Name = "GetAll")]
        public List<ProductDTO> Get()
        {
            return _productManager.GetList();
        }
       
        // GET api/values/5
        [HttpGet("{id}")]
        [ValidateAntiForgeryToken]
        public ProductDTO Get(int id)
        {
            return _productManager.GetById(id);
        }

        // POST api/values
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Post([FromBody]ProductDTO product)
        {
            _productManager.Create(product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public void Put(int id, [FromBody] ProductDTO product)
        {
            _productManager.Update(product);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public void Delete(int id)
        {
             _productManager.Delete(id);
        }
    }
}
