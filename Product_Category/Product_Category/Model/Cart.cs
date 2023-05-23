using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_Category.Model
{
    public class Cart
    {

        [Key]
        public int CartId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Products")]
        public int ProductId { get; set; }

        public Products Products { get; set; }


        
    }
}
