using System.ComponentModel.DataAnnotations;

namespace MyShop.Models
{
    public class Values
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}