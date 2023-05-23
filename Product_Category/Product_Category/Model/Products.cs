using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_Category.Model
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
  
        public string ProductName { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        

       
    }
}
