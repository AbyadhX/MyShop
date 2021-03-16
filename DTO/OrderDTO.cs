using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.DTO
{
    public class OrderDTO
    {
        [Required]
        public int order_id { get; set; }
        [Required]
        public int product_id { get; set; }
        [Required]
        public int customer_id { get; set; }
        [Required]
        public DateTime order_date { get; set; }

        [Required]
        public string customer_name { get; set; }
        [Required]
        public string product_name { get; set; }
        [Required]
        public decimal product_price { get; set; }
    }
}