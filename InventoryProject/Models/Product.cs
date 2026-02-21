using System.ComponentModel.DataAnnotations;

namespace InventoryProject.Models
{
    public class Product
    {

        //table Product

        
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; } = "";

        [Range(0,1000)]
        public int ProductQuantity { get; set; }

        [Range(10,6000)]
        public decimal ProductPrice { get; set; }

        [Required]
        [MinLength(2)]
        public string ProductCategory { get; set; } = "";









    }
}
