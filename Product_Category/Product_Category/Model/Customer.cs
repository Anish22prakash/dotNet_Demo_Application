using System.ComponentModel.DataAnnotations;

namespace Product_Category.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
       
         
    }
}
