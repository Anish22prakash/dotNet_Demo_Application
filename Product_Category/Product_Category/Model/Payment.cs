using System.ComponentModel.DataAnnotations;

namespace Product_Category.Model
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public string PaymentType { get; set; }
    }
}
