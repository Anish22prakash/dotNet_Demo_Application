using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_Category.Model
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("Payment")]
        public int PaymentId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
         public double TotalAmount { get; set; }

       public DateTime OrderDate { get; set; }




    }
}
