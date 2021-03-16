using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyShop.Data;
using MyShop.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly Context _context;

        public ProductController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts()
        {
            var product = from products in _context.Product
                          select new ProductDTO
                          {
                              product_name = products.product_name,
                              product_id = products.product_id,
                              product_price = products.product_price
                          };

            var getProducts = product.ToList();

            if (getProducts == null)
                return NotFound();
            return getProducts;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetProducts_byId(int id)
        {
            var product = from products in _context.Product
                          select new ProductDTO
                          {
                              product_name = products.product_name,
                              product_id = products.product_id,
                              product_price = products.product_price
                          };

            var getProducts = product.ToList().Find(x => x.product_id == id);

            if (getProducts == null)
                return NotFound();

            return getProducts;
        }
    }
}