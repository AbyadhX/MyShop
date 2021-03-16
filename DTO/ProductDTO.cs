using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.DTO
{
    public class ProductDTO
    {
        [Required]
        public int product_id { get; set; }
        [Required]
        public string product_name { get; set; }
        [Required]
        public decimal product_price { get; set; }
    }
}