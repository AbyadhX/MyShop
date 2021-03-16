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
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly Context _context;

        public OrderController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderDTO>> GetOrders()
        {
            var order = from orders in _context.Order
                        join customers in _context.Customer on orders.customer_id equals customers.customer_id
                        join products in _context.Product on orders.product_id equals products.product_id
                        select new OrderDTO
                        {
                            customer_id = orders.customer_id,
                            customer_name = customers.customer_name,
                            product_id = orders.product_id,
                            product_price = products.product_price,
                            order_date = orders.order_date,
                            product_name = products.product_name,
                            order_id = orders.order_id

                        };
            var getOrders = order.ToList();

            if (getOrders == null)
                return NotFound();
            return getOrders;
        }

        [HttpGet("{id}")]
        public ActionResult<OrderDTO> GetOrders_byId(int id)
        {
            var order = from orders in _context.Order
                        join customers in _context.Customer on orders.customer_id equals customers.customer_id
                        join products in _context.Product on orders.product_id equals products.product_id
                        select new OrderDTO
                        {
                            customer_id = orders.customer_id,
                            customer_name = customers.customer_name,
                            product_id = orders.product_id,
                            product_price = products.product_price,
                            order_date = orders.order_date,
                            product_name = products.product_name,
                            order_id = orders.order_id

                        };
            var getOrders_byId = order.ToList().Find(x => x.order_id == id);

            if (getOrders_byId == null)
                return NotFound();
            return getOrders_byId;
        }
    }
}