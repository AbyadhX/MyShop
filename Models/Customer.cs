using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class Customer
    {
        [Key]
        public int customer_id { get; set; }
        public string customer_name { get; set; }
    }
}
