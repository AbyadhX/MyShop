using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class Order
    {
        [Key]
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int customer_id { get; set; }
        public DateTime order_date { get; set; }

        public Order(int _order_id, int _product_id, int _customer_id, DateTime _order_date)
        {
            order_id = _order_id;
            product_id = _product_id;
            customer_id = _customer_id;
            order_date = _order_date;
        }
    }
}
