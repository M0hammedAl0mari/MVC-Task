using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace WEBAPP.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
