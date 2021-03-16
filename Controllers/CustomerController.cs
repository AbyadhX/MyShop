using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using MyShop.Data;
using MyShop.DTO;

namespace MyShop.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly Context _context;

        public CustomerController(Context context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDTO> GetCustomer_byId(int id)
        {
            var order = from orders in _context.Order
                        join customers in _context.Customer on id equals customers.customer_id
                        join products in _context.Product on orders.product_id equals products.product_id
                        select new OrderDTO
                        {
                            customer_id = customers.customer_id,
                            customer_name = customers.customer_name,
                            product_id = orders.product_id,
                            product_price = products.product_price,
                            order_date = orders.order_date,
                            product_name = products.product_name,
                            order_id = orders.order_id
                        };

            List<Order> customer_orders = new List<Order>();
            foreach (var o in order)
            {
                if (o.customer_id == id)
                    customer_orders.Add(new Order(o.order_id, o.product_id, o.customer_id, o.order_date));
            }

            var customer = from customers in _context.Customer
                           where id == customers.customer_id
                           select new CustomerDTO
                           {
                               customer_orders = customer_orders,
                               customer_name = customers.customer_name,
                               customer_id = customers.customer_id
                           };

            var customer_by_id = customer.ToList().Find(x => x.customer_id == id);


            if (customer_by_id == null)
                return NotFound();
            return customer_by_id;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDTO>> GetCustomers()
        {
            var customer = from customers in _context.Customer
                           select new CustomerDTO
                           {
                               customer_name = customers.customer_name,
                               customer_id = customers.customer_id
                           };

            var getCustomers = customer.ToList();

            if (getCustomers == null)
                return NotFound();
            return getCustomers;
        }
    }
}