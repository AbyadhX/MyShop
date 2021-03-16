using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MyShop.Models;

namespace MyShop.DTO
{
    public class CustomerDTO
    {
        [Required]
        public int customer_id { get; set; }
        [Required]
        public string customer_name { get; set; }
        [Required]
        public List<Order> customer_orders { get; set; }
    }
}
